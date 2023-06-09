﻿using System.Net;
using System.Text;
using KP11.Integration.Models;
using Newtonsoft.Json;

namespace KP11.Integration;

public static class API
{
    public static class Auth
    {
        public static async Task<string> Authorize(HttpClient client, string login, string password)
        {
            string result = string.Empty;
            try
            {
                result = await GetAsync(client, $"/auth?login={login}&password={password}");
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return string.Empty;
                }
            }

            string token = result.Substring(1, result.Length - 1);
            result = token.Remove(token.Length - 1, 1);
            
            return result ?? throw new Exception("Authorization unsuccessful!");
        }
    }
    
    public static class Manuals
    {
        public static async Task<Manual> Get(HttpClient client, int id)
        {
            string result = await GetAsync(client, $"/manuals/get/{id}");

            return JsonConvert.DeserializeObject<Manual>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<List<Manual>> GetAll(HttpClient client)
        {
            string result = await GetAsync(client, "/manuals/get-all");

            return JsonConvert.DeserializeObject<List<Manual>>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<List<Manual>> GetAllOfSubject(HttpClient client, int subjectID)
        {
            string result = await GetAsync(client, $"/manuals/subject/{subjectID}");

            return JsonConvert.DeserializeObject<List<Manual>>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<List<Manual>> GetAllOfSubject(HttpClient client, Subject subject)
        {
            return await GetAllOfSubject(client, subject.ID);
        }
        
        public static async Task<Manual> Add(HttpClient client, Manual manual)
        {
            string result = await PostAsync(client, "/manuals/add", JsonConvert.SerializeObject(manual));

            return JsonConvert.DeserializeObject<Manual>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task Update(HttpClient client, Manual manual)
        {
            await PutAsync(client, "/manuals/update", JsonConvert.SerializeObject(manual));
        }
        
        public static async Task Delete(HttpClient client, int id)
        {
            await DeleteAsync(client, $"/manuals/delete/{id}");
        }
    }

    public static class Subjects
    {
        public static async Task<Subject> Get(HttpClient client, int id)
        {
            string result = await GetAsync(client, $"/subjects/get/{id}");

            return JsonConvert.DeserializeObject<Subject>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<List<Subject>> GetAll(HttpClient client)
        {
            string result = await GetAsync(client, "/subjects/get-all");

            return JsonConvert.DeserializeObject<List<Subject>>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<List<Subject>> GetAllOfProfessor(HttpClient client, int professorID)
        {
            string result = await GetAsync(client, $"/subjects/professor/{professorID}");

            return JsonConvert.DeserializeObject<List<Subject>>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<int> GetSubjectsManualAmount(HttpClient client, int id)
        {
            string result = await GetAsync(client, $"/subjects/{id}/manual-amount");

            return JsonConvert.DeserializeObject<SubjectManualAmountResponse>(result)?.Amount ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<List<Subject>> GetAllOfProfessor(HttpClient client, Professor professor)
        {
            return await GetAllOfProfessor(client, professor.ID);
        }
        
        public static async Task<Subject> Add(HttpClient client, Subject subject)
        {
            string result = await PostAsync(client, "/subjects/add", JsonConvert.SerializeObject(subject));

            return JsonConvert.DeserializeObject<Subject>(result) ?? throw new Exception("Unable to return a model!");
        }

        public static async Task Update(HttpClient client, Subject subject)
        {
            await PutAsync(client, "/subjects/update", JsonConvert.SerializeObject(subject));
        }
        
        public static async Task Delete(HttpClient client, int id)
        {
            await DeleteAsync(client, $"/subjects/delete/{id}");
        }
    }

    public static class Professors
    {
        public static async Task<Professor> Get(HttpClient client, int id)
        {
            string result = await GetAsync(client, $"/professors/get/{id}");

            return JsonConvert.DeserializeObject<Professor>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<List<Professor>> GetAll(HttpClient client)
        {
            string result = await GetAsync(client, "/professors/get-all");

            return JsonConvert.DeserializeObject<List<Professor>>(result) ?? throw new Exception("Unable to return a model!");
        }

        public static async Task<Professor> Add(HttpClient client, Professor professor)
        {
            string result = await PostAsync(client, "/professors/add", JsonConvert.SerializeObject(professor));

            return JsonConvert.DeserializeObject<Professor>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task<Professor> Update(HttpClient client, Professor professor)
        {
            string result = await PutAsync(client, "/professors/update", JsonConvert.SerializeObject(professor));

            return JsonConvert.DeserializeObject<Professor>(result) ?? throw new Exception("Unable to return a model!");
        }
        
        public static async Task Delete(HttpClient client, int id)
        {
            await DeleteAsync(client, $"/professors/delete/{id}");
        }
    }
    
    public static async Task<string> GetAsync(HttpClient client, string url)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, client.BaseAddress + url);
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<string> PostAsync(HttpClient client, string url, string body)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, client.BaseAddress + url);
        StringContent bodyContent = new(body, Encoding.UTF8, "application/json");
        bodyContent.Headers.ContentType = new("application/json");
        
        HttpResponseMessage response = await client.PostAsync(url, bodyContent);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }
    
    public static async Task<string> PutAsync(HttpClient client, string url, string body)
    {
        using HttpRequestMessage requestMessage = new(HttpMethod.Put, client.BaseAddress + url);
        StringContent bodyContent = new(body, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, bodyContent);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
    
    public static async Task<string> DeleteAsync(HttpClient client, string url)
    {
        using HttpRequestMessage request = new(HttpMethod.Delete, client.BaseAddress + url);
        HttpResponseMessage response = await client.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadAsStringAsync();
    }

    private static HttpRequestMessage ProcessRequestHeaders(HttpMethod method, string url)
    {
        HttpRequestMessage request = new HttpRequestMessage(method, url);
        request.Headers.Connection.Add("keep-alive");
        return request;
    }
}