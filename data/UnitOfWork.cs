using domain;
using Microsoft.EntityFrameworkCore;


namespace data
{

    public class UnitOfWork : IUnitOfWork
    {

        readonly AplicationpContext _AppContext;

      
        public UnitOfWork(AplicationpContext AppContext)
        {
            _AppContext = AppContext;
           
        }


        public async Task<bool> CommitAsync()
        => await _AppContext.SaveChangesAsync() > 0;
      

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
