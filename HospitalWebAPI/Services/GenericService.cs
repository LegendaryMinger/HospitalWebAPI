using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using HospitalWebAPI.Classes;
using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Middlewares.Exceptions;
using HospitalWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

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
			return await _dbSet.ToListAsync(cancellationToken);
		}
		public async Task<XLWorkbookFile> GetAllExcelFileAsync(CancellationToken cancellationToken)
		{
			var entriesList = await _dbSet.ToListAsync();
			if (entriesList.Count == 0)
				throw new EntryIsNullException();

			XLWorkbookFile xlEntryFile = new XLWorkbookFile() 
			{ 
				File = XLWorkbookFile.CreateXLFileSingleEntry(entriesList), 
				ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
				FileName = $"{typeof(T).Name}-{DateTime.Now}.xlsx" 
			};

			return xlEntryFile;
		}
		public async Task<T> GetEntryByIdAsync(int id, CancellationToken cancellationToken)
		{
			if (id == 0)
				throw new ArgumentException();

			return await _dbSet.FindAsync(id, cancellationToken);
		}
		public async Task<T> CreateEntryAsync(T entry, CancellationToken cancellationToken)
		{
			if (entry == null)
				throw new ArgumentNullException();

			await _dbSet.AddAsync(entry);
			await _context.SaveChangesAsync(cancellationToken);
			return entry;
		}
		public async Task<T> UpdateEntryAsync(T entry, CancellationToken cancellationToken)
		{
			if (entry == null)
				throw new ArgumentNullException();

			_dbSet.Update(entry);
			await _context.SaveChangesAsync(cancellationToken);
			return entry;
		}
		public async Task DeleteEntryAsync(int id, CancellationToken cancellationToken)
		{
			if (id == 0)
				throw new ArgumentException();

			var entry = Activator.CreateInstance<T>();
			typeof(T).GetProperty("Id").SetValue(entry, id);

			_dbSet.Entry(entry).State = EntityState.Deleted;
			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
