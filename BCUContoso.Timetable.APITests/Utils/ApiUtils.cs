using RestSharp;
using System.Text.Json;
using System;

public class ApiUtils
{
    private RestClient _client;
    private RestResponse _response;
    private JsonDocument _jsonResponse;

    public void SetClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public JsonDocument SendGetRequest(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        _response = _client.Execute<RestResponse>(request);
        LogResponse();
        if (!string.IsNullOrWhiteSpace(_response.Content))
            _jsonResponse = JsonDocument.Parse(_response.Content);
        return _jsonResponse;
    }

    public JsonDocument SendPutRequest(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Put);
        _response = _client.Execute<RestResponse>(request);
        LogResponse();
        if (!string.IsNullOrWhiteSpace(_response.Content))
            _jsonResponse = JsonDocument.Parse(_response.Content);
        return _jsonResponse;
    }

    public JsonDocument GetJsonResponse() => _jsonResponse;
    public RestResponse GetRawResponse() => _response;

    private void LogResponse()
    {
        Console.WriteLine($"Status Code: {_response.StatusCode}");
        Console.WriteLine($"Response: {_response.Content}");
        Console.WriteLine($"Error: {_response.ErrorMessage}");
    }
}
