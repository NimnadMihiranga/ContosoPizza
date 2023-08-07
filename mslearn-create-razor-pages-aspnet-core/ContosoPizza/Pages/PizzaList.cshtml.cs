using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages;
using ContosoPizza.Models;
using ContosoPizza.Services;

public class PizzaListModel : PageModel
{
    private readonly PizzaService _service;
    public IList<Pizza> PizzaList { get;set; } = default!;
    [BindProperty] public Pizza newPizza { get; set; } = default;
    

    public PizzaListModel(PizzaService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        PizzaList = _service.GetPizzas();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid || newPizza == null)
        {
            return Page();
        }
        
        _service.AddPizza(newPizza);
        return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(int id)
    {
        _service.DeletePizza(id);
        return RedirectToAction("Get");
    }
}