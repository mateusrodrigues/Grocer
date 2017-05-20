using Grocer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grocer.Data.Repository
{
    public class ItemsRepository
    {
        private readonly GrocerDbContext _context;

        public ItemsRepository()
        {
            _context = new GrocerDbContext();
        }

        public async Task<List<Item>> All()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> Find(Guid id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task Delete(Item item)
        {
            _context.Items.Remove(item);

            await _context.SaveChangesAsync();
        }
    }
}
