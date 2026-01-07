using System.Runtime.InteropServices;

namespace ImAnim.NET.Structs;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ImAnimSpringParams
{
    public float Mass;
    public float Stiffness;
    public float Damping;
    public float InitialVelocity;
}
