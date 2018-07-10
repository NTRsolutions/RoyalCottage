using System;

namespace RoyalCottage.Framework.Core.Models
{
    public abstract class DomainEntityBase : EntityBase
    {
        #region properties
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string IsActive { get; set; }
        #endregion

        #region ctor
        public DomainEntityBase(Guid key) : base(key) { }
        #endregion
    }
}
