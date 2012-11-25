using System;

namespace Easypost
{
    public class EasyPostAddress : ReponseBase
    {
        public Address Address { get; set; }
        public string Message { get; set; }
    }
}