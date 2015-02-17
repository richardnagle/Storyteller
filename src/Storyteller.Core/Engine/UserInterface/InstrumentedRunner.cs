using System.Threading.Tasks;

namespace Storyteller.Core.Engine.UserInterface
{
    public class InstrumentedRunner : ISpecRunner
    {
        private readonly IUserInterfaceObserver _observer;
        private StopConditions _stopConditions;

        public InstrumentedRunner(IUserInterfaceObserver observer)
        {
            _observer = observer;
        }

        public Task<ISpecContext> Execute(SpecExecutionRequest request, IExecutionContext execution, IExecutionQueue queue)
        {
            var context = new SpecContext(_observer, _stopConditions, execution.Services);


            return Task.Factory.StartNew(() =>
            {
                var plan = request.Plan;
                _observer.SpecStarted(plan);
                var executor = new InstrumentedExecutor(context, plan, _observer);
                plan.AcceptVisitor(executor);

                return context as ISpecContext;
            }, context.Cancellation);
        }


        public void UseStopConditions(StopConditions conditions)
        {
            _stopConditions = conditions;
        }
    }
}