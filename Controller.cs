using LoanAPI.Models;
using LoanAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
private readonly MediatorDataService _service;
public LoanController()
    {
_service = new MediatorDataService(new SystemJsonData());
    }


    [HttpGet]
    public IActionResult Get()
    { return Ok(_service.GetAll()); }



    [HttpPost]
    public IActionResult Create([FromBody]     SystemDataModel loan)
    { 
    if (loan == null)
    return BadRequest("Invalid data");
    _service.Create(loan);
    return Ok("Loan created successfully");
    }



    [HttpPut]
    public IActionResult Update([FromBody]       
    SystemDataModel loan)
    {
    if (loan == null || loan.Id == Guid.Empty)
    return BadRequest("Invalid data");
    _service.Update(loan);
    return Ok("Updated successfully");
    }



   [HttpDelete("{id}")]
   public IActionResult Delete(Guid id)
   {
    _service.Delete(id);
    return Ok("Deleted successfully");
    }


    }
}