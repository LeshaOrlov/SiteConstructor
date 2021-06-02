using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteConstructor.WebApp.Models;

namespace SiteConstructor.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly TestContext _context;

        public TestApiController(TestContext context)
        {
            _context = context;
        }

        // GET: api/TestApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestEntity2>>> Get()
        {
            return await _context.TestEntities2.ToListAsync();
        }

        // GET: api/TestApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestEntity2>> Get(int id)
        {
            var testEntity2 = await _context.TestEntities2.FindAsync(id);

            if (testEntity2 == null)
            {
                return NotFound();
            }

            return testEntity2;
        }

        // PUT: api/TestApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TestEntity2 testEntity2)
        {
            if (id != testEntity2.Id)
            {
                return BadRequest();
            }

            _context.Entry(testEntity2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestEntity2Exists(id))
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

        // POST: api/TestApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestEntity2>> Post(TestEntity2 testEntity2)
        {
            _context.TestEntities2.Add(testEntity2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestEntity2", new { id = testEntity2.Id }, testEntity2);
        }

        // DELETE: api/TestApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestEntity2>> DeleteTestEntity2(int id)
        {
            var testEntity2 = await _context.TestEntities2.FindAsync(id);
            if (testEntity2 == null)
            {
                return NotFound();
            }

            _context.TestEntities2.Remove(testEntity2);
            await _context.SaveChangesAsync();

            return testEntity2;
        }

        private bool TestEntity2Exists(int id)
        {
            return _context.TestEntities2.Any(e => e.Id == id);
        }
    }
}
