using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void AddToSystem(Color color)
        {
            _colorDal.Add(color);
        }

        public void DeleteToSystem(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }


        public void UpdateToSystem(Color color)
        {
            _colorDal.Update(color);
        }

        
    }
}
