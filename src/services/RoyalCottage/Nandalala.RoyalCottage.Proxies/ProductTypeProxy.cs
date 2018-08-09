using System;

namespace Nandalala.RoyalCottage.Proxies
{
    public class ProductTypeProxy
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Guid CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
}
