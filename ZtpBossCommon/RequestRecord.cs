using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lyy = LyyLibrary;

namespace ZtpBoss.Common
{
    public class RequestRecord
    {
        public void SaveRequestStr2Log(string requestStr)
        {
            Lyy.LogFile.filePath = @"D:\testLog.txt";
            Lyy.LogFile.write(requestStr);
        }
        
    }
}
