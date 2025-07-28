namespace C.ImGuiGLFW.Data;

[Flags]
public enum FilterType : long
{
    Verbose = 0b1,
    Debug = 0b10,
    Info = 0b100,
    Warning = 0b1000,
    Error = 0b10000,
    Fatal = 0b100000,
    Default = Info | Warning | Error | Fatal
}
