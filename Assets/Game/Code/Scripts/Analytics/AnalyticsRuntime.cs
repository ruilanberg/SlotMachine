using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Analytics
{
    public class AnalyticsRuntime : IAnalytics
    {
        private readonly List<AnalyticsData> _data;

        public AnalyticsRuntime()
        {
            _data = new List<AnalyticsData>();
        }

        public List<AnalyticsData> GetData()
        {
            return _data;
        }

        public void CashIn(long credits)
        {
            AnalyticsData data = new AnalyticsData()
            {
                Date = DateTime.Now,
                Key = "CASH_IN_ANALYTICS",
                Value = credits.ToString()
            };

            _data.Add(data);
        }

        public void CashOut(long credits)
        {
            AnalyticsData data = new AnalyticsData()
            {
                Date = DateTime.Now,
                Key = "CASH_OUT_ANALYTICS",
                Value = credits.ToString()
            };

            _data.Add(data);
        }

        public void EndSpin(long credits)
        {
            AnalyticsData data = new AnalyticsData()
            {
                Date = DateTime.Now,
                Key = "END_SPIN",
                Value = credits.ToString()
            };

            _data.Add(data);
        }

        public void StartSpin(long credits)
        {
            AnalyticsData data = new AnalyticsData()
            {
                Date = DateTime.Now,
                Key = "START_SPIN",
                Value = credits.ToString()
            };

            _data.Add(data);
        }

        public void WinJackpot(long credits)
        {
            AnalyticsData data = new AnalyticsData()
            {
                Date = DateTime.Now,
                Key = "WIN_JACKPOT",
                Value = credits.ToString()
            };

            _data.Add(data);
        }
    }
}
