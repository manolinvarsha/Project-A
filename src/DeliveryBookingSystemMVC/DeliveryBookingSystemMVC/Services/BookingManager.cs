using DeliveryBookingSystemMVC.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC.Services
{
    public class BookingManager : ILogin<Booking>
    {
        public DeliveryContext _context;
        public ILogger<BookingManager> _logger;
        public BookingManager(DeliveryContext context, ILogger<BookingManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Booking t)
        {
            try
            {
                _context.Bookings.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Booking Get(int id)
        {
            try
            {
                Booking b = _context.Bookings.FirstOrDefault(a => a.OrderId == id);
                return b;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Booking> GetAll()
        {
            try
            {
                if ((_context.Bookings) == null)
                    return null;
                return _context.Bookings.ToList();

            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }



        public int Login(Booking t)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Booking t)
        {
            Booking b = Get(id);
            if (b != null)
            {
                b.City = t.City;
            }
            _context.SaveChanges();

        }
    }
}
