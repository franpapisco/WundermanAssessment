using WundermanAssessment.DbContext.EFCoreInMemoryDbDemo;
using WundermanAssessment.Models;
using WundermanAssessment.Repository;

namespace WundermanAssessment.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;
        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
            DataJobs = new DataJobDTORepository();            
        }
        public DataJobDTORepository DataJobs { get; private set; }        
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
