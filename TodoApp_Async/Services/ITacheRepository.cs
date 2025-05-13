namespace TodoApp_Async.Services;

public interface ITacheRepository
{
    Task<IEnumerable<Tache_Entity>> GetTachesAsync();
}