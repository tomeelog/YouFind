using System;
using System.Data;
using YouFindAssessment.BusinessLogic.Services.HotelDataService;
using YouFindAssessment.BusinessLogic.Services.HotelService;
using YouFindAssessment.Common.Models;

namespace YouFindAssessment.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
             string fileName = "task 2 - hotelrates.json";
            var mainHotel = new JsonDataMapper(fileName).Deserialize<HotelData>(new HotelData());

            DataTable mainHotelTable = mainHotel.AsDataTable();

            var reportService = new DocumentService("HotelRateReport");
            reportService.LoadFromDataTable(mainHotelTable);
            reportService.Dispose();
        }
    }
}
