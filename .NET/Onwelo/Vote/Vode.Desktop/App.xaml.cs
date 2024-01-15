using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Windows;
using Vode.Desktop.Model;
using Vode.Desktop.ViewModel;

namespace Vode.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider; 

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            this.DispatcherUnhandledException += AppDispatcherUnhandledException;
        }

        private void AppDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error");
            e.Handled = true;

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //this
            Thread.Sleep(30 * 1000);

            this.MainWindow = serviceProvider.GetService<MainWindow>();
            this.MainWindow.DataContext = serviceProvider.GetService<VoteViewModel>();
            VoteViewModel viewModel = this.MainWindow.DataContext as VoteViewModel;
            viewModel.GetDataCommand.Execute(null);
            this.MainWindow.Show();

        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IVoteApiClient, VoteApiClient>();
            services.AddSingleton<VoteViewModel>();
            services.AddSingleton<MainWindow>();
        }
    }
}
