using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZtpBoss.Common;

namespace ZtpBoss.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult Index()
        {


            Common.RequestRecord rr = new RequestRecord();
            rr.SaveRequestStr2Log(HttpContext.Request.QueryString.ToString());

            string token = "lyytoken";
            string signatureStr = HttpContext.Request.QueryString["signature"];
            string timestampStr = HttpContext.Request.QueryString["timestamp"];
            string nonceStr = HttpContext.Request.QueryString["nonce"];
            string echostr = HttpContext.Request.QueryString["echostr"];
            BLL.Validate validate = new BLL.Validate();

            ContentResult cr = new ContentResult();
            if(signatureStr is null)
            {
                return Content("Empty Request");
            }
            if (validate.checkSignature(signatureStr, timestampStr, nonceStr, token))
            {
                cr.Content = echostr;
                return cr;
                
            }
            else
            {
                cr.Content = "ValidateFail";
                return cr;
            }

            
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            //Request.Params["MsgType"];
            //var msgType = HttpContext.Request.Form["MsgType"];
            var msgType= HttpContext.Request.Params["MsgType"];

            Common.RequestRecord rr = new Common.RequestRecord();

            string postStr;
            if (Request.HttpMethod.ToLower() == "post")
            {
                Stream s = System.Web.HttpContext.Current.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int)s.Length);
                postStr = Encoding.UTF8.GetString(b);
                //if (!string.IsNullOrEmpty(postStr))
                //{
                //    ResponseMsg(postStr);
                //}
                //WriteLog("postStr:" + postStr);
                rr.SaveRequestStr2Log(postStr);
            }


            if (msgType == "text")
            {
                rr.SaveRequestStr2Log("进入了text方法");
                
                return Content(BLL.TestMessageHandlerBLL.Handle(HttpContext));
            }

            
            
            return Content("Handle Failed");
        }
    }
}