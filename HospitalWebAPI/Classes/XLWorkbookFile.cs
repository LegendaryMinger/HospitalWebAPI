using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Reflection;

namespace HospitalWebAPI.Classes
{
	public class XLWorkbookFile
	{
		public MemoryStream File {  get; set; }
		public string ContentType { get; set; }
		public string FileName { get; set; }
		public static XLWorkbookFile CreateXLFileSingleEntry<T>(List<T> entriesList)
		{
			var xlWorkbook = new XLWorkbook();
			AddXLWorksheet(entriesList, xlWorkbook);

			using (MemoryStream memoryStream = new MemoryStream())
			{
				xlWorkbook.SaveAs(memoryStream);
				XLWorkbookFile xlEntryFile = new XLWorkbookFile()
				{
					File = memoryStream,
					ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
					FileName = $"{typeof(T)}-{DateTime.Now}.xlsx"
				};
				return xlEntryFile;
			}
		}
		public static XLWorkbookFile CreateXLFileGlobalEntries<T>(List<List<T>> multipleEntriesList)
		{
			var xlWorkbook = new XLWorkbook();
			foreach (var entriesList in multipleEntriesList)
			{
				if (entriesList == null)
					continue;
				AddXLWorksheet(entriesList, xlWorkbook);
			}

			using (MemoryStream memoryStream = new MemoryStream())
			{
				xlWorkbook.SaveAs(memoryStream);
				XLWorkbookFile xlMultipleEntritsFile = new XLWorkbookFile()
				{
					File = memoryStream,
					ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
					FileName = $"Global-{DateTime.Now}.xlsx"
				};
				return xlMultipleEntritsFile;
			}
		}
		public static void AddXLWorksheet<T>(List<T> entriesList, XLWorkbook xlWorkbook)
		{
			var propertyList = entriesList.FirstOrDefault().GetType().GetProperties();
			var xlWorksheet = xlWorkbook.Worksheets.Add(entriesList.FirstOrDefault().GetType().Name);

			int columnsHeaderCount = 1;
			foreach (var property in propertyList)
			{
				xlWorksheet.Cell(1, columnsHeaderCount).SetValue(property.Name);
				columnsHeaderCount++;
			}
			xlWorksheet.Range(1, 1, 1, propertyList.Length).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
			xlWorksheet.Range(1, 1, 1, propertyList.Length).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);

			int rowsMainCount = 2;
			foreach (var entry in entriesList)
			{
				for (int i = 0; i < propertyList.Length; i++)
					xlWorksheet.Cell(rowsMainCount, i + 1).SetValue(propertyList[i].GetValue(entry).ToString());
				rowsMainCount++;
			}
			xlWorksheet.Range(2, 1, rowsMainCount - 1, propertyList.Length).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
			xlWorksheet.Range(2, 1, rowsMainCount - 1, propertyList.Length).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
		}
	}
}
