using AutoMapper;
using InnoCVExercise.DomainLayer;
using InnoCVExercise.DomainLayer.DTOs;
using InnoCVExercise.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InnoCVExercise.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(Manager manager, IMapper mapper) : base(manager, mapper)
        {
        }

        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers()
        {
            var models = Manager.UserService.GetAll().Select(x => Mapper.Map<UserModel>(x));
            if (models == null)
                return NoContent();            
            return Ok(models.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUser(int id)
        {
            var model = Mapper.Map<UserModel>(Manager.UserService.GetById(id));
            if (model == null)
                return NoContent();
            return Ok(model);
        }

        [HttpPost]
        public ActionResult AddUser([FromBody]UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manager.UserService.Add(Mapper.Map<UserDTO>(user));
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody]UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manager.UserService.Update(Mapper.Map<UserDTO>(user));
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            Manager.UserService.Delete(id);
            return Ok();
        }
    }
}
