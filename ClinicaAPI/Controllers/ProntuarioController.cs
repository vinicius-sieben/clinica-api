using ClinicaAPI.Data;
using ClinicaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : ControllerBase
    {
        private ClinicaDbContext _context;

        public ProntuarioController(ClinicaDbContext context)
        {
            _context = context;
        }

        // Listando todos os prontuarios
        [HttpGet()]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Prontuario>>> Listar()
        {
            if (_context is null) return NotFound();
            return await _context.Prontuario.ToListAsync();
        }

        // Cadastrando um prontuario
        [HttpPost()]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Prontuario prontuario)
        {
            if (_context is null) return NotFound();
            await _context.AddAsync(prontuario);
            await _context.SaveChangesAsync();
            return Created("", prontuario);
        }

        [HttpGet()]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Prontuario>> Buscar([FromRoute] int id)
        {
            if (_context is null) return NotFound();
            var prontuario = await _context.Prontuario.FindAsync(id);
            if (prontuario is null) return NotFound();
            return prontuario;
        }

        // Alterando um prontuario
        [HttpPut()]
        [Route("alterar")]
        public async Task<IActionResult> Alterar(Prontuario prontuario)
        {
            if (_context is null) return NotFound();
            _context.Prontuario.Update(prontuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Alterando paciente
        [HttpPatch()]
        [Route("mudarpaciente/{id}")]
        public async Task<ActionResult> MudarPaciente([FromRoute] int id, int pacienteId) 
        {
            if (_context is null) return NotFound();
            var objProntuario = await _context.Prontuario.FindAsync(id);
            if (objProntuario is null) return NotFound();
            objProntuario.PacienteId = pacienteId;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Alterando Diagnostico
        [HttpPatch()]
        [Route("mudardiagnostico/{id}")]
        public async Task<ActionResult> MudarDiagnostico([FromRoute] int id, string diagnostico) 
        {
            if (_context is null) return NotFound();
            var objProntuario = await _context.Prontuario.FindAsync(id);
            if (objProntuario is null) return NotFound();
            objProntuario.Diagnostico = diagnostico;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Alterando tratamento
        [HttpPatch()]
        [Route("mudartratamento/{id}")]
        public async Task<ActionResult> MudarTratamento([FromRoute] int id, string tratamento)
        {
            if (_context is null) return NotFound();
            var objProntuario = await _context.Prontuario.FindAsync(id);
            if (objProntuario is null) return NotFound();
            objProntuario.Tratamento = tratamento;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Excluindo um prontuario
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir([FromRoute] int id)
        {
            if (_context is null) return NotFound();
            var objProntuario = await _context.Prontuario.FindAsync(id);
            if (objProntuario is null) return NotFound();
            _context.Prontuario.Remove(objProntuario);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
