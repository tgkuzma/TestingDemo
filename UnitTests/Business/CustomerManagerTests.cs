using System;
using System.Collections.Generic;
using Business;
using Models;
using Models.Interfaces;
using Moq;
using NUnit.Framework;

namespace UnitTests.Business
{
    [TestFixture]
    public class CustomerManagerTests
    {
        private Mock<ICustomerRepository> _mockCustomerRepository;
        private CustomerManager _customerManager;

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
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _customerManager = new CustomerManager(_mockCustomerRepository.Object);
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
        public void GetAllCustomers_Calls_Repository_Once()
        {
            //Arange
            _mockCustomerRepository.Setup(x => x.GetAll()).Returns(new List<Customer>());

            //Act
            _customerManager.GetAllCustomers();

            //Assert
            _mockCustomerRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void GetCustomerById_Calls_Repository_Once()
        {
            //Arange
            _mockCustomerRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Customer());

            //Act
            _customerManager.GetCustomerById(It.IsAny<int>());

            //Assert
            _mockCustomerRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetCustomerByDateOfBirth_Calls_Repository_Once()
        {
            //Arange
            _mockCustomerRepository.Setup(x => x.GetByDateOfBirth(It.IsAny<DateTime>())).Returns(new Customer());

            //Act
            _customerManager.GetCustomerByDateOfBirth(It.IsAny<DateTime>());

            //Assert
            _mockCustomerRepository.Verify(x => x.GetByDateOfBirth(It.IsAny<DateTime>()), Times.Once);
        }

        [Test]
        public void AddNewCustomer_Calls_Repository_Twice()
        {
            //Arange
            var customer = CustomerCreator.CreateSingleCustomer(20);

            //Act
            _customerManager.AddNewCustomer(customer);

            //Assert
            _mockCustomerRepository.Verify(x => x.Add(It.IsAny<Customer>()), Times.Once);
            _mockCustomerRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteCustomer_Calls_Repository_Twice()
        {
            //Arange
            var customer = CustomerCreator.CreateSingleCustomer(20);

            //Act
            _customerManager.DeleteCustomer(customer);

            //Assert
            _mockCustomerRepository.Verify(x => x.Delete(It.IsAny<Customer>()), Times.Once);
            _mockCustomerRepository.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void UpdateCustomer_Calls_Repository_Once()
        {
            //Arange

            //Act
            _customerManager.UpdateCustomer();

            //Assert
            _mockCustomerRepository.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}