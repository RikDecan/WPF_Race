using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Races.Db;
using System;
using System.Linq;
using System.Windows;

namespace Generic.Host.WPF.App
{
    /// <summary>
    /// Interaction logic for DriversWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        #region Properties
        private readonly ILogger<CarsWindow> _logger;
        /*
        private readonly IConfiguration _configuration; 
        */
        private readonly RacesDb _repository;
        private static int _loadCount = 0;
        #endregion

        #region Ctor
        public CarsWindow(ILogger<CarsWindow> logger, RacesDb db/*, IConfiguration configuration*/)
        {
            InitializeComponent();

            _logger = logger;
            //_configuration = configuration;
            _repository = db;
        }
        #endregion

        #region Methods
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //_logger.LogDebug("Closing");
            //_logger.LogInformation("Connection string: " + _configuration.GetConnectionString("Db"));
            
            this.Visibility = Visibility.Collapsed; // om te verbergen
            e.Cancel = true; // om te voorkomen dat de WPF app het window toch nog vernietigt
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void EditButton_Click(object sender, RoutedEventArgs e) 
        { 
            // CRUD operaties maken, UPDATE METHOD
            // Repo pack maken Cars
            //stap 1: Data displayen in de datagrid, maxspeed, cc, datumregistratie
            //stap 2: Data ophalen van uw datagrind 
            // stap 3: Data inserten in uw database

            //button maken om te editen, als we op de button klikken gebruiken we de CRUD method om de data te inserten in database
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) 
        {

        }



        #endregion
    }
}
