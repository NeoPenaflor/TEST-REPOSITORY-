namespace LoanAPI.Models
{
    public class SystemDataModel
    {  
    public Guid Id             { get; set; }
    public string Name         { get; set; }
    public string Job          { get; set; }
    public int Salary          { get; set; }
    public string Company      { get; set; }
    public int LoanMonths      { get; set; }
    public double InterestRate { get; set; }
    public double LoanAmount   { get; set; }
    public double TotalPayment { get; set; }
    }
}