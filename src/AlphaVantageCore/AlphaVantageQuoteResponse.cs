// AlphaVantageQuoteResponse.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using CsvHelper.Configuration.Attributes;

namespace AlphaVantageCore;

public sealed class AlphaVantageQuoteResponse : AlphaVantageResponse
{
    [Name("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [Name("latestDay")]
    public DateTime LatestDay { get; set; }

    [Name("previousClose")]
    public decimal PreviousClose { get; set; }

    [Name("change")]
    public decimal Change { get; set; }
}
