using System;

namespace Easypost
{
    public class EasyPostAddress : ReponseBase
    {
        public Address Address { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return string.Format("Address: {0}, Message: {1}, Error: {2}", Address, Message, Error);
        }

        protected bool Equals(EasyPostAddress other)
        {
            return Equals(Address, other.Address) && string.Equals(Message, other.Message, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EasyPostAddress) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0)*397) ^ (Message != null ? Message.GetHashCode() : 0);
            }
        }
    }
}