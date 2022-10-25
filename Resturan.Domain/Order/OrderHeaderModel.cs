using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Base;
using Resturan.Domain.OrderDetail;

namespace Resturan.Domain.Order
{
    public class OrderHeaderModel:BaseModel
    {
        public string Email { get; private set; }
        public string PickupName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Comments { get; private set; }
        public float OrderTotal { get; private set; }
        public string Status { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime PickupTime { get; private set; }
        public DateTime PickupDate { get; private set; }
        public ICollection<OrderDetailModel> OrderDetail { get; private set; }

        public OrderHeaderModel(string email, string pickupName, string phoneNumber, string comments, float orderTotal, string status, DateTime pickupTime, DateTime pickupDate)
        {
            Email = email;
            PickupName = pickupName;
            PhoneNumber = phoneNumber;
            Comments = comments;
            OrderTotal = orderTotal;
            Status = status;
            OrderDate = DateTime.Now;
            PickupTime = pickupTime;
            PickupDate = pickupDate;
        }
    }
}
