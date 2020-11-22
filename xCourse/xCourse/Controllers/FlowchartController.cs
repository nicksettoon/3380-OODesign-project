using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xCourse.Entities;
using xCourse.Models;

namespace xCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowchartController : ControllerBase
    {
        private readonly FlowchartContext _context;

        public FlowchartController(FlowchartContext context)
        {
            _context = context;
        }

        // GET: api/Flowchart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlowchartModel>>> GetFlowchartModel()
        {
            return await _context.FlowchartModel.ToListAsync();
        }

        // GET: api/Flowchart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlowchartModel>> GetFlowchartModel(string id)
        {
            var flowchartModel = await _context.FlowchartModel.FindAsync(id);

            if (flowchartModel == null)
            {
                return NotFound();
            }



            return Ok(flowchartModel);
        }

        // PUT: api/Flowchart/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlowchartModel(string id, FlowchartModel flowchartModel)
        {
            if (id != flowchartModel.CourseCodeAbbriviation)
            {
                return BadRequest();
            }

            _context.Entry(flowchartModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowchartModelExists(id))
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

        // POST: api/Flowchart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FlowchartModel>> PostFlowchartModel(FlowchartModel flowchartModel)
        {
            _context.FlowchartModel.Add(flowchartModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlowchartModelExists(flowchartModel.CourseCodeAbbriviation))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlowchartModel", new { id = flowchartModel.CourseCodeAbbriviation }, flowchartModel);
        }

        // DELETE: api/Flowchart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FlowchartModel>> DeleteFlowchartModel(string id)
        {
            var flowchartModel = await _context.FlowchartModel.FindAsync(id);
            if (flowchartModel == null)
            {
                return NotFound();
            }

            _context.FlowchartModel.Remove(flowchartModel);
            await _context.SaveChangesAsync();

            return flowchartModel;
        }

        private bool FlowchartModelExists(string id)
        {
            return _context.FlowchartModel.Any(e => e.CourseCodeAbbriviation == id);
        }
    }
}
