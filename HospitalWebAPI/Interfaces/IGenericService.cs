namespace HospitalWebAPI.Interfaces
{
	public interface IGenericService<T>
	{
		Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
		Task<T> GetEntryByIdAsync(int id, CancellationToken cancellationToken);
		Task<T> CreateEntryAsync(T entry, CancellationToken cancellationToken);
		Task<T> UpdateEntryAsync(T entry, CancellationToken cancellationToken);
		Task DeleteEntryAsync(int id, CancellationToken cancellationToken);
	}
}
