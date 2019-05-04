using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtpBoss.BLL;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string signature = "d730831a3f51fedc21e1f17d3226e0613251e996";
            //string echostr = "5180564166454267899";
            //string timestamp = "1544014921";
            //string nonce = "825712591";
            //string token = "lyytoken";

            //Validate validate = new Validate();
            //validate.checkSignature(signature, timestamp, nonce, token);

            AccessToken.UpdateAccessToken();
            
        }
    }
}
