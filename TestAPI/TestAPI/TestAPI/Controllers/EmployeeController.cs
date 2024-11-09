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
    public class EmployeeController : Controller
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
        [HttpPost("addemployee")]
        public IActionResult AddEmployee([FromBody] NhanVien nhanvien)
        {
            if (string.IsNullOrEmpty(nhanvien.TenNv))
            {
                return BadRequest("Thiếu thông tin nhân viên!");
            }
            //Xu ly them
            return Ok(new { message = "Đã thêm mới nhân viên", nhanvien });
        }

        [Authorize(Roles = "Admin,NV")]
        [HttpPost("list")]
        public IActionResult List()
        {
            var employees = da.NhanViens.ToList();


            return Ok(employees);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("themNV")]
        public IActionResult ThemNV([FromBody] NhanVien nhanvien)
        {

            if (string.IsNullOrEmpty(nhanvien.TenNv))
            {
                return BadRequest("Thiếu thông tin nhân viên!");
            }
            //Xu ly them
            da.NhanViens.Add(nhanvien);
            da.SaveChanges();
            return Ok(new { message = "Nhân viên đã được thêm!", nhanvien });
        }
    }
}
