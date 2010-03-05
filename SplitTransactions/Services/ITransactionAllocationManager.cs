using System.Collections.Generic;
using SplitTransactions.UpaySplitService;

namespace SplitTransactions.Services
{
    public interface ITransactionAllocationManager
    {
        /// <summary>
        /// Add allocations to the current transaction
        /// </summary>
        /// <param name="fid">
        /// 3-character FID code identifying your merchant activity.  These are assigned by Internal Control.
        /// </param>
        /// <param name="chart">
        /// 1-character chart code of the account to which you want to allocate the credit transaction.
        /// </param>
        /// <param name="account">
        /// 7-character account number to which you want to allocate the credit transaction.
        /// </param>
        /// <param name="subAccount">Optional</param>
        /// <param name="project">Optional</param>
        /// <param name="giftNotificationId">
        /// Used by gift transactions to direct the generated gift document to a particular person.  
        /// If this value is not passed (or is not valid) then the gift document will be generated 
        /// to the inbox of the person set up as the default on the server. 
        /// This value should be the UCD Login ID of the desired recipient in upper case.
        /// </param>
        /// <param name="allocationValue">
        /// The amount or percent to allocate to this allocation
        /// </param>
        /// <param name="allocationType">
        /// The type of allocation -- either percent or $ amount
        /// </param>
        void AddAllocation(string fid, string chart, string account, string subAccount, string project, string giftNotificationId, double allocationValue, AllocationType allocationType);

        /// <summary>
        /// Get an copy of the allocations to view
        /// </summary>
        IEnumerable<allocRequestTransactionAllocation> GetAllocations();

        /// <summary>
        /// Allocate the transaction using the given service.
        /// </summary>
        /// <param name="allocationService">Service which can allocate transactions</param>
        /// <returns>Result string -- use the service's AllocateResultSuccess method to determine pass/fail</returns>
        string Allocate(ITransactionAllocationService allocationService);
    }
}