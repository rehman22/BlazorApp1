using BlazorApp1.Data;
using BlazorApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer RegisterCustomer(string customerName, string cnic, string fatherName, string cellNo, string address, string accountNo)
        {
            // Check if the CNIC is unique
            //if (_context.Customers.Any(c => c.CNIC.Equals(cnic, StringComparison.OrdinalIgnoreCase)))
            //{
            //    // CNIC is not unique
            //    return null;
            //}

            // Create a new customer
            var customer = new Customer
            {
                CustomerName = customerName,
                CNIC = cnic,
                FatherName = fatherName,
                CellNo = cellNo,
                Address = address,
                AccountNo = accountNo
            };

            // Add the customer to the database
            _context.Customers.Add(customer);
            _context.SaveChanges(); // Save changes to the database

            return customer;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public List<Customer> GetCustomers() // Add this method
        {
            return _context.Customers.ToList();
        }
        public List<Customer> FilterCustomers(List<Customer> customers, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return customers.ToList(); // Return all customers if the search term is empty
            }

            // Case-insensitive search based on customer properties
            return customers.Where(c =>
                c.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.CNIC.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.FatherName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.CellNo.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.Address.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.AccountNo.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }

}
