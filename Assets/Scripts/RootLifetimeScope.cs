using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SequenceManager>(Lifetime.Singleton);
        builder.Register<StageProgressManager>(Lifetime.Singleton);
        builder.Register<SaveManager>(Lifetime.Singleton);
    }
}
