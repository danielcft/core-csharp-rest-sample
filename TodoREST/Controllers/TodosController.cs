using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoREST.Data;
using TodoREST.Models;

namespace TodoREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
      private readonly AppDbContext _db;
      public TodosController(AppDbContext db)
      {
        _db = db;
      }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
          return JsonConvert.SerializeObject(_db.Todo);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
          return JsonConvert.SerializeObject(_db.Todo.Find(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Todo todo)
        {
          _db.Todo.Add(todo);
          _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          var toRemove = _db.Todo.First(t=>t.Id==id);
          _db.Todo.Remove(toRemove);
          _db.SaveChanges();
    }
  }
}
