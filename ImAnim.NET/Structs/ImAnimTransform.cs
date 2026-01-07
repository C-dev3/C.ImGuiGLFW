using System.Numerics;
using System.Runtime.InteropServices;

namespace ImAnim.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct ImAnimTransform
{
    public Vector2 Position;
    public Vector2 Scale;
    public float Rotation;
}
