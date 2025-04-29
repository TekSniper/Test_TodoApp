namespace TodoApp_Async.Entities;

public class Tache_Entity
{
    public int Id { get; set; }
    public string MatriculeAgent { get; set; } = String.Empty;
    public string Titre { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public bool Statut { get; set; } = false;
    public DateTime DateCreation { get; set; } = DateTime.UtcNow.Date;
    public DateTime DateLimite { get; set; } = DateTime.UtcNow.Date;
    public int NiveauPriorite { get; set; } = 0;
}