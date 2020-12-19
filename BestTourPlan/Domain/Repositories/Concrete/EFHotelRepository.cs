using BestTourPlan.Domain.Entities;
using BestTourPlan.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BestTourPlan.Domain.Repositories.Concrete
{
    public class EFHotelRepository : IHotelRepository
    {
        private readonly AppDbContext context;

        public EFHotelRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteHotel(Guid id)
        {
            context.Hotels.Remove(new Hotel() { Id = id });
            context.SaveChanges();
        }

        public Hotel GetHotelById(Guid id)
        {
            var hotel = context.Hotels.FirstOrDefault(x => x.Id == id);

            if (hotel == null)
            {
                Console.WriteLine($"Could not find hotel with Id {id}");
                return null;
            }
            return hotel;
        }

        public IQueryable<Hotel> GetHotels()
        {
            return context.Hotels;
        }

        public void SaveHotel(Hotel hotel)
        {
            context.Entry(hotel).State = hotel.Id == default ? 
                EntityState.Added : EntityState.Modified;
            context.SaveChanges();
        }
    }
}
