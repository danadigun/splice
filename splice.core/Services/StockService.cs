﻿using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using splice.core.Repository.contracts;
using splice.core.Repository.data;
using splice.core.Repository.data.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using splice.core.Repository.data.POCOs;

namespace splice.core.Services
{
    [Route("/api/sales/stock")]
    public class StockDTO
    {
        public int? stockId { get; set; }
        public int? itemId { get; set; }
        public Stock stock { get; set; }
        public List<StockItems> items { get; set; }
    }
    public class StockService : Service, IRepositoryApi<StockDTO>
    {

        public object get(StockDTO dto)
        {
            using (var uow = new UnitOfWork(DataSource.sqlConnectionString))
            {
                var _repo = uow.stockRepo;
                if (dto.stockId.HasValue)
                {
                    return _repo.GetStockWithItems(dto.stockId.Value);
                }
                return "no transaction requested";
            }
        }

        public void post(StockDTO dto)
        {
            using (var uow = new UnitOfWork(DataSource.sqlConnectionString))
            {
                var _repo = uow.stockRepo;
                if (dto.stock != null)
                {
                    _repo.CreateStock(dto.stock);
                }

                //add items to stock
                if (dto.items != null && dto.stockId.HasValue)
                {
                    _repo.AddItemsToStock(dto.stockId.Value, dto.items);
                }
            }
        }

        public void put(StockDTO dto)
        {
            throw new NotImplementedException();
        }

        public object delete(StockDTO dto)
        {
            using (var uow = new UnitOfWork(DataSource.sqlConnectionString))
            {
                var _repo = uow.stockRepo;
                if (dto.stockId.HasValue)
                {
                    return _repo.removeStock(dto.stockId.Value);
                }

                //remove items from stock
                if (dto.itemId.HasValue)
                {
                    return _repo.removeItemFromStock(dto.itemId.Value);
                }
                return false;
            }
        }
    }
}