using Optional;
using System;
using System.Collections.Generic;
using ValueOf;

namespace TypesInsteadOfAnarchySolution
{
    public class Controller
    {
        private readonly ILogic logic;

        public Controller(ILogic logic) => this.logic = logic;

        public TimeSpan GetTrainingDuration(Guid id) =>
            logic
                .LoadTraining(id)
                .Map(training => training.Ended - training.Started)
                .ValueOr(TimeSpan.Zero);

        public void LogTrainingEvent(Training training, Trainee trainee, string @event)
        {
            logic.LogTrainingProgress(training.Id, trainee.Id, @event);
        }
    }

    public interface ILogic
    {
        Option<Training> LoadTraining(Guid id);
        void LogTrainingProgress(TrainingId trainingId, TraineeId traineeId, string @event);
    }

    public class Logic : ILogic
    {
        public IList<Event> Events { get; } = new List<Event>();

        public Option<Training> LoadTraining(Guid id)
        {
            return Option.None<Training>();
        }

        public void LogTrainingProgress(TrainingId trainingId, TraineeId traineeId, string @event)
        {
            if (string.IsNullOrWhiteSpace(@event)) throw new ArgumentException("event message must not be empty");
            Events.Add(new Event { TrainingId = trainingId, TraineeId = traineeId, Text = @event });
        }
    }

    /* --- Model --- */
    public class TrainingId : ValueOf<Guid, TrainingId> { }
    public class Training
    {
        public TrainingId Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
    }
    public class TraineeId : ValueOf<Guid, TraineeId> { }
    public class Trainee
    {
        public TraineeId Id { get; set; }
        public string Name { get; set; }
    public class TrainingId : ValueOf<Guid, TrainingId> { }
    }
    public class Event
    {
        public TrainingId TrainingId { get; set; }
        public TraineeId TraineeId { get; set; }
        public string Text { get; set; }
    }
    public class Success { }
    public class Error
    {
        public string Message { get; set; }
    }
}
