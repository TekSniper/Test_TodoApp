namespace TodoApp_Async.Services;

public interface IAgentRepository
{
    Task<IEnumerable<Agent_Entity>> GetAgentsAsync();
    Task<string> CreateAgentAsync(Agent_Entity agent);
}