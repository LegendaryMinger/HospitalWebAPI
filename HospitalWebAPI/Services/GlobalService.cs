using AutoMapper;
using HospitalWebAPI.Classes;
using HospitalWebAPI.Contexts;
using HospitalWebAPI.Interfaces;
using HospitalWebAPI.Middlewares.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebAPI.Services
{
	public class GlobalService : IGlobalService
	{
		private readonly HospitalContext _context;
		public GlobalService(HospitalContext context)
		{
			_context = context;
		}
		public async Task<XLWorkbookFile> GetGlobalExcelFileAsync(CancellationToken cancellationToken)
		{
			var multipleEntriesList = new List<List<object>>();

			multipleEntriesList.Add((await _context.AppointmentDisease.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Comment.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Department.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Disease.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Employee.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Equipment.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Gender.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.History.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Instruction.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Patient.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Payment.ToListAsync(cancellationToken)).Cast<object>().ToList());
			multipleEntriesList.Add((await _context.Service.ToListAsync(cancellationToken)).Cast<object>().ToList());

			bool isAllEntriesListsNull = true;
			foreach (var entriesList in multipleEntriesList)
			{
				if (entriesList.Count != 0)
				{
					isAllEntriesListsNull = false;
					break;
				}
			}
			if (isAllEntriesListsNull)
				throw new EntryIsNullException();

			return XLWorkbookFile.CreateXLFileGlobalEntries(multipleEntriesList);
		}

		//var contextDbSets = _context.Model.GetEntityTypes();
		//foreach (var contextDbSet in contextDbSets)
		//{
		//	var dbSetType = contextDbSet.ClrType;
		//	var dbSetMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes).MakeGenericMethod(dbSetType);
		//	var dbSetModel = dbSetMethod.Invoke(_context, null) as IQueryable;

		//	var test = dbSetModel.GetType().GetProperties();
	}
}