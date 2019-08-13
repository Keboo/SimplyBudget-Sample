using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SimplyBudget.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IList<Transaction> Transactions { get; } 
            = new ObservableCollection<Transaction>();

        public ICommand AddTransaction { get; }
        public ICommand RemoveTransaction { get; }

        public MainWindowViewModel()
        {
            AddTransaction = new RelayCommand(OnAddTransaction);
            RemoveTransaction = new RelayCommand<Transaction>(OnRemoveTransaction);
        }

        private async void OnAddTransaction()
        {
            var dialogVieWModel = new AddTransactionViewModel();

            //TODO: Start here: fix Unit Test
            if (await DialogHost.Show(dialogVieWModel) is bool shouldAddTransaction && 
                shouldAddTransaction)
            {
                var newTransaction = new Transaction
                {
                    Description = dialogVieWModel.Description
                };
                Transactions.Add(newTransaction);
                throw new Exception("Sample crash");
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