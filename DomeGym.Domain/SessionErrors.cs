using ErrorOr;

namespace DomeGym.Domain
{
    public static class SessionErrors
    {
        public static readonly Error SessionIsFull = Error.Validation(
            code: "Session.Full",
            description: "Session is full");

        public static readonly Error CancellationTooCloseToSession = Error.Validation(
            code: "Session.CancellationTooClose",
            description: "Cancellation is too close to session start time");
    }
}
