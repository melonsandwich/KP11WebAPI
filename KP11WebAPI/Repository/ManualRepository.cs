using KP11.Integration.Models;

namespace KP11WebAPI;

public class ManualRepository : IManualRepository, IDisposable
{
    private readonly ManualDb _context;

    public ManualRepository(ManualDb context)
    {
        _context = context;
    }
    
    public Task<List<Manual>> GetManualsAsync()
    {
        return _context.Manuals.ToListAsync();
    }

    public Task<List<Manual>> GetManualsAsync(string query)
    {
        return _context.Manuals.Where(m => m.Name.Contains(query)).ToListAsync();
    }

    public async Task<Manual> GetManualAsync(int manualID)
    {
        return (await _context.Manuals.FindAsync(manualID))!;
    }

    public Task<List<Manual>> GetAllManualsOfSubject(int subjectID)
    {
        return _context.Manuals.Where(m => m.SubjectID == subjectID).ToListAsync();
    }

    public async Task AddManualAsync(Manual manual)
    {
        await _context.Manuals.AddAsync(manual);
    }

    public async Task UpdateManualAsync(Manual manual)
    {
        Manual? manualFromDb = await _context.Manuals.FindAsync(manual.ID);
        if (manualFromDb == null)
            return;

        manualFromDb.Name = manual.Name;
        manualFromDb.SubjectID = manual.SubjectID;
        manualFromDb.ContentLink = manual.ContentLink;
    }

    public async Task DeleteManualAsync(int manualID)
    {
        Manual? manualFromDb = await _context.Manuals.FindAsync(manualID);
        if (manualFromDb == null)
            return;

        _context.Manuals.Remove(manualFromDb);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}