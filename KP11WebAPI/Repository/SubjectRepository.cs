using KP11.Integration.Models;

namespace KP11WebAPI;

public class SubjectRepository : ISubjectRepository, IDisposable
{
    private readonly ManualDb _context;

    public SubjectRepository(ManualDb context)
    {
        _context = context;
    }
    
    public Task<List<Subject>> GetSubjectsAsync()
    {
        return _context.Subjects.ToListAsync();
    }

    public Task<List<Subject>> GetAllSubjectsOfProfessor(int professorID)
    {
        return _context.Subjects.Where(s => s.ProfessorID == professorID).ToListAsync();
    }

    public async Task<Subject> GetSubjectAsync(int subjectID)
    {
        return (await _context.Subjects.FindAsync(subjectID))!;
    }

    public async Task AddSubjectAsync(Subject subject)
    {
        await _context.Subjects.AddAsync(subject);
    }

    public async Task UpdateSubjectAsync(Subject subject)
    {
        Subject? subjectFromDb = await _context.Subjects.FindAsync(subject.ID);
        if (subjectFromDb == null)
            return;

        subjectFromDb.Name = subject.Name;
        subjectFromDb.ProfessorID = subject.ProfessorID;
    }

    public async Task DeleteSubjectAsync(int subjectID)
    {
        Subject? subjectFromDb = await _context.Subjects.FindAsync(subjectID);
        if (subjectFromDb == null)
            return;

        _context.Subjects.Remove(subjectFromDb);
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