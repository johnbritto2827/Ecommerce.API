
namespace ECommerce.Common
{
    public class Constant
    {
    }

    public class StroredProc
    {
        public const string GetProduct = "Sp_ProductInfo";
        public const string GetOrder = "Sp_OrderInfo";
        //public const string SP_Email = "Sp_EmailInfo";

        public const string UserDetails = "[ecom].[usp_UserInfo]";
        public const string ProductDetails = "[ecom].[usp_ProductDetails]";
        public const string VendorDetails = "[ecom].[usp_VendorDetails]";

    }
}