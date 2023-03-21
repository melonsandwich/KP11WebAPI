using KP11WebAPI.Auth;
using KP11WebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace KP11WebAPI.APIs;

public class ManualAPI : IAPI
{
    public void Register(WebApplication app)
    {
        app.MapGet("/manuals", GetAll)
            .Produces<List<Manual>>()
            .WithName("GetAllManuals")
            .WithTags("GET");

        app.MapGet("/manuals/search/name/{query}", Search)
            .Produces<List<Manual>>()
            .Produces(StatusCodes.Status404NotFound)
            .WithName("SearchManuals")
            .WithTags("GET");

        app.MapGet("/manuals/{id:int}", GetByID)
            .Produces<Manual>()
            .WithName("GetManual")
            .WithTags("GET");

        app.MapPost("/manuals", Add)
            .Accepts<Manual>("application/json")
            .Produces<Manual>(StatusCodes.Status201Created)
            .WithName("CreateManual")
            .WithName("POST");

        app.MapPut("/manuals", Update)
            .Accepts<Manual>("application/json")
            .WithName("UpdateManual")
            .WithName("PUT");

        app.MapDelete("manuals/{id:int}", Delete)
            .WithName("DeleteManual")
            .WithTags("DELETE");
    }

    [AllowAnonymous]
    private static async Task<IResult> GetAll(IManualRepository repository)
    {
        return Results.Ok(await repository.GetManualsAsync());
    }
    
    [Authorize]
    private static async Task<IResult> Search(string query, IManualRepository repository)
    {
        return await repository.GetManualsAsync(query) is IEnumerable<Manual> manuals
            ? Results.Ok(manuals)
            : Results.NotFound(Array.Empty<Manual>());
    }
    
    [Authorize]
    private static async Task<IResult> GetByID(int id, IManualRepository repository)
    {
        return await repository.GetManualAsync(id) is { } manual
            ? Results.Ok(manual)
            : Results.NotFound();
    }
    
    [Authorize]
    private static async Task<IResult> Add([FromBody] Manual manual, IManualRepository repository)
    {
        await repository.AddManualAsync(manual);
        await repository.SaveAsync();
        return Results.Created($"/manuals/{manual.ID}", manual);
    }
    
    [Authorize]
    private static async Task<IResult> Update([FromBody] Manual manual, IManualRepository repository)
    {
        await repository.UpdateManualAsync(manual);
        await repository.SaveAsync();
        return Results.NoContent();
    }
    
    [Authorize]
    private static async Task<IResult> Delete(int id, IManualRepository repository)
    {
        await repository.DeleteManualAsync(id);
        await repository.SaveAsync();
        return Results.NoContent();
    }
}