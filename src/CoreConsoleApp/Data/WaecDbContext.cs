using CoreConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp.Data
{
    public class WaecDbContext : DbContext
    {
        public WaecDbContext(DbContextOptions<WaecDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateWassce> Candidates { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder options) 
        //    => options.UseSqlServer("server=.;database=WAEC_SL_BRS;trusted_connection=true;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<CandidateWassce>(entity =>
            {
                entity.ToTable("Candidate_WASSCE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IndexNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NewData).IsUnicode(false);

                entity.Property(e => e.OldData).IsUnicode(false);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

    }
}
//Scaffold-DbContext "server=.;database=WAEC_SL_BRS;trusted_connection=true;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -t Candidate_WASSCE