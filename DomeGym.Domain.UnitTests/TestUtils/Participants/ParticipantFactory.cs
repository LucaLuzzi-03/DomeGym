namespace DomeGym.Domain.UnitTests.TestUtils.Participants;

public static class ParticipantFactory
{
    public static Domain.Participant CreateParticipant(Guid? id = null, Guid? userId = null)
    {
        return new Domain.Participant(
            userId: userId ?? Constants.User.Id,
            id: id ?? Constants.Participant.Id);
    }
}