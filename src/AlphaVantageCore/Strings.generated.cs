




// Strings.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AlphaVantageCore
{
    public sealed class AlphaVantageInterval : IEquatable<AlphaVantageInterval>
    {
        public static readonly AlphaVantageInterval Minute = new AlphaVantageInterval("1min");
          
        public static readonly AlphaVantageInterval FiveMinute = new AlphaVantageInterval("5min");
          
        public static readonly AlphaVantageInterval FifteenMinute = new AlphaVantageInterval("15min");
          
        public static readonly AlphaVantageInterval HalfHour = new AlphaVantageInterval("30min");
          
        public static readonly AlphaVantageInterval Hour = new AlphaVantageInterval("60min");
          
        private readonly string _value;

        private AlphaVantageInterval(string value)
        {
            _value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is AlphaVantageInterval other && Equals(other);
        }

        public bool Equals(AlphaVantageInterval other)
        {
            return _value == other._value;
        }

        public static bool operator ==(AlphaVantageInterval left, AlphaVantageInterval right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AlphaVantageInterval left, AlphaVantageInterval right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }
    }

    public sealed class AlphaVantageOutputSize : IEquatable<AlphaVantageOutputSize>
    {
        public static readonly AlphaVantageOutputSize Full = new AlphaVantageOutputSize("full");
          
        public static readonly AlphaVantageOutputSize Compact = new AlphaVantageOutputSize("compact");
          
        private readonly string _value;

        private AlphaVantageOutputSize(string value)
        {
            _value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is AlphaVantageOutputSize other && Equals(other);
        }

        public bool Equals(AlphaVantageOutputSize other)
        {
            return _value == other._value;
        }

        public static bool operator ==(AlphaVantageOutputSize left, AlphaVantageOutputSize right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AlphaVantageOutputSize left, AlphaVantageOutputSize right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }
    }

    public sealed class AlphaVantageTimeSeries : IEquatable<AlphaVantageTimeSeries>
    {
        public static readonly AlphaVantageTimeSeries Daily = new AlphaVantageTimeSeries("TIME_SERIES_DAILY");
          
        public static readonly AlphaVantageTimeSeries Weekly = new AlphaVantageTimeSeries("TIME_SERIES_WEEKLY");
          
        public static readonly AlphaVantageTimeSeries WeeklyAdjusted = new AlphaVantageTimeSeries("TIME_SERIES_WEEKLY_ADJUSTED");
          
        public static readonly AlphaVantageTimeSeries Monthly = new AlphaVantageTimeSeries("TIME_SERIES_MONTHLY");
          
        public static readonly AlphaVantageTimeSeries MonthlyAdjusted = new AlphaVantageTimeSeries("TIME_SERIES_MONTHLY_ADJUSTED");
          
        private readonly string _value;

        private AlphaVantageTimeSeries(string value)
        {
            _value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is AlphaVantageTimeSeries other && Equals(other);
        }

        public bool Equals(AlphaVantageTimeSeries other)
        {
            return _value == other._value;
        }

        public static bool operator ==(AlphaVantageTimeSeries left, AlphaVantageTimeSeries right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AlphaVantageTimeSeries left, AlphaVantageTimeSeries right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
