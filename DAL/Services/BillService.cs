using DAL.IServices;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace DAL.Services
{
    public class BillService : Connection, IBillService
    {
        public string SaveBillDetail(string orders, int billId)
        {
            try
            {
                var orderList = JsonConvert.DeserializeObject<List<OrderBillDetail>>(orders);

                foreach (OrderBillDetail detail in orderList)
                {
                    Query = @"Insert into bill_detail (billId,itemId, quantity, unitPrice, amount) values(@billId, @itemId, @quantity, @unitPrice, @amount)";

                    Command = new SqlCommand(Query, Con);
                    //Con.Open();

                    Command.Parameters.AddWithValue("@billId", billId);
                    Command.Parameters.AddWithValue("@itemId", detail.ItemId);
                    Command.Parameters.AddWithValue("@quantity", detail.Quantity);
                    Command.Parameters.AddWithValue("@unitPrice", detail.UnitPrice);
                    Command.Parameters.AddWithValue("@amount", detail.Amount);

                  int row =  Command.ExecuteNonQuery();
                }
                //Con.Close();
                return "Succes";
            }
            catch (Exception)
            {
                Con.Close();
                throw;
            }
        }

        public string SaveBillMaster(OrderBillMaster orderBillMaster)
        {
            try
            {
                Query = @"Insert into dbo.bill_master (subtotal,discount,vat,bill_date,bill_time)  output INSERTED.ID values(@subtotal  ,@discount,@vat   ,@bill_date,@bill_time); ";

                Command = new SqlCommand(Query, Con);
                //,Con.BeginTransaction()

                Con.Open();

                Command.Parameters.AddWithValue("@subtotal", orderBillMaster.SubTotal);
                Command.Parameters.AddWithValue("@discount", orderBillMaster.Discount);
                Command.Parameters.AddWithValue("@vat", orderBillMaster.VAT);
                Command.Parameters.AddWithValue("@bill_date", orderBillMaster.Date);
                Command.Parameters.AddWithValue("@bill_time", orderBillMaster.Time);

                var rowAffected = (int)Command.ExecuteScalar();

                SaveBillDetail(orderBillMaster.Orders, rowAffected);

                //Command.Transaction.Commit();
                Con.Close();
                return "Success";
            }
            catch (Exception)
            {
                //Command.Transaction.Rollback();
                Con.Close();
                throw;
            }
        }
    }
}
