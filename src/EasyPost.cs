using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Easypost
{
    /// <seealso href="https://www.easypost.co/docs"/>
    public class EasyPost
    {
        public string ApiKey { get; private set; }
        public string BaseAddress { get; private set; }
        public string VerifyAddressUri { get; private set; }
        public string CalculatePostageUri { get; private set; }
        public string PurchasePostageUri { get; private set; }
        public string GetPostageUri { get; private set; }
        public string ListPostageUri { get; private set; }

        public EasyPost(string apiKey, string baseAddress = "https://www.easypost.co/", string verifyAddressUri = "/api/address/verify", string calculatePostageUri = "/api/postage/rates", string purchasePostageUri = "/api/postage/buy", string getPostageUri = "/api/postage/get", string listPostageUri = "/api/postage/list")
        {
            ApiKey = apiKey;
            BaseAddress = baseAddress;
            VerifyAddressUri = verifyAddressUri;
            CalculatePostageUri = calculatePostageUri;
            PurchasePostageUri = purchasePostageUri;
            GetPostageUri = getPostageUri;
            ListPostageUri = listPostageUri;
        }

        /// <summary>
        /// For valid addresses the return value is just address. Note that some data can be missing and still result in a valid address. For instance, if you forget to include the state we will try to fill this in for you and add this data to the returned JSON.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <seealso cref="https://www.easypost.co/docs#addresses-verification"/>
        public EasyPostAddress VerifyAddress(Address model)
        {
            if (string.IsNullOrWhiteSpace(VerifyAddressUri))
                throw new ArgumentException("invalid url", VerifyAddressUri);
            return Execute<EasyPostAddress, Address>(model, VerifyAddressUri);
        }

        /// <summary>
        /// Getting the rates for a shipment requires 3 essential pieces of info - who the parcel is to, who the parcel is from, and lastly the parcel info (size and weight). Parcels can either be defined by their length, width, height, and weight, or by using a predefined package name (such as a USPS Small Flat Rate Box). For more info about parcels, see the Parcels section.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <seealso cref="https://www.easypost.co/docs#postage-rates"/>
        public EasyPostRates CalculatePostage(PostageRate model)
        {
            if (string.IsNullOrWhiteSpace(CalculatePostageUri))
                throw new ArgumentException("invalid url", CalculatePostageUri);
            return Execute<EasyPostRates, PostageRate>(model, CalculatePostageUri);
        }

        /// <summary>
        /// Calls to buy postage are very similar to looking up postage rates, except you need to provide more detailed information for the to and from addresses. In some cases you also have to provide a from phone number. For example, when using Express Mail with USPS a from phone number is required. For best results, always include a from phone number.  Parcels can either be defined by their length, width, height, and weight, or by using a predefined package name (such as a USPS Small Flat Rate Box). For more info about parcels, see the Parcels section.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <seealso cref="https://www.easypost.co/docs#postage-buying"/>
        public EasyPostPostage BuyPostage(PostagePurchase model)
        {
            if (string.IsNullOrWhiteSpace(PurchasePostageUri))
                throw new ArgumentException("invalid url", PurchasePostageUri);
            return Execute<EasyPostPostage, PostagePurchase>(model, PurchasePostageUri);
        }

        /// <summary>
        /// If you need to access the postage label, it is located at https://www.easypost.co/assets/<label_file_name> You can also lookup other details for your previously purchased postage, such as the price paid or the tracking code. Purchased postage is retrieved using the label_file_name.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <seealso cref="https://www.easypost.co/docs#postage-lookups"/>
        public EasyPostPostage GetPostage(ParcelFileName model)
        {
            if (string.IsNullOrWhiteSpace(GetPostageUri))
                throw new ArgumentException("invalid url", GetPostageUri);
            return Execute<EasyPostPostage, ParcelFileName>(model, GetPostageUri);
        }

        /// <summary>
        /// You can also request a list of all existing postage label_file_names. The only data returned is an array of label_file_names you have access to.
        /// </summary>
        /// <returns></returns>
        /// <seealso cref="https://www.easypost.co/docs#postage-lookups"/>
        public EasyPostPostageList ListPostage()
        {
            if (string.IsNullOrWhiteSpace(ListPostageUri))
                throw new ArgumentException("invalid url", ListPostageUri);
            return Execute<EasyPostPostageList>(ListPostageUri);
        }

        private HttpClient CreateClient()
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("invalid api key", ApiKey);

            var handler = new WebRequestHandler { AllowAutoRedirect = true, UseProxy = true };
            var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) };
            var apiKeyBase64String = Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", ApiKey, String.Empty)));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", apiKeyBase64String);
            return client;
        }

        private T Execute<T, TR>(TR model, string apiUri) where TR : IEncodable
        {
            using (var client = CreateClient())
            {
                HttpContent content = model.AsFormUrlEncodedContent();

                HttpResponseMessage httpResponseMessage = client.PostAsync(apiUri, content).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<T>().Result;
                return response;
            }
        }

        private T Execute<T>(string apiUri)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage httpResponseMessage = client.PostAsync(apiUri, null).Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                var response = httpResponseMessage.Content.ReadAsAsync<T>().Result;
                return response;
            }
        }
    }
}