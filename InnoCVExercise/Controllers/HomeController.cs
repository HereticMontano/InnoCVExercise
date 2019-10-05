using AutoMapper;
using InnoCVExercise.Models;
using InnoCVExercise.Service;
using InnoCVExercise.Service.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InnoCVExercise.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private Manager Manager { get; set; }

        private IMapper Mapper { get; set; }
        public HomeController(Manager manager, IMapper mapper)
        {
            Manager = manager;
            Mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUsers()
        {
            Manager.UserService.Add(new UserDTO { Name = "manuel" });
            return Manager.UserService.GetAll().Select(x => Mapper.Map<UserModel>(x));
        }

        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            return Mapper.Map<UserModel>(Manager.UserService.GetById(id)) ;
        }



        [HttpPost]
        public void AddUser([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
                Manager.UserService.Add(Mapper.Map<UserDTO>(user));
        }
        
        [HttpPut]
        public void Put([FromBody]UserModel value)
        {
        }
        
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}
