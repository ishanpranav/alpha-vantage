// Program.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        DateTime end = DateTime.Now;
        SortedDictionary<DateTime, AlphaVantageTimeSeriesResponse> items = new SortedDictionary<DateTime, AlphaVantageTimeSeriesResponse>();

        for (DateTime month = new DateTime(2000, 1, 1);
            month < end;
            month = month.AddMonths(1))
        {
            await Console.Out.WriteLineAsync($"GET {month:MMM yyyy}\tn = {items.Count:n0}");

            var response = await client.GetTimeSeriesAsync(
                new AlphaVantageIntradayTimeSeriesRequest()
                {
                    OutputSize = AlphaVantageOutputSize.Full,
                    Symbol = "QQQ",
                    Interval = AlphaVantageInterval.Minute,
                    Month = month
                });

            foreach (var item in response)
            {
                items[item.Timestamp] = item;
            }
        }

        using TextWriter textWriter = File.CreateText("qqq-time-series.csv");
        using CsvWriter writer = new CsvWriter(textWriter, CultureInfo.CurrentCulture);

        writer.WriteHeader<AlphaVantageTimeSeriesResponse>();
        writer.NextRecord();

        foreach (var value in items.Values)
        {
            writer.WriteRecord(value);
            writer.NextRecord();
        }
    }
}
