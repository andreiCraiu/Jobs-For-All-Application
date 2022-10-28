using JobsForAll.Library.Contracts;
using JobsForAll.SqlDatabase.Contracts;

namespace JobsForAll.SqlDatabase.Services
{
    internal class Repository : IRepository
    {
        public Repository(IDataCore dataCore, IDbMapper mapper)
        {
            this.dataCore = dataCore;
        }


        //

        private readonly IDataCore dataCore;
    }
}
