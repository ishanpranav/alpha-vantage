// AlphaVantageRequest.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using RestSharp;

namespace AlphaVantageCore
{
    public class AlphaVantageRequest
    {
        [RequestProperty(Name = "symbol")]
        public string Symbol { get; set; }
    }
}
