using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StanteonApi.Models;
using StanteonApi.Models.Users;

namespace StanteonApi.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class CreatorsController : ControllerBase
{
    private readonly StanteonContext _context;

    public CreatorsController(StanteonContext context)
    {
        _context = context;
    }

    // GET: api/Creators
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Creator>>> GetCreators()
    {
        if (_context.Creators == null)
        {
            return NotFound();
        }
        return await _context.Creators.ToListAsync();
    }

    // GET: api/Creators/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Creator>> GetCreator(long id)
    {
        if (_context.Creators == null)
        {
            return NotFound();
        }
        var user = await _context.Creators.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/Creators/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCreator(long id, Creator user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CreatorExists(id))
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

    // POST: api/Creators
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Creator>> PostCreator(Creator user)
    {
        if (_context.Creators == null)
        {
            return Problem("Entity set 'StanteonContext.Creators'  is null.");
        }
        _context.Creators.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCreator", new { id = user.UserId }, user);
    }

    // DELETE: api/Creators/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCreator(long id)
    {
        if (_context.Creators == null)
        {
            return NotFound();
        }
        var user = await _context.Creators.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Creators.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CreatorExists(long id)
    {
        return (_context.Creators?.Any(e => e.UserId == id)).GetValueOrDefault();
    }
}