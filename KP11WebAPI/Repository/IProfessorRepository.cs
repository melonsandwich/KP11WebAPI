using KP11.Integration.Models;

namespace KP11WebAPI;

public interface IProfessorRepository
{
    Task<List<Professor>> GetProfessorsAsync();
    Task<Professor> GetProfessorAsync(int professorID);
    Task AddProfessorAsync(Professor professor);
    Task UpdateProfessorAsync(Professor professor);
    Task DeleteProfessorAsync(int professorID);
    Task SaveAsync();
}