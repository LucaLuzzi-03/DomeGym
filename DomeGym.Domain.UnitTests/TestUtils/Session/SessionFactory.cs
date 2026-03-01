using DomeGym.Domain.UnitTests.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.Session
{
    public static class SessionFactory
    {
        public static Domain.Session CreateSession(int maxParticipants, Guid? id = null) 
            => new Domain.Session(
                trainerId: Constants.Trainer.Id, 
                maxParticipants: maxParticipants,
                id: id ?? Constants.Session.Id);
    }
}
