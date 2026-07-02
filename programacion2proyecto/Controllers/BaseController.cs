using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Data;
using programacion2proyecto.Models.Entities;

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
        [HttpGet]
        public virtual ActionResult<List<T>> GetAll()
            => Ok(_context.Set<T>().ToList());

        [HttpGet("{id}")]
        public virtual ActionResult<T> GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public virtual ActionResult Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null) return NotFound();
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
