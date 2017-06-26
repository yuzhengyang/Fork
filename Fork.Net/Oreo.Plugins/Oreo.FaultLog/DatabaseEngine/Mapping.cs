using Oreo.FaultLog.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Oreo.FaultLog.DatabaseEngine
{
    public class FaultLogsMap : EntityTypeConfiguration<FaultLogs>
    {
        public FaultLogsMap()
        {
            this.Property(o => o.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
}
