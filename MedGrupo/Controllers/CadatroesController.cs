using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedGrupo.Services.Services;
using MedGrupo.Services.DTO;

namespace MedGrupo.Controllers
{
    public class CadatroesController : Controller
    {
        private readonly PessoaServices _services;

        public CadatroesController(PessoaServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var cadatro = await _services.GetIdAsync(id.Value);
            if (cadatro == null)
                return NotFound();

            return View(cadatro);
        }
       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PessoaDTO pessoaDTO)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(pessoaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaDTO);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var cadatro = await _services.GetIdAsync(id.Value);
            if (cadatro == null)
                return NotFound();
            
            return View(cadatro);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PessoaDTO cadatro)
        {
            if (id != cadatro.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _services.EditAsync(cadatro);
                return RedirectToAction(nameof(Index));
            }

            return View(cadatro);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var cadatro = await _services.GetIdAsync(id.Value);
            if (cadatro == null)
                return NotFound();

            return View(cadatro);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
