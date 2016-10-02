using kSpot.Win.BOL.Resources;
using System.Resources;

namespace kSpot.Win.BOL.Factories
{
    public static class ResourceFactory
    {
        public static ResourceManager GetResourceManagerInstance(ResourceType resourceType)
        {
            ResourceManager resourceManager = null;

            switch (resourceType)
            {
                case ResourceType.HistoryTracker:
                    resourceManager = new ResourceManager(typeof(HistoryTrackerResources));
                    break;

                default:
                    break;
            }

            return resourceManager;
        }
    }

    public enum ResourceType
    {
        HistoryTracker
    }
}