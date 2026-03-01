using System;
using System.Collections.Generic;
using System.Text;

namespace DomeGym.Domain.UnitTests.TestConstants
{
    public static partial class Constants
    {
        public static class Session
        {
            public static readonly Guid Id = Guid.NewGuid();
            public const int MaxParticipants = 1;
            public static readonly DateOnly Date = new DateOnly(2026, 3, 1);
            public static readonly TimeOnly StartTime = new TimeOnly(12, 30);
            public static readonly TimeOnly EndTime = new TimeOnly(13, 30);
        }
    }
}
