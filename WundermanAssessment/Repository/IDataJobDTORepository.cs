using WundermanAssessment.Models;
using WundermanAssessment.Repository.Generic;

namespace WundermanAssessment.Repository
{
    public interface IDataJobDTORepository : IGenericRepository<DataJobDTO>
    {
        public DataJobDTO GetByGuid(Guid dataJobID);
        public void RemoveByGuid(Guid dataJobID);
    }
}
