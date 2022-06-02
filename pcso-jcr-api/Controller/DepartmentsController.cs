
using pcso_jcr_api.Data;
using pcso_jcr_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//created by : Jeremiah R. Peralta
//2022-01-06

namespace DASHBOARD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var departmentList = await _context.Departments.FindAsync(id);

            if (departmentList == null)
            {
                return NotFound();
            }

            return departmentList;
        }
        //get departmentid

        [HttpGet("Department/{sectorID}")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsBysectorID(int sectorID)
        {
            return await _context.Departments.Where(s => s.sectorID == sectorID).ToListAsync();
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartments(int id, Department departments)
        {
            //  if (id != productList.id)
            //  {
            //      return BadRequest();
            //  }
            departments.id = id;

            _context.Entry(departments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!departmentListExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var departmentList = await _context.Departments.FindAsync(id);
            if (departmentList == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(departmentList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool departmentListExists(int id)
        {
            return _context.Departments.Any(e => e.id == id);
        }
    }
}
