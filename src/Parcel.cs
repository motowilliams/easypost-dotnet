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
    }
}