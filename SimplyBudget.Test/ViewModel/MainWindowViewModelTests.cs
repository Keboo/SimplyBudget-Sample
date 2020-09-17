using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplyBudget.Test.Simulators;
using SimplyBudget.ViewModel;

namespace SimplyBudget.Test.ViewModel
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void CanRemoveExistingTransaction()
        {
            //Arrange
            var sut = new MainWindowViewModel(new DialogService(x => null));
            var transaction = new Transaction();
            sut.Transactions.Add(transaction);

            //Act
            sut.RemoveTransaction.Execute(transaction);

            //Assert
            Assert.AreEqual(0, sut.Transactions.Count);
        }

        [TestMethod]
        public void CanAddTransaction()
        {
            //Arrange
            var dialogService = new DialogService(x => true);
            var sut = new MainWindowViewModel(dialogService);

            //Act
            sut.AddTransaction.Execute(null);

            //Assert
            Assert.AreEqual(1, sut.Transactions.Count);
        }
    }
}
