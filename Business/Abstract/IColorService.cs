using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        void AddToSystem(Color color);
        void UpdateToSystem(Color color);
        void DeleteToSystem(Color color);
        List<Color> GetAll();
        
    }
}
