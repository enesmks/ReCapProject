﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Abstracts.Autofac.Caching;
using Core.Abstracts.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal imageDal)
        {
            _carImageDal = imageDal;
        }
        [SecuredOperation("admin,supplier")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carImage.CarId), CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,supplier")]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            var image = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            if (image == null)
            {
                return new ErrorResult();
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.ImageId == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll().ToList());
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId).ToList());
        }

        [SecuredOperation("admin,supplier")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            if (isImage == null)
            {
                return new ErrorResult();
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }


        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Count;
                if (result >= 1)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(CarImage carImage)
        {
            _carImageDal.Add(carImage);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
