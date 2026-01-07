using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;

namespace ImAnim.NET;

[InterpolatedStringHandler]
public ref struct ImU8String
{
    public const int AllocFreeBufferSize = 512;
    private const int MinimumRentSize = AllocFreeBufferSize * 2;

    private IFormatProvider? formatProvider;
    private byte[]? rentedBuffer;
    private ref readonly byte externalFirstByte;
    private State state;
    private FixedBufferContainer fixedBuffer;

    [Flags]
    private enum State : byte
    {
        None = 0,
        Initialized = 1 << 0,
        NullTerminated = 1 << 1,
        Interpolation = 1 << 2,
    }

    public ImU8String()
    {
        Unsafe.SkipInit(out fixedBuffer);
        FixedBufferByteRef = 0;
    }

    public ImU8String(int literalLength, int formattedCount)
        : this(""u8)
    {
        state |= State.Interpolation;
        literalLength += formattedCount * 4;
        Reserve(literalLength);
    }

    public ImU8String(int literalLength, int formattedCount, IFormatProvider? formatProvider)
        : this(literalLength, formattedCount)
    {
        this.formatProvider = formatProvider;
    }

    public ImU8String(ReadOnlySpan<byte> text, bool ensureNullTermination = false)
        : this()
    {
        if (Unsafe.IsNullRef(in MemoryMarshal.GetReference(text)))
        {
            state = State.None;
            return;
        }

        state = State.Initialized;
        if (text.IsEmpty)
        {
            state |= State.NullTerminated;
        }
        else if (ensureNullTermination)
        {
            Reserve(text.Length + 1);
            var buffer = Buffer;
            text.CopyTo(buffer);
            buffer[^1] = 0;
            Length = text.Length;
            state |= State.NullTerminated;
        }
        else
        {
            externalFirstByte = ref text[0];
            Length = text.Length;
            if (Unsafe.Add(ref Unsafe.AsRef(in externalFirstByte), Length) == 0)
                state |= State.NullTerminated;
        }
    }

    public ImU8String(ReadOnlyMemory<byte> text, bool ensureNullTermination = false)
        : this(text.Span, ensureNullTermination)
    {
    }

    public ImU8String(ReadOnlySpan<char> text)
        : this()
    {
        if (Unsafe.IsNullRef(in MemoryMarshal.GetReference(text)))
        {
            state = State.None;
            return;
        }

        state = State.Initialized | State.NullTerminated;
        Length = Encoding.UTF8.GetByteCount(text);
        if (Length + 1 < AllocFreeBufferSize)
        {
            var newSpan = FixedBufferSpan[..Length];
            Encoding.UTF8.GetBytes(text, newSpan);
            FixedBufferSpan[Length] = 0;
        }
        else
        {
            rentedBuffer = ArrayPool<byte>.Shared.Rent(Length + 1);
            var newSpan = rentedBuffer.AsSpan(0, Length);
            Encoding.UTF8.GetBytes(text, newSpan);
            rentedBuffer[Length] = 0;
        }
    }

    public ImU8String(ReadOnlyMemory<char> text)
        : this(text.Span)
    {
    }

    public ImU8String(string? text)
        : this(text.AsSpan())
    {
    }

    public unsafe ImU8String(byte* text)
        : this(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(text))
    {
        state |= State.NullTerminated;
    }

    public unsafe ImU8String(char* text)
        : this(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(text))
    {
    }

    public static ImU8String Empty => default;

    public readonly ReadOnlySpan<byte> Span =>
        !Unsafe.IsNullRef(in externalFirstByte)
            ? MemoryMarshal.CreateReadOnlySpan(in externalFirstByte, Length)
            : rentedBuffer is { } rented
                ? rented.AsSpan(0, Length)
                : Unsafe.AsRef(in this).FixedBufferSpan[..Length];

    public int Length { get; private set; }

    public readonly bool IsNull => (state & State.Initialized) == 0;

    public readonly bool IsEmpty => Length == 0;

    internal Span<byte> Buffer
    {
        get
        {
            if (Unsafe.IsNullRef(in externalFirstByte))
                ConvertToOwned();

            return rentedBuffer is { } buf
                       ? buf.AsSpan()
                       : MemoryMarshal.Cast<FixedBufferContainer, byte>(new Span<FixedBufferContainer>(ref Unsafe.AsRef(ref fixedBuffer)));
        }
    }

    private Span<byte> RemainingBuffer => Buffer[Length..];

    private ref byte FixedBufferByteRef => ref FixedBufferSpan[0];

    private Span<byte> FixedBufferSpan =>
        MemoryMarshal.Cast<FixedBufferContainer, byte>(new Span<FixedBufferContainer>(ref Unsafe.AsRef(ref fixedBuffer)));

    public static implicit operator ImU8String(ReadOnlySpan<byte> text) => new(text);
    public static implicit operator ImU8String(ReadOnlyMemory<byte> text) => new(text);
    public static implicit operator ImU8String(Span<byte> text) => new(text);
    public static implicit operator ImU8String(Memory<byte> text) => new(text);
    public static implicit operator ImU8String(byte[]? text) => new(text.AsSpan());
    public static implicit operator ImU8String(ReadOnlySpan<char> text) => new(text);
    public static implicit operator ImU8String(ReadOnlyMemory<char> text) => new(text);
    public static implicit operator ImU8String(Span<char> text) => new(text);
    public static implicit operator ImU8String(Memory<char> text) => new(text);
    public static implicit operator ImU8String(char[]? text) => new(text.AsSpan());
    public static implicit operator ImU8String(string? text) => new(text);
    public static unsafe implicit operator ImU8String(byte* text) => new(text);
    public static unsafe implicit operator ImU8String(char* text) => new(text);

    public ref readonly byte GetPinnableReference()
    {
        if (IsNull)
            return ref Unsafe.NullRef<byte>();

        if (IsEmpty)
            return ref FixedBufferSpan[0];

        return ref Span.GetPinnableReference();
    }

    public ref readonly byte GetPinnableReference(ReadOnlySpan<byte> defaultValue)
    {
        if (IsNull)
            return ref defaultValue.GetPinnableReference();

        if (IsEmpty)
            return ref FixedBufferSpan[0];

        return ref Span.GetPinnableReference();
    }

    public ref readonly byte GetPinnableNullTerminatedReference(ReadOnlySpan<byte> defaultValue = default)
    {
        if (IsNull)
            return ref defaultValue.GetPinnableReference();

        if (IsEmpty)
        {
            ref var t = ref FixedBufferSpan[0];
            t = 0;
            return ref t;
        }

        if ((state & State.NullTerminated) == 0)
            ConvertToOwned();

        return ref Span[0];
    }

    private void ConvertToOwned()
    {
        if (Unsafe.IsNullRef(in externalFirstByte))
            return;

        Debug.Assert(rentedBuffer is null);

        if (Length + 1 < AllocFreeBufferSize)
        {
            var fixedBufferSpan = FixedBufferSpan;
            Span.CopyTo(fixedBufferSpan);
            fixedBufferSpan[Length] = 0;
        }
        else
        {
            var newBuffer = ArrayPool<byte>.Shared.Rent(Length + 1);
            Span.CopyTo(newBuffer);

            newBuffer[Length] = 0;
            rentedBuffer = newBuffer;
        }

        state |= State.NullTerminated;
        externalFirstByte = ref Unsafe.NullRef<byte>();
    }

    public void Recycle()
    {
        if (rentedBuffer is { } buf)
        {
            rentedBuffer = null;
            ArrayPool<byte>.Shared.Return(buf);
        }
    }

    public ImU8String MoveOrDefault(ImU8String other)
    {
        if (!IsNull)
        {
            other.Recycle();
            var res = this;
            this = default;
            return res;
        }

        return other;
    }

    public override readonly string ToString() => Encoding.UTF8.GetString(Span);

    public void AppendLiteral(string value)
    {
        if (string.IsNullOrEmpty(value))
            return;

        var remaining = RemainingBuffer;
        var len = Encoding.UTF8.GetByteCount(value);
        if (remaining.Length <= len)
            IncreaseBuffer(out remaining, Length + len + 1);
        Buffer[Length += Encoding.UTF8.GetBytes(value.AsSpan(), remaining)] = 0;
    }

    public void AppendFormatted(ReadOnlySpan<byte> value) => AppendFormatted(value, null);

    public void AppendFormatted(ReadOnlySpan<byte> value, string? _)
    {
        var remaining = RemainingBuffer;
        if (remaining.Length < value.Length + 1)
            IncreaseBuffer(out remaining, Length + value.Length + 1);
        value.CopyTo(remaining);
        Buffer[Length += value.Length] = 0;
    }

    public void AppendFormatted(ReadOnlySpan<byte> value, int alignment) =>
        AppendFormatted(value, alignment, null);

    public void AppendFormatted(ReadOnlySpan<byte> value, int alignment, string? format)
    {
        var startingPos = Length;
        AppendFormatted(value, format);
        FixAlignment(startingPos, alignment);
    }

    public void AppendFormatted(ReadOnlySpan<char> value) => AppendFormatted(value, null);

    public void AppendFormatted(ReadOnlySpan<char> value, string? _)
    {
        var remaining = RemainingBuffer;
        var len = Encoding.UTF8.GetByteCount(value);
        if (remaining.Length < len + 1)
            IncreaseBuffer(out remaining, Length + len + 1);
        Buffer[Length += Encoding.UTF8.GetBytes(value, remaining)] = 0;
    }

    public void AppendFormatted(ReadOnlySpan<char> value, int alignment) =>
        AppendFormatted(value, alignment, null);

    public void AppendFormatted(ReadOnlySpan<char> value, int alignment, string? format)
    {
        var startingPos = Length;
        AppendFormatted(value, format);
        FixAlignment(startingPos, alignment);
    }

    public void AppendFormatted(object? value) => AppendFormatted<object>(value!);
    public void AppendFormatted(object? value, string? format) => AppendFormatted<object>(value!, format);
    public void AppendFormatted(object? value, int alignment) => AppendFormatted<object>(value!, alignment);
    public void AppendFormatted(object? value, int alignment, string? format) =>
        AppendFormatted<object>(value!, alignment, format);

    public void AppendFormatted<T>(T value) => AppendFormatted(value, null);

    public void AppendFormatted<T>(T value, string? format)
    {
        var remaining = RemainingBuffer;
        if (remaining.Length < 1)
            IncreaseBuffer(out remaining);

        int written;
        while (true)
        {
            var handler = new Utf8.TryWriteInterpolatedStringHandler(1, 1, remaining[..^1], formatProvider, out _);
            handler.AppendFormatted(value, format);
            if (Utf8.TryWrite(remaining, formatProvider, ref handler, out written))
                break;
            IncreaseBuffer(out remaining);
        }

        Buffer[Length += written] = 0;
    }

    public void AppendFormatted<T>(T value, int alignment) => AppendFormatted(value, alignment, null);

    public void AppendFormatted<T>(T value, int alignment, string? format)
    {
        var startingPos = Length;
        AppendFormatted(value, format);
        FixAlignment(startingPos, alignment);
    }

    public void Reserve(int length)
    {
        if (length >= AllocFreeBufferSize)
            IncreaseBuffer(out _, length);
    }

    private void FixAlignment(int startingPos, int alignment)
    {
        var appendedLength = Length - startingPos;

        var leftAlign = alignment < 0;
        if (leftAlign)
            alignment = -alignment;

        var fillLength = alignment - appendedLength;
        if (fillLength <= 0)
            return;

        var destination = Buffer;
        if (fillLength > destination.Length - Length)
        {
            IncreaseBuffer(out _, fillLength + 1);
            destination = Buffer;
        }

        if (leftAlign)
        {
            destination.Slice(Length, fillLength).Fill((byte)' ');
        }
        else
        {
            destination.Slice(startingPos, appendedLength).CopyTo(destination[(startingPos + fillLength)..]);
            destination.Slice(startingPos, fillLength).Fill((byte)' ');
        }

        Buffer[Length += fillLength] = 0;
    }

    private void IncreaseBuffer(out Span<byte> remaining, int minCapacity = 0)
    {
        minCapacity = Math.Max(minCapacity, Math.Max(Buffer.Length * 2, MinimumRentSize));
        var newBuffer = ArrayPool<byte>.Shared.Rent(minCapacity);
        Span.CopyTo(newBuffer);
        newBuffer[Length] = 0;
        if (rentedBuffer is not null)
            ArrayPool<byte>.Shared.Return(rentedBuffer);

        rentedBuffer = newBuffer;
        externalFirstByte = ref Unsafe.NullRef<byte>();
        remaining = newBuffer.AsSpan(Length);
    }

    [StructLayout(LayoutKind.Sequential, Size = AllocFreeBufferSize)]
    private struct FixedBufferContainer;
}
