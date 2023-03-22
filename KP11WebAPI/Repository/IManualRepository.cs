using KP11.Integration.Models;

namespace KP11WebAPI;

public interface IManualRepository
{
    Task<List<Manual>> GetManualsAsync();
    Task<List<Manual>> GetManualsAsync(string query);
    Task<List<Manual>> GetAllManualsOfSubject(int subjectID);
    Task<Manual> GetManualAsync(int manualID);
    Task AddManualAsync(Manual manual);
    Task UpdateManualAsync(Manual manual);
    Task DeleteManualAsync(int manualID);
    Task SaveAsync();
}