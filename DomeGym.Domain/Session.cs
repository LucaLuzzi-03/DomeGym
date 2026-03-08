
using ErrorOr;

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

        public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
        {
            if (IsTooCloseToSession(dateTimeProvider.UtcNow))
            {
                return SessionErrors.CancellationTooCloseToSession;
            }

            if (!_participantIds.Remove(participant.Id))
            {
                return Error.NotFound(description: "Reservation not found");
            }

            return Result.Success;
        }

        private bool IsTooCloseToSession(DateTime utcNow)
        {
            const int MinHours = 24;
            return (_date.ToDateTime(_startTime) - utcNow).TotalHours < MinHours;
        }

        public ErrorOr<Success> ReserveSpot(Participant participant)
        {
            if (_participantIds.Count >= _maxParticipants)
            {
                return SessionErrors.SessionIsFull;
            }

            _participantIds.Add(participant.Id);
            return Result.Success;
        }
    }
}
