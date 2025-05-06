using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp_Async.Pages.Agent;

public class Agents : PageModel
{
    public IList<Agent_Entity> agents { get; set; }
    public async Task OnGetAsync()
    {
        using (var cnx = new DbConnexion().GetConnection())
        {
            await cnx.OpenAsync();
            var cm = new SqlCommand("select * from agent", cnx);
            agents = new List<Agent_Entity>();
            using (var reader = await cm.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    agents.Add(new Agent_Entity
                    {
                        Matricule = reader.GetString(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2),
                        Email = reader.GetString(3)
                    });
                }
            }
        }
    }
}