// Program.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
            new AlphaVantageIntradayTimeSeriesRequest()
            {
                OutputSize = AlphaVantageOutputSize.Full,
                Symbol = "QQQ",
                Interval = AlphaVantageInterval.Minute
            });

        File.WriteAllText("qqq-time-series.json", response[0].Content);
    }
}
