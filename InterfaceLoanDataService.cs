using LoanAPI.Models;
namespace LoanAPI.Services

{
    public interface InterfaceLoanDataService {
    void Create(SystemDataModel loan);
    void Update(SystemDataModel loan);
    void Delete(Guid id);
    List<SystemDataModel> View();             }
}