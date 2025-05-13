using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp_Async.Pages.Tache;

public class Taches : PageModel
{
    public IEnumerable<Tache_Entity> taches { get; set; } 
    TacheRepository tacheRepository = new TacheRepository();
    public async Task OnGetAsync()
    {
        taches = await tacheRepository.GetTachesAsync();
    }
}