﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task5_EF.Interfaces;
using Task5_EF.IRepository;
using Task5_EF.Models;

namespace Task5_EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SupplyContext supplyDbContext;
        private FlowerRepository flowerRepository;
        private WarehouseRepository warehouseRepository;

        public UnitOfWork(SupplyContext dbContext)
        {
            supplyDbContext = dbContext;
        }


        public IRepository<FlowerModel> Flowers
        {
            get
            {
                if (flowerRepository == null)
                    flowerRepository = new FlowerRepository(supplyDbContext);
                return flowerRepository;
            }
        }

        public IRepository<WarehouseModel> Warehouses
        {
            get
            {
                if (warehouseRepository == null)
                    warehouseRepository = new WarehouseRepository(supplyDbContext);
                return warehouseRepository;
            }
        }

        public void Save()
        {
            supplyDbContext.SaveChanges();
        }
    }
}