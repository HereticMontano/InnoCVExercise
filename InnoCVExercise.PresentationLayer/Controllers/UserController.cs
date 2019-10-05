using AutoMapper;
using InnoCVExercise.DomainLayer;
using InnoCVExercise.DomainLayer.DTOs;
using InnoCVExercise.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InnoCVExercise.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(Manager manager, IMapper mapper)
        {
            Manager = manager;
            Mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUsers()
        {            
            return Manager.UserService.GetAll().Select(x => Mapper.Map<UserModel>(x));
        }

        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            return Mapper.Map<UserModel>(Manager.UserService.GetById(id));
        }

        [HttpPost]
        public void AddUser([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
                Manager.UserService.Add(Mapper.Map<UserDTO>(user));
        }
        
        [HttpPut]
        public void UpdateUser([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
                Manager.UserService.Update(Mapper.Map<UserDTO>(user));
        }
        
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            Manager.UserService.Delete(id);
        }
    }
}
