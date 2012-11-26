using System;
using System.Collections.Generic;

namespace Easypost
{
    public class EasyPostPostageList : ReponseBase
    {
        public List<string> Postages { get; set; }

        protected bool Equals(EasyPostPostageList other)
        {
            return Equals(Postages, other.Postages);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EasyPostPostageList) obj);
        }

        public override int GetHashCode()
        {
            return (Postages != null ? Postages.GetHashCode() : 0);
        }
    }
}