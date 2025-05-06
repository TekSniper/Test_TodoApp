using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp_Async.Pages.Tache;

public class Taches : PageModel
{
    public IList<Tache_Entity> taches { get; set; } 
    public async Task OnGetAsync()
    {
        using (var cnx = new DbConnexion().GetConnection())
        {
            await cnx.OpenAsync();
            var cm = new SqlCommand("SELECT * FROM tache", cnx);
            using (var reader = await cm.ExecuteReaderAsync())
            {
                taches = new List<Tache_Entity>();
                while (await reader.ReadAsync())
                {
                    taches.Add(new Tache_Entity
                    {
                        Id = reader.GetInt32(0),
                        MatriculeAgent = reader.GetString(1),
                        Titre = reader.GetString(2),
                        Details = reader.GetString(3),
                        Statut = reader.GetBoolean(4),
                        DateCreation = reader.GetDateTime(5),
                        DateLimite = reader.GetDateTime(6),
                        NiveauPriorite = reader.GetInt32(7)
                    });
                }
            }
        }
    }
}