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
        public bool Post(Guid shoeId,Guid sizeID,Guid brandID,Guid categoryId,Guid colorId,
            string code, int priceInput, int priceOutput, int quantity, bool status)
        {
            ShoeDetail shDetail = new ShoeDetail();
            shDetail.id = Guid.NewGuid();
            shDetail.ShoeId = shoeId;
            shDetail.SizeId = sizeID; 
            shDetail.BrandId = brandID; 
            shDetail.CategoryId = categoryId; 
            shDetail.ColorId = colorId; 
            shDetail.Code = code; 
            shDetail.PriceInput = priceInput; 
            shDetail.PriceOutput = priceOutput;
            shDetail.Quantity = quantity;
            shDetail.Status = status;
            return services.Add(shDetail);
        }
        // PUT api/< PaymentMethodController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid shoeId, Guid sizeID, Guid brandID, Guid categoryId, Guid colorId,
            string code, int priceInput, int priceOutput, int quantity, bool status)
        {
            var shDetail = services.GetAll().FirstOrDefault(x => x.id == id);
            if (shDetail != null)
            {
                shDetail.ShoeId = shoeId;
                shDetail.SizeId = sizeID;
                shDetail.BrandId = brandID;
                shDetail.CategoryId = categoryId;
                shDetail.ColorId = colorId;
                shDetail.Code = code;
                shDetail.PriceInput = priceInput;
                shDetail.PriceOutput = priceOutput;
                shDetail.Quantity = quantity;
                shDetail.Status = status;
                return services.Update(shDetail);
            }
            return false;
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
