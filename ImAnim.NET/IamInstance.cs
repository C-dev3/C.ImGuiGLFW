using System.Numerics;

namespace ImAnim.NET;

internal class IamInstance
{
    private uint instanceID;

    public IamInstance() => instanceID = 0;

    public IamInstance(uint instanceID) => this.instanceID = instanceID;

    public void Pause()
    {

    }

    public void Resume()
    {

    }

    public void Stop()
    {

    }

    public void Destroy()
    {

    }

    public void Seek(float time)
    {

    }

    public void SetTimeScale(float scale)
    {

    }

    public void SetWeight(float weight)
    {

    }

    public IamInstance Then(uint nextClipId)
    {
        return this;
    }

    public IamInstance Then(uint nextClipId, uint nextInstanceId)
    {
        return this;
    }

    public IamInstance ThenDelay(float delay)
    {
        return this;
    }

    public float Time()
    {
        return 0f;
    }

    public float Duration()
    {
        return 0f;
    }

    public bool IsPlaying()
    {
        return false;
    }

    public bool IsPaused()
    {
        return false;
    }

    public bool GetFloat(uint channel, out float value)
    {
        value = 0f;
        return false;
    }

    public bool GetVec2(uint channel, out Vector2 value)
    {
        value = default;
        return false;
    }

    public bool GetVec4(uint channel, out Vector4 value)
    {
        value = default;
        return false;
    }

    public bool GetInt(uint channel, out int value)
    {
        value = 0;
        return false;
    }

    public bool GetColor(uint channel, out Vector4 value, int colorSpace = IamColOklab)
    {
        value = default;
        return false;
    }

    // Check validity
    public bool Valid()
    {
        return false;
    }

    public static implicit operator bool(IamInstance instance)
    {
        return instance?.Valid() ?? false;
    }

    public uint Id()
    {
        return instanceID;
    }

    // 定数（元のコードで参照されている想定）
    private const int IamColOklab = 0;
}
