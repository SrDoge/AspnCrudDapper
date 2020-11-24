using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnCrudDapper.Repository;

namespace AspnCrudDapper.Pages.Funcionario
{
    public class EditModel : PageModel
    {
        IFuncionarioRepository _funcionarioRepository;
        public EditModel(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [BindProperty]
        public Entities.Funcionario funcionario { get; set; }
        public void OnGet(int id)
        {
            funcionario = _funcionarioRepository.GetFuncionario(id);
        }

        public IActionResult OnPost()
        {
            var dados = funcionario;
            if (ModelState.IsValid)
            {
                var count = _funcionarioRepository.UpdateFuncionario(dados);
                if(count > 0)
                {
                    return RedirectToPage("/Funcionario/Index");
                }

            }
            return Page();
        }
    }
}
