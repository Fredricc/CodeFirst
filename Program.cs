using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace CodeFirst
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15900)]
        public string Description { get; set; }
        [Required]
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        [ForeignKey("Author")]
        public int AuthorId {  get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses  { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3

    }

    public class PlutoContext : DbContext
    {
        private const string name = "DefaultConnection";

        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public PlutoContext(): base(name)
        {
                
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

        class Program
        {
            static void Main(string[] args)
            {
            string luckyNumber = "16";

            int parsedLuckyNumber = int.Parse(luckyNumber);

            CultureInfo culture = new CultureInfo("de-DE");
            double temperature = double.Parse("30.7", culture);

            Console.WriteLine($"{parsedLuckyNumber} and temperature {temperature}");

            Console.ReadLine();

        }
        }
    
}