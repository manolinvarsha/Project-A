using DeliveryBookingSystemMVC.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC.Services
{
    public class ExecutiveManager : ILogin<DeliveryExecutive>
    {
        public DeliveryContext _context;
        public ILogger<ExecutiveManager> _logger;
        public ExecutiveManager(DeliveryContext context, ILogger<ExecutiveManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(DeliveryExecutive t)
        {
            try
            {
                _context.DeliveryExecutives.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }
        public IEnumerable<DeliveryExecutive> GetAll()
        {
            try
            {
                if ((_context.DeliveryExecutives) == null)
                    return null;
                return _context.DeliveryExecutives.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }



        public int Login(DeliveryExecutive t)
        {
            var obj = _context.DeliveryExecutives.Where(i => i.Username.Equals(t.Username) && i.Password.Equals(t.Password) && i.IsVerified == "Verified").FirstOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.ExecutiveId;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }
        public DeliveryExecutive Get(int id)
        {
            try
            {
                DeliveryExecutive delivery = _context.DeliveryExecutives.Where(a => a.ExecutiveId == id).FirstOrDefault();
                return delivery;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
        public void Update(int id, DeliveryExecutive t)
        {
            DeliveryExecutive delivery = Get(id);
            if (delivery != null)
            {
                delivery.IsVerified = t.IsVerified;
            }
            _context.SaveChanges();

        }
    }
}


