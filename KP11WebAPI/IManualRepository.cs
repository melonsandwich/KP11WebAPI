using KP11WebAPI.Models;

namespace KP11WebAPI;

public interface IManualRepository
{
    Task<List<Manual>> GetManualsAsync();
    Task<List<Manual>> GetManualsAsync(string query);
    Task<Manual> GetManualAsync(int manualID);
    Task AddManualAsync(Manual manual);
    Task UpdateManualAsync(Manual manual);
    Task DeleteManualAsync(int manualID);
    Task SaveAsync();
}