using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPI : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CouponAPI(AppDbContext db, IMapper mapper) 
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try { 
                IEnumerable<Coupon> objList = _db.Coupons.ToList();

                _response.Result = _mapper.Map<IList<CouponDto>>(objList); ;
              
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message.ToString();
            }

            return _response;
        
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon objList = _db.Coupons.First(u=>u.CouponId==id);
                _response.Result = _mapper.Map<CouponDto>(objList);
                            
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message.ToString();
            }

            return _response;

        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto Get(string code)
        {
            try
            {
                Coupon objList = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(objList);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message.ToString();
            }

            return _response;

        }

        [HttpPost]        
        public ResponseDto Post([FromBody] CouponDto coupnDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(coupnDto);

                _db.Coupons.Add(obj);

                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message.ToString();
            }

            return _response;

        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto coupnDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(coupnDto);

                _db.Coupons.Update(obj);

                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message.ToString();
            }

            return _response;

        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {

                Coupon obj = _db.Coupons.First(u => u.CouponId == id);

                _db.Coupons.Remove(obj);

                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message.ToString();
            }

            return _response;

        }

    }
}
