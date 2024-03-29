﻿using AutoMapper;
using InnoCVExercise.DomainLayer;
using Microsoft.AspNetCore.Mvc;

namespace InnoCVExercise.PresentationLayer.Controllers
{
    public class BaseController : Controller
    {
        protected Manager Manager { get; set; }
        protected IMapper Mapper { get; set; }

        public BaseController(Manager manager, IMapper mapper)
        {
            Manager = manager;
            Mapper = mapper;
        }
    }
}
