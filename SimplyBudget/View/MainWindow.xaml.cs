using SimplyBudget.Services;
using SimplyBudget.ViewModel;

namespace SimplyBudget.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new DialogService());
        }
    }
}
