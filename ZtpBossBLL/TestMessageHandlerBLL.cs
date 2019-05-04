using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZtpBoss.Model;

namespace ZtpBoss.BLL
{
    public class TestMessageHandlerBLL
    {
        public static string Handle(HttpContextBase httpContext)
        {
            ZtpBoss.Model.TestMessagePost tmp = new TestMessagePost();
            LoadEntity(httpContext, tmp);

            Model.TestMessageResponse tmr = new TestMessageResponse();
            tmr.ToUserName = tmr.ToUserName;
            tmr.FromUserName = tmr.FromUserName;
            tmr.CreateTime = tmr.CreateTime;
            tmr.MsgType = tmr.MsgType;
            tmr.Content = tmr.Content;

            
            return Common.XmlHelper.XmlSerialize(tmr,Encoding.UTF8);

            //return tmp.Content;
            //目前完成信息的接受，后续要进行信息的回复，要参考公众号文档推送XML，因此，要重温对XML的操作（自动做洲际里）
            
        }

        private static void LoadEntity(HttpContextBase httpContext, TestMessagePost tmp)
        {

            tmp.ToUserName = httpContext.Request.Form["ToUserName"];
            tmp.FromUserName = httpContext.Request.Form["FromUserName"];
            tmp.CreateTime = httpContext.Request.Form["CreateTime"];
            tmp.MsgType = httpContext.Request.Form["MsgType"];
            tmp.Content = httpContext.Request.Form["Content"];
            tmp.MsgId = httpContext.Request.Form["MsgId"];
            //ToUserName  开发者微信号
            //FromUserName    发送方帐号（一个OpenID）
            //CreateTime 消息创建时间 （整型）
            //MsgType text
            //Content 文本消息内容
            //MsgId 消息id，64位整型
        }
    }
}
