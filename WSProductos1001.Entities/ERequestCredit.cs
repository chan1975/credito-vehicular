namespace WSProductos1001.Entities;

public class ERequestCredit
{
    public int Id { get; set; }
    public DateTime BuildDate { get; set; }
    public int ClientId { get; set; }
    public int PatioId { get; set; }
    public int VehicleId { get; set; }
    public int TermMonth { get; set; }
    public int Fee { get; set; }
    public int Entry { get; set; }
    public int AgentId { get; set; }
    public string Observation { get; set; }
    public int CreditStatus { get; set; }
}