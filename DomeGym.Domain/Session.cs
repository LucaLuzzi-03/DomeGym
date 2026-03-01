
namespace DomeGym.Domain
{
    public class Session
    {
        private readonly Guid _id;
        private readonly Guid _trainerId;
        private readonly List<Guid> _participantIds = [];
        private readonly int _maxParticipants;

        public Session(Guid trainerId, int maxParticipants, Guid? id = null)
        {
            _id = id ?? Guid.NewGuid();
            _trainerId = trainerId;
            _maxParticipants = maxParticipants;
        }

        public void ReserveSpot(Participant participant)
        {
            if (_participantIds.Count >= _maxParticipants)
            {
                throw new InvalidOperationException("Session is full");
            }

            _participantIds.Add(participant.Id);
        }
    }
}
