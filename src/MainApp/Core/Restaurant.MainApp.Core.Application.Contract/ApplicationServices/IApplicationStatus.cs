namespace Restaurant.MainApp.Core.Application.Contract.ApplicationServices
{
	public interface IApplicationStatus
	{
        
        public  string StatusPending { get; } // "Pending_Payment";
        public  string StatusSubmitted { get; } // "Submitted_PaymentApproved";
        public  string StatusRejected { get; }// "Rejected_Payment";
        public  string StatusInProcess { get; }// "Being Prepared";
        public  string StatusReady { get; }// "Ready for Pickup";
        public  string StatusCompleted { get; }// "Completed";
        public  string StatusCancelled { get; }// "Cancelled";
        public  string StatusRefunded { get; }//"Refunded";
        public  string SessionCart { get; }//"SessionCart";
    }
}
