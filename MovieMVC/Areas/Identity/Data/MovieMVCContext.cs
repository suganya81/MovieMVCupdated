using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Areas.Identity.Data;
using MovieMVC.Models;

namespace MovieMVC.Data
{
    public class MovieMVCContext : IdentityDbContext<MovieMVCUser>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MovieMVCContext(DbContextOptions<MovieMVCContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Categories table
            builder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Drama" },
                new Category { Id = 2, CategoryName = "Action" },
                new Category { Id = 3, CategoryName = "Family" },
                new Category { Id = 4, CategoryName = "Comedy" },
                new Category { Id = 5, CategoryName = "Animation" },
                new Category { Id = 6, CategoryName = "Crime" },
                new Category { Id = 7, CategoryName = "Fantasy" },
                new Category { Id = 8, CategoryName = "Historical" },
                new Category { Id = 9, CategoryName = "Horror" },
                new Category { Id = 10, CategoryName = "Romance" }
            );

            // Seed Posts table
            builder.Entity<Post>().HasData(
               new Post { Id = 1, Title = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1995-03-02", ImagePost = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg", CategoryId = 1 },
               new Post { Id = 2, Title = "The Godfather", Description = "The aging patriarch of an organized crime dynasty transfers control of his empire to his son.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1972-09-28", ImagePost = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", CategoryId = 6 },
               new Post { Id = 3, Title = "The Dark Knight", Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "2008-07-24", ImagePost = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_.jpg", CategoryId = 2 },
               new Post { Id = 4, Title = "Forrest Gump", Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1994-09-22", ImagePost = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg", CategoryId = 4 },
               new Post { Id = 5, Title = "Inception", Description = "A thief who enters the dreams of others to steal secrets from their subconscious is given the inverse task of planting an idea into the mind of a CEO.", Status = "Draft", CreatedAt = DateTime.Now, ReleaseDate = "2010-07-16", ImagePost = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg", CategoryId = 7 },
               new Post { Id = 6, Title = "Fight Club", Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1999-11-04", ImagePost = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", CategoryId = 6 },
               new Post { Id = 7, Title = "Pulp Fiction", Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1994-12-01", ImagePost = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", CategoryId = 6 },
               new Post { Id = 8, Title = "Schindler's List", Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1994-03-03", ImagePost = "https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg", CategoryId = 8 },
               new Post { Id = 9, Title = "The Matrix", Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1999-06-17", ImagePost = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg", CategoryId = 2 },
               new Post {Id = 10,Title = "Goodfellas", Description = "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", Status = "Published",CreatedAt = DateTime.Now,ReleaseDate = "1990-11-02",ImagePost = "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtMzhiMi00NjZmLTg5NGItZDNiZjU5NTU4OTE0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V", CategoryId = 6 });
               new Post { Id = 10, Title = "Goodfellas", Description = "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "1990-11-02", ImagePost = "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtMzhiMi00NjZmLTg5NGItZDNiZjU5NTU4OTE0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", CategoryId = 6 };
               new Post { Id = 11, Title = "The Lord of the Rings: The Return of the King", Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", Status = "Published", CreatedAt = DateTime.Now, ReleaseDate = "2003-12-17", ImagePost = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg", CategoryId = 3 };
       }

        public DbSet<MovieMVC.Models.Post> Posts { get; set; }
        public DbSet<MovieMVC.Models.Category> Categories { get; set; }
    }
}
