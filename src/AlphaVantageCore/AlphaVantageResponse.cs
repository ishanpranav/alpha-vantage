// AlphaVantageResponse.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;

namespace AlphaVantageCore;

public abstract class AlphaVantageResponse : IAlphaVantageResponse
{
    protected AlphaVantageResponse() { }

    [Name("open")]
    public decimal Open { get; set; }

    [Name("high")]
    public decimal High { get; set; }

    [Name("low")]
    public decimal Low { get; set; }

    [Name("volume")]
    public decimal Volume { get; set; }

    [Ignore]
    [JsonIgnore]
    public string? Content { get; set; }
}
