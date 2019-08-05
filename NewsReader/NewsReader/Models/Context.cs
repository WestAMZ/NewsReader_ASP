namespace NewsReader.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'Context' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'NewsReader.Models.Context' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'Context'  en el archivo de configuración de la aplicación.
        public Context() : base("name=Context")
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuration in News table
            modelBuilder.Entity<News>().ToTable("News", "dbo");
            modelBuilder.Entity<News>().HasKey(n => n.Id);
            modelBuilder.Entity<News>().Property(n => n.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<News>().Property(n => n.Title).HasMaxLength(150);
            modelBuilder.Entity<News>().Property(n => n.Content).HasMaxLength(1000);
            modelBuilder.Entity<News>().HasRequired<Category>(n => n.Category)
                                        .WithMany(c => c.News)
                                        .HasForeignKey<int>(n => n.IdCategory);
            modelBuilder.Entity<News>().HasRequired<Country>(n => n.Country)
                                        .WithMany(c => c.News)
                                        .HasForeignKey<int>(n => n.IdCountry);

            modelBuilder.Entity<Country>().ToTable("Country", "dbo");
            modelBuilder.Entity<Country>().HasKey(c => c.Id);
            //modelBuilder.Entity<Country>().HasMany(c => c.News);

            modelBuilder.Entity<Category>().ToTable("Category", "dbo");
            modelBuilder.Entity<Category>().HasKey(c => c.Id);


        }
    }
}
    