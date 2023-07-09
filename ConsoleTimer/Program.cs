using Autofac;

namespace ConsoleTimer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Model>();
            builder.RegisterType<ViewModel>();
            builder.RegisterType<View>();

            var container = builder.Build();

            var view = container.Resolve<View>();

            view.Show();
        }
    }
}

