using API.IServices;
using API.Services;
using MCV.Models;
using MCV.Models.DBnhom6;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeDetailController : ControllerBase
    {
        private readonly IAllServices<ShoeDetail> services;
        DbSet<ShoeDetail> dbSet;
        DBnhom6TT context = new DBnhom6TT();
        public ShoeDetailController()
        {
            dbSet = context.ShoeDetail;
            AllServices<ShoeDetail> all = new AllServices<ShoeDetail>(context, dbSet);
            services = all;
        }
        [HttpGet]
        public List<ShoeDetail> Get()
        {
            return services.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ShoeDetail Get(Guid id)
        {
            return services.GetAll().FirstOrDefault(x => x.id == id);
        }

        [HttpPost]
        public bool Post(ShoeDetail obj)
        {
            ShoeDetail shDetail = new ShoeDetail();
            shDetail.id = obj.id;
            shDetail.ShoeId = obj.ShoeId;
            shDetail.SizeId = obj.SizeId; 
            shDetail.BrandId = obj.BrandId; 
            shDetail.CategoryId = obj.CategoryId; 
            shDetail.ColorId = obj.ColorId; 
            shDetail.Code = obj.Code; 
            shDetail.PriceInput = obj.PriceInput; 
            shDetail.PriceOutput = obj.PriceOutput;
            shDetail.Quantity = obj.Quantity;
            shDetail.Status = obj.Status;
            return services.Add(shDetail);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(ShoeDetail obj)
        {
            ShoeDetail shDetail = services.GetAll().FirstOrDefault(x => x.id == obj.id);
            shDetail.ShoeId = obj.ShoeId;
            shDetail.SizeId = obj.SizeId;
            shDetail.BrandId = obj.BrandId;
            shDetail.CategoryId = obj.CategoryId;
            shDetail.ColorId = obj.ColorId;
            shDetail.Code = obj.Code;
            shDetail.PriceInput = obj.PriceInput;
            shDetail.PriceOutput = obj.PriceOutput;
            shDetail.Quantity = obj.Quantity;
            shDetail.Status = obj.Status;
            return services.Update(shDetail);
        }
        // DELETE api/< PaymentMethodController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var sv = services.GetAll().FirstOrDefault(x => x.id == id);
            return services.Delete(sv);
        }
    }
}
