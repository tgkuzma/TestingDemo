using System;
using Models;
using Testing.ViewModels;
using NUnit.Framework;

namespace UnitTests.Views
{
    [TestFixture]
    public class CustomerViewModelTests
    {
        #region Setup / Tear Down
        /// <summary>
        /// This runs only once at the beginning of all tests and is used for all tests in the
        /// class.
        /// </summary>
        [OneTimeSetUp]
        public void InitialSetup()
        {
        }

        /// <summary>
        /// This runs only once at the end of all tests and is used for all tests in the class.
        /// </summary>
        [OneTimeTearDown]
        public void FinalTearDown()
        {
        }

        /// <summary>
        /// This setup funcitons runs before each test method
        /// </summary>
        [SetUp]
        public void SetupForEachTest()
        {
        }

        /// <summary>
        /// This setup funcitons runs after each test method
        /// </summary>
        [TearDown]
        public void TearDownForEachTest()
        {
        }
        #endregion Setup / Tear Down

        [Test]
        public void Returns_Hydrated_CustomerViewModel_With_FullName()
        {
            //Arange
            var customer = CustomerCreator.CreateSingleCustomer(20);

            //Act
            var viewModel = new CustomerViewModel(customer);

            //Assert
            Assert.AreEqual(customer.FirstName + " " + customer.LastName, viewModel.FullName);
        }

        [TestCase(17)]
        [TestCase(21)]
        public void IsUnderAge_Flag_Set_Correctly(int age)
        {
            //Arange
            var customer = CustomerCreator.CreateSingleCustomer(age);
            var isUnderAge = age < 18;

            //Act
            var viewModel = new CustomerViewModel(customer);

            //Assert
            Assert.IsTrue(isUnderAge == viewModel.IsUnderAge);
        }
    }
}