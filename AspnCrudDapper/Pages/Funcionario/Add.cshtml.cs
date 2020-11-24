using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnCrudDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnCrudDapper.Pages.Funcionario
{
    public class AddModel : PageModel
    {
        IFuncionarioRepository _funcionarioRepository;
        public AddModel(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [BindProperty]
        public Entities.Funcionario funcionario { get; set; }

        [TempData]
        public string Message { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = _funcionarioRepository.AddFuncionario(funcionario);
                if (count > 0)
                {
                    Message = "Novo Funcionario incluído com sucesso! ";
                    return RedirectToPage("/Funcionario/Index");
                }
            }
            return Page();
        }
    }
}
