using KP11.Integration.Models;

namespace KP11.Integration;

public static class KP11ClientExtensions
{
    public static async Task<List<Manual>> Manuals_GetAll(this KP11Client client)
    {
        return await API.Manuals.GetAll(client.HttpClient);
    }
    
    public static async Task<Manual> Manuals_Get(this KP11Client client, int id)
    {
        return await API.Manuals.Get(client.HttpClient, id);
    }
    
    public static async Task<List<Manual>> Manuals_GetAllOfSubject(this KP11Client client, int subjectID)
    {
        return await API.Manuals.GetAllOfSubject(client.HttpClient, subjectID);
    }
    
    public static async Task<List<Manual>> Manuals_GetAllOfSubject(this KP11Client client, Subject subject)
    {
        return await API.Manuals.GetAllOfSubject(client.HttpClient, subject);
    }
    
    public static async Task<Manual> Manuals_Add(this KP11Client client, Manual manual)
    {
        return await API.Manuals.Add(client.HttpClient, manual);
    }
    
    public static async Task Manuals_Update(this KP11Client client, Manual manual)
    {
        await API.Manuals.Update(client.HttpClient, manual);
    }
    
    public static async Task Manuals_Delete(this KP11Client client, int id)
    {
        await API.Manuals.Delete(client.HttpClient, id);
    }
}