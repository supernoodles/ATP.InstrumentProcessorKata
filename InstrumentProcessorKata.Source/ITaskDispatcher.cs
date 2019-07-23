namespace InstrumentProcessorKata.Source
{
    public interface ITaskDispatcher
    {
        string GetTask();
        void FinishedTask(string task);
    }
}