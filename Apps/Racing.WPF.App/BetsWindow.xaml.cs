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
    public partial class BetsWindow : Window
    {
        #region Properties
        private readonly ILogger<BetsWindow> _logger;
        /*
        private readonly IConfiguration _configuration; 
        */
        private readonly RacesDb _repository;
        private static int _loadCount = 0;
        #endregion

        #region Ctor
        public BetsWindow(ILogger<BetsWindow> logger, RacesDb db/*, IConfiguration configuration*/)
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
            LoadDrivers();
        }

        private void LoadDrivers()
        {
            var drivers = _repository.Driver.Query.All();
            MyDataGrid.ItemsSource = drivers;
            _loadCount++;
            LoadButton.Content = $"Load all ({_loadCount})";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var driverRow = MyDataGrid.SelectedItem as Driver;
                var driver = _repository.Driver.Query.ByDriverId(driverRow.DriverId).Single();
                driver.FirstName = driverRow.FirstName;
                driver.LastName = driverRow.LastName;
                driver.IsDeleted = driverRow.IsDeleted;
                driver.CallSign = driverRow.CallSign;
                _repository.Driver.Update.ByDriverId(driver);
                _repository.SaveChanges();
                MessageBox.Show("Row Updated Successfully.");
                LoadDrivers();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var driverRow = MyDataGrid.SelectedItem as Driver;
            var driver = _repository.Driver.Query.ByDriverId(driverRow.DriverId).Single();
            _repository.Driver.Delete.ByDriverId(driver.DriverId);
            _repository.SaveChanges();
            MessageBox.Show("Row Deleted Successfully.");
            LoadDrivers();
        }
        #endregion
    }
}
