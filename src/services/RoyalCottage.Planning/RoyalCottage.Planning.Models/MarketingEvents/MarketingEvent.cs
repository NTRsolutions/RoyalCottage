using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Planning.Models.MarketingEvents
{
    public class MarketingEvent
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string RemoteId { get; set; }
        public DateTime StartedAt { get; set; }
        public object EndedAt { get; set; }
        public object ScheduledToEndAt { get; set; }
        public string Budget { get; set; }
        public string Currency { get; set; }
        public object ManageUrl { get; set; }
        public object PreviewUrl { get; set; }
        public string UtmCampaign { get; set; }
        public string UtmSource { get; set; }
        public string UtmMedium { get; set; }
        public object UtmContent { get; set; }
        public object UtmTerm { get; set; }
        public string BudgetType { get; set; }
        public object Description { get; set; }
        public string MarketingChannel { get; set; }
        public bool Paid { get; set; }
        public string ReferringDomain { get; set; }
        public object BreadcrumbId { get; set; }
        public string AdminGraphqlApiId { get; set; }
        public IList<object> MarketedResources { get; set; }
    }
}
