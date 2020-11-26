using System;
using System.Net;

namespace SportAppNet.Tool
{
    public class HandleError : Exception
    {

        public string Message { get; set; }     
        public int Code { get; set; }

        public HandleError(int Code,string Message)
        {
            this.Code = Code;
            this.Message = Message;
            
        }
    }
}
