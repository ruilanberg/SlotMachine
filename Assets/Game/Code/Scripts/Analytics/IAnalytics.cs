using System.Collections.Generic;
using UnityEngine;

namespace Game.Analytics
{
    public interface IAnalytics
    {
        public List<AnalyticsData> GetData();

        public void CashIn(long credits);
        public void CashOut(long credits);

        public void StartSpin(long credits);
        public void EndSpin(long credits);

        public void WinJackpot(long credits);
    }
}
