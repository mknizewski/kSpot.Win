using kSpot.Win.BOL.Attributes;
using System.Reflection;

namespace kSpot.Win.UI.Infrastructure
{
    public class BaseView<T>
    {
        public BaseView()
        {
        }

        public void RegisterExecution(MethodBase methodBase)
        {
            HistoryTrackerAttribute historyTracker = methodBase.GetCustomAttribute<HistoryTrackerAttribute>();
            historyTracker.SaveHistoryLog();
        }

        protected virtual void Dispose()
        {
        }
    }
}