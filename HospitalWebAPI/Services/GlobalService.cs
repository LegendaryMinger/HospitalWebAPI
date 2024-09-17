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
			var appointments = await _context.Appointment.ToListAsync(cancellationToken);
			var appointmentDiseases = await _context.AppointmentDisease.ToListAsync(cancellationToken);
			var comments = await _context.Comment.ToListAsync(cancellationToken);
			var departments = await _context.Department.ToListAsync(cancellationToken);
			var diseases = await _context.Disease.ToListAsync(cancellationToken);
			var employees = await _context.Employee.ToListAsync(cancellationToken);
			var equipment = await _context.Equipment.ToListAsync(cancellationToken);
			var gender = await _context.Gender.ToListAsync(cancellationToken);
			var history = await _context.History.ToListAsync(cancellationToken);
			var instructions = await _context.Instruction.ToListAsync(cancellationToken);
			var patients = await _context.Patient.ToListAsync(cancellationToken);
			var payments = await _context.Payment.ToListAsync(cancellationToken);
			var services = await _context.Service.ToListAsync(cancellationToken);

			var multipleEntriesList = new List<List<object>>
		{
				appointments.Cast<object>().ToList(),
				appointmentDiseases.Cast<object>().ToList(),
				comments.Cast<object>().ToList(),
				departments.Cast<object>().ToList(),
				diseases.Cast<object>().ToList(),
				employees.Cast<object>().ToList(),
				equipment.Cast<object>().ToList(),
				gender.Cast<object>().ToList(),
				history.Cast<object>().ToList(),
				instructions.Cast<object>().ToList(),
				patients.Cast<object>().ToList(),
				payments.Cast<object>().ToList(),
				services.Cast<object>().ToList(),
		};

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

			XLWorkbookFile xlEntryFile = new XLWorkbookFile()
			{
				File = XLWorkbookFile.CreateXLFileGlobalEntries(multipleEntriesList),
				ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
				FileName = $"Global-{DateTime.Now}.xlsx"
			};

			return xlEntryFile;
		}
	}
}