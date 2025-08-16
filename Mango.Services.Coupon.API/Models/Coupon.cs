namespace Mango.Services.Coupon.API.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount {  get; set; }
        public int MinAmount { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
