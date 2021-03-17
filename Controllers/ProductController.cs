using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/product")]
  public class ProductController : ControllerBase
  {
    private dbContext db = new dbContext();

    [AllowAnonymous]
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Product>>> findAll()
    {
      return await this.db.Products.ToListAsync();
    }

    [AllowAnonymous]
    [HttpGet("category")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Product>>> findAllByCategoryId([FromQuery] uint id)
    {
      return await this.db.Products.Where(p => p.IdCategory == id).ToListAsync();
    }

    [HttpPost("save")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<List<Product>>> save([FromBody] Product product)
    {
      try
      {
        var saveTask = await this.db.Products.AddAsync(product);
        if (saveTask.State == EntityState.Added)
        {
          await this.db.SaveChangesAsync();
          return Ok(product);
        }
        else
        {
          return BadRequest();
        }
      }
      catch (DbUpdateConcurrencyException)
      {
        return BadRequest(product);
      }
    }

  }
}
