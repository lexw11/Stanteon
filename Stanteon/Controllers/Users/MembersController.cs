using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StantreonApi.Dtos.Users;
using StantreonApi.Models;
using StantreonApi.Models.Users;

namespace StantreonApi.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly StantreonContext _context;

    public MembersController(StantreonContext context)
    {
        _context = context;
    }

    // GET: api/Members
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembers()
    {
        if (_context.Members == null)
        {
            return NotFound();
        }
        return await _context.Members
            .Select(member => MemberToDto(member))
            .ToListAsync();
    }

    // GET: api/Members/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MemberDto>> GetMember(long id)
    {
        if (_context.Members == null)
        {
            return NotFound();
        }
        var member = await _context.Members.FindAsync(id);

        if (member == null)
        {
            return NotFound();
        }

        return MemberToDto(member);
    }

    // PUT: api/Members/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMember(long id, MemberDto memberDto)
    {
        if (id != memberDto.UserId)
        {
            return BadRequest();
        }

        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            return NotFound();
        }

        member.UserId = memberDto.UserId;
        member.Email = memberDto.Email;
        member.Phone = memberDto.Phone;
        member.FirstName = memberDto.FirstName;
        member.LastName = memberDto.LastName;
        member.DisplayName = memberDto.DisplayName;

        _context.Entry(member).State = EntityState.Modified;

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
    public async Task<ActionResult<MemberDto>> PostMember(MemberDto memberDto)
    {
        if (_context.Members == null)
        {
            return Problem("Entity set 'StantreonContext.Members'  is null.");
        }

        var member = new Member
        {
            UserId = memberDto.UserId,
            Email = memberDto.Email,
            Phone = memberDto.Phone,
            FirstName = memberDto.FirstName,
            LastName = memberDto.LastName,
            DisplayName = memberDto.DisplayName,
        };

        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMember", new { id = member.UserId }, MemberToDto(member));
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

    private static MemberDto MemberToDto(Member member) =>
        new MemberDto
        {
            UserId = member.UserId,
            Email = member.Email,
            Phone = member.Phone,
            FirstName = member.FirstName,
            LastName = member.LastName,
            DisplayName = member.DisplayName,
        };
}
