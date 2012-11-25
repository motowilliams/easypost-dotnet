using System;
using System.Net.Http;

namespace Easypost
{
    public class ParcelFileName : IEncodable
    {
        public string label_file_name { get; set; }

        public FormUrlEncodedContent AsFormUrlEncodedContent()
        {
            var collection = new CollectionBuilder()
                .AddRequired("label_file_name".ToKvp(label_file_name));
            return collection.AsFormUrlEncodedContent();
        }
    }
}