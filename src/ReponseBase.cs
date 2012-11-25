using System;

namespace Easypost
{
    public abstract class ReponseBase
    {
        public string Error { get; set; }
        public bool IsError { get { return !string.IsNullOrWhiteSpace(Error); } }
    }
}