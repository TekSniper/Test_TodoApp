using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp_Async.Pages.Agent;

public class Creer : PageModel
{
    [BindProperty]
    public Agent_Entity agent { get; set; } = new Agent_Entity();
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
                using (var cnx = new DbConnexion().GetConnection())
                {
                    await cnx.OpenAsync();
                    var cm = new SqlCommand("insert into agent values(@matricule, @nom, @prenom, @email)", cnx);
                    cm.Parameters.AddWithValue("@matricule", agent.Matricule);
                    cm.Parameters.AddWithValue("@nom", agent.Nom);
                    cm.Parameters.AddWithValue("@prenom", agent.Prenom);
                    cm.Parameters.AddWithValue("@email", agent.Email);
                    await cm.ExecuteNonQueryAsync();
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