using splice.core.Repository.data.POCOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splice.core.Repository.contracts
{
    public interface IExpense
    {
        /// <summary>
        /// returns all expenses with their items
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        object GetExpenseWithItems(int expenseId);

        /// <summary>
        /// create a new expense
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
        /// removes an expense with the associated items
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        bool removeExpense(int expenseId);

        /// <summary>
        /// removes a single item from an expense
        /// </summary>
        /// <param name="itemId"></param>
        void removeItemFromExpense(int itemId);
    }
}
