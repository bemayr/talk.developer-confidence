using System;
using Xunit;

namespace TypesInsteadOfAnarchy.Tests
{
    public class IntegrationTests
    {
        private readonly Controller controller;
        private readonly Logic logic;

        public IntegrationTests()
        {
            logic = new Logic();
            controller = new Controller(logic);
        }

        [Fact]
        public void CanGetTrainingDuration()
        {
            var trainingId = Guid.Parse("ED029FBD-A7B8-4A01-BFE9-1BD12E7EF90F");
            controller.GetTrainingDuration(trainingId);
        }

        [Fact]
        public void CanLogTrainingEvent()
        {
            var training = new Training { Id = Guid.Parse("ED029FBD-A7B8-4A01-BFE9-1BD12E7EF90F"), Started = new DateTime(2018, 12, 13, 8, 50, 0) };
            var trainee = new Trainee { Id = Guid.Parse("4ED67A26-BCC6-41DA-BD54-277C5977FA92"), Name = "Sebastian" };

            controller.LogTrainingEvent(training, trainee, "Poison spilled");
            Assert.Contains(logic.Events, @event => @event.TrainingId == training.Id && @event.TraineeId == trainee.Id && @event.Text == "Poison spilled");

            controller.LogTrainingEvent(training, trainee, "");
        }
    }
}
