using System;
using System.Text;
using System.Runtime.InteropServices;

namespace EVOFramework.Win32.API
{
    public static class User32 {
        private const string USER32 = "USER32.DLL";

        [DllImport(USER32)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport(USER32)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        /// <summary>
        /// The GetParent function retrieves a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="hWnd">[in] Handle to the window whose parent window handle is to be retrieved.</param>
        /// <returns></returns>
        [DllImport(USER32)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        /// <summary>
        /// The SetParent function changes the parent window of the specified child window. 
        /// </summary>
        /// <param name="hWndChild">[in] Handle to the child window</param>
        /// <param name="hWndNewParent">[in] Handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window. Windows 2000/XP: If this parameter is HWND_MESSAGE, the child window becomes a message-only window.</param>
        /// <returns></returns>
        [DllImport(USER32)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    }
    public static class Kernel32
    {        
        private const string KERNEL32 = "KERNEL32.DLL";

        [DllImport(KERNEL32)]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFilename);

        [DllImport(KERNEL32)]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFilename);
    }
}
