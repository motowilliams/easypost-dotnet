using System;
using System.Configuration;
using Easypost;
using Machine.Specifications;

namespace tests
{
    public class EasyPostContext
    {
        /// <summary>
        /// Please visit https://www.easypost.co/ for a Api key
        /// </summary>
        public static string ApiKey = "ENTER_API_KEY";

        private Establish context = () =>
            {
                if (ApiKey.Equals("ENTER_API_KEY") || String.IsNullOrWhiteSpace(ApiKey))
                    throw new ConfigurationErrorsException("PLEASE SET YOUR API KEY");
                EasyPost = new EasyPost(ApiKey);
            };

        protected static EasyPost EasyPost;

    }

    [Subject(typeof(EasyPost), "Retrieving Postage")]
    public class when_retrieving_postage : EasyPostContext
    {
        private Because of = () =>
            response = EasyPost.ListPostage();

        It should_return_at_least_one_item = () =>
            response.Postages.Count.ShouldBeGreaterThan(0);

        protected static EasyPostPostageList response;
    }

    [Subject(typeof(EasyPost), "Retrieving Postage")]
    public class when_retrieving_postage_list : EasyPostContext
    {
        private Because of = () =>
            response = EasyPost.GetPostage(new ParcelFileName() { label_file_name = "test.png" });

        It should_return_tracking_code = () =>
            response.Tracking_Code.ShouldNotBeEmpty();

        protected static EasyPostPostage response;
    }

    [Subject(typeof(EasyPost), "Buying Postage")]
    public class when_purchasing_predefined_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = EasyPost.BuyPostage(TestData.predefinedPostagePurchase);

        It should_return_tracking_code = () =>
            response.Tracking_Code.ShouldNotBeEmpty();

        protected static EasyPostPostage response;
    }

    [Subject(typeof(EasyPost), "Buying Postage")]
    public class when_purchasing_custom_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = EasyPost.BuyPostage(TestData.customPostagePurchase);

        It should_return_tracking_code = () =>
            response.Tracking_Code.ShouldNotBeEmpty();

        protected static EasyPostPostage response;
    }

    [Subject(typeof(EasyPost), "Calculating Postage")]
    public class when_calculating_predefined_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = EasyPost.CalculatePostage(new PostageRate { Parcel = TestData.predefinedParcel, Zip = new Zip { To = "94107", From = "59847" } });

        It should_return_at_least_one_rate = () =>
            response.Rates.Length.ShouldBeGreaterThan(0);

        protected static EasyPostRates response;
    }

    [Subject(typeof(EasyPost), "Calculating Postage")]
    public class when_calculating_custom_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = EasyPost.CalculatePostage(new PostageRate { Parcel = TestData.customParcel, Zip = new Zip { To = "94107", From = "59847" } });

        It should_return_at_least_one_rate = () =>
            response.Rates.Length.ShouldBeGreaterThan(0);

        protected static EasyPostRates response;
    }

    [Subject(typeof(EasyPost), "Address Verification")]
    public class when_validating_complete_address : EasyPostContext
    {
        private Because of = () =>
            response = EasyPost.VerifyAddress(TestData._inputAddress);

        It should_return_same_address = () =>
            response.ShouldEqual<EasyPostAddress>(new EasyPostAddress { Address = TestData._inputAddress });

        protected static EasyPostAddress response;
    }

    [Subject(typeof(EasyPost), "Address Verification")]
    public class when_validating_partial_address : EasyPostContext
    {
        private Because of = () =>
            {
                removedZip = TestData._inputAddress.Zip;
                TestData._inputAddress.Zip = null;
                response = EasyPost.VerifyAddress(TestData._inputAddress);
            };

        private It should_return_complete_address = () =>
            {
                TestData._inputAddress.Zip = removedZip;
                response.ShouldEqual<EasyPostAddress>(new EasyPostAddress {Address = TestData._inputAddress});
            };

        protected static EasyPostAddress response;
        protected static string removedZip;
    }
}
