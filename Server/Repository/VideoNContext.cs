using Microsoft.EntityFrameworkCore;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Repository.Databases.Interfaces;

namespace YogIT.Module.VideoN.Repository
{
    public class VideoNContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.VideoN> VideoN { get; set; }

        public VideoNContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
