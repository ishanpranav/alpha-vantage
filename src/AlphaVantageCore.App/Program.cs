// Program.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlphaVantageCore.App;

internal static class Program
{
    private static async Task Main()
    {
        string? apiKey = Environment.GetEnvironmentVariable("API_KEY");

        if (apiKey == null)
        {
            throw new Exception();
        }

        using AlphaVantageClient client = new AlphaVantageClient(apiKey);

        var response = await client.GetTimeSeriesAsync(
            AlphaVantageAdjustedTimeSeries.Daily,
            new AlphaVantageTimeSeriesRequest()
            {
                OutputSize = AlphaVantageOutputSize.Compact,
                Symbol = "QQQ"
            });

        using FileStream output = File.Create("qqq.json");

        await JsonSerializer.SerializeAsync(output, response, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
    }
}
