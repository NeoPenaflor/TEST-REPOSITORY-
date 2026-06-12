using LoanAPI.Models;
using System.Text.Json;

namespace LoanAPI.Services
{
    public class SystemJsonData : InterfaceLoanDataService
    {
    private List<SystemDataModel> loans = new();
    private string filePath = "loans.json";
    public SystemJsonData()
        {
    if (!File.Exists(filePath))
    File.WriteAllText(filePath, "[]");
    Load();
        }

        private void Load()
        {
     var json = File.ReadAllText(filePath);
     loans = JsonSerializer.Deserialize<List<SystemDataModel>>(json) ?? new();
        }

        private void Save()
        {
        File.WriteAllText(filePath,
        JsonSerializer.Serialize(loans, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void Create(SystemDataModel loan)
        {
            Load();
            loans.Add(loan);
            Save();
        }

        public void Update(SystemDataModel loan)
        {
            Load();
            var existing = loans.FirstOrDefault(x => x.Id == loan.Id);
            if (existing != null)
        {
existing.Name = loan.Name;
existing.Job = loan.Job;
existing.Salary = loan.Salary;
existing.Company = loan.Company;
existing.LoanMonths = loan.LoanMonths;
existing.InterestRate = loan.InterestRate;
existing.LoanAmount = loan.LoanAmount;
existing.TotalPayment = loan.TotalPayment;
Save();
        }
        }
        public void Delete(Guid id)
        {
            Load();
            loans.RemoveAll(x => x.Id == id);
            Save();
        }
        public List<SystemDataModel> View()
        {
            Load();
            return loans;
        }
    }
}