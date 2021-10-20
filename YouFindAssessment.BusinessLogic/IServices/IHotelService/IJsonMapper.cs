using System;
using System.Collections.Generic;
using System.Text;

namespace YouFindAssessment.BusinessLogic.IServices.IHotelService
{
    public interface IJsonMapper
    {
        T Deserialize<T>(T entity, string fileName);
    }
}
