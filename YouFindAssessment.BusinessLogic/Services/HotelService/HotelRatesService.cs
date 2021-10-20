using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouFindAssessment.BusinessLogic.IServices.IHotelService;
using YouFindAssessment.Common.Models;

namespace YouFindAssessment.BusinessLogic.Services.HotelService
{
    public class HotelRatesService : IHotelRatesService
    {
        private readonly IJsonMapper _mapper;
        private IEnumerable<MainHotel> _mainHotels;

        public HotelRatesService(IJsonMapper mapper)
        {
            _mapper = mapper;

            _mainHotels = _mapper.Deserialize<IEnumerable<MainHotel>>(new List<MainHotel>(), "task 3 - hotelsrates.json");
        }

        public MainHotel GetHotelRates(int hotelId, DateTime arrivalDate)
        {
            var filteredHotel = _mainHotels.SingleOrDefault(h => h.hotel.hotelId == hotelId);
            if (filteredHotel == null)
            {
                throw new ArgumentNullException("Hotel not found");
            }
            //filter hotel rates by provided arrival date
            var filteredRates = filteredHotel.hotelRates.Where(r => r.targetDay.Date == arrivalDate.Date);
            return new MainHotel { hotel = filteredHotel.hotel, hotelRates = filteredRates.ToList() };
        }
    }
}
