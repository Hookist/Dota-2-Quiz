namespace Intelligence.entyty {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext {
        public Model1()
            : base("name=Model1") {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Answers>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questions>()
                .Property(e => e.question)
                .IsUnicode(false);

            modelBuilder.Entity<Questions>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Questions)
                .HasForeignKey(e => e.question_id)
                .WillCascadeOnDelete(false);
        }
    }
}
