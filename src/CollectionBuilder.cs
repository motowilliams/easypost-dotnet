using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Easypost
{
    internal class CollectionBuilder
    {
        private readonly List<KeyValuePair<string, string>> _collection = new List<KeyValuePair<string, string>>();

        public CollectionBuilder AddRequired(KeyValuePair<string, string> kvp)
        {
            if (!string.IsNullOrWhiteSpace(kvp.Value))
                _collection.Add(kvp);
            return this;
        }

        public void Add(KeyValuePair<string, string> kvp)
        {
            if (!string.IsNullOrWhiteSpace(kvp.Value))
                _collection.Add(kvp);
        }

        public FormUrlEncodedContent AsFormUrlEncodedContent()
        {
            return new FormUrlEncodedContent(_collection);
        }

        public CollectionBuilder AddParcel(Parcel parcel)
        {
            _collection.Add("parcel[weight]".ToKvp(parcel.Weight));
            if (parcel.PredefinedPackage == UspsParcelType.Unknown)
            {
                _collection.Add("parcel[length]".ToKvp(parcel.Length.ToString()));
                _collection.Add("parcel[width]".ToKvp(parcel.Width.ToString()));
                _collection.Add("parcel[height]".ToKvp(parcel.Height.ToString()));
            }
            else
            {
                _collection.Add("parcel[predefined_package]".ToKvp(parcel.PredefinedPackage.ToString()));
            }

            return this;
        }
    }
}