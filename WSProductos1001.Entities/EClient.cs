namespace WSProductos1001.Entities;

public class EClient
{
    public int Id { get; set; }
    public string Identification { get; set; }
    public string Names { get; set; }
    public DateTime BirthDay { get; set; }
    public string LastNames { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int MaritalStatus { get; set; }
    public string SpouseIdentification { get; set; }
    public string SpouseName { get; set; }
    public int SubjectCredit { get; set; }
}