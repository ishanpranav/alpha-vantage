// AlphaVantageTimeSeriesRequest.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using RestSharp;

namespace AlphaVantageCore
{
    public class AlphaVantageTimeSeriesRequest : AlphaVantageRequest
    {
        [RequestProperty(Name = "outputsize")]
        public AlphaVantageOutputSize OutputSize { get; set; } = AlphaVantageOutputSize.Compact;
    }
}
