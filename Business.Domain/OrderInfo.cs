using System;

namespace Business.Domain
{
    public class OrderInfo
    {
        public int order_id { get; set; }
        public string order_no { get; set; }
        public int customer_id { get; set; }
        public string customer_account { get; set; }
        public int order_amount { get; set; }
        public string order_currency { get; set; }
        public int product_qty { get; set; }
        public int payment_method { get; set; }
        public string shop_id { get; set; }
        public string shop_name { get; set; }
        public string order_status { get; set; }
        public int order_type { get; set; }
        public int package_id { get; set; }
        public string sub_order_no { get; set; }
        public string source_order_id { get; set; }
        public DateTime order_time { get; set; }
        public DateTime pay_time { get; set; }
        public DateTime send_time { get; set; }
        public int create_by { get; set; }
        public DateTime create_time { get; set; }
        public int update_by { get; set; }
        public DateTime update_time { get; set; }
    }
}