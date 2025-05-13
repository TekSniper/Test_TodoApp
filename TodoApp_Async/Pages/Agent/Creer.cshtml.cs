using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp_Async.Pages.Agent;

public class Creer : PageModel
{
    [BindProperty]
    public Agent_Entity agent { get; set; } = new Agent_Entity();
    public IAgentRepository agentRepository = new AgentRepository();
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            if(string.IsNullOrWhiteSpace(agent.Matricule) || string.IsNullOrWhiteSpace(agent.Nom) || string.IsNullOrWhiteSpace(agent.Email))
            {
                ModelState.AddModelError("agent", "Veuillez remplir les champs obligatoires !");
                return Page();
            }
            else
            {
                var msg = await agentRepository.CreateAgentAsync(agent);
                if (msg == "Succès")
                {
                    
                }
                else
                {
                    if (msg == "Echec")
                    {
                        ModelState.AddModelError("erreur", "Echec de l'enregistrement");
                        return Page();      ;
                    }
                    else
                    {
                        ModelState.AddModelError("erreur", msg);
                        return Page();       ;
                    }
                }
            }

            return RedirectToPage("./Agents");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("erreur", ex.Message);
            return Page();       
        }
    }
}