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
    public class AuthController : ControllerBase
    {
        
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] TaiKhoan loginModel)
        {
            //// Kiểm tra thông tin đăng nhập 
            //if (loginModel.TenDn == "admin" && loginModel.MatKhau == "password123")
            //{
            //    var token = _authService.GenerateJwtToken(loginModel.TenDn);
            //    return Ok(new { Token = token });
            //}



            // Giả định xác thực tài khoản với vai trò Admin hoặc NV
            if (loginModel.TenDn == "admin" && loginModel.MatKhau == "password123")
            {
                var token = _authService.GenerateJwtToken(loginModel.TenDn, "Admin");
                return Ok(new { token });
            }
            else if (loginModel.TenDn == "NV" && loginModel.MatKhau == "123")
            {
                var token = _authService.GenerateJwtToken(loginModel.TenDn, "NV");
                return Ok(new { token });
            }
            // Nếu sai, trả về lỗi
            return Unauthorized(new { Message = "Invalid credentials" });
        }

        [HttpPost("CheckToken")]

        public IActionResult CheckToken([FromBody] TaiKhoan loginModel)
        {

            return Unauthorized(new { Message = "Invalid credentials" });
        }
    }
}
