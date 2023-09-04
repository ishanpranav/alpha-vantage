// AlphaVantageSecurityType.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using CsvHelper.Configuration.Attributes;

namespace AlphaVantageCore;

public enum AlphaVantageSecurityType
{
    [Name("Equity")]
    Equity,

    [Name("Mutual Fund")]
    MutualFund,

    [Name("ETF")]
    Etf
}
