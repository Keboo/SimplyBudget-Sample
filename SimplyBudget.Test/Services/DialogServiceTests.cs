using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplyBudget.Services;

namespace SimplyBudget.Test.Services
{
    public abstract class DialogServiceBaseTests
    {
        protected abstract IDialogService CreateService();

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public async Task CanShowDialogWithBooleanReturn(bool expectedResult)
        {
            //Arrange
            IDialogService sut = CreateService();
            var dialog = new object();

            //Act
            bool result = await sut.Show(dialog);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }

    [TestClass]
    public class DialogServiceTests : DialogServiceBaseTests
    {
        protected override IDialogService CreateService()
        {
            return new SimplyBudget.Services.DialogService();
        }
    }

    [TestClass]
    public class DialogServiceSimulatorTests : DialogServiceBaseTests
    {
        protected override IDialogService CreateService()
        {
            return new Simulators.DialogService(x => true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsOnNull()
        {
            new Simulators.DialogService(null);
        }
    }
}