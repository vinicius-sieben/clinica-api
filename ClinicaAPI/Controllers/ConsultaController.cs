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

            var consultas = await _context.Consulta.Include(consulta => consulta.Paciente).Include(consulta => consulta.Medico).ToListAsync();

            return Ok(consultas);
        }

        // Cadastrando uma consulta
        [HttpPost()]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Consulta consulta)
        {
            if (_context is null) return NotFound();

            var existingPaciente = await _context.Paciente.FindAsync(consulta.PacienteId);
            var existingMedico = await _context.Medico.FindAsync(consulta.MedicoId);

            if (existingMedico == null || existingPaciente == null) return BadRequest("Paciente ou médico não encontrados.");
            consulta.Paciente = existingPaciente;
            consulta.Medico = existingMedico;
            
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
            return Ok(consulta);
        }

        // Alterando consulta
        [HttpPut()]
        [Route("alterar")]
        public async Task<IActionResult> Alterar(Consulta consulta)
        {
            if (_context is null) return NotFound();

            var tempConsulta = await _context.Consulta.FindAsync(consulta.Id);
            if (tempConsulta is null) return BadRequest("Consulta não encontrada.");

            _context.Consulta.Update(consulta);
            await _context.SaveChangesAsync();
            return Ok("Consulta alterada com sucesso.");
        }

        // Alterando médico da consulta
        [HttpPatch()]
        [Route("mudarmedico/{id}")]
        public async Task<ActionResult> MudarMedico([FromRoute] int id, Medico medico) 
        {
            if (_context is null) return NotFound();
            var objConsulta = await _context.Consulta.FindAsync(id);
            if (objConsulta is null) return NotFound();

            var tempMedico = await _context.Medico.FindAsync(medico.Id);
            if (tempMedico is null) return BadRequest("Médico não encontrado.");

            objConsulta.Medico = medico;
            await _context.SaveChangesAsync();
            return Ok("Médico responsável pela consulta alterado com sucesso.");
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
            return Ok("Data da consulta alterada com sucesso.");
        }

        // Excluindo uma consulta
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_context is null) return NotFound();
            var objConsulta = await _context.Consulta.FindAsync(id);
            if (objConsulta is null) return BadRequest("Consulta não encontrada.");
            _context.Consulta.Remove(objConsulta);
            await _context.SaveChangesAsync();
            return Ok("Consulta excluída com sucesso.");
        }
    }
}