using System.Windows;

namespace Generic.Host.WPF.App
{
    /// <summary>
    /// Interaction logic for Driver.xaml
    /// </summary>
    public partial class DriverWindow : Window
    {
        #region Properties
        private readonly DriversWindow _testWindow;
        #endregion

        #region Ctor
        public DriverWindow(DriversWindow testWindow)
        {
            InitializeComponent();

            _testWindow = testWindow;
        }
        #endregion

        #region Methods
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; // om te verbergen
            e.Cancel = true; // om te voorkomen dat de WPF app het window toch nog vernietigt
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            _testWindow?.Show();
        }
        #endregion
    }
}
