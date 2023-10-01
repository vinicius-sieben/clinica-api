using ClinicaAPI.Data;
using ClinicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private ClinicaDbContext _context;

        public ConsultaController(ClinicaDbContext context)
        {
            _context = context;
        }

        // Listando todas as consultas
        [HttpGet()]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Consulta>>> Listar()
        {
            if (_context is null) return NotFound();
            return await _context.Consulta.ToListAsync();
        }

        // Cadastrando uma consulta
        [HttpPost()]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Consulta consulta)
        {
            if (_context is null) return NotFound();
            await _context.AddAsync(consulta);
            await _context.SaveChangesAsync();
            return Created("", consulta);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Consulta>> Buscar([FromRoute] int id)
        {
            if (_context is null) return NotFound();
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta is null) return NotFound();
            return consulta;
        }

        // Alterando consulta
        [HttpPut()]
        [Route("alterar")]
        public async Task<IActionResult> Alterar(Consulta consulta)
        {
            if (_context is null) return NotFound();
            _context.Consulta.Update(consulta);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Alterando médico da consulta
        [HttpPatch()]
        [Route("mudarmedico/{id}")]
        public async Task<ActionResult> MudarMedico([FromRoute] int id, int idMedico) 
        {
            if (_context is null) return NotFound();
            var objConsulta = await _context.Consulta.FindAsync(id);
            if (objConsulta is null) return NotFound();
            objConsulta.IdMedico = idMedico;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Alterando data da consulta
        [HttpPatch()]
        [Route("mudardata/{id}")]
        public async Task<ActionResult> MudarData([FromRoute] int id, DateTime data)
        {
            if (_context is null) return NotFound();
            var objConsulta = await _context.Consulta.FindAsync(id);
            if (objConsulta is null) return NotFound();
            objConsulta.DataHora = data;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Excluindo uma consulta
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_context is null) return NotFound();
            var objConsulta = await _context.Consulta.FindAsync(id);
            if (objConsulta is null) return NotFound();
            _context.Consulta.Remove(objConsulta);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
