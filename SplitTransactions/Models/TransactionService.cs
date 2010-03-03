namespace SplitTransactions
{
    public class TransactionService
    {

        public TransactionService()
        {
            var client = new UpaySplitService.AllocClient();
        }
    }
}