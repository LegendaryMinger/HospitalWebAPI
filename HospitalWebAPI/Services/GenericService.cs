using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Models;
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
		public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
		{
			try
			{
				return await _dbSet.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
		public async Task<T> GetEntryByIdAsync(int id, CancellationToken cancellationToken)
		{
			if (id == 0)
				throw new ArgumentNullException();

			try
			{
				return await _dbSet.FindAsync(id);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
		public async Task<T> CreateEntryAsync(T entry, CancellationToken cancellationToken)
		{
			if (entry == null)
				throw new ArgumentNullException(nameof(entry));

			try
			{
				await _dbSet.AddAsync(entry);
				await _context.SaveChangesAsync();
				return entry;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
		public async Task<T> UpdateEntryAsync(T entry, CancellationToken cancellationToken)
		{
			if (entry == null)
				throw new ArgumentNullException(nameof(entry));

			try
			{
				_dbSet.Update(entry);
				await _context.SaveChangesAsync();
				return entry;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
		public async Task DeleteEntryAsync(int id, CancellationToken cancellationToken)
		{
			if (id == 0)
				throw new ArgumentNullException();

			try
			{
				var entry = Activator.CreateInstance<T>();
				typeof(T).GetProperty("Id").SetValue(entry, id);

				_dbSet.Entry(entry).State = EntityState.Deleted;
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}
	}
}
