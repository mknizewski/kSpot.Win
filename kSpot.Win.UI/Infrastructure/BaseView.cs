using Caliburn.Micro;
using kSpot.Win.BOL.Attributes;
using System.Reflection;

namespace kSpot.Win.UI.Infrastructure
{
    public class BaseView<T> where T : ViewAware
    {
        public T View;

        public BaseView()
        {
            View = NinjectBindings.GetInstance<T>();
        }

        public void RegisterExecution(MethodBase methodBase)
        {
            HistoryTrackerAttribute historyTracker = methodBase.GetCustomAttribute<HistoryTrackerAttribute>();
            historyTracker.SaveHistoryLog();
        }

        protected virtual void Dispose()
        {
            View = null;
        }
    }
}
