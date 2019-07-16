using GalaSoft.MvvmLight;

namespace SimplyBudget.ViewModel
{
    public class AddTransactionViewModel : ViewModelBase
    {
        private string _description;
        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }
    }
}