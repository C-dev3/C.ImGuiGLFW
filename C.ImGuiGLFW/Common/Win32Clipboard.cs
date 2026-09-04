using System.Runtime.InteropServices;

namespace C.ImGuiGLFW.Common;

internal static class Win32Clipboard
{
    private const uint CF_DIB = 8;
    private const uint GMEM_MOVEABLE = 0x0002;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool CloseClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool EmptyClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GlobalLock(IntPtr hMem);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GlobalUnlock(IntPtr hMem);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GlobalFree(IntPtr hMem);

    public static void SetImage(byte[] dibBytes)
    {
        if (!OpenClipboard(IntPtr.Zero))
            throw new InvalidOperationException("Failed to open clipboard.");

        try
        {
            EmptyClipboard();

            IntPtr hGlobal = GlobalAlloc(GMEM_MOVEABLE, (UIntPtr)dibBytes.Length);
            if (hGlobal == IntPtr.Zero)
                throw new OutOfMemoryException("GlobalAlloc failed.");

            IntPtr pGlobal = GlobalLock(hGlobal);
            try
            {
                Marshal.Copy(dibBytes, 0, pGlobal, dibBytes.Length);
            }
            finally
            {
                GlobalUnlock(hGlobal);
            }

            if (SetClipboardData(CF_DIB, hGlobal) == IntPtr.Zero)
            {
                GlobalFree(hGlobal);
                throw new InvalidOperationException("SetClipboardData failed.");
            }
        }
        finally
        {
            CloseClipboard();
        }
    }
}
