using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Data;
using WebRest.EF.Models;
using WebRestAPI.Interfaces.Area.Common;


namespace WebRestAPI.Controllers.UD;

[ApiController]
[Route("api/[controller]")]
public class InstructorAddressController : ControllerBase, iCRUD<InstructorAddress>
{
    private WebRestOracleContext _context;
    // Create a field to store the mapper object
    private readonly IMapper _mapper;

    public InstructorAddressController(WebRestOracleContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        var lst = await _context.InstructorAddress.ToListAsync();
        if (lst.Count == 0)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        } 
        return Ok(lst);
    }


    [HttpGet]
    [Route("Get/{ID}")]
    public async Task<IActionResult> Get(string ID)
    {
        var itm = await _context.InstructorAddress.Where(x => x.InstructorAddressGuid == ID).FirstOrDefaultAsync();
        if (itm == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }        
        return Ok(itm);
    }


    [HttpDelete]
    [Route("Delete/{ID}")]
    public async Task<IActionResult> Delete(string ID)
    {
        var itm = await _context.InstructorAddress.Where(x => x.InstructorAddressGuid == ID).FirstOrDefaultAsync();
        if (itm == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }
        try
        {
            _context.InstructorAddress.Remove(itm);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Record not deleted. " + ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] InstructorAddress _Item)
    {
        var trans = _context.Database.BeginTransaction();

        try
        {
            var itm = await _context.InstructorAddress.AsNoTracking()
            .Where(x => x.InstructorAddressGuid == _Item.InstructorAddressGuid)
            .FirstOrDefaultAsync();
            if (itm != null)
            {
                itm = _mapper.Map<InstructorAddress>(_Item);
                _context.InstructorAddress.Update(itm);
                await _context.SaveChangesAsync();
                trans.Commit();

            }
        }
        catch (Exception ex)
        {
            trans.Rollback();
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InstructorAddress _Item)
    {
        var trans = _context.Database.BeginTransaction();
        try
        {
            _Item.InstructorAddressGuid = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            _context.InstructorAddress.Add(_Item);
            await _context.SaveChangesAsync();
            trans.Commit();
        }
        catch (Exception ex)
        {
            trans.Rollback();
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        return Ok(_Item);
    }
}
