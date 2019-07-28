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
		public HttpResponseMessage GetCustomers()
		{
			var customers = _telecomDBServices.GetAllCustomers();
			if (customers != null)
				return Request.CreateResponse(HttpStatusCode.OK, customers);
			return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer data is empty.");
		}

		[HttpGet]
		public HttpResponseMessage GetCustomer(int CustomerId)
		{
			var customer = _telecomDBServices.GetCustomer(CustomerId);
			if (customer != null)
				return Request.CreateResponse(HttpStatusCode.OK, customer);
			return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer data is empty.");
		}

		[HttpGet]
		public HttpResponseMessage AddCutomerPhoneNumber(int CustomerId, string PhoneNumber, bool Active)
		{
			var customer = _telecomDBServices.AddCutomerPhoneNumber(CustomerId, PhoneNumber, Active);
			if (customer != null)
				return Request.CreateResponse(HttpStatusCode.OK, customer);
			return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer data is empty.");
		}

		[HttpGet]
		public HttpResponseMessage UpdateCutomerPhoneNumber(int CustomerId, string PhoneNumber, bool Active)
		{
			var customer = _telecomDBServices.UpdateCutomerPhoneNumber(CustomerId, PhoneNumber, Active);
			if (customer != null)
				return Request.CreateResponse(HttpStatusCode.OK, customer);
			return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer data is empty.");
		}

	}
}
