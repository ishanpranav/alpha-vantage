// Program.cs
// Copyright (c) 2019-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
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

        var result = await client.SearchAsync("Apple");

        Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions()
        {
            WriteIndented = true
        }));
    }
}
