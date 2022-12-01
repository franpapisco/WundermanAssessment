using WundermanAssessment.Repository;

namespace WundermanAssessment.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DataJobDTORepository DataJobs { get; }
        int Complete();
    }
}