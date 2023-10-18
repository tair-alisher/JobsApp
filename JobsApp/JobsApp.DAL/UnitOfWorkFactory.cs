using JobsApp.DAL.Interfaces;

namespace JobsApp.DAL
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IContextFactory _contextFactory;

        public UnitOfWorkFactory(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_contextFactory);
        }
    }
}