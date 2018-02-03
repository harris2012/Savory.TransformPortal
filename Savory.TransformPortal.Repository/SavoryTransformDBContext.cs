using Savory.Repository.TransformDB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.TransformPortal.Repository
{
    public class SavoryTransformDBContext : DbContext
    {
        public SavoryTransformDBContext() : base("name=SavoryTransformDB")
        {
        }

        public virtual DbSet<TransformEntity> Transform { get; set; }

        public virtual DbSet<TemplateEntity> Template { get; set; }
    }
}
