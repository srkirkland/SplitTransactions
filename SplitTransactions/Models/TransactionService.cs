﻿using System;
using System.Collections.Generic;
using SplitTransactions.UpaySplitService;

namespace SplitTransactions.Models
{
    public class TransactionAllocationService
    {
        protected List<allocRequestTransactionAllocation> Allocations { get; set; }
        protected allocRequestTransaction Transaction { get; set; }

        /// <summary>
        /// Provide the transactionId and merchantId which correspond to the transaction you wish to 'split'/allocate
        /// </summary>
        /// <param name="transactionId">
        /// This is the unique transaction ID assigned to a transaction within your merchant ID.  
        /// This value is returned to your server via the post-back in the TPG_TRANS_ID variable.
        /// </param>
        /// <param name="merchantId">
        /// This is the merchant ID as known to the TouchNet payment gateway.  You must obtain this 
        /// number from Internal Control.  It is an integer between 0 and 255.  It is NOT your 
        /// UPAY_SITE_ID or any other number that is used during the process.  (Sorry, this is due to 
        /// the data available to the nightly process.)
        /// </param>
        public TransactionAllocationService(string transactionId, int merchantId)
        {
            Transaction = new allocRequestTransaction() {transactionId = transactionId, merchantId = merchantId};

            Allocations = new List<allocRequestTransactionAllocation>();
        }

        public void AddAllocation(string fid, string chart, string account, string subAccount, string project, string giftNotificationId, double allocationValue, AllocationType allocationType)
        {
            var allocation = new allocRequestTransactionAllocation
                                 {
                                     fid = fid,
                                     chart = chart,
                                     account = account,
                                     subAccount = subAccount,
                                     project = project,
                                     giftNotificationId = giftNotificationId
                                 };

            switch (allocationType)
            {
                case AllocationType.Amount:
                    allocation.amount = allocationValue;
                    allocation.amountSpecified = true;
                    break;
                case AllocationType.Percent:
                    allocation.percent = allocationValue;
                    allocation.percentSpecified = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("allocationType");
            }

            //Now we have an allocation, add it to the allocation collection
            Allocations.Add(allocation);
        }

        public enum AllocationType
        {
            Amount,
            Percent
        }
    }
}