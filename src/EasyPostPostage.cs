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
    }
}