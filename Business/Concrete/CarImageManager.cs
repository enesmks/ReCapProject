using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(IFormFile file, CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.ImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int carImageId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carImageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(x => x.ImageId == carImage.ImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        private IResult CheckImageCount(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId && x.ImageId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CheckImageCount);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int carImageId)
        {
            string path = @"\Images\logo.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carImageId);
            if (result != null)
            {
                return new List<CarImage> { new CarImage { CarId = carImageId, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(x => x.CarId == carImageId);
        }
    }
}
