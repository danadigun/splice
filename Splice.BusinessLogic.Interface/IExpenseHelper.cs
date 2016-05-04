using Splice.DomainObjects;
using Splice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.BusinessLogic.Interface
{
    public interface IExpenseHelper
    {
        /// <summary>
        /// returns all expenses with their items
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        ExpenseWithItems GetExpenseWithItems(int expenseId);

        /// <summary>
        /// create a new expens
        /// </summary>
        /// <param name="expense"></param>
        void CreateNewExpense(Expense expense);

        /// <summary>
        /// Adds items to a newly created expense
        /// </summary>
        /// <param name="expenseId"></param>
        /// <param name="items"></param>
        void AddItemsToExpense(int expenseId, List<ExpenseItems> items);

        /// <summary>
        /// removes an expense with the associated item
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        bool RemoveExpense(int expenseId);

        /// <summary>
        /// removes a single item from an expense
        /// </summary>
        /// <param name="itemId"></param>
        void RemoveItemFromExpense(int itemId);
    }
}
