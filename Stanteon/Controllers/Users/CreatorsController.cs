using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StantreonApi.Dtos.Users;
using StantreonApi.Models;
using StantreonApi.Models.Users;

namespace StantreonApi.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class CreatorsController : ControllerBase
{
    private readonly StantreonContext _context;

    public CreatorsController(StantreonContext context)
    {
        _context = context;
    }

    // GET: api/Creators
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CreatorDto>>> GetCreators()
    {
        if (_context.Creators == null)
        {
            return NotFound();
        }
        return await _context.Creators
            .Select(creator => CreatorToDto(creator))
            .ToListAsync();
    }

    // GET: api/Creators/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CreatorDto>> GetCreator(long id)
    {
        if (_context.Creators == null)
        {
            return NotFound();
        }
        var creator = await _context.Creators.FindAsync(id);

        if (creator == null)
        {
            return NotFound();
        }

        return CreatorToDto(creator);
    }

    // PUT: api/Creators/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCreator(long id, CreatorDto creatorDto)
    {
        if (id != creatorDto.UserId)
        {
            return BadRequest();
        }

        var creator = await _context.Creators.FindAsync(id);
        if (creator == null)
        {
            return NotFound();
        }

        creator.UserId = creatorDto.UserId;
        creator.Email = creatorDto.Email;
        creator.Phone = creatorDto.Phone;
        creator.FirstName = creatorDto.FirstName;
        creator.LastName = creatorDto.LastName;
        creator.PageName = creatorDto.PageName;
        creator.UrlHandle = creatorDto.UrlHandle;

        _context.Entry(creator).State = EntityState.Modified;

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
    public async Task<ActionResult<CreatorDto>> PostCreator(CreatorDto creatorDto)
    {
        if (_context.Creators == null)
        {
            return Problem("Entity set 'StantreonContext.Creators' is null.");
        }

        var creator = new Creator
        {
            UserId = creatorDto.UserId,
            Email = creatorDto.Email,
            Phone = creatorDto.Phone,
            FirstName = creatorDto.FirstName,
            LastName = creatorDto.LastName,
            PageName = creatorDto.PageName,
            UrlHandle = creatorDto.UrlHandle,
        };

        _context.Creators.Add(creator);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCreator", new { id = creator.UserId }, CreatorToDto(creator));
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

    private static CreatorDto CreatorToDto(Creator creator) =>
        new CreatorDto
        {
            UserId = creator.UserId,
            Email = creator.Email,
            Phone = creator.Phone,
            FirstName = creator.FirstName,
            LastName = creator.LastName,
            PageName = creator.PageName,
            UrlHandle = creator.UrlHandle,
        };
}