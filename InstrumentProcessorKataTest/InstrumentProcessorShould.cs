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
            var instrumentProcessor = new InstrumentProcessor(taskDispatcher.Object, instrument.Object);

            taskDispatcher
                .Setup(theTaskDispatcher => theTaskDispatcher.GetTask())
                .Returns("task 1");
            instrument
                .Setup(theInstrument => theInstrument.Execute("task 1"))
                .Raises(theInstrument => theInstrument.Finished += null, new FinishedEventArgs("task 1"));


            instrumentProcessor.Process();


            taskDispatcher.Verify(theTaskDispatcher => theTaskDispatcher.FinishedTask("task 1"), Times.Once());
        }
    }
}