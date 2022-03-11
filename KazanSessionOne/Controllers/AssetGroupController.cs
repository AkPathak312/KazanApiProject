using KazanSessionOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace KazanSessionOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetGroupController : Controller
    {
        Session1Context db=new Session1Context();
        [HttpGet]
        public IEnumerable<AssetGroup> GET()
        {
            List < AssetGroup > assetgroups= db.AssetGroups.ToList();
            assetgroups.Insert(0, new AssetGroup { Id = 0, Name = "Asset Group" });
            return assetgroups;
        }

        [HttpGet("{id:int}")]
        public AssetGroup GETSingle(int id)
        {
            
            return db.AssetGroups.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public AssetGroup POST(int id)
        {
            return db.AssetGroups.Where(x => x.Id == id).FirstOrDefault();

        }

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
