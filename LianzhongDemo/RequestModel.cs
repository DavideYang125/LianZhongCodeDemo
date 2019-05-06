using System;
using System.Collections.Generic;
using System.Text;

namespace LianzhongDemo
{
    public class RequestModel
    {
        public int softwareId;
        public string softwareSecret;
        public string username;
        public string password;
        public string captchaData;

        public int captchaType;
        public int captchaMinLength;
        public int captchaMaxLength;
        public int workerTipsId;
    }
}
