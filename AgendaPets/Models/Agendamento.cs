namespace AgendaPets.Models;

public class Agendamento
{
    public int Id { get; set; }
    public string? NomePet { get; set; }
    public string? NomeTutor { get; set; }
    public string? Especie { get; set; }
    public string? Servico { get; set; }
    public DateTime DataAgendamento { get; set; }
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
