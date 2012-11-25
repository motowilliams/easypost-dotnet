using System;
using System.Net.Http;

namespace Easypost
{
    public class PostagePurchase : IEncodable
    {
        public Address To { get; set; }
        public Address From { get; set; }
        public Parcel Parcel { get; set; }
        public string Carrier { get; set; }
        public string Service { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }

        public FormUrlEncodedContent AsFormUrlEncodedContent()
        {
            var collection = new CollectionBuilder()
                .AddRequired("to[name]".ToKvp(Recipient))
                .AddRequired("from[name]".ToKvp(Sender))
                .AddRequired("to[name]".ToKvp(Recipient))
                .AddRequired("to[street1]".ToKvp(To.Street1))
                .AddRequired("to[street2]".ToKvp(To.Street2))
                .AddRequired("to[city]".ToKvp(To.City))
                .AddRequired("to[state]".ToKvp(To.State))
                .AddRequired("to[zip]".ToKvp(To.Zip))
                .AddRequired("from[name]".ToKvp(Sender))
                .AddRequired("from[street1]".ToKvp(From.Street1))
                .AddRequired("from[street2]".ToKvp(From.Street2))
                .AddRequired("from[city]".ToKvp(From.City))
                .AddRequired("from[state]".ToKvp(From.State))
                .AddRequired("from[zip]".ToKvp(From.Zip))
                .AddParcel(Parcel)
                .AddRequired("carrier".ToKvp(Carrier))
                .AddRequired("service".ToKvp(Service));
            
            return collection.AsFormUrlEncodedContent();
        }
    }
}