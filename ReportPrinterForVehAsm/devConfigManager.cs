using System;
using System.Collections.Generic;
using System.Text;
using WIN32_H;
using Infrastructure;
using System.IO;
namespace ReportPrinterForVehAsm
{
     public static class DevConfigManager
    {
         private static string m_ConfigPath;
         public static bool ready { get; private set; }
         public static void
             InitConfig()
         {
             m_ConfigPath = Path.GetFullPath("..") + @"\Config\sqlcfg.ini";
             ready = true;
         }
         public static string 
             GetConfigString(string Section,
                                            string Key,
                                            string Defualt,
                                            StringBuilder buffer,
                                            int size)
         {
             long size_t = KERNETL32.GetPrivateProfileString(Section, Key, Defualt, buffer, size, m_ConfigPath);
             if (size_t > 0) return buffer.ToString();
             else return null;
         }

         public static bool
             SetConfigString(string Section,
                                           string Key,
                                           string Value)
         {
             long result = KERNETL32.WritePrivateProfileString(Section, Key, Value, m_ConfigPath);
             if (result != 0) return true;
             else return false;
         }       
    }
}
