// AlphaVantageIntradayTimeSeriesRequest.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using RestSharp;

namespace AlphaVantageCore
{
    public class AlphaVantageIntradayTimeSeriesRequest : AlphaVantageTimeSeriesRequest
    {
        [RequestProperty(Name = "interval")]
        public AlphaVantageInterval Interval { get; set; } = AlphaVantageInterval.Hour;

        [RequestProperty(Name = "adjusted")]
        public bool Adjusted { get; set; }

        [RequestProperty(Name = "extended_hours")]
        public bool ExtendedHours { get; set; }

        [RequestProperty(Name = "month", Format = "yyyy-MM")]
        public DateTime Month { get; set; }
    }
}
