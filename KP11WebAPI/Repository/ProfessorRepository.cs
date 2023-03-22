using KP11.Integration.Models;

namespace KP11WebAPI;

public class ProfessorRepository : IProfessorRepository, IDisposable
{
    private readonly ManualDb _context;

    public ProfessorRepository(ManualDb context)
    {
        _context = context;
    }
    
    public Task<List<Professor>> GetProfessorsAsync()
    {
        return _context.Professors.ToListAsync();
    }

    public async Task<Professor> GetProfessorAsync(int professorID)
    {
        return (await _context.Professors.FindAsync(professorID))!;
    }

    public async Task AddProfessorAsync(Professor professor)
    {
        await _context.Professors.AddAsync(professor);
    }

    public async Task UpdateProfessorAsync(Professor professor)
    {
        Professor? professorFromDb = await _context.Professors.FindAsync(professor.ID);
        if (professorFromDb == null)
            return;

        professorFromDb.Name = professor.Name;
        professorFromDb.Occupation = professor.Occupation;
        professorFromDb.ImageURL = professor.ImageURL;
        professorFromDb.AlmaMater = professor.AlmaMater;
        professorFromDb.Speciality = professor.Speciality;
        professorFromDb.WorkExperience = professor.WorkExperience;
        professorFromDb.Email = professor.Email;
        professorFromDb.Phone = professor.Phone;
    }

    public async Task DeleteProfessorAsync(int professorID)
    {
        Professor? professorFromDb = await _context.Professors.FindAsync(professorID);
        if (professorFromDb == null)
            return;

        _context.Professors.Remove(professorFromDb);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _context.Dispose();
        }
    }
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}