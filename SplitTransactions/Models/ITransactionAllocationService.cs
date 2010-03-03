using SplitTransactions.UpaySplitService;

namespace SplitTransactions.Models
{
    public interface ITransactionAllocationService
    {
        /// <summary>
        /// Allocation service from UPay
        /// </summary>
        /// <param name="requestTransactions">
        /// This element forms the body of the request.  It can contain one or more transaction elements.  
        /// Each of those can contain one or more allocation elements.
        /// </param>
        /// <returns>
        /// This is the response element.  It will contain a string representing the results of the allocation request.
        /// This will be the string "OK" if the process succeeded.  Otherwise, it will contain a list of error messages.
        /// Allocation records are *only* applied if all lines validate properly.
        /// </returns>
        string Allocate(allocRequestTransaction[] requestTransactions);

        /// <summary>
        /// Determines if the allocate result string represents a success or failure
        /// </summary>
        /// <param name="allocateResult">
        /// The alloc result returned from the call to alloc().
        /// </param>
        /// <returns>
        /// true if the result equals the success string
        /// </returns>
        bool AllocateResultSuccess(string allocateResult);
    }
}