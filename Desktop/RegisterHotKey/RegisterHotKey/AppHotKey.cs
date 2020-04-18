using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RegisterHotKey
{
    public class AppHotKey
    {
        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();

        [DllImport("user32.dll" , SetLastError = true)]
        private static extern bool RegisterHotKey(
            IntPtr hWnd ,
            int id ,
            KeyModifiers modiKey ,
            Keys vk
            );

        [DllImport("user32.dll" , SetLastError = true)]
        private static extern bool UnregisterHotKey(
            IntPtr hWnd ,
            int id
            );

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(string lpStr);


        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt16 uInt16);

        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        public static void RegKey(IntPtr hWnd , int hotKeyID , KeyModifiers modiKey , Keys vk)
        {
            try
            {
                if( !RegisterHotKey(hWnd , hotKeyID , modiKey , vk) )
                {
                    if( Marshal.GetLastWin32Error() == 1409 )
                    {
                        MessageBox.Show("被占用");
                    }
                    else
                    {
                        MessageBox.Show("失败");
                    }
                }
            }
            catch( Exception )
            {

                throw;
            }
        }

        public static void Unregkey(IntPtr hWnd , int hotKeyID)
        {
            UnregisterHotKey(hWnd , hotKeyID);
        }
    }
}
