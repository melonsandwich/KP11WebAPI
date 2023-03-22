using KP11.Integration.Models;

namespace KP11WebAPI;

public interface ISubjectRepository
{
    Task<List<Subject>> GetSubjectsAsync();
    Task<List<Subject>> GetAllSubjectsOfProfessor(int professorID);
    Task<Subject> GetSubjectAsync(int subjectID);
    Task AddSubjectAsync(Subject subject);
    Task UpdateSubjectAsync(Subject subject);
    Task DeleteSubjectAsync(int subjectID);
    Task SaveAsync();
}