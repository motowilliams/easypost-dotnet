using System;
using System.Net.Http;

namespace Easypost
{
    public class Address : IEncodable
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public FormUrlEncodedContent AsFormUrlEncodedContent()
        {
            var collection = new CollectionBuilder()
                    .AddRequired("address[street1]".ToKvp(Street1))
                    .AddRequired("address[street2]".ToKvp(Street2))
                    .AddRequired("address[city]".ToKvp(City))
                    .AddRequired("address[state]".ToKvp(State))
                    .AddRequired("address[zip]".ToKvp(Zip));

            return collection.AsFormUrlEncodedContent();
        }

        public override string ToString()
        {
            return string.Format("Street1: {0}, Street2: {1}, City: {2}, State: {3}, Zip: {4}", Street1, Street2, City, State, Zip);
        }

        protected bool Equals(Address other)
        {
            return string.Equals(Street1, other.Street1, StringComparison.OrdinalIgnoreCase) && string.Equals(Street2, other.Street2, StringComparison.OrdinalIgnoreCase) && string.Equals(City, other.City, StringComparison.OrdinalIgnoreCase) && string.Equals(State, other.State, StringComparison.OrdinalIgnoreCase) && string.Equals(Zip, other.Zip, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Street1 != null ? Street1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Street2 != null ? Street2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Zip != null ? Zip.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Address left, Address right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Address left, Address right)
        {
            return !Equals(left, right);
        }
    }
}