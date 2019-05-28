namespace APBDProject.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarRentalDb : DbContext
    {
        public CarRentalDb()
            : base("name=CarRentalDb")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<FeulType> FeulType { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Rent)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Client_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeulType>()
                .Property(e => e.Feul)
                .IsUnicode(false);

            modelBuilder.Entity<FeulType>()
                .HasMany(e => e.Vehicle)
                .WithRequired(e => e.FeulType)
                .HasForeignKey(e => e.FeulType_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.Type1)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Vehicle)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.Type_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Rent)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserStatus>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<UserStatus>()
                .HasMany(e => e.User)
                .WithRequired(e => e.UserStatus)
                .HasForeignKey(e => e.UserStatus_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.Brand)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.Rent)
                .WithRequired(e => e.Vehicle)
                .HasForeignKey(e => e.Vehicle_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
