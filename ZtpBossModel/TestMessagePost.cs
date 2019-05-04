using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZtpBoss.Model
{
    public class TestMessagePost
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
        public string Content { get; set; }
        public string MsgId { get; set; }


        //ToUserName  开发者微信号
        //FromUserName    发送方帐号（一个OpenID）
        //CreateTime 消息创建时间 （整型）
        //MsgType text
        //Content 文本消息内容
        //MsgId 消息id，64位整型
    }
}
