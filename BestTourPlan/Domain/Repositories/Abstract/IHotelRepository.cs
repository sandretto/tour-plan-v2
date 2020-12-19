using BestTourPlan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BestTourPlan.Domain.Repositories.Abstract
{
    public interface IHotelRepository
    {
        IQueryable<Hotel> GetHotels();
        Hotel GetHotelById(Guid id);
        void SaveHotel(Hotel hotel);
        void DeleteHotel(Guid id);
    }
}
