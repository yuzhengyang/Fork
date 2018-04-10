using Azylee.BlackBox.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Azylee.BlackBox.DBEngine
{
    public class RunningStatusMap : EntityTypeConfiguration<RunningStatus>
    {
        public RunningStatusMap()
        {
            //this.Property(o => o.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
}
