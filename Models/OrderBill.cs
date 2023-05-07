using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderBillMaster
    {
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal VAT { get; set; }
        public decimal GrandTotal{ get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public List<OrderBillDetail> Details { get; set; }
        public string Orders { get; set; } 
    }

    public class OrderBillDetail
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice{ get; set; }
        public decimal Amount { get; set; }
       
    }
}
