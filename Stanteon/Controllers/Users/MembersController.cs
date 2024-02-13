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
public class MembersController : ControllerBase
{
    private readonly StanteonContext _context;

    public MembersController(StanteonContext context)
    {
        _context = context;
    }

    // GET: api/Members
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
    {
        if (_context.Members == null)
        {
            return NotFound();
        }
        return await _context.Members.ToListAsync();
    }

    // GET: api/Members/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Member>> GetMember(long id)
    {
        if (_context.Members == null)
        {
            return NotFound();
        }
        var user = await _context.Members.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/Members/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMember(long id, Member user)
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
            if (!MemberExists(id))
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

    // POST: api/Members
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Member>> PostMember(Member user)
    {
        if (_context.Members == null)
        {
            return Problem("Entity set 'StanteonContext.Members'  is null.");
        }
        _context.Members.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMember", new { id = user.UserId }, user);
    }

    // DELETE: api/Members/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(long id)
    {
        if (_context.Members == null)
        {
            return NotFound();
        }
        var user = await _context.Members.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Members.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MemberExists(long id)
    {
        return (_context.Members?.Any(e => e.UserId == id)).GetValueOrDefault();
    }
}
