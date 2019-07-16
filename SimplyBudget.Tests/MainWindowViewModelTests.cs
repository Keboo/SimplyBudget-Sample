using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplyBudget.ViewModel;
using System.Linq;

namespace SimplyBudget.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void AddTransactionAddsANewTransaction()
        {
            //Arrange
            var viewModel = new MainWindowViewModel();

            //Act
            viewModel.AddTransaction.Execute(null);

            //Assert
            Assert.AreEqual(1, viewModel.Transactions.Count);
        }

        [TestMethod]
        public void RemoveTransactionRemovesTheSelectedTransaction()
        {
            //Arrange
            var viewModel = new MainWindowViewModel();
            var transaction1 = new Transaction { Description = "1" };
            var transaction2 = new Transaction { Description = "2" };
            viewModel.Transactions.Add(transaction1);
            viewModel.Transactions.Add(transaction2);

            //Act
            viewModel.RemoveTransaction.Execute(transaction1);

            //Assert
            Assert.AreEqual(transaction2, viewModel.Transactions.Single());
        }
    }
}
