using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VillaAPI.Models.DTO;
using VillaAPI.Data;
using VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {

        //se crea esta variable y luego se inyecta en el constructor
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;

        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(_db.Villas.ToList());
        }

        [HttpGet("id", Name = "GetVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_db.Villas.FirstOrDefault(v => v.Nombre.ToUpper() == villa.Nombre.ToUpper()) != null)
            {
                ModelState.AddModelError("ElNombreYaExiste", "la villa con ese nombre ya existe");

                return BadRequest(ModelState);
            }

            if (villa == null)
            {
                return BadRequest();
            }
            if (villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa modelo = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Habitantes = villa.Habitantes,
                ImagenUrl = villa.ImagenUrl,
                Fecha = DateTime.Now
            };

            _db.Villas.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = villa.Id, nombre = villa.Nombre });
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.ToList().FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            _db.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villa)
        {

            if (villa == null || id != villa.Id)
            {
                return BadRequest();
            }

            Villa modelo = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Habitantes = villa.Habitantes,
                ImagenUrl = villa.ImagenUrl,
                Acualizacion = DateTime.Now
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult PatchVilla(int id, JsonPatchDocument<VillaDto> jsondoc)
        {

            if (jsondoc == null || id ==0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.AsNoTracking().FirstOrDefault(x => x.Id == id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Habitantes = villa.Habitantes,
                ImagenUrl = villa.ImagenUrl
            };

            if (villa == null)
            {
                return BadRequest();
            }

            jsondoc.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Villa modelo = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Habitantes = villaDto.Habitantes,
                ImagenUrl = villaDto.ImagenUrl,
                Acualizacion = DateTime.Now
            };
             
            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
