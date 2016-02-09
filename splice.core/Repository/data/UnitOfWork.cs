using ServiceStack.OrmLite;
using splice.core.Repository.data.model;
using splice.core.Repository.data.POCOs;
using splice.core.Repository.queries;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace splice.core.Repository.data
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed;
        private IDbConnection db;
        static UnitOfWork()
        {
            OrmLiteConfig.DialectProvider = SqlServerDialect.Provider;
        }

        public UnitOfWork(string connection)
        {
            db = connection.OpenDbConnection();
            

            //create tables if they dont and populate seed data when initialized for the first time.
            
            //ExpenseTable
            expenseRepo = new ExpenseRepository(db);
            if (!db.TableExists("Expense"))
            {
                db.CreateTableIfNotExists<Expense>();
                Expense exp = new Expense
                {
                    title = "Expenses for marketing",
                    dateCreated = DateTime.Now,
                };
                db.Save<Expense>(exp);


                db.CreateTableIfNotExists<ExpenseItems>();
                ExpenseItems items = new ExpenseItems
                {
                    ExpenseId = db.Select<Expense>().FirstOrDefault().Id,
                    dateCreated = DateTime.Now,
                    itemName = "Garri",
                    price = 24.34M
                };
                db.Save<ExpenseItems>(items);
            }

            //Stock Table
            stockRepo = new StockRepository(db);
            if (!db.TableExists("Stock"))
            {
                db.CreateTableIfNotExists<Stock>();
                Stock stock = new Stock()
                {
                    title = "January Stock",
                   description = "Items purchased from Lagos on the 1st of January",
                   dateCreated = DateTime.Now,
                };
                db.Save<Stock>(stock);

                //add items to stock
                db.CreateTableIfNotExists<StockItems>();
                StockItems item = new StockItems
                {
                    name = "Yams",
                    price = 23.56M,
                    qty = 12,
                    StockId = db.Select<Stock>().FirstOrDefault().Id,
                    dateCreated = DateTime.Now,                    
                };
                db.Save<StockItems>(item);
            }

            //SalesTransaction Table
            transactionRepo = new TransactionRepository(db);
            if (!db.TableExists("SalesTransaction"))
            {
                db.CreateTableIfNotExists<SalesTransaction>();
                SalesTransaction transaction = new SalesTransaction
                {
                    soldby = "daniel.adigun@yahoo.com",
                    dateCreated = DateTime.Now,
                };
                db.Save<SalesTransaction>(transaction);

                db.CreateTableIfNotExists<SalesTransactionItem>();
                SalesTransactionItem item = new SalesTransactionItem
                {
                    name = "Garri",
                    price = 25.00M,
                    qty = 2,
                    SalesTransactionId = db.Select<SalesTransaction>().FirstOrDefault().Id,
                    serial = "233445",
                };
                db.Save<SalesTransactionItem>(item);
            }
        }

        //Initialize Each Repository
        public TransactionRepository transactionRepo { get; private set; }
        public StockRepository stockRepo { get; private set; }
        public ExpenseRepository expenseRepo { get; set; }

        //dispose
        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                db.Dispose();
                db = null;
            }
        }
    }
}