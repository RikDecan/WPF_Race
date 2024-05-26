using Microsoft.Extensions.Logging;
using Races.Db;
using Races.Db.RepositoryPacks;
using System;
using System.Windows;

namespace Generic.Host.WPF.App
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        #region Properties

        private readonly ILogger<LogInWindow> _logger;


        private readonly LogInWindow _logInWindow;

        private readonly RacesDb _repository;




        #endregion

        #region Ctor


        public LogInWindow(ILogger<LogInWindow> logger, RacesDb db)
        {
            InitializeComponent();

            _logger = logger;

            _repository = db; 
        }


        #endregion

        #region Methods
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; // om te verbergen
            e.Cancel = true; // om te voorkomen dat de WPF app het window toch nog vernietigt
        }

        public static class GlobalVariables
        {
            public static bool loggedIn = false;
        }

        private void CheckLogInGevevensClick(object sender, RoutedEventArgs e)
        {
            string callsign = CallSignTb.Text;
            string password = PasswordTb.Text;

            _logger.LogInformation($"Callsign: {callsign}, Wachtwoord: {password}");

            var users = _repository.User.Query.All();
            foreach (var user in users)
            {
                if (user.CallSign == callsign && user.Password == password)
                {
                    _logger.LogInformation("User found and authenticated.");
                    this.Visibility = Visibility.Collapsed; // om te verbergen

                    GlobalVariables.loggedIn = true;

                }

            }
        }
        #endregion
    }
}
