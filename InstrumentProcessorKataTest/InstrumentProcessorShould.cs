namespace InstrumentProcessorKataTest
{
    using InstrumentProcessorKata.Source;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class InstrumentProcessorShould
    {
        [Test]
        public void OnSuccess_InvokeFinishTask()
        {
            var taskDispatcher = new Mock<ITaskDispatcher>();
            var instrument = new Mock<IInstrument>();
            taskDispatcher.Setup(theTaskDispatcher => theTaskDispatcher.GetTask()).Returns("task 1");

            taskDispatcher.Verify(theTaskDispatcher => theTaskDispatcher.FinishedTask("task 1"), Times.Once());
            instrument.Verify(theInstrument => theInstrument.Execute("task 1"), Times.Once());
        }
    }
}