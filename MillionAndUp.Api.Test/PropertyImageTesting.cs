using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Api.Application.Models;
using MillionAndUp.Api.Controllers;
using MillionAndUp.Domain.Enum;
using MillionAndUp.Domain.Interfaces.Repository;
using MillionAndUp.Domain;
using MillionAndUp.Infraestructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionAndUp.Infraestructure.Interfaces;
using MillionAndUp.Api.Application.Mapper;

namespace MillionAndUp.Api.Test
{
    public class PropertyImageTesting
    {
        private readonly PropertyImageController propertyImageController;
        protected Mock<IReposityImage<PropertyImage>> iRepositoryPropertyImage = new();
        protected Mock<IRepositoryProperty<Property>> iRepositoryProperty = new();
        protected IServiceImage<PropertyImage> serviceImage;

        public PropertyImageTesting()
        {

            var config = new MapperConfiguration(cfg => cfg.AddProfile<PropertyImageProfile>());
            var mapper = config.CreateMapper();

            iRepositoryPropertyImage.Setup(x => x.AddRangeAsync(GetPropertyImages()));

            ;
            iRepositoryProperty.Setup(x => x.GetId(1)).Returns(Task.FromResult(GetProperty()));

            iRepositoryPropertyImage.Setup(x => x.Save()).Returns(Task.FromResult(1));



            serviceImage = new PropertyImageService(iRepositoryPropertyImage.Object, iRepositoryProperty.Object);
            propertyImageController = new PropertyImageController(serviceImage, mapper);
        }

        [Fact]
        public async Task AddPPropertyImageTest()
        {

            var response = (StatusCodeResult)await propertyImageController.Post(new List<PropertyImageModel>() {
                new()
                {
                    IdProperty = 1,
                    File = "test.img",
                    Enabled = true
                },
                new()
                {
                    IdProperty = 1,
                    File = "test2.img",
                    Enabled = true
                }});
            Assert.Equal(StatusCodes.Status201Created, response.StatusCode);
        }

        public static Property GetProperty()
        {
            Property propertyModel = new()
            {
                Name = "Name",
                Address = "calle 7sur",
                CodeInternal = "123456789",
                Price = 200000.5,
                IdOwner = 1,
                TypeProperty = TypeProperty.Building,
                Year = 2020
            };
            propertyModel.PropertyImages?.Add(new()
            {
                File = "test.img",
                Enabled = true
            });
            return propertyModel;
        }

        public static List<PropertyImage> GetPropertyImages() => new()
        {
            new()
            {
                File = "test.img",
                Enabled = true
            },
            new()
            {
                File = "test2.img",
                Enabled = true
            }
        };
    }
}

