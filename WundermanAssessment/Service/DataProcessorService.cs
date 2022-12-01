using WundermanAssessment.Models;
using WundermanAssessment.Repository;
using WundermanAssessment.UnitOfWork;

namespace WundermanAssessment.Service
{
    public class DataProcessorService : IDataProcessorService
    {
        IUnitOfWork _unitOfWork;

        public DataProcessorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DataJobDTO Create(DataJobDTO dataJob)
        {
            _unitOfWork.DataJobs.Add(dataJob);
            _unitOfWork.Complete();
            return dataJob;
        }

        public void Delete(Guid dataJobID)
        {
            _unitOfWork.DataJobs.RemoveByGuid(dataJobID);
            _unitOfWork.Complete();
        }

        public IEnumerable<DataJobDTO> GetAllDataJobs()
        {
            return _unitOfWork.DataJobs.GetAll();
        }

        public List<string> GetBackgroundProcessResults(Guid dataJobId)
        {
            return _unitOfWork.DataJobs.GetByGuid(dataJobId).Results.ToList();
        }

        public DataJobStatus GetBackgroundProcessStatus(Guid dataJobId)
        {
            return _unitOfWork.DataJobs.GetByGuid(dataJobId).Status;
        }

        public DataJobDTO GetDataJob(Guid id)
        {
            return _unitOfWork.DataJobs.GetByGuid(id);
        }

        public IEnumerable<DataJobDTO> GetDataJobsByStatus(DataJobStatus status)
        {
            return _unitOfWork.DataJobs.Find(dataJobDTO => dataJobDTO.Status == status);
        }

        public bool StartBackgroundProcess(Guid dataJobId)
        {
            var dataJob = _unitOfWork.DataJobs.GetByGuid(dataJobId);
            dataJob.Status = DataJobStatus.Processing;
            _unitOfWork.Complete();

            return true;
        }

        public DataJobDTO Update(DataJobDTO dataJob)
        {
            _unitOfWork.DataJobs.Update(dataJob);          
            _unitOfWork.Complete();

            return dataJob;
        }
    }
}
