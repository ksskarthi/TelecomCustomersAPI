using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using TelecomCustomersAPI.DataServices;
using TelecomCustomersAPI.Classes;

namespace TelecomDataServices.Controllers
{
    public class CustomersController : ApiController
    {
		private static SqlCredentials _credentials = HelperClass.GetSQLCredentials();

		private static TelecomDBServices _telecomDBServices = new TelecomDBServices(HelperClass.GetConfigurationStringData("ConnectionString"));

		[HttpGet]
		public string Hello()
		{
			return "Hello world";
		}


		[HttpGet]
		public List<Customer> GetDummyCustomers()
		{
			return new List<Customer> { new Customer { CustomerId = 1, FirstName = "tester", LastName = "tester lastname", Title = "mr", PhoneNumbers = new List<CustomerPhoneNumber> { new CustomerPhoneNumber { IsActive = true, PhoneNumber = "038489384" } } } };
		}

		[HttpGet]
		public List<Customer> GetCustomers()
		{
			return _telecomDBServices.GetAllCustomers();
		}

		[HttpGet]
		public Customer GetCustomer(int CustomerId)
		{
			return _telecomDBServices.GetCustomer(CustomerId);
		}

		[HttpGet]
		public Customer AddCutomerPhoneNumber(int CustomerId, string PhoneNumber, bool Active)
		{
			return _telecomDBServices.AddCutomerPhoneNumber(CustomerId, PhoneNumber, Active);
		}

		[HttpGet]
		public Customer UpdateCutomerPhoneNumber(int CustomerId, string PhoneNumber, bool Active)
		{
			return _telecomDBServices.UpdateCutomerPhoneNumber(CustomerId, PhoneNumber, Active);
		}

	}
}
