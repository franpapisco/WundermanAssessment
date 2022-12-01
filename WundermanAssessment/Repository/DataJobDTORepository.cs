using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;
using WundermanAssessment.DbContext.EFCoreInMemoryDbDemo;
using WundermanAssessment.Models;
using WundermanAssessment.Repository.Generic;

namespace WundermanAssessment.Repository
{
    public class DataJobDTORepository : GenericRepository<DataJobDTO>, IDataJobDTORepository
    {
        public void RemoveByGuid(Guid dataJobID)
        {
            var result = _context.DataJobs.Find(dataJobID);
            _context.Remove(result);
        }

        public DataJobDTO GetByGuid(Guid dataJobID)
        {
            return _context.DataJobs.Find(dataJobID);           
        }       
        
    }

}
