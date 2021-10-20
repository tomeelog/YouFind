using System;
using System.Collections.Generic;
using System.Text;
using YouFindAssessment.Common.Models;

namespace YouFindAssessment.BusinessLogic.IServices.IHotelService
{
    public interface IHotelRatesService
    {
        MainHotel GetHotelRates(int hotelId, DateTime arrivalDate);
    }
}
