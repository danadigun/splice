using NHibernate;
using Splice.DomainObjects;
using Splice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
namespace Splice.Repository.Impl
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepo
    {
        private ISession _session;
        private IRepository<ExpenseItems> _expendItemRepo;
        public ExpenseRepository(ISession session)
            : base(session)
        {
            
        }

        public Expense GetExpenseWithItems(int expenseId)
        {
            var expense = base.GetById(expenseId);
            var expenseItems = _session.Query<ExpenseItems>().Where(x => x.ExpenseId == expenseId);

            //var expenseWithItems = new ExpenseWithItems
            //{
            //    expenseId = expense.Id,
            //    expenseTitle = expense.title,
            //    dateCreated = expense.dateCreated,
            //    items = expenseItems
            //};
            return expenseWithItems;
        }

        public void CreateNewExpense(Expense expense)
        {
            base.Save(expense);
        }

        public void AddItemsToExpense(int expenseId, List<ExpenseItems> items)
        {

        }

        public bool RemoveExpense(int expenseId)
        {
            throw new NotImplementedException();
        }

        public void RemoveItemFromExpense(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
