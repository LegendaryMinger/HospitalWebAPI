using HospitalWebAPI.Classes;

namespace HospitalWebAPI.Interfaces
{
	public interface IGlobalService
	{
		Task<XLWorkbookFile> GetGlobalExcelFileAsync(CancellationToken cancellationToken);
	}
}
