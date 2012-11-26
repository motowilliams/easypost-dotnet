using System;

namespace Easypost
{
    public class EasyPostRates : ReponseBase
    {
        public CarrierRate[] Rates { get; set; }

        protected bool Equals(EasyPostRates other)
        {
            return Equals(Rates, other.Rates);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EasyPostRates) obj);
        }

        public override int GetHashCode()
        {
            return (Rates != null ? Rates.GetHashCode() : 0);
        }
    }
}