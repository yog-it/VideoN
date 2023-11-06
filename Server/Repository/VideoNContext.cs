using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
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
