using LoanAPI.Models;

namespace LoanAPI.Services
{
    public class MediatorDataService
    {
private readonly InterfaceLoanDataService _data;
public MediatorDataService(InterfaceLoanDataService data)
     {_data = data;}

public List<SystemDataModel> GetAll() => _data.View();
public void Create(SystemDataModel loan)
     {
            loan.Id = Guid.NewGuid();
            loan.TotalPayment = loan.LoanAmount + (loan.LoanAmount * loan.InterestRate);
            _data.Create(loan);
      }
public void Update(SystemDataModel loan)
      {
loan.TotalPayment = loan.LoanAmount + (loan.LoanAmount * loan.InterestRate);
           _data.Update(loan);
      }
public void Delete(Guid id) => _data.Delete(id);
      }
}