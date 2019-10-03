using AutoMapper;
using InnoCVExercise.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoCVExercise.Service
{
    public class BaseService
    {
        protected Context _context;
        protected readonly IMapper _mapper;

        public BaseService(Context context, IMapper mapper)
        {

        }
    }
}
