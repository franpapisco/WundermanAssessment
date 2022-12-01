using Microsoft.AspNetCore.Mvc;
using WundermanAssessment.Models;
using WundermanAssessment.Service;

namespace WundermanAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataJobController : ControllerBase
    {        

        private readonly IDataProcessorService _dataProcessorService;
        public DataJobController(IDataProcessorService dataProcessorService)
        {
            _dataProcessorService = dataProcessorService;
        }

        [HttpGet(Name = "GetDataJobs")]
        public IEnumerable<DataJobDTO> GetAllDataJobs()
        {
            return _dataProcessorService.GetAllDataJobs();
        }
        
    }
}