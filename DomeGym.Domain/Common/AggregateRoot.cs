using System;
using System.Collections.Generic;
using System.Text;

namespace DomeGym.Domain.Common
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
