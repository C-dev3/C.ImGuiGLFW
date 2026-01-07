using Hexa.NET.ImGui;
using System.Numerics;

namespace ImAnim.NET;

public struct IamInstanceData
{
    public uint InstId;
    public uint ClipId;        // Store clip ID instead of pointer to avoid invalidation
    public float Time;
    public float TimeScale;
    public float Weight;
    public float DelayLeft;
    public bool Playing;
    public bool Paused;
    public bool BeginCalled;   // iam_track whether on_begin has been called
    public int DirSign;
    public int LoopsLeft;
    public uint LastSeenFrame;

    // Per-channel current values (cached after evaluation)
    public ImGuiStorage ValuesFloat;
    public ImGuiStorage ValuesInt;

    // vec2/vec4/color stored as float pairs/quads in separate arrays
    public struct Vec2Entry
    {
        public uint Ch;
        public Vector2 V;
    }

    public struct Vec4Entry
    {
        public uint Ch;
        public Vector4 V;
    }

    public struct ColorEntry
    {
        public uint Ch;
        public Vector4 V;
        public int ColorSpace;
    }

    // Relative types need 8 floats: percent(4) + px_bias(4)
    public struct Vec4RelEntry
    {
        public uint Ch;
        public Vector4 Percent;
        public Vector4 PxBias;
    }

    public struct ColorRelEntry
    {
        public uint Ch;
        public Vector4 Percent;
        public Vector4 PxBias;
        public int ColorSpace;
    }

    public ImVector<Vec2Entry> ValuesVec2;
    public ImVector<Vec4Entry> ValuesVec4;
    public ImVector<ColorEntry> ValuesColor;
    public ImVector<Vec4RelEntry> ValuesVec4Rel;
    public ImVector<ColorRelEntry> ValuesColorRel;

    // Layered blending output (written by iam_layer_end)
    public ImGuiStorage BlendedFloat;
    public ImGuiStorage BlendedInt;
    public ImVector<Vec2Entry> BlendedVec2;
    public ImVector<Vec4Entry> BlendedVec4;
    public ImVector<ColorEntry> BlendedColor;
    public bool HasBlended;    // true if blended values are valid

    // Marker tracking - bitset for triggered markers (reset on loop)
    public ImVector<bool> MarkersTriggered;
    public float PrevTime;     // Previous time for marker crossing detection

    // Animation chaining - next clip to play when this one completes
    public uint ChainNextClipId;   // Clip to play next (0 = none)
    public uint ChainNextInstId;   // Instance ID for next clip (0 = auto-generate)
    public float ChainDelay;       // Delay before starting chained clip

    // Loop variation tracking
    public int CurrentLoop;        // Current loop iteration (0-based), used for variation calculations
    public uint VarRngState;       // RNG state for deterministic variation random

    public IamInstanceData()
    {
        InstId = 0;
        ClipId = 0;
        Time = 0f;
        TimeScale = 1.0f;
        Weight = 1.0f;
        DelayLeft = 0f;
        Playing = false;
        Paused = false;
        BeginCalled = false;
        DirSign = 1;
        LoopsLeft = 0;
        LastSeenFrame = 0;
        ValuesFloat = default;
        ValuesInt = default;
        ValuesVec2 = new ImVector<Vec2Entry>();
        ValuesVec4 = new ImVector<Vec4Entry>();
        ValuesColor = new ImVector<ColorEntry>();
        ValuesVec4Rel = new ImVector<Vec4RelEntry>();
        ValuesColorRel = new ImVector<ColorRelEntry>();
        BlendedFloat = default;
        BlendedInt = default;
        BlendedVec2 = new ImVector<Vec2Entry>();
        BlendedVec4 = new ImVector<Vec4Entry>();
        BlendedColor = new ImVector<ColorEntry>();
        HasBlended = false;
        MarkersTriggered = new ImVector<bool>();
        PrevTime = 0f;
        ChainNextClipId = 0;
        ChainNextInstId = 0;
        ChainDelay = 0f;
        CurrentLoop = 0;
        VarRngState = 12345;
    }
}
