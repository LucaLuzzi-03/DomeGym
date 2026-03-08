using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.Participant;
using DomeGym.Domain.UnitTests.TestUtils.Services;
using DomeGym.Domain.UnitTests.TestUtils.Session;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests
{
    public class SessionTests
    {
        [Fact]
        public void ReserveSpot_WhenNoMoreRoom_ShouldFailReservation()
        {
            //Arrange
            var session = SessionFactory.CreateSession(maxParticipants: 1);
            var participant1 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());
            var participant2 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());

            //Act
            var reserveParticipant1result = session.ReserveSpot(participant1);
            var reserveParticipant2result = session.ReserveSpot(participant2);

            //Assert
            reserveParticipant1result.IsError.Should().BeFalse();

            reserveParticipant2result.IsError.Should().BeTrue();
            reserveParticipant2result.FirstError.Code.Should().Be(SessionErrors.SessionIsFull.Code);
        }

        [Fact]
        public void CancelReservation_WhenCancellationIsTooCloseToSession_ShouldFailCancellation()
        {
            // Arrange
            var session = SessionFactory.CreateSession(
                date: Constants.Session.Date,
                startTime: Constants.Session.StartTime,
                endTime: Constants.Session.EndTime);

            var participant = ParticipantFactory.CreateParticipant();
            var cancellationDateTime = Constants.Session.Date.ToDateTime(TimeOnly.MinValue);

            // Act
            var reserveSpotResult = session.ReserveSpot(participant);
            var cancelReservationResult = session.CancelReservation(participant, 
                new TestDateTimeProvider(fixedDateTime: cancellationDateTime));

            // Assert
            reserveSpotResult.IsError.Should().BeFalse();

            cancelReservationResult.IsError.Should().BeTrue();
            cancelReservationResult.FirstError.Code.Should().Be(SessionErrors.CancellationTooCloseToSession.Code);
        }
    }
}
