using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace C.ImGuiGLFW.ImGuiMethods;

public static class ImDragDrop
{
    private const int MaxStackAllocSize = 1024;

    public static unsafe void SetDragDropPayload<T>(string type, T data, ImGuiCond cond = ImGuiCond.None)
        where T : unmanaged
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        var ptr = Unsafe.AsPointer(ref data);
        var size = (nuint)Unsafe.SizeOf<T>();

        ImGui.SetDragDropPayload(type, ptr, size, cond);
    }

    public static unsafe bool AcceptDragDropPayload<T>(string type, out T payload, ImGuiDragDropFlags flags = ImGuiDragDropFlags.None)
        where T : unmanaged
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        ImGuiPayload* pload = ImGui.AcceptDragDropPayload(type, flags);

        if (pload != null && pload->Data != null && pload->DataSize >= Unsafe.SizeOf<T>())
        {
            payload = Unsafe.Read<T>(pload->Data);
            return true;
        }

        payload = default;
        return false;
    }

    public static unsafe void SetDragDropPayloadJson<T>(string type, T data, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(data);

        var json = JsonSerializer.Serialize(data);
        var byteCount = Encoding.UTF8.GetByteCount(json);

        if (byteCount <= MaxStackAllocSize)
        {
            var bytes = stackalloc byte[byteCount];
            Encoding.UTF8.GetBytes(json.AsSpan(), new Span<byte>(bytes, byteCount));
            ImGui.SetDragDropPayload(type, bytes, (nuint)byteCount, cond);
        }
        else
        {
            var bytes = Encoding.UTF8.GetBytes(json);
            fixed (byte* ptr = bytes)
            {
                ImGui.SetDragDropPayload(type, ptr, (nuint)bytes.Length, cond);
            }
        }
    }

    public static unsafe bool AcceptDragDropPayloadJson<T>(string type, out T? payload, ImGuiDragDropFlags flags = ImGuiDragDropFlags.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ImGuiPayload* pload = ImGui.AcceptDragDropPayload(type, flags);
        if (pload != null && pload->Data != null && pload->DataSize > 0)
        {
            try
            {
                var json = Encoding.UTF8.GetString((byte*)pload->Data, pload->DataSize);
                payload = JsonSerializer.Deserialize<T>(json);
                return payload != null;
            }
            catch (Exception)
            {
                payload = default;
                return false;
            }
        }
        payload = default;
        return false;
    }

    public static unsafe void SetDragDropPayload(string type, string data, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(data);

        var byteCount = Encoding.UTF8.GetByteCount(data);

        if (byteCount <= MaxStackAllocSize)
        {
            var bytes = stackalloc byte[byteCount];
            Encoding.UTF8.GetBytes(data.AsSpan(), new Span<byte>(bytes, byteCount));
            ImGui.SetDragDropPayload(type, bytes, (nuint)byteCount, cond);
        }
        else
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            fixed (byte* ptr = bytes)
            {
                ImGui.SetDragDropPayload(type, ptr, (nuint)bytes.Length, cond);
            }
        }
    }

    public static unsafe bool AcceptDragDropPayload(string type, out string payload, ImGuiDragDropFlags flags = ImGuiDragDropFlags.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        ImGuiPayload* pload = ImGui.AcceptDragDropPayload(type, flags);

        if (pload != null && pload->Data != null && pload->DataSize > 0)
        {
            try
            {
                payload = Encoding.UTF8.GetString((byte*)pload->Data, pload->DataSize);
                return true;
            }
            catch (ArgumentException)
            {
                payload = null!;
                return false;
            }
        }

        payload = null!;
        return false;
    }

    public static unsafe void SetDragDropPayload(string type, ReadOnlySpan<byte> data, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        fixed (byte* ptr = data)
        {
            ImGui.SetDragDropPayload(type, ptr, (nuint)data.Length, cond);
        }
    }

    public static unsafe bool AcceptDragDropPayload(string type, out byte[]? payload, ImGuiDragDropFlags flags = ImGuiDragDropFlags.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        ImGuiPayload* pload = ImGui.AcceptDragDropPayload(type, flags);

        if (pload != null && pload->Data != null && pload->DataSize > 0)
        {
            payload = new byte[pload->DataSize];
            var span = new Span<byte>((byte*)pload->Data, pload->DataSize);
            span.CopyTo(payload);
            return true;
        }

        payload = null;
        return false;
    }

    public static unsafe void SetDragDropPayload(string type, int[] indices, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(indices);

        var totalSize = sizeof(int) + indices.Length * sizeof(int);
        var buffer = stackalloc byte[totalSize];

        Unsafe.Write(buffer, indices.Length);
        var dataPtr = buffer + sizeof(int);
        fixed (int* indicesPtr = indices)
        {
            Buffer.MemoryCopy(indicesPtr, dataPtr, indices.Length * sizeof(int), indices.Length * sizeof(int));
        }

        ImGui.SetDragDropPayload(type, buffer, (nuint)totalSize, cond);
    }

    public static unsafe bool AcceptDragDropPayload(string type, out int[] indices, ImGuiDragDropFlags flags = ImGuiDragDropFlags.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        ImGuiPayload* pload = ImGui.AcceptDragDropPayload(type, flags);

        if (pload != null && pload->Data != null && pload->DataSize >= sizeof(int))
        {
            try
            {
                var length = Unsafe.Read<int>(pload->Data);
                var expectedSize = sizeof(int) + length * sizeof(int);

                if (pload->DataSize >= expectedSize && length >= 0 && length <= 10000)
                {
                    indices = new int[length];
                    if (length > 0)
                    {
                        var dataPtr = (byte*)pload->Data + sizeof(int);
                        fixed (int* indicesPtr = indices)
                        {
                            Buffer.MemoryCopy(dataPtr, indicesPtr, length * sizeof(int), length * sizeof(int));
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
            }
        }

        indices = [];
        return false;
    }

    public static void SetDragDropPayloadList<T>(string type, IList<T> list, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(list);

        SetDragDropPayloadJson(type, list, cond);
    }

    public static bool AcceptDragDropPayloadList<T>(string type, out IList<T> list, ImGuiDragDropFlags flags = ImGuiDragDropFlags.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        if (AcceptDragDropPayloadJson<List<T>>(type, out var deserializedList, flags) && deserializedList != null)
        {
            list = deserializedList;
            return true;
        }

        list = [];
        return false;
    }

    public static void SetDragDropPayload(string type, IEnumerable<int> indices, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(indices);

        var indexArray = indices.ToArray();
        SetDragDropPayload(type, indexArray, cond);
    }

    public static void SetDragDropPayload(string type, HashSet<int> indices, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(indices);

        var indexArray = indices.ToArray();
        SetDragDropPayload(type, indexArray, cond);
    }

    public static bool AcceptDragDropPayload(string type, out HashSet<int> indices, ImGuiDragDropFlags flags = ImGuiDragDropFlags.None)
    {
        if (AcceptDragDropPayload(type, out int[] indexArray, flags))
        {
            indices = [.. indexArray];
            return true;
        }

        indices = [];
        return false;
    }
}