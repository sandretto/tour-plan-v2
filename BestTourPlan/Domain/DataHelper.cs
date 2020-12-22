using BestTourPlan.Domain.Repositories.Abstract;

namespace BestTourPlan.Domain
{
    public class DataHelper
    {
        public IHotelRepository Hotels { get; set; }

        public DataHelper(IHotelRepository hotelsRepository)
        {
            Hotels = hotelsRepository;
        }
    }
}
