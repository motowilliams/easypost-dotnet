using System;

namespace Easypost
{
    public class EasyPostPostage : ReponseBase
    {
        public CarrierRate Rate { get; set; }
        public string Tracking_Code { get; set; }
        public string label_file_name { get; set; }
        public string label_file_type { get; set; }
        public string label_url { get; set; }

        public override string ToString()
        {
            return string.Format("Rate: {0}, Tracking_Code: {1}, label_file_name: {2}, label_file_type: {3}, label_url: {4}", Rate, Tracking_Code, label_file_name, label_file_type, label_url);
        }

        protected bool Equals(EasyPostPostage other)
        {
            return Rate.Equals(other.Rate) && string.Equals(Tracking_Code, other.Tracking_Code, StringComparison.OrdinalIgnoreCase) && string.Equals(label_file_name, other.label_file_name, StringComparison.OrdinalIgnoreCase) && string.Equals(label_file_type, other.label_file_type, StringComparison.OrdinalIgnoreCase) && string.Equals(label_url, other.label_url, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EasyPostPostage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Rate.GetHashCode();
                hashCode = (hashCode*397) ^ Tracking_Code.GetHashCode();
                hashCode = (hashCode*397) ^ label_file_name.GetHashCode();
                hashCode = (hashCode*397) ^ label_file_type.GetHashCode();
                hashCode = (hashCode*397) ^ label_url.GetHashCode();
                return hashCode;
            }
        }
    }
}