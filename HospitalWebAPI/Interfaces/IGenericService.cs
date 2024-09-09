namespace HospitalWebAPI.Interfaces
{
	public interface IGenericService<T>
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetEntryByIdAsync(int id);
		Task CreateEntryAsync(T entry);
		Task UpdateEntryAsync(T entry);
		Task DeleteEntryAsync(int id);
	}
}
