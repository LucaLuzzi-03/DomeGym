using System;
using System.Collections.Generic;
using System.Text;

namespace DomeGym.Domain
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
