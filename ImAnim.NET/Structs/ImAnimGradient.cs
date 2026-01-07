using Hexa.NET.ImGui;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ImAnim.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct ImAnimGradient
{
    public ImVector<Vector2> Positions;
    public ImVector<Vector2> Colors;
}
