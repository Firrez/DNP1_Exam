using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace WebAPI.DataAccess
{
    public class KinderGardenContext : DbContext
    {
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = KinderGarden.db");
        }

        public async Task AddChildAsync(Child child)
        {
            await Children.AddAsync(child);
            await SaveChangesAsync();
        }

        public async Task<List<Child>> GetAllChildrenAsync()
        {
            List<Child> list = await Children.Include(c => c.Toys).ToListAsync();
            return list;
        }

        public async Task AddToyAsync(string childName, Toy toy)
        {
            Child child = await Children
                .Include(c => c.Toys)
                .FirstAsync(c => c.Name.Equals(childName));
            
            child.Toys.Add(toy);
            Toys.Add(toy);
            await SaveChangesAsync();
        }

        public async Task RemoveToyAsync(string toyId)
        {
            Toy toyToRemove = await Toys.FirstAsync(t => t.Name.Equals(toyId));
            Toys.Remove(toyToRemove);
            await SaveChangesAsync();
        }
    }
}