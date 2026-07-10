using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Domain.Core;
using programacion2proyecto.Infraestructure.Contex;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        public readonly DataContext _context;
        public readonly IMapper Mapper;
        public BaseController(DataContext context, IMapper mapper)
        {
            _context = context;
            Mapper = mapper;
        }

    }
}

