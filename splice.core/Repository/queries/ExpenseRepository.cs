using splice.core.Repository.contracts;
using splice.core.Repository.data;
using splice.core.Repository.data.DataSource;
using splice.core.Repository.data.POCOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace splice.core.Repository.queries
{
    public class ExpenseRepository : IExpense
    {
        
        private Repository<Expense> _expense;
        private Repository<ExpenseItems> _expenseItems;
        public ExpenseRepository(IDbConnection db)
        {
            _expense = new Repository<Expense>(db);
            _expenseItems = new Repository<ExpenseItems>(db);
        }

        public object GetExpenseWithItems(int expenseId)
        {
            var expense = _expense.GetById(expenseId);
            var expenseItems = _expenseItems.Get(x => x.ExpenseId == expenseId);

            var expenseWithItems = new ExpenseWithItems
            {
                expenseId = expense.Id,
                expenseTitle = expense.title,
                dateCreated = expense.dateCreated,
                items = expenseItems
            };
            return expenseWithItems;
        }

        public void CreateNewExpense(Expense expense)
        {
            _expense.Save(expense);
        }

        public void AddItemsToExpense(int expenseId, List<ExpenseItems> items)
        {
            foreach (var item in items)
            {
                item.ExpenseId = expenseId;
                _expenseItems.Save(item);
            }
        }

        public bool removeExpense(int expenseId)
        {
            var expense = _expense.GetById(expenseId);
            if (expense != null)
            {
                _expense.Delete(expenseId);
                _expenseItems.Delete(x => x.ExpenseId == expenseId);
                return true;
            }
            return false;
        }

        public void removeItemFromExpense(int itemId)
        {
            _expenseItems.Delete(itemId);
        }
    }

   
}