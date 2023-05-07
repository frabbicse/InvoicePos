using Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IServices
{
    public interface IBillService
    {
        public string SaveBillMaster(OrderBillMaster orderBillMaster);
        public string SaveBillDetail(string orders,int billId);
    }
}
