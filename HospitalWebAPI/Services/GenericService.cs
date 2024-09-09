using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebAPI.Services
{
	public class GenericService<T> : IGenericService<T> where T : class
	{
		private readonly HospitalContext _context;
		private readonly DbSet<T> _dbSet;
		public GenericService(HospitalContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}
		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}
		public async Task<T> GetEntryByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}
		public async Task CreateEntryAsync(T entry)
		{
			await _dbSet.AddAsync(entry);
			await _context.SaveChangesAsync();
		}
		public async Task UpdateEntryAsync(T entry)
		{
			_dbSet.Update(entry);
			await _context.SaveChangesAsync();
		}
		public async Task DeleteEntryAsync(int id)
		{
			var entry = await _dbSet.FindAsync(id);
			if (entry != null)
			{
				_dbSet.Remove(entry);
				await _context.SaveChangesAsync();
			}
		}
	}
}
