
namespace DomeGym.Domain
{
    public class Session
    {
        private readonly Guid _id;
        private readonly Guid _trainerId;
        private readonly List<Guid> _participantIds = [];
        private readonly int _maxParticipants;
        private readonly DateOnly _date;
        private readonly TimeOnly _startTime;
        private readonly TimeOnly _endTime;

        public Session(DateOnly date, TimeOnly startTime, TimeOnly endTime, Guid trainerId, int maxParticipants, Guid? id = null)
        {
            _date = date;
            _startTime = startTime;
            _endTime = endTime;
            _trainerId = trainerId;
            _maxParticipants = maxParticipants;
            _id = id ?? Guid.NewGuid();
        }

        public void CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
        {
            if (IsTooCloseToSession(dateTimeProvider.UtcNow))
            {
                throw new InvalidOperationException("Cannot cancel reservation too close to session");
            }

            if (!_participantIds.Remove(participant.Id))
            {
                throw new InvalidOperationException("Reservation not found");
            }
        }

        private bool IsTooCloseToSession(DateTime utcNow)
        {
            const int MinHours = 24;
            return (_date.ToDateTime(_startTime) - utcNow).TotalHours < MinHours;
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
