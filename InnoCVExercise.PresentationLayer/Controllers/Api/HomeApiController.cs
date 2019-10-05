using AutoMapper;
using InnoCVExercise.DomainLayer;
using InnoCVExercise.DomainLayer.DTOs;
using InnoCVExercise.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InnoCVExercise.PresentationLayer.Controllers.Api
{
    [Route("api/[controller]")]
    public class HomeApiController : BaseApiController
    {
        public HomeApiController(Manager manager, IMapper mapper)
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
            return Mapper.Map<UserModel>(Manager.UserService.GetById(id));
        }

        [HttpPost]
        public void AddUser([FromBody]UserModel user)
        {
            if (ModelState.IsValid)
                Manager.UserService.Add(Mapper.Map<UserDTO>(user));
        }
        
        [HttpPut]
        public void Put([FromBody]UserModel user)
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
