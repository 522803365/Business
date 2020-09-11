using Business.Domain;
using log4net;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;
using Dapper; 
using Business.Configurations;
using ControlCenterServices.BackgroundJobs;

namespace Business.BackgroundJobs.jobs.Data
{
    public class DataSynchronizationjob : IBackgroundJob
    {
        private readonly log4net.ILog _log;

        public DataSynchronizationjob()
        {
            _log = LogManager.GetLogger(typeof(TestJob));
        }

        public async Task ExecuteAsync()
        {
            using IDbConnection conn1 = new MySqlConnection(AppSettings.RemoteMysql);
            var sql1 = @"SELECT * FROM `ControlCenterServices`.`order_info`;
                        SELECT * FROM `ControlCenterServices`.`package`";
            var result = await conn1.QueryMultipleAsync(sql1);

            var orderInfos = await result.ReadAsync<OrderInfo>();
            var packages = await result.ReadAsync<Package>();

            using IDbConnection conn2 = new MySqlConnection(AppSettings.ConnectionStrings);
            var sql2 = @"TRUNCATE TABLE `ControlCenterServices`.`order_info`;
                         TRUNCATE TABLE `ControlCenterServices`.`package`";
            await conn2.ExecuteAsync(sql2);

            await conn2.ExecuteAsync("INSERT INTO `order_info` VALUES (@order_id,@order_no,@customer_id,@customer_account,@order_amount,@order_currency,@product_qty,@payment_method,@shop_id,@shop_name,@order_status,@order_type,@package_id,@sub_order_no,@source_order_id,@order_time,@pay_time,@send_time,@create_by,@create_time,@update_by,@update_time)", orderInfos);

            await conn2.ExecuteAsync("INSERT INTO `package` VALUES (@package_id,@package_code,@cur_package_code,@customer_id,@product_qty,@product_type,@currency,@country_code,@tracking_no,@third_tracking_no,@platform_id,@site_id,@warehouse_id,@account_id,@send_time,@package_remark,@channel_code,@package_status,@tax_no,@create_by,@create_time,@update_by,@update_time)", packages);
        }
    }
}