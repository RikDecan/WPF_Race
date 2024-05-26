using Racing.WPF.App.Languages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Windows;
using Races.Db;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows.Controls;
using Racing.WPF.App.DTO;
using Racing.Infrastructure;
namespace Generic.Host.WPF.App
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        private readonly ILogger<MainWindow>? _logger;
        private readonly DriversWindow? _testWindow;
        private readonly DriverWindow? _driverWindow;
        private readonly RacesDb _repository;
        private readonly CarsWindow _carsWindow;
        private readonly LogInWindow _logInWindow;
        private readonly BetsWindow _betsWindow;





        #endregion

        #region Ctor
        // We gebruiken DI om het logger singleton te bekomen: parameter van constructor
        public MainWindow(ILogger<MainWindow>? logger,
            DriversWindow testWindow,
            DriverWindow driverWindow,
            RacesDb repository,
            CarsWindow carsWindow, 
            LogInWindow logInWindow,
            BetsWindow betsWindow) // DI vult singleton invullen, automatisch
        {
            InitializeComponent();

            _logger = logger;
            _testWindow = testWindow;
            _driverWindow = driverWindow;
            _repository = repository;
            _carsWindow = carsWindow;
            _logInWindow = logInWindow;
            _betsWindow = betsWindow;

            List<Driver> drivers = _repository.Driver.Query.All();
            //User user = _repository.User.Query.ByPrimaryKey(1);
            List<User> users = _repository.User.Query.All();

            /*List<UserType>*/
            var userTypes = _repository.UserType.Query.All();

            List<UserDTO> ownUsers = ReadUsersUsingReader();

            List<CarsDTO> ownCars = ReadCarReader();

            List<Race> ownRace = _repository.Race.Query.All();

            //List<Bet> ownBet = _repository.Bet.Query.All();

            //mijn stuk (Rik Decan)

            //eind mijn stuk

            // via {Binding}, zie xaml, worden public properties gemapt van de klasse in de lijst:
            DriversDg.ItemsSource = drivers;
            UsersDg.ItemsSource = users;
            UserTypesDg.ItemsSource = userTypes;
            JoinedUsersDg.ItemsSource = ownUsers;
            CarsDg.ItemsSource = ownCars;
            RacesDg.ItemsSource = ownRace;
            //BetsDg.ItemsSource = betsWindow;
        }

        private List<UserDTO> ReadUsersUsingReader()
        {
            _repository.Connection.Open();

            SqlCommand command = new(
                "SELECT U.FirstName, U.LastName, T.Name FROM [User] AS U JOIN UserType AS T ON U.UserTypeId = T.UserTypeId",
                _repository.Connection
            );

            SqlDataReader reader = command.ExecuteReader();
            List<UserDTO> ownUsers = new();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ownUsers.Add(new UserDTO()
                    {
                        FirstName = (string)reader.GetValue(0),
                        LastName = (string)reader.GetValue(1),
                        Type = (string)reader.GetValue(2)
                    });
                }
            }

            _repository.Connection.Close();
            return ownUsers;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Toegevoegd om te kunnen de applicatie stoppen met het kruisje van MainWindow
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();  // ik neem huidige WPF app en ik vraag deze om te stoppen
            //e.Cancel = true;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            _testWindow?.Show();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            //System.Environment.Exit(0); // we stoppen niet proper op deze manier met Generic Host
            Application.Current.Shutdown(); // ik neem huidige WPF app en ik vraag deze om te stoppen
        }

        private void NewClick(object sender, RoutedEventArgs e)
        {
            var info = GC.GetGCMemoryInfo();
            System.Diagnostics.Debug.WriteLine(Translations.HeapSizeTag + info.HeapSizeBytes);
            var totalMemoryBeforeCleanup = GC.GetTotalMemory(false);
            System.Diagnostics.Debug.WriteLine("Total memory before cleanup: " + totalMemoryBeforeCleanup);
            var totalMemoryAfterCleanup = GC.GetTotalMemory(true); // effectief zoveel mogelijk vrijgeven naar het OS met true
            System.Diagnostics.Debug.WriteLine("Total memory after cleanup: " + totalMemoryAfterCleanup);

            StatusBarTxt.Text = "Memory cleanup: from " + totalMemoryBeforeCleanup + " to " + totalMemoryAfterCleanup + " bytes";
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            _testWindow?.Show();
        }

        private void DriversDg_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = e.Source as DataGridRow;
            if (row != null)
            {
                var driver = row.DataContext as Driver;
                if (driver != null)
                {
                    _driverWindow.DriverFirstNameTb.Text = driver.FirstName;
                    _driverWindow.DriverLastNameTb.Text = driver.LastName;
                    _driverWindow.Show();
                }
            }
        }

        //mijn stuk (Rik Decan)

        private List<CarsDTO> ReadCarReader()
        {
            _repository.Connection.Open();

            SqlCommand command = new(
                "SELECT CarId, Naam, MaximaleSnelheid, Cc, DatumRegistratie FROM Car",
                _repository.Connection
            );

            SqlDataReader reader = command.ExecuteReader();
            List<CarsDTO> ownCars = new();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ownCars.Add(new CarsDTO(
                        (int)reader.GetValue(0), // CarId
                        (string)reader.GetValue(1), // Naam
                        (int)reader.GetValue(2), // MaximaleSnelheid
                        (int)reader.GetValue(3), // Cc
                        (DateTime?)reader.GetValue(4) // DatumRegistratie
                    ));
                }
            }
            _repository.Connection.Close();
            return ownCars;
        }

        private void CarsDg_Row_DoubleClick(object sender, RoutedEventArgs e) 
        {
            //nieuwe car window
            _carsWindow.Show();
        }


        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            _logInWindow?.Show();
        }


        private void RacesDg_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            //var row = e.Source as DataGridRow;
            //if (row != null)
            //{
            //    var driver = row.DataContext as Driver;
            //    if (driver != null)
            //    {
            //        _driverWindow.DriverFirstNameTb.Text = driver.FirstName;
            //        _driverWindow.DriverLastNameTb.Text = driver.LastName;
            //        _driverWindow.Show();
            //    }
            //}
        }


        #endregion
    }
}
