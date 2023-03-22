using KP11.Integration.Models;
using Microsoft.AspNetCore.Authorization;

namespace KP11WebAPI.APIs;

public class SubjectAPI : IAPI
{
    public void Register(WebApplication app)
    {
        app.MapGet("/subjects/get-all", GetAllSubjects)
            .Produces<List<Subject>>()
            .WithName("GetAllSubjects")
            .WithTags("GET");

        app.MapGet("/subjects/professor/{professorID:int}", GetAllSubjectsOfProfessor)
            .Produces<List<Subject>>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetAllSubjectsOfProfessor")
            .WithTags("GET");

        app.MapGet("/subjects/get/{id:int}", GetSubjectByID)
            .Produces<Subject>()
            .WithName("GetSubject")
            .WithTags("GET");

        app.MapPost("/subjects/add", AddSubject)
            .Accepts<Subject>("application/json")
            .Produces<Subject>(StatusCodes.Status201Created)
            .WithName("CreateSubject")
            .WithTags("POST");

        app.MapDelete("/manuals/delete/{id:int}", DeleteSubject)
            .WithName("DeleteSubject")
            .WithTags("DELETE");
    }

    [AllowAnonymous]
    private static async Task<IResult> GetAllSubjects(ISubjectRepository repository)
    {
        return Results.Ok(await repository.GetSubjectsAsync());
    }
    
    [AllowAnonymous]
    private static async Task<IResult> GetAllSubjectsOfProfessor(int professorID, ISubjectRepository repository)
    {
        return await repository.GetAllSubjectsOfProfessor(professorID) is IEnumerable<Subject> subjects
            ? Results.Ok(subjects)
            : Results.NotFound(Array.Empty<Manual>());
    }
    
    [AllowAnonymous]
    private static async Task<IResult> GetSubjectByID(int id, ISubjectRepository repository)
    {
        return await repository.GetSubjectAsync(id) is { } subject
            ? Results.Ok(subject)
            : Results.NotFound();
    }
    
    [Authorize]
    private static async Task<IResult> AddSubject([FromBody] Subject subject, ISubjectRepository repository)
    {
        await repository.AddSubjectAsync(subject);
        await repository.SaveAsync();
        return Results.Created($"/subjects/{subject.ID}", subject);
    }
    
    [Authorize]
    private static async Task<IResult> DeleteSubject(int id, ISubjectRepository repository)
    {
        await repository.DeleteSubjectAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}