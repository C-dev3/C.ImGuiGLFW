using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace C.ImGuiGLFW.ImGuiMethods;

/// <summary>
/// Provides helper methods for ImGui drag and drop operations with type-safe payload handling.
/// </summary>
/// <remarks>
/// This static class wraps ImGui's drag and drop functionality to provide convenient overloads
/// for common data types including unmanaged types, JSON serializable objects, strings, byte arrays,
/// integer arrays, and collections. It handles memory management and encoding automatically.
/// The class uses stack allocation for small payloads (up to 1024 bytes) for performance optimization.
/// </remarks>
public static class ImDragDrop
{
    private const int MaxStackAllocSize = 1024;

    /// <summary>
    /// Sets a drag and drop payload with an unmanaged data type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of the data to set as payload.</typeparam>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="data">The data to set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// This method is suitable for primitive types and unmanaged structs. The data is copied
    /// directly to the payload without serialization.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    public static unsafe void SetDragDropPayload<T>(string type, T data, ImGuiCond cond = ImGuiCond.None)
        where T : unmanaged
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        var ptr = Unsafe.AsPointer(ref data);
        var size = (nuint)Unsafe.SizeOf<T>();

        ImGui.SetDragDropPayload(type, ptr, size, cond);
    }

    /// <summary>
    /// Accepts a drag and drop payload with an unmanaged data type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type expected from the payload.</typeparam>
    /// <param name="type">The payload type identifier string to accept.</param>
    /// <param name="payload">When this method returns, contains the payload data if successful; otherwise, the default value.</param>
    /// <param name="flags">Flags controlling the acceptance behavior.</param>
    /// <returns>true if the payload was successfully accepted and contains valid data; otherwise, false.</returns>
    /// <remarks>
    /// This method validates that the payload size matches the expected type size before reading the data.
    /// If the payload is smaller than expected, the method returns false.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
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

    /// <summary>
    /// Sets a drag and drop payload by serializing an object to JSON.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="data">The object to serialize and set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// This method uses System.Text.Json for serialization. For small payloads (up to 1024 bytes),
    /// stack allocation is used for better performance. Larger payloads use heap allocation.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when data is null.</exception>
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

    /// <summary>
    /// Accepts a drag and drop payload by deserializing JSON data.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON payload to.</typeparam>
    /// <param name="type">The payload type identifier string to accept.</param>
    /// <param name="payload">When this method returns, contains the deserialized object if successful; otherwise, null.</param>
    /// <param name="flags">Flags controlling the acceptance behavior.</param>
    /// <returns>true if the payload was successfully accepted and deserialized; otherwise, false.</returns>
    /// <remarks>
    /// This method uses System.Text.Json for deserialization. If deserialization fails or the
    /// resulting object is null, the method returns false. All exceptions during deserialization
    /// are caught and result in a false return value.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
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

    /// <summary>
    /// Sets a drag and drop payload with string data.
    /// </summary>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="data">The string data to set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// The string is encoded as UTF-8 bytes. For small strings (up to 1024 bytes when encoded),
    /// stack allocation is used for better performance. Larger strings use heap allocation.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when data is null.</exception>
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

    /// <summary>
    /// Accepts a drag and drop payload as string data.
    /// </summary>
    /// <param name="type">The payload type identifier string to accept.</param>
    /// <param name="payload">When this method returns, contains the UTF-8 decoded string if successful; otherwise, null.</param>
    /// <param name="flags">Flags controlling the acceptance behavior.</param>
    /// <returns>true if the payload was successfully accepted and decoded; otherwise, false.</returns>
    /// <remarks>
    /// The payload data is decoded from UTF-8 bytes to a string. If the UTF-8 decoding fails,
    /// the method returns false.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
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

    /// <summary>
    /// Sets a drag and drop payload with raw byte data.
    /// </summary>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="data">The byte data to set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// This method allows setting arbitrary binary data as the payload. The data is copied
    /// directly without any encoding or transformation.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    public static unsafe void SetDragDropPayload(string type, ReadOnlySpan<byte> data, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        fixed (byte* ptr = data)
        {
            ImGui.SetDragDropPayload(type, ptr, (nuint)data.Length, cond);
        }
    }

    /// <summary>
    /// Accepts a drag and drop payload as raw byte data.
    /// </summary>
    /// <param name="type">The payload type identifier string to accept.</param>
    /// <param name="payload">When this method returns, contains a copy of the payload bytes if successful; otherwise, null.</param>
    /// <param name="flags">Flags controlling the acceptance behavior.</param>
    /// <returns>true if the payload was successfully accepted; otherwise, false.</returns>
    /// <remarks>
    /// This method creates a new byte array and copies the payload data into it. The returned
    /// array is independent of the original payload data.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
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

    /// <summary>
    /// Sets a drag and drop payload with an integer array.
    /// </summary>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="indices">The integer array to set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// The array is stored with a length prefix followed by the array data. This format
    /// allows for safe deserialization with bounds checking. The entire payload is allocated
    /// on the stack for performance.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when indices is null.</exception>
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

    /// <summary>
    /// Accepts a drag and drop payload as an integer array.
    /// </summary>
    /// <param name="type">The payload type identifier string to accept.</param>
    /// <param name="indices">When this method returns, contains the integer array if successful; otherwise, an empty array.</param>
    /// <param name="flags">Flags controlling the acceptance behavior.</param>
    /// <returns>true if the payload was successfully accepted and contains valid array data; otherwise, false.</returns>
    /// <remarks>
    /// This method validates the payload format including length prefix and bounds checking.
    /// Arrays larger than 10000 elements are rejected for safety. If validation fails,
    /// an empty array is returned.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
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

    /// <summary>
    /// Sets a drag and drop payload with a generic list by serializing it to JSON.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="list">The list to serialize and set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// This method is a convenience wrapper around SetDragDropPayloadJson for IList&lt;T&gt; types.
    /// The list is serialized to JSON using System.Text.Json.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when list is null.</exception>
    public static void SetDragDropPayloadList<T>(string type, IList<T> list, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(list);

        SetDragDropPayloadJson(type, list, cond);
    }

    /// <summary>
    /// Accepts a drag and drop payload as a generic list by deserializing from JSON.
    /// </summary>
    /// <typeparam name="T">The type of elements expected in the list.</typeparam>
    /// <param name="type">The payload type identifier string to accept.</param>
    /// <param name="list">When this method returns, contains the deserialized list if successful; otherwise, an empty list.</param>
    /// <param name="flags">Flags controlling the acceptance behavior.</param>
    /// <returns>true if the payload was successfully accepted and deserialized; otherwise, false.</returns>
    /// <remarks>
    /// This method deserializes the JSON payload to a List&lt;T&gt; and returns it as IList&lt;T&gt;.
    /// If deserialization fails, an empty list is returned.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
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

    /// <summary>
    /// Sets a drag and drop payload with an enumerable of integers.
    /// </summary>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="indices">The enumerable of integers to set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// This method converts the enumerable to an array and uses the integer array payload format.
    /// The enumerable is materialized only once during the conversion.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when indices is null.</exception>
    public static void SetDragDropPayload(string type, IEnumerable<int> indices, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(indices);

        var indexArray = indices.ToArray();
        SetDragDropPayload(type, indexArray, cond);
    }

    /// <summary>
    /// Sets a drag and drop payload with a HashSet of integers.
    /// </summary>
    /// <param name="type">The payload type identifier string.</param>
    /// <param name="indices">The HashSet of integers to set as the drag and drop payload.</param>
    /// <param name="cond">Conditions for setting the payload.</param>
    /// <remarks>
    /// This method converts the HashSet to an array and uses the integer array payload format.
    /// The order of elements in the resulting payload is not guaranteed to match the HashSet's
    /// internal order.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
    /// <exception cref="ArgumentNullException">Thrown when indices is null.</exception>
    public static void SetDragDropPayload(string type, HashSet<int> indices, ImGuiCond cond = ImGuiCond.None)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);
        ArgumentNullException.ThrowIfNull(indices);

        var indexArray = indices.ToArray();
        SetDragDropPayload(type, indexArray, cond);
    }

    /// <summary>
    /// Accepts a drag and drop payload as a HashSet of integers.
    /// </summary>
    /// <param name="type">The payload type identifier string to accept.</param>
    /// <param name="indices">When this method returns, contains the HashSet of integers if successful; otherwise, an empty HashSet.</param>
    /// <param name="flags">Flags controlling the acceptance behavior.</param>
    /// <returns>true if the payload was successfully accepted and contains valid array data; otherwise, false.</returns>
    /// <remarks>
    /// This method first accepts the payload as an integer array, then converts it to a HashSet.
    /// Duplicate values in the original array are automatically removed by the HashSet.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when type is null or empty.</exception>
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