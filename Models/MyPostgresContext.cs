using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BulletJournal.Models
{
    public partial class MyPostgresContext : DbContext
    {
        public MyPostgresContext()
        {
        }

        public MyPostgresContext(DbContextOptions<MyPostgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BjTodo> BjTodos { get; set; }
        public virtual DbSet<BjWorkrank> BjWorkranks { get; set; }
        public virtual DbSet<BjWorktarget> BjWorktargets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "item_priority", new[] { "CRITICAL", "HIGH", "MEDIUM", "LOW", "FUNNY" })
                .HasPostgresEnum(null, "item_status", new[] { "NONE", "MONTH", "WEEK", "TODAY", "NEXTTIME", "COMPLETED" })
                .HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<BjTodo>(entity =>
            {
                entity.ToTable("bj_todo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('seq_bj_todo_id'::regclass)");

                entity.Property(e => e.Createdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("createdate")
                    .HasDefaultValueSql("to_char(CURRENT_TIMESTAMP, 'YYYYMMDD'::text)");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Iscompleted)
                    .HasMaxLength(1)
                    .HasColumnName("iscompleted")
                    .HasDefaultValueSql("'0'::bpchar");

                entity.Property(e => e.Targetdate)
                    .HasMaxLength(8)
                    .HasColumnName("targetdate")
                    .HasDefaultValueSql("to_char(CURRENT_TIMESTAMP, 'YYYYMMDD'::text)");

                entity.Property(e => e.Workrankid)
                    .HasMaxLength(1)
                    .HasColumnName("workrankid")
                    .HasDefaultValueSql("'3'::bpchar");

                entity.Property(e => e.Worktargetid).HasColumnName("worktargetid");

                entity.Property(e => e.Worktitle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("worktitle");
            });

            modelBuilder.Entity<BjWorkrank>(entity =>
            {
                entity.ToTable("bj_workrank");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Rankname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("rankname")
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<BjWorktarget>(entity =>
            {
                entity.ToTable("bj_worktarget");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('seq_bj_work_target_id'::regclass)");

                entity.Property(e => e.Targetdate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("targetdate");

                entity.Property(e => e.Targetdescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("targetdescription");
            });


            modelBuilder.HasSequence("seq_bj_todo_id");

            modelBuilder.HasSequence("seq_bj_work_target_id");

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
