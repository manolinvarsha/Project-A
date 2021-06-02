using DeliveryBookingSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
   
    namespace DeliveryBookingSystemMVC.Services
    {
    public class CustomerManager : ILogin<Customer>
    {
        public DeliveryContext _context;
        public ILogger<CustomerManager> _logger;
        public CustomerManager(DeliveryContext context, ILogger<CustomerManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Customer t)
        {
            try
            {
                _context.Customers.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

     
        public IEnumerable<Customer> GetAll()
        {
            try
            {
                if ((_context.Customers) == null)
                    return null;
                return _context.Customers.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }



        public int Login(Customer t)
        {
            Customer obj = _context.Customers.Where((i => i.Username.Equals(t.Username) && i.Password.Equals(t.Password) && i.IsVerified == "Verified")).FirstOrDefault();

            try
            {
                if (obj != null)
                {
                    return obj.CustomerId;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }
        public Customer Get(int id)
        {
            try
            {
                Customer customer = _context.Customers.FirstOrDefault(a => a.CustomerId == id);
                return customer;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Customer t)
        {
            Customer customer = Get(id);
            if (customer != null)
            {
                customer.IsVerified = t.IsVerified;
            }
            _context.SaveChanges();
          
        }
    }
}


          
    
