using MedGrupo.Domain.Error;
using MedGrupo.Services.DTO;
using MedGrupo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedGrupo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServices _services;

        public PessoaController(IPessoaServices services)
        {
            _services = services;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAsync());
        }

        [HttpGet("{id}", Name = "Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var cadatro = await _services.GetIdAsync(id.Value);
            if (cadatro == null)
                return NotFound();

            return Ok(cadatro);
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(PessoaDTO pessoaDTO)
        {
            if (ModelState.IsValid)
                pessoaDTO = await _services.CreateAsync(pessoaDTO);

            if (!string.IsNullOrEmpty(pessoaDTO.MsgError))
                return BadRequest(new { Result = false, PessoaDTO = pessoaDTO, Message = pessoaDTO.MsgError });

            return Ok(new { Result = true, PessoaDTO = pessoaDTO, Message = "Sucesso" });
        }

        [HttpPut(Name = "Edit")]
        public async Task<IActionResult> Edit(PessoaDTO pessoaDTO)
        {
            if (ModelState.IsValid)
                pessoaDTO = await _services.EditAsync(pessoaDTO);

            if (!string.IsNullOrEmpty(pessoaDTO.MsgError))
                return BadRequest(new { Result = false, PessoaDTO = pessoaDTO, Message = pessoaDTO.MsgError });

            return Ok(new { Result = true, PessoaDTO = pessoaDTO, Message = "Sucesso" });
        }

        [HttpDelete("{id}", Name = "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _services.DeleteAsync(id);
                return Ok(new { Result = true, Message = "Sucesso" });
            }
            catch (NotFoundException nex) 
            {
                return NotFound(new { Result = false, Message = nex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Result = false, Message = ex.Message });
            }
        }
    }
}
