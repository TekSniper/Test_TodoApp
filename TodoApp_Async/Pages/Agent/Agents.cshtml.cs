using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp_Async.Pages.Agent;

public class Agents : PageModel
{
    public IEnumerable<Agent_Entity> agents { get; set; } 
    IAgentRepository agentRepository = new AgentRepository();
    public async Task OnGetAsync()
    {
        agents = await agentRepository.GetAgentsAsync();
    }
}