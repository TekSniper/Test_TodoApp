namespace TodoApp_Async.Services;

public class AgentRepository : IAgentRepository
{
    public async Task<IEnumerable<Agent_Entity>> GetAgentsAsync()
    {
        using (var cnx = new DbConnexion().GetConnection())
        {
            await cnx.OpenAsync();
            string query = "SELECT * FROM Agent";
            return await cnx.QueryAsync<Agent_Entity>(query);
        }
    }

    public async Task<string> CreateAgentAsync(Agent_Entity agent)
    {
        using (var cnx = new DbConnexion().GetConnection())
        {
            var message = string.Empty;
            await cnx.OpenAsync();
            try
            {
                var sql = "insert into agent values (@matricule,@nom,@prenom,@email)";
                var rows = await cnx.ExecuteAsync(sql, agent);
                if (rows != 0)
                    message = "Succès";
                else
                    message = "Echec";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return message;
        }
    }

    public async Task<string> UpdateAgentAsync(Agent_Entity agent)
    {
        var message = string.Empty;
        using (var cnx = new DbConnexion().GetConnection())
        {
            await cnx.OpenAsync();
            try
            {
                var rows = await cnx.ExecuteAsync(
                    "update agent set nom = @nom, prenom = @prenom, email = @email where matricule = @matricule", 
                    agent);
                if (rows != 0)
                    message = "Succès";
                else
                    message = "Echec";           
            }
            catch (Exception ex)
            {
                return ex.Message;           
            }
        }
        return message;
    }
}