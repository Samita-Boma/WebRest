using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Data;
using WebRest.EF.Models;
using WebRestAPI.Interfaces.Area.Common;


namespace WebRestAPI.Controllers.UD;

[ApiController]
[Route("api/[controller]")]
public class GradeTypeController : ControllerBase, iCRUD<GradeType>
{
    private WebRestOracleContext _context;
    // Create a field to store the mapper object
    private readonly IMapper _mapper;

    public GradeTypeController(WebRestOracleContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        var lst = await _context.GradeType.ToListAsync();
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
        var itm = await _context.GradeType.Where(x => x.GradeTypeGuid == ID).FirstOrDefaultAsync();
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
        var itm = await _context.GradeType.Where(x => x.GradeTypeGuid == ID).FirstOrDefaultAsync();
        if (itm == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }
        try
        {
            _context.GradeType.Remove(itm);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Record not deleted. " + ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] GradeType _Item)
    {
        var trans = _context.Database.BeginTransaction();

        try
        {
            var itm = await _context.GradeType.AsNoTracking()
            .Where(x => x.GradeTypeGuid == _Item.GradeTypeGuid)
            .FirstOrDefaultAsync();
            if (itm != null)
            {
                itm = _mapper.Map<GradeType>(_Item);
                _context.GradeType.Update(itm);
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
    public async Task<IActionResult> Post([FromBody] GradeType _Item)
    {
        var trans = _context.Database.BeginTransaction();
        try
        {
            _Item.GradeTypeGuid = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            _context.GradeType.Add(_Item);
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
