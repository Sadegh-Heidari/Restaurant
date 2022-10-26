using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.ApplicationServices;

namespace Resturan.Application
{
	public class ApplicationStatus:IApplicationStatus
	{
        public ApplicationStatus()
        {
            StatusPending = "Pending_Payment";
            StatusSubmitted = "Submitted_PaymentApproved";
            StatusRejected = "Rejected_Payment";
            StatusInProcess = "Being Prepared";
            StatusReady = "Ready for Pickup";
            StatusCompleted = "Completed";
            StatusCancelled = "Cancelled";
            StatusRefunded = "Refunded";
            SessionCart = "SessionCart";
        }

        public string StatusPending { get; }
        public string StatusSubmitted { get; }
        public string StatusRejected { get; }
        public string StatusInProcess { get; }
        public string StatusReady { get; }
        public string StatusCompleted { get; }
        public string StatusCancelled { get; }
        public string StatusRefunded { get; }
        public string SessionCart { get; }
    }
}
