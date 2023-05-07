using Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IServices;

namespace DAL.Services
{
    public class ItemService : Connection, IItemService
    {
        public List<Item> GetItems()
        {
            try
            {
                Query = "Select * from items";
                Command = new SqlCommand(Query, Con);

                Con.Open();

                Reader = Command.ExecuteReader();

                List<Item> items = new List<Item>();

                while (Reader.Read())
                {
                    Item item = new Item();

                    item.Id = Reader.GetInt32(0);
                    item.Name = Reader.GetString(1);

                    items.Add(item);
                }
                Reader.Close();
                Con.Close();
                return items;
            }
            catch (Exception e)
            {
                Reader.Close();
                Con.Close();

                throw;
            }
        }
    }
}
