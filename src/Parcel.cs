using System;

namespace Easypost
{
    public class Parcel
    {
        public UspsParcelType PredefinedPackage { get; set; }
        /// <summary>
        /// parcel weight in ounces
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// parcel size in inches
        /// </summary>
        public decimal? Height { get; set; }
        /// <summary>
        /// parcel size in inches
        /// </summary>
        public decimal? Width { get; set; }
        /// <summary>
        /// parcel size in inches
        /// </summary>
        public decimal? Length { get; set; }

        protected bool Equals(Parcel other)
        {
            return PredefinedPackage == other.PredefinedPackage && Weight == other.Weight && Height == other.Height && Width == other.Width && Length == other.Length;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Parcel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (int) PredefinedPackage;
                hashCode = (hashCode*397) ^ Weight.GetHashCode();
                hashCode = (hashCode*397) ^ Height.GetHashCode();
                hashCode = (hashCode*397) ^ Width.GetHashCode();
                hashCode = (hashCode*397) ^ Length.GetHashCode();
                return hashCode;
            }
        }
    }
}