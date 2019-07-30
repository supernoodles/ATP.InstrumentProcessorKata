namespace InstrumentProcessorKata.Source
{
    using System;

    public class InstrumentProcessor : IInstrumentProcessor
    {
        private readonly ITaskDispatcher _taskDispatcher;
        private readonly IInstrument _instrument;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            _taskDispatcher = taskDispatcher;
            _instrument = instrument;
            _instrument.Finished += OnFinished;
        }

        private void OnFinished(object sender, EventArgs e)
        {
            var finishedEventArgs = e as FinishedEventArgs;

            _taskDispatcher.FinishedTask(finishedEventArgs.Task);
        }

        public void Process()
        {
            var task = _taskDispatcher.GetTask();
            _instrument.Execute(task);
        }
    }

    public class FinishedEventArgs : EventArgs
    {
        public FinishedEventArgs(string task)
        {
            Task = task;
        }

        public string Task { get;}

    }


}

