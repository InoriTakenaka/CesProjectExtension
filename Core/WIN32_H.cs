using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WIN32_H
{
     public static class KERNETL32
    {
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        // 返回取得字符串缓冲区的长度
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern long GetPrivateProfileString(string Section, string Key, string Defualt, StringBuilder buffer, int size, string FilePath);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileInt(string Section, string Key, int Defualt, string FilePath);
    }
}
