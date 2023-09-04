﻿// AlphaVantageTimeSeriesRequest.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using RestSharp;

namespace AlphaVantageCore;

public class AlphaVantageTimeSeriesRequest
{
    [RequestProperty(Name = "symbol")]
    public string Symbol { get; set; } = string.Empty;

    [RequestProperty(Name = "outputsize")]
    public AlphaVantageOutputSize OutputSize { get; set; } = AlphaVantageOutputSize.Compact;
}
