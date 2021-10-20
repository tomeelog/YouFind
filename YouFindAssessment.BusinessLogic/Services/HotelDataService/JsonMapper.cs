using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YouFindAssessment.BusinessLogic.Services.HotelDataService
{
    public class JsonDataMapper
    {
        public string fileName { get; set; }
        public JsonDataMapper(string name)
        {
            fileName = name;
        }

        public T Deserialize<T>(T entity)
        {
            //get json file as filestream
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {
                string json = r.ReadToEnd();
                var type = entity.GetType();
                //Deserialize hoterates.json into T class
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
