﻿using Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IServices
{
    public interface IItemService
    {
        public List<Item> GetItems();
    }
}
