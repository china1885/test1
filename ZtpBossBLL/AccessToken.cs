using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtpBoss.DAL;
using ZtpBoss.Model;
using System.Net;
using Newtonsoft.Json;

namespace ZtpBoss.BLL
{
    public class AccessToken
    {
        private static string AppID;
        private static string AppSecret;
        //用来获取accessToken的URL（其中一部分，后面要接上参数）
        private static string GetStringHead = @"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential";

        private static void RefreshAppID_Secret()
        {
            List<Model.CommonValues> list = DAL.CommonValuesDAL.GetAppID_Secret();
            AppID = list.Find(p => p.Key_Str == "AppID").Value_Str;
            AppSecret = list.Find(p => p.Key_Str == "AppSecret").Value_Str;
        }

        public static void UpdateAccessToken()
        {
            RefreshAppID_Secret();
            StringBuilder sb = new StringBuilder();
            sb.Append(GetStringHead);
            sb.Append("&appid=" + AppID);
            sb.Append("&secret=" + AppSecret);

            Common.HttpCommon hc = new Common.HttpCommon();
            string responseStr = hc.HttpGet(sb.ToString(), "");

            decodeResponseAndImport(responseStr);


            

        }


        public static void decodeResponseAndImport(string ResponseStr)
        {
            Newtonsoft.Json.Linq.JObject jo = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(ResponseStr);
            if(jo["access_token"] is null)
            {
                throw new Exception("获取AccessToken失败，微信服务器返回：\r\n"+ResponseStr);
            }
            var access_tokenStr = jo["access_token"].ToString();
            var expires_in = Convert.ToDouble(jo["expires_in"]);
            Model.CommonValues cv = new CommonValues();
            cv.Key_Str = "AccessToken";
            cv.Value_Str = access_tokenStr;
            cv.Update_time = DateTime.Now;
            DAL.CommonValuesDAL.UpdateToken(cv);
            

        }
    }
}
