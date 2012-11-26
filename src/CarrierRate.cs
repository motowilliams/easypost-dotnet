using System;

namespace Easypost
{
    public class CarrierRate
    {
        public string Carrier { get; set; }
        public string Service { get; set; }
        public decimal Rate { get; set; }

        public override string ToString()
        {
            return string.Format("Carrier: {0}, Service: {1}, Rate: {2}", Carrier, Service, Rate);
        }

        protected bool Equals(CarrierRate other)
        {
            return string.Equals(Carrier, other.Carrier, StringComparison.OrdinalIgnoreCase) && string.Equals(Service, other.Service, StringComparison.OrdinalIgnoreCase) && Rate == other.Rate;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CarrierRate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Carrier != null ? Carrier.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Service != null ? Service.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Rate.GetHashCode();
                return hashCode;
            }
        }
    }
}