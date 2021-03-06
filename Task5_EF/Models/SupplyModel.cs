﻿using System;
using System.Collections.Generic;

namespace Task5_EF.Models
{
    public class SupplyModel
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public WarehouseModel WarehouseModel { get; set; }

        public int PlantationId { get; set; }

        public PlantationModel PlantationModel { get; set; }

        public DateTime ScheduledDate { get; set; }

        public DateTime ClosedDate { get; set; }

        public int StatusId { get; set; }

        public StatusModel StatusModel { get; set; }

        public virtual IList<FlowerSupplyModel> FlowerSupplyModels { get; set; }
    }
}