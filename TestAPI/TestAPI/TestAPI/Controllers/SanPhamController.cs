using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SanPhamController : Controller
    {
        QLBHContext da = new QLBHContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("them")]
        public IActionResult Them()
        {
            return Ok("Đúng");
        }

        [Authorize]
        [HttpPost("addproduct")]
        public IActionResult AddProduct([FromBody] SanPham product)
        {
            if (string.IsNullOrEmpty(product.TenSp) || product.GiaMua <= 0)
            {
                return BadRequest("Thiếu thông tin sản phẩm!");
            }
            //Xu ly them
            return Ok(new { message = "Sản phẩm đã được thêm!", product });
        }

        [Authorize(Roles = "Admin,NV")]
        [HttpPost("list")]
        public IActionResult List()
        {
            var products = da.SanPhams.ToList();
            

            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("themSP")]
        public IActionResult ThemSP([FromBody] SanPham product)
        {
            
            if (string.IsNullOrEmpty(product.TenSp) || product.GiaMua <= 0)
            {
                return BadRequest("Thiếu thông tin sản phẩm!");
            }
            //Xu ly them
            da.SanPhams.Add(product);
            da.SaveChanges();
            return Ok(new { message = "Sản phẩm đã được thêm!", product });
        }
    }
}
