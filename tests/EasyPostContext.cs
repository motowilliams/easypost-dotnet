using System;
using System.Configuration;
using Easypost;
using Machine.Specifications;

namespace tests
{
    public static class EasyPostConfig
    {
        /// <summary>
        /// Please visit https://www.easypost.co/ for a Api key
        /// </summary>
        public static string ApiKey = "ENTER_API_KEY";
    }

    public class EasyPostContext
    {
        private Establish context = () =>
            {
                if (EasyPostConfig.ApiKey.Equals("ENTER_API_KEY") || string.IsNullOrWhiteSpace(EasyPostConfig.ApiKey))
                    throw new ConfigurationErrorsException("Please set your Api Key");
                easyPost = new EasyPost(EasyPostConfig.ApiKey);
            };

        protected static EasyPost easyPost;
        protected static Address _inputAddress = new Address { Street1 = "388 Townsend St", Street2 = "Apt 20", City = "San Francisco", State = "CA", Zip = "94107" };
        protected static Parcel customParcel = new Parcel { Height = 8.0m, Length = 10.0m, Width = 5.0m, Weight = 10.0m };
        protected static Parcel predefinedParcel = new Parcel { PredefinedPackage = UspsParcelType.MediumFlatRateBox, Weight = 10m };
        protected static PostagePurchase predefinedPostagePurchase = new PostagePurchase { Carrier = "USPS", Service = "Priority", Parcel = predefinedParcel,
            To = new Address { City = "San Francisco", State = "CA", Zip = "94107", Street1 = "388 Townsend St", Street2 = "Apt 20" },
            From = new Address { City = "Half Moon Bay", State = "CA", Zip = "94019", Street1 = "310 Granelli Ave" },
            Sender = "Jarrett Streebin",
            Recipient = "Jon Calhoun"
        };
        protected static PostagePurchase customPostagePurchase = new PostagePurchase { Carrier = "USPS", Service = "Priority", Parcel = customParcel,
            To = new Address { City = "San Francisco", State = "CA", Zip = "94107", Street1 = "388 Townsend St", Street2 = "Apt 20" },
            From = new Address { City = "Half Moon Bay", State = "CA", Zip = "94019", Street1 = "310 Granelli Ave" },
            Sender = "Jarrett Streebin",
            Recipient = "Jon Calhoun"
        };
    }

    [Subject(typeof(EasyPost))]
    public class when_retrieving_postage : EasyPostContext
    {
        private Because of = () =>
            response = easyPost.ListPostage();

        It should_return_at_least_one_item = () =>
            response.Postages.Count.ShouldBeGreaterThan(0);

        protected static EasyPostPostageList response;
    }

    [Subject(typeof(EasyPost))]
    public class when_retrieving_postage_list : EasyPostContext
    {
        private Because of = () =>
            response = easyPost.GetPostage(new ParcelFileName() { label_file_name = "test.png" });

        It should_return_tracking_code = () =>
            response.Tracking_Code.ShouldNotBeEmpty();

        protected static EasyPostPostage response;
    }

    [Subject(typeof(EasyPost))]
    public class when_purchasing_predefined_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = easyPost.BuyPostage(predefinedPostagePurchase);

        It should_return_tracking_code = () =>
            response.Tracking_Code.ShouldNotBeEmpty();

        protected static EasyPostPostage response;
    }

    [Subject(typeof(EasyPost))]
    public class when_purchasing_custom_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = easyPost.BuyPostage(customPostagePurchase);

        It should_return_tracking_code = () =>
            response.Tracking_Code.ShouldNotBeEmpty();

        protected static EasyPostPostage response;
    }

    [Subject(typeof(EasyPost))]
    public class when_calculating_predefined_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = easyPost.CalculatePostage(new PostageRate { Parcel = predefinedParcel, Zip = new Zip { To = "94107", From = "59847" } });

        It should_return_at_least_one_rate = () =>
            response.Rates.Length.ShouldBeGreaterThan(0);

        protected static EasyPostRates response;
    }

    [Subject(typeof(EasyPost))]
    public class when_calculating_custom_package_postage : EasyPostContext
    {
        private Because of = () =>
            response = easyPost.CalculatePostage(new PostageRate { Parcel = customParcel, Zip = new Zip { To = "94107", From = "59847" } });

        It should_return_at_least_one_rate = () =>
            response.Rates.Length.ShouldBeGreaterThan(0);

        protected static EasyPostRates response;
    }

    [Subject(typeof(EasyPost))]
    public class when_validating_complete_address : EasyPostContext
    {
        private Because of = () =>
            response = easyPost.VerifyAddress(_inputAddress);

        It should_return_same_address = () =>
            response.ShouldEqual<EasyPostAddress>(new EasyPostAddress { Address = _inputAddress });

        protected static EasyPostAddress response;
    }

    [Subject(typeof(EasyPost))]
    public class when_validating_partial_address : EasyPostContext
    {
        private Because of = () =>
            {
                removedZip = _inputAddress.Zip;
                _inputAddress.Zip = null;
                response = easyPost.VerifyAddress(_inputAddress);
            };

        private It should_return_complete_address = () =>
            {
                _inputAddress.Zip = removedZip;
                response.ShouldEqual<EasyPostAddress>(new EasyPostAddress {Address = _inputAddress});
            };

        protected static EasyPostAddress response;
        protected static string removedZip;
    }
}
