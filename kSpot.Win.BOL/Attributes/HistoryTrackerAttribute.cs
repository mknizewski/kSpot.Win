using kSpot.Win.BOL.Factories;
using kSpot.Win.BOL.Infrastucture;
using kSpot.Win.DAL.Interfaces;
using System;
using System.Resources;

namespace kSpot.Win.BOL.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HistoryTrackerAttribute : Attribute
    {
        private string MethodName { get; set; }
        private ResourceManager HistoryAttributeResxManager { get; set; }

        public HistoryTrackerAttribute(string methodName)
        {
            this.MethodName = methodName;
            this.HistoryAttributeResxManager = ResourceFactory.GetResourceManagerInstance(ResourceType.HistoryTracker);

            SaveHistoryLog();
        }

        private void SaveHistoryLog()
        {
            IkSpotContext kSpotContext = NinjectBindings.GetInstance<IkSpotContext>(typeof(IkSpotContext));

            //TODO: Dodać logikę zapisu do bazy historii

            kSpotContext.Dispose();
        }
    }
}
