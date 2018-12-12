using System;
using System.Collections.Generic;

namespace TypesInsteadOfAnarchy
{
    public class Controller
    {
        private readonly ILogic logic;

        public Controller(ILogic logic) => this.logic = logic;

        public TimeSpan GetTrainingDuration(Guid id)
        {
            var training = logic.LoadTraining(id);
            return training.Ended - training.Started;
        }

        public void LogTrainingEvent(Training training, Trainee trainee, string @event)
        {
            logic.LogTrainingProgress(trainee.Id, training.Id, @event);
        }
    }

    public interface ILogic
    {
        Training LoadTraining(Guid id);
        void LogTrainingProgress(Guid trainingId, Guid traineeId, string @event);
    }
    public class Logic : ILogic
    {
        public IList<Event> Events { get; } = new List<Event>();

        public Training LoadTraining(Guid id)
        {
            return null;
        }

        public void LogTrainingProgress(Guid trainingId, Guid traineeId, string @event)
        {
            if (string.IsNullOrWhiteSpace(@event)) throw new ArgumentException("event message must not be empty");
            Events.Add(new Event { TrainingId = trainingId, TraineeId = traineeId, Text = @event });
        }
    }

    /* --- Model --- */
    public class Training
    {
        public Guid Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
    }
    public class Trainee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class Event
    {
        public Guid TrainingId { get; set; }
        public Guid TraineeId { get; set; }
        public string Text { get; set; }
    }
}
