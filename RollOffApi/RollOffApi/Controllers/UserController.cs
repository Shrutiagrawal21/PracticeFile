using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RollOffApi.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace RollOffApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RollOffProjectContext _authContext;
        
        public UserController(RollOffProjectContext ourExcelData)
        {
            _authContext = ourExcelData;   
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<IEnumerable<User>> GetUsers() {
            try {
                return await _authContext.Users.ToListAsync();
            }
            catch(Exception e)
            {
                return (IEnumerable<User>)BadRequest("Something went wrong" + e);
            }


     }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authentication([FromBody] User usertable)
        {
            try
            {

                if (usertable == null)
                    return BadRequest();
                var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == usertable.UserName && x.Password == usertable.Password);
                if (user == null)
                    return NotFound(new { Message = "User Not Found" });

                user.Token = CreateJwtToken(user);
                return Ok(new
                {
                    Token = user.Token,
                    Message = "Login Success!"
                });

            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
}
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User usertable)
        {
            try {
                if (usertable == null)
                    return BadRequest();
                await _authContext.Users.AddAsync(usertable);
                await _authContext.SaveChangesAsync();
                return Ok(new
                {
                    Message = "User Registered!"
                });
            }
            catch(Exception e)
            {
                return BadRequest("something went wrong" + e);
            }
          }

        private string CreateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("verysecretefsagddsdfafdafsa");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, $"{user.Role}"),
                 new Claim(ClaimTypes.Name, $"{user.FirstName}{user.LastName}")


            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescripter);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}

