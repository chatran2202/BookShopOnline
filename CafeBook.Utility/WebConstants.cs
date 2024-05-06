using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBook.Utility
{
	public static class WebConstants
	{
        //User = Người dùng có tài khoản, có thể đặt hàng
		public const string Role_User = "User";
        //Company = User có thể thanh toán trong vòng 30 ngày
        public const string Role_Company = "Company";
        //Admin = Người quản trị mọi tác vụ
        public const string Role_Admin = "Admin";
        //Employee = Người có quyền truy cập, sửa đổi product và detail
        public const string Role_Employee = "Employee";

        public const string StatusPending = "Pending";
		public const string StatusApproved = "Approved";
		public const string StatusInProcess = "Processing";
		public const string StatusShipped = "Shipped";
		public const string StatusCancelled = "Cancelled";
		public const string StatusRefunded = "Refunded";

		public const string PaymentStatusPending = "Pending";
		public const string PaymentStatusApproved = "Approveed";
		public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
		public const string PaymentStatusRejected = "Rejected";
	}
}
