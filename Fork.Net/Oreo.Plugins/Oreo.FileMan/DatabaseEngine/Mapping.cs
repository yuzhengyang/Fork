using Oreo.FileMan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreo.FileMan.DatabaseEngine
{
    public class UsnFilesMap : EntityTypeConfiguration<UsnFiles>
    {
        public UsnFilesMap()
        {
            this.Property(o => o.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
    public class UsnDrivesMap : EntityTypeConfiguration<UsnDrives>
    {
        public UsnDrivesMap()
        {
            this.Property(o => o.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
    public class BackupPathsMap : EntityTypeConfiguration<BackupPaths>
    {
        public BackupPathsMap()
        {
            this.Property(o => o.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
    public class BackupFilesMap : EntityTypeConfiguration<BackupFiles>
    {
        public BackupFilesMap()
        {
            this.Property(o => o.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
        }
    }
}
