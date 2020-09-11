using System;

namespace Business
{
    public class Package
    {
        public int package_id { get; set; }
        public string package_code { get; set; }
        public string cur_package_code { get; set; }
        public int customer_id { get; set; }
        public int product_qty { get; set; }
        public int product_type { get; set; }
        public string currency { get; set; }
        public string country_code { get; set; }
        public string tracking_no { get; set; }
        public string third_tracking_no { get; set; }
        public int platform_id { get; set; }
        public int site_id { get; set; }
        public int warehouse_id { get; set; }
        public int account_id { get; set; }
        public DateTime send_time { get; set; }
        public string package_remark { get; set; }
        public string channel_code { get; set; }
        public string package_status { get; set; }
        public string tax_no { get; set; }
        public int create_by { get; set; }
        public DateTime create_time { get; set; }
        public int update_by { get; set; }
        public DateTime update_time { get; set; }
    }
}