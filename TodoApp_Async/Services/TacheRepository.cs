namespace TodoApp_Async.Services;

public class TacheRepository : ITacheRepository
{
    public async Task<IEnumerable<Tache_Entity>> GetTachesAsync()
    {
        using (var cnx = new DbConnexion().GetConnection())
        {
            await cnx.OpenAsync();
            return await cnx.QueryAsync<Tache_Entity>("SELECT * FROM tache");       
        }
    }
}