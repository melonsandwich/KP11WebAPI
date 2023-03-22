using KP11.Integration.Models;
using Microsoft.AspNetCore.Authorization;

namespace KP11WebAPI.APIs;

public class ManualAPI : IAPI
{
    public void Register(WebApplication app)
    {
        app.MapGet("/manuals/get-all", GetAllManuals)
            .Produces<List<Manual>>()
            .WithName("GetAllManuals")
            .WithTags("GET");

        app.MapGet("/manuals/search/name/{query}", SearchManuals)
            .Produces<List<Manual>>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchManuals")
            .WithTags("GET");

        app.MapGet("/manuals/get/{id:int}", GetManualByID)
            .Produces<Manual>()
            .WithName("GetManual")
            .WithTags("GET");
        
        app.MapGet("/manuals/subject/{subjectID:int}", GetAllManualsOfSubject)
            .Produces<List<Manual>>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetAllManualsOfSubject")
            .WithTags("GET");

        app.MapPost("/manuals/add", AddManual)
            .Accepts<Manual>("application/json")
            .Produces<Manual>(StatusCodes.Status201Created)
            .WithName("CreateManual")
            .WithName("POST");

        app.MapPut("/manuals/update", UpdateManual)
            .Accepts<Manual>("application/json")
            .WithName("UpdateManual")
            .WithName("PUT");

        app.MapDelete("/manuals/delete/{id:int}", DeleteManual)
            .WithName("DeleteManual")
            .WithTags("DELETE");
    }

    [AllowAnonymous]
    private static async Task<IResult> GetAllManuals(IManualRepository repository)
    {
        return Results.Ok(await repository.GetManualsAsync());
    }
    
    [AllowAnonymous]
    private static async Task<IResult> GetAllManualsOfSubject(int subjectID, IManualRepository repository)
    {
        return await repository.GetAllManualsOfSubject(subjectID) is IEnumerable<Manual> manuals
            ? Results.Ok(manuals)
            : Results.NotFound(Array.Empty<Manual>());
    }
    
    [AllowAnonymous]
    private static async Task<IResult> SearchManuals(string query, IManualRepository repository)
    {
        return await repository.GetManualsAsync(query) is IEnumerable<Manual> manuals
            ? Results.Ok(manuals)
            : Results.NotFound(Array.Empty<Manual>());
    }
    
    [AllowAnonymous]
    private static async Task<IResult> GetManualByID(int id, IManualRepository repository)
    {
        return await repository.GetManualAsync(id) is { } manual
            ? Results.Ok(manual)
            : Results.NotFound();
    }
    
    [Authorize]
    private static async Task<IResult> AddManual([FromBody] Manual manual, IManualRepository repository)
    {
        await repository.AddManualAsync(manual);
        await repository.SaveAsync();
        return Results.Created($"/manuals/{manual.ID}", manual);
    }
    
    [Authorize]
    private static async Task<IResult> UpdateManual([FromBody] Manual manual, IManualRepository repository)
    {
        await repository.UpdateManualAsync(manual);
        await repository.SaveAsync();
        return Results.NoContent();
    }
    
    [Authorize]
    private static async Task<IResult> DeleteManual(int id, IManualRepository repository)
    {
        await repository.DeleteManualAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}