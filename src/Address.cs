using System;
using System.Net.Http;

namespace Easypost
{
    public partial class Address : IEncodable
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
    }
}