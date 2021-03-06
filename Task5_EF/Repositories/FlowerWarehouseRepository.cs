﻿using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Task5_EF.IRepository;
using Task5_EF.Models;

namespace Task5_EF.Repositories
{
    public class FlowerWarehouseRepository : IRepository<FlowerWarehouseModel>
    {
        private SupplyContext supplyDbContext;

        public FlowerWarehouseRepository(SupplyContext supplyContext)
        {
            supplyDbContext = supplyContext;
        }

        public void Create(FlowerWarehouseModel item)
        {
            if (item != null)
            {
                supplyDbContext.FlowerWarehouses.Add(item);
            }
        }

        public void Delete(FlowerWarehouseModel item)
        {
            if (item != null)
            {
                var deleteItem = GetById(item.Id);
                if (deleteItem != null)
                {
                    supplyDbContext.FlowerWarehouses.Remove(deleteItem);
                }
            }
        }

        public List<FlowerWarehouseModel> GetAll()
        {
            return supplyDbContext.FlowerWarehouses
                .Include(x => x.FlowerModel)
                .Include(x => x.WarehouseModel)
                .ToList();
        }

        public FlowerWarehouseModel GetById(int id)
        {
            return supplyDbContext.FlowerWarehouses
                .Find(id);
        }

        public void Update(FlowerWarehouseModel item)
        {
            if (item != null)
            {
                var updateItem = GetById(item.Id);
                if (updateItem != null)
                {
                    updateItem.Amount = item.Amount;
                }
            }
        }
    }
}