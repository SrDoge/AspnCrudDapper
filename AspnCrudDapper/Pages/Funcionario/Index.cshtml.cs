using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnCrudDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnCrudDapper.Pages.Funcionario
{
    public class IndexModel : PageModel
    {
        IFuncionarioRepository _funcionarioRepository;

        public IndexModel(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        [BindProperty]
        public IEnumerable <Entities.Funcionario> listaFuncionarios { get; set; }

        [BindProperty]
        public Entities.Funcionario funcionario { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            listaFuncionarios = _funcionarioRepository.GetAllFuncionarios();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _funcionarioRepository.DeleteFuncionario(id);
                if (count > 0)
                {
                    Message = "Funcionario Deletado com sucesso !";
                    return RedirectToPage("/Funcionario/Index");
                }
            }
            return Page();
        }
    }
}
