using KP11.Integration.Models;
using Microsoft.AspNetCore.Authorization;

namespace KP11WebAPI.APIs;

public class ProfessorAPI : IAPI
{
    public void Register(WebApplication app)
    {
        app.MapGet("/professors/get-all", GetAllProfessors)
            .Produces<List<Professor>>()
            .WithName("GetAllProfessors")
            .WithTags("GET");

        app.MapGet("/professors/get/{id:int}", GetProfessorByID)
            .Produces<Professor>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetProfessor")
            .WithTags("GET");

        app.MapPost("/professors/add", AddProfessor)
            .Accepts<Professor>("application/json")
            .Produces<Professor>(StatusCodes.Status201Created)
            .WithName("CreateProfessor")
            .WithTags("POST");

        app.MapPut("/professors/update", UpdateProfessor)
            .Accepts<Professor>("application/json")
            .WithName("UpdateProfessor")
            .WithTags("PUT");

        app.MapDelete("/professors/delete/{id:int}", DeleteProfessor)
            .WithName("DeleteProfessor")
            .WithTags("DELETE");
    }
    
    [AllowAnonymous]
    private static async Task<IResult> GetAllProfessors(IProfessorRepository repository)
    {
        return Results.Ok(await repository.GetProfessorsAsync());
    }
    
    [AllowAnonymous]
    private static async Task<IResult> GetProfessorByID(int id, IProfessorRepository repository)
    {
        return await repository.GetProfessorAsync(id) is { } professor
            ? Results.Ok(professor)
            : Results.NotFound();
    }
    
    [Authorize]
    private static async Task<IResult> AddProfessor([FromBody] Professor professor, IProfessorRepository repository)
    {
        await repository.AddProfessorAsync(professor);
        await repository.SaveAsync();
        return Results.Created($"/professors/{professor.ID}", professor);
    }
    
    [Authorize]
    private static async Task<IResult> UpdateProfessor([FromBody] Professor professor, IProfessorRepository repository)
    {
        await repository.UpdateProfessorAsync(professor);
        await repository.SaveAsync();
        return Results.NoContent();
    }
    
    [Authorize]
    private static async Task<IResult> DeleteProfessor(int id, IProfessorRepository repository)
    {
        await repository.DeleteProfessorAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}