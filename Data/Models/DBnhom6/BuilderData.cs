using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCV.Models;

namespace Data.Models.DBnhom6
{
    public static class BuilderData
    {
        public static void Send(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>().HasData(
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-SuperRep-Cycle-2", Status = true, avata = "Nike_Nike-SuperRep-Cycle-2-Next-Nature_Cam(3).webp", PriceInput=120,PriceOutput=150,Code="001"},
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-Winflo-9", Status = true, avata = "Nike_Nike-Winflo-9_TrangCam(3).webp", PriceInput = 130, PriceOutput = 155, Code = "002" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-Zegama", Status = true, avata = "Nike_Nike-Zegama_Den(3).webp", PriceInput = 125, PriceOutput = 140, Code = "003" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-React-Infinity-3", Status = true, avata = "Nike_Nike-React-Infinity-3-Premium_BayMau(3).webp", PriceInput = 120, PriceOutput = 151, Code = "004" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-Pegasus-Turbo", Status = true, avata = "Nike_Nike-Pegasus-Turbo_Do(3).webp", PriceInput = 150, PriceOutput = 170, Code = "005" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-Metcon-8-Premium_Bac", Status = true ,avata = "Nike_Nike-Metcon-8-Premium_Bac(3).webp", PriceInput = 120, PriceOutput = 150, Code = "006" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-Metcon-8-MF_DoDen", Status = true, avata = "Nike_Nike-Metcon-8-MF_DoDen(3).webp", PriceInput = 120, PriceOutput = 148, Code = "007" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-Metcon-8-AMP_VangXam", Status = true, avata = "Nike_Nike-Metcon-8-AMP_VangXam(3).webp", PriceInput = 120, PriceOutput = 133, Code = "008" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Nike-Metcon-8_Xanh", Status = true, avata = "Nike_Nike-Metcon-8_Xanh(3).webp", PriceInput = 120, PriceOutput = 143, Code = "009" },
                new Shoe() { id = Guid.NewGuid(), name = "Nike_Ja-1-Hunger-EP_XanhDo", Status = true, avata = "Nike_Ja-1-Hunger-EP_XanhDo(3).webp", PriceInput = 120, PriceOutput = 160, Code = "010" }
            );
            modelBuilder.Entity<Size>().HasData(
                new Size() { id = Guid.NewGuid(), name = "34", Status = true },
                new Size() { id = Guid.NewGuid(), name = "35", Status = true },
                new Size() { id = Guid.NewGuid(), name = "36", Status = true },
                new Size() { id = Guid.NewGuid(), name = "37", Status = true },
                new Size() { id = Guid.NewGuid(), name = "38", Status = true },
                new Size() { id = Guid.NewGuid(), name = "39", Status = true },
                new Size() { id = Guid.NewGuid(), name = "40", Status = true },
                new Size() { id = Guid.NewGuid(), name = "41", Status = true },
                new Size() { id = Guid.NewGuid(), name = "42", Status = true },
                new Size() { id = Guid.NewGuid(), name = "43", Status = true }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { id = Guid.NewGuid(), name = "Đế thấp", Status = true },
                new Category() { id = Guid.NewGuid(), name = "Đế vừa", Status = true },
                new Category() { id = Guid.NewGuid(), name = "Đế cao", Status = true }
            );
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { id = Guid.NewGuid(), name = "Adidas", Status = true },
                new Brand() { id = Guid.NewGuid(), name = "Nike", Status = true }
            );
            modelBuilder.Entity<Color>().HasData(
                new Color() { id = Guid.NewGuid(), name = "Trắng", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Vàng xanh", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Xanh đen", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Đỏ đen", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Đỏ", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Cam", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Vàng", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Xanh Lục", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Xanh Lục Đậm", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Tràm", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Tím", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Trắng cam", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Tráng Hồng", Status = true },
                new Color() { id = Guid.NewGuid(), name = "Đen", Status = true }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role() { id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214414"), name = "QuanLy", Status = true },
                new Role() { id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214415"), name = "NhanVien", Status = true },
                new Role() { id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214416"), name = "KhachHang", Status = true }
            );
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod() { id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214417"), Method = "Thanh toán khi nhận hàng", Status = true, Note = "" },
                new PaymentMethod() { id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214418"), Method = "Thanh toán qua VNpay", Status = true, Note = "" },
                new PaymentMethod() { id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214419"), Method = "Thanh toán tại cửa hàng", Status = true, Note = "" },
            new PaymentMethod() { id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214420"), Method = "Thanh toán qua chuyển khoảng", Status = true, Note = "" }
            );

        }
    }
}
