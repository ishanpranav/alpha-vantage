// AlphaVantageSearchResponse.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;

namespace AlphaVantageCore;

public sealed class AlphaVantageSearchResponse : IAlphaVantageResponse
{
    [Name("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [Name("name")]
    public string Name { get; set; } = string.Empty;

    [Name("type")]
    public AlphaVantageSecurityType Type { get; set; }

    [Name("region")]
    public string Region { get; set; } = string.Empty;

    [Name("currency")]
    public string Currency { get; set; } = string.Empty;

    [Name("matchScore")]
    public decimal MatchScore { get; set; }

    [Ignore]
    [JsonIgnore]
    public string? Content { get; set; }
}
