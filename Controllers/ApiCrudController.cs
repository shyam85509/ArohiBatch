using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCrudController : ControllerBase
    {
        public readonly DatabaseContext _context;

        public ApiCrudController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("getAllData")]
        [HttpGet]
        public ActionResult <IEnumerable<Tbl_Demo>> GetAllData()
        {
            var res = (from s in _context.Tbl_Demo select s).ToList();
            return res;
        }
        [Route("GetDataByGender")]
        [HttpGet]
        public IEnumerable<Tbl_Demo> GetDataByGender(string gender)
        {
            var res = from s in _context.Tbl_Demo where s.Gender == gender select s;
            return res;
        }

        [Route("GetDataId")]
        [HttpGet]
        public IEnumerable<Tbl_Demo> GetDataId(int Id)
        {
            var res = from s in _context.Tbl_Demo where s.Id == Id select s;
            return res;
        }

        [Route("login")]
        [HttpGet]
        public IEnumerable<Tbl_Demo> login(string Email, string Password)
        {
            var res = from s in _context.Tbl_Demo where s.Email == Email && s.Password == Password select s;
            return res;
        }

        [Route("Insert")]
        [HttpPost]
        public ActionResult<Tbl_Demo> Insert(Tbl_Demo obj)
        {
            if(obj == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Add(obj);
                _context.SaveChanges();
                return CreatedAtAction("getAllData", new {id=obj.Id, obj});
            }
        }

        [Route("Update")]
        [HttpPut]
        public bool Update(Tbl_Demo obj)
        {
            if(obj.Id == null)
            {
                return false;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(obj).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
            }
            return true;
        }

        [HttpDelete]
        [Route("DeleteData")]

        public int Delete(int id)
        {
            if(id == 0)
            {
                return 0;
            }
            else
            {
                var res = _context.Tbl_Demo.Find(id);
                _context.Remove(res);
                _context.SaveChanges();
                return 1;
            }
        }

        [HttpGet]
        [Route("Detials")]

        public Tbl_Demo Detials(int id)
        {
            Tbl_Demo obj = new Tbl_Demo();
            obj = _context.Tbl_Demo.Find(id);
            return obj;
        }

    }
}














