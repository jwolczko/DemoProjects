using FluentAssertions;
using Tracker.Domain;

namespace Tracker.Tests;

[TestClass]
public class TrackerTests
{
    [TestMethod]
    public void SetNextState_OutOfService_ShouldSetLoading()
    {
        // Arrange
        var truck = new Truck { Status = TrackStatus.OutOfService };
        var truckState = new TruckState();

        // Act
        truckState.SetNextState(truck);

        // Assert
        truck.Status.Should().Be(TrackStatus.Loading);
    }

    [TestMethod]
    public void SetNextState_Loading_ShouldSetToJob()
    {
        // Arrange
        var truck = new Truck { Status = TrackStatus.Loading };
        var truckState = new TruckState();

        // Act
        truckState.SetNextState(truck);

        // Assert
        truck.Status.Should().Be(TrackStatus.ToJob);
    }

    [TestMethod]
    public void SetNextState_ToJob_ShouldSetAtJob()
    {
        // Arrange
        var truck = new Truck { Status = TrackStatus.ToJob };
        var truckState = new TruckState();

        // Act
        truckState.SetNextState(truck);

        // Assert
        truck.Status.Should().Be(TrackStatus.AtJob);
    }

    [TestMethod]
    public void SetNextState_AtJob_ShouldSetReturning()
    {
        // Arrange
        var truck = new Truck { Status = TrackStatus.AtJob };
        var truckState = new TruckState();

        // Act
        truckState.SetNextState(truck);

        // Assert
        truck.Status.Should().Be(TrackStatus.Returning);
    }

    [TestMethod]
    public void SetNextState_Returning_ShouldSetLoading()
    {
        // Arrange
        var truck = new Truck { Status = TrackStatus.Returning };
        var truckState = new TruckState();

        // Act
        truckState.SetNextState(truck);

        // Assert
        truck.Status.Should().Be(TrackStatus.Loading);
    }    
}