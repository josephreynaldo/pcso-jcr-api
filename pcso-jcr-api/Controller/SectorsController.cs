
using pcso_jcr_api.Data;
using pcso_jcr_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//created by : Jeremiah R. Peralta
//2022-04-07

namespace ERMSDMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly DataContext _context;

        public SectorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Sectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetSectors()
        {
            return await _context.Sectors.ToListAsync();
        }

        // GET: api/Sectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(int id)
        {
            var sectorList = await _context.Sectors.FindAsync(id);

            if (sectorList == null)
            {
                return NotFound();
            }

            return sectorList;
        }

        // PUT: api/Sectors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectors(int id, Sector sectors)
        {
            //  if (id != productList.id)
            //  {
            //      return BadRequest();
            //  }
            sectors.id = id;

            _context.Entry(sectors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sectorListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sectors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSector(Sector sector)
        {
            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSector", new { id = sector.id }, sector);
        }

        // DELETE: api/Sectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            var sectorList = await _context.Sectors.FindAsync(id);
            if (sectorList == null)
            {
                return NotFound();
            }

            _context.Sectors.Remove(sectorList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool sectorListExists(int id)
        {
            return _context.Sectors.Any(e => e.id == id);
        }
    }
}
