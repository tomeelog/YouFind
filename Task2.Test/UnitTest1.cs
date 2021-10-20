using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using YouFindAssessment.Common.Models;

namespace Task2.Test
{
    public class Task2_Tests
    {
        private HotelData _mainHotel;
        private DataTable _dt;
        [SetUp]
        public void Setup()
        {
            _mainHotel = new HotelData
            {
                hotel = new Hotel { classification = 1, hotelId = 1, name = "Test Hotel", reviewscore = 1.2 },
                hotelRates = new List<HotelRate> {
                    new HotelRate {
                        adults=2,
                        los=1,
                        price= new Price {currency = "EUR", numericFloat=325.5, numericInteger=32550},
                        rateDescription = "Test Description",
                        rateID = "_TESTID",
                        rateName = "My Test RateName",
                        rateTags = new List<RateTag>{new RateTag{name = "Myrate", shape = true}},
                        targetDay = DateTime.Now
                        }
                }
            };

            _dt = _mainHotel.AsDataTable();
        }

        [Test]
        public void DataTable_Rows_Should_Be_Equal_To_HotelRates_Count()
        {
            //assert
            Assert.AreEqual(_mainHotel.hotelRates.Count, _dt.Rows.Count);
        }

        [Test]
        public void DataTable_Price_DataType_Should_Be_Equal_To_Double()
        {
            //Arrange
            double anyDoubleNumber = 1.2;
            var dtPrice = _dt.Rows[0]["PRICE"];

            //Act
            Type expectedDataType = anyDoubleNumber.GetType();
            Type dtPriceType = dtPrice.GetType();

            //assert
            Assert.AreEqual(expectedDataType, dtPriceType);
        }
    }
}