using Mango.Services.Coupon.API.Data;
using Microsoft.AspNetCore.Mvc;
using Mango.Services.Coupon.API.Models;

namespace Mango.Services.Coupon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPI : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponAPI(AppDbContext db) 
        {
            _db = db;
        }

        [HttpGet]
        public object Get()
        {
            try { 
                IEnumerable<API.Models.Coupon> objList = _db.Coupons.ToList();
                return objList;
            }
            catch(Exception ex)
            {
            
            }

            return null;
        
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                API.Models.Coupon objList = _db.Coupons.FirstOrDefault(u=>u.CouponId==id);
                return objList;
            }
            catch (Exception ex)
            {

            }

            return null;

        }

    }
}
