using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Framework.Core.Models
{
    public abstract class EntityBase
    {
        #region properties
        public Guid Id { get; set; }
        #endregion

        #region ctor
        public EntityBase(Guid key)
        {
            Id = key;
        }
        #endregion
    }
}
