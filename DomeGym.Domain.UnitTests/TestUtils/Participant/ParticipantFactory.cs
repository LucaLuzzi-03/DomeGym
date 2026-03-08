using DomeGym.Domain.UnitTests.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.Participant
{
    public static class ParticipantFactory
    {
        public static ParticipantAggregate.Participant CreateParticipant(Guid? id = null, Guid? userId = null)
            => new ParticipantAggregate.Participant(
                userId: userId ?? Constants.User.Id,
                id: id ?? Constants.Participant.Id);
    }
}
