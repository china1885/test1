using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtpBoss.Common;

namespace ZtpBoss.BLL
{
    public class Validate
    {
        public bool checkSignature(string signatureStr, string timestampStr, string nonceStr, string token)
        {
            
            

            List<string> list = new List<string>();
            list.Add(timestampStr);
            list.Add(nonceStr);
            list.Add(token);
            var orderedList= list.OrderBy(p => p, StringComparer.Ordinal).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in orderedList)
            {
                sb.Append(item);
            }
            string encryptStr= Common.EncryptHelper.Sha1(sb.ToString());

            if (encryptStr.ToUpper() == signatureStr.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }



    }
}
