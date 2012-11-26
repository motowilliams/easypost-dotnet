using System;

namespace Easypost
{
    public class Zip
    {
        public string To { get; set; }
        public string From { get; set; }

        protected bool Equals(Zip other)
        {
            return string.Equals(To, other.To, StringComparison.OrdinalIgnoreCase) && string.Equals(From, other.From, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Zip) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((To != null ? To.GetHashCode() : 0)*397) ^ (From != null ? From.GetHashCode() : 0);
            }
        }
    }
}