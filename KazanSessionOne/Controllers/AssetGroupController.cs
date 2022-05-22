using KazanSessionOne.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KazanSessionOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetGroupController : Controller
    {
        Session1Context db=new Session1Context();

        [Authorize]
        [HttpGet]
        public IEnumerable<AssetGroup> GET()
        {
            List < AssetGroup > assetgroups= db.AssetGroups.ToList();
            assetgroups.Insert(0, new AssetGroup { Id = 0, Name = "Asset Group" });
            return assetgroups;
        }

        //Auth endpoint to get token
        [HttpPost("/auth")]
        public String GetToken(String email)
        {
            if (email == "admin")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("this is a secrity token for authentication");
                var description = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name,email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

                };
                var token=tokenHandler.CreateToken(description);
                return tokenHandler.WriteToken(token);
            }
            return "error";
        }









     /*   [HttpGet("{id:int}")]
        public AssetGroup GETSingle(int id)
        {
            
            return db.AssetGroups.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public AssetGroup POST(int id)
        {
            return db.AssetGroups.Where(x => x.Id == id).FirstOrDefault();

        }*/

        [HttpPost("/create")]
        public String CREATE(String assetGroupName)
        {
            AssetGroup assetGroup = new AssetGroup();
            assetGroup.Name=assetGroupName;
            db.AssetGroups.Add(assetGroup);
            db.SaveChanges();
            return "success";
        }

        [HttpGet("/search")]
        public IEnumerable<Asset> Search(int department,int assetgroup, DateTime start, DateTime end)
        {
            return db.Assets.Where(x => (x.DepartmentLocationId == department ||x.DepartmentLocationId!=0)
            && (x.AssetGroupId == assetgroup || x.AssetGroupId!=0)
           ).ToList();
        }

    }
}
