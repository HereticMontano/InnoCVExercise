using InnoCVExercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InnoCVExercise.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IEnumerable<UserModel> GetUser()
        {
            return null;
        }          

        
        [HttpPost]
        public void AddUser([FromBody]UserModel value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UserModel value)
        {
        }
        
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}
