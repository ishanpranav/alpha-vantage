using RestSharp;
using RestSharp.Serializers.CsvHelper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaVantageCore;

public sealed class AlphaVantageClient : IDisposable
{
    private const string FunctionParameter = "function";

    private readonly CsvHelperSerializer _serializer = new CsvHelperSerializer();
    private readonly string _apiKey;

    private RestClient? _restClient;

    public AlphaVantageClient(string apiKey)
    {
        _restClient = new RestClient(CreateRestClientOptions());
        _apiKey = apiKey;
    }

    public AlphaVantageClient(HttpClient client, string apiKey)
    {
        _restClient = new RestClient(client, CreateRestClientOptions());
        _apiKey = apiKey;
    }

    private static RestClientOptions CreateRestClientOptions()
    {
        return new RestClientOptions("https://www.alphavantage.co");
    }

    public Task<IReadOnlyList<AlphaVantageTimeSeriesResponse>> GetIntradayTimeSeriesAsync(AlphaVantageIntradayTimeSeriesRequest request)
    {
        RestRequest restRequest = CreateRequest();

        restRequest.AddObject(request);
        restRequest.AddQueryParameter(FunctionParameter, "TIME_SERIES_INTRADAY");

        return ExecuteRequestAsync<AlphaVantageTimeSeriesResponse>(restRequest);
    }

    public Task<IReadOnlyList<AlphaVantageTimeSeriesResponse>> GetTimeSeriesAsync(AlphaVantageTimeSeries timeSeries, AlphaVantageTimeSeriesRequest request)
    {
        RestRequest restRequest = CreateRequest();

        restRequest.AddObject(request);
        restRequest.AddQueryParameter(FunctionParameter, timeSeries.ToString());

        return ExecuteRequestAsync<AlphaVantageTimeSeriesResponse>(restRequest);
    }

    public async Task<AlphaVantageQuoteResponse> GetQuoteAsync(AlphaVantageRequest request)
    {
        RestRequest restRequest = CreateRequest();

        restRequest.AddObject(request);
        restRequest.AddQueryParameter(FunctionParameter, "GLOBAL_QUOTE");

        IReadOnlyList<AlphaVantageQuoteResponse> response = await ExecuteRequestAsync<AlphaVantageQuoteResponse>(restRequest);

        return response[0];
    }

    public Task<IReadOnlyList<AlphaVantageSearchResponse>> SearchAsync(string keywords)
    {
        RestRequest restRequest = CreateRequest();

        restRequest.AddQueryParameter("keywords", keywords);
        restRequest.AddQueryParameter(FunctionParameter, "SYMBOL_SEARCH");

        return ExecuteRequestAsync<AlphaVantageSearchResponse>(restRequest);
    }

    private RestRequest CreateRequest()
    {
        RestRequest restRequest = new RestRequest("query");

        restRequest.AddHeader(KnownHeaders.Accept, "*/*");
        restRequest.AddQueryParameter("apikey", _apiKey);
        restRequest.AddQueryParameter("datatype", "csv");

        return restRequest;
    }

    private async Task<IReadOnlyList<TResponse>> ExecuteRequestAsync<TResponse>(RestRequest request)
    {
        if (_restClient == null)
        {
            throw new InvalidOperationException();
        }

        RestResponse restResponse = await _restClient.GetAsync(request);
        List<TResponse>? result = _serializer.Deserialize<List<TResponse>>(restResponse);

        if (result == null)
        {
            throw new Exception();
        }

        return result;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_restClient != null)
            {
                _restClient.Dispose();

                _restClient = null;
            }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
