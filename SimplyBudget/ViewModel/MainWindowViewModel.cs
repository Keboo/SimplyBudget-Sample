using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MaterialDesignThemes.Wpf;
using SimplyBudget.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SimplyBudget.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService _DialogService;

        public IList<Transaction> Transactions { get; } 
            = new ObservableCollection<Transaction>();

        public ICommand AddTransaction { get; }
        public ICommand RemoveTransaction { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _DialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            AddTransaction = new RelayCommand(OnAddTransaction);
            RemoveTransaction = new RelayCommand<Transaction>(OnRemoveTransaction);
        }

        private async void OnAddTransaction()
        {
            var dialogVieWModel = new AddTransactionViewModel();
            
            if (await _DialogService.Show(dialogVieWModel))
            {
                var newTransaction = new Transaction
                {
                    Description = dialogVieWModel.Description
                };
                Transactions.Add(newTransaction);
            }
        }

        private void OnRemoveTransaction(Transaction transaction)
        {
            Transactions.Remove(transaction);
        }
    }

    public class Transaction
    {
        public string Description { get; set; }
    }
}