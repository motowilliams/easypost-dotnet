using System;
using System.Net.Http;

namespace Easypost
{
    public class PostageRate : IEncodable
    {
        public Zip Zip { get; set; }
        public Parcel Parcel { get; set; }

        public FormUrlEncodedContent AsFormUrlEncodedContent()
        {
            CollectionBuilder collection = new CollectionBuilder()
                .AddRequired("to[zip]".ToKvp(Zip.To))
                .AddRequired("from[zip]".ToKvp(Zip.From))
                .AddParcel(Parcel);

            return collection.AsFormUrlEncodedContent();
        }
    }
}