namespace DomeGym.Domain.UnitTests.TestUtils.Participants;

public static class ParticipantFactory
{
    public static ParticipantAggregate.Participant CreateParticipant(Guid? id = null, Guid? userId = null)
    {
        return new ParticipantAggregate.Participant(
            userId: userId ?? Constants.User.Id,
            id: id ?? Constants.Participant.Id);
    }
}