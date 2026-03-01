using DomeGym.Domain.UnitTests.TestConstants;
using System.Reflection.Metadata;

namespace DomeGym.Domain.UnitTests.TestUtils.Session
{
    public static class SessionFactory
    {
        public static Domain.Session CreateSession(
            DateOnly? date = null,
            TimeOnly? startTime = null,
            TimeOnly? endTime = null,
            int maxParticipants = Constants.Session.MaxParticipants,
            Guid? id = null) 
            => new Domain.Session(
                date: date ?? Constants.Session.Date,
                startTime: startTime ?? Constants.Session.StartTime,
                endTime: endTime ?? Constants.Session.EndTime,
                maxParticipants: maxParticipants,
                trainerId: Constants.Trainer.Id, 
                id: id ?? Constants.Session.Id);
    }
}
