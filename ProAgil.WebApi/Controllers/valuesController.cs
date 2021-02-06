using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebApi.Data;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class valuesController : ControllerBase
    {
        public readonly DataContext _Context;
        public valuesController(DataContext context)
        {
            _Context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _Context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
          
        }

         [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           try
            {
                var results = await  _Context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
    }
}


