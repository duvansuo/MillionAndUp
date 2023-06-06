using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MillionAndUp.Api.Application.Mapper;
using MillionAndUp.Api.Application.Models;
using MillionAndUp.Api.Application.Validators;
using MillionAndUp.Api.Controllers;
using MillionAndUp.Domain;
using MillionAndUp.Domain.Enum;
using MillionAndUp.Domain.Interfaces.Repository;
using MillionAndUp.Infraestructure.Interfaces;
using MillionAndUp.Infraestructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Xunit;
using Validators = MillionAndUp.Api.Application.Validators.Validators;

namespace MillionAndUp.Api.Test
{
    public class PropertyTesting
    {

        private readonly PropertyController propertyController;
        private readonly Validators validators;
        protected Mock<IRepositoryProperty<Property>> iRepositoryProperty = new();
        protected Mock<IRepositoryBase<Owner, int>> iRepositoryOwner = new();
        protected Mock<IReposityImage<PropertyImage>> iRepositoryPropertyImage = new();
        protected IServiceProperty<Property> serviceProperty;

        public PropertyTesting()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile> { new PropertyProfile(), new PropertyImageProfile() }));
            var mapper = config.CreateMapper();

            iRepositoryProperty.Setup(x => x.Add(GetProperty())).Returns(Task.FromResult(GetProperty()));
            iRepositoryProperty.Setup(x => x.GetId(1)).Returns(Task.FromResult(GetProperty()));
            iRepositoryProperty.Setup(x => x.Update(GetProperty())).Returns(Task.FromResult(true));
            iRepositoryProperty.Setup(x => x.GetFilters(FiltersModel())).Returns(Task.FromResult(GetPropertyList()));
            iRepositoryProperty.Setup(x => x.Save()).Returns(Task.FromResult(1));

            iRepositoryOwner.Setup(x => x.GetId(1)).Returns(Task.FromResult(GeOwner()));

            iRepositoryPropertyImage.Setup(x => x.AddRangeAsync(GetPropertyImages()));
            validators = new Validators();
            serviceProperty = new PropertyService(iRepositoryProperty.Object, iRepositoryOwner.Object, iRepositoryPropertyImage.Object);
            propertyController = new PropertyController(serviceProperty, mapper, validators);
        }

        [Fact]
        public async Task AddPPropertyTest()
        {

            PropertyModel propertyModel = new()
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
            var response = (StatusCodeResult)await propertyController.Post(propertyModel);
            Assert.Equal(StatusCodes.Status201Created, response.StatusCode);
        }

        [Fact]
        public async Task ChangePriceTest()
        {

            ChangePriceModel changePriceModel = new()
            {
                IdProperty = 1,
                Price = 200000.5
            };
            var response = await propertyController.ChangePrice(changePriceModel);
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public async Task UpdateTest()
        {
            PropertyEditModel propertyEditModel = new()
            {
                IdProperty = 1,
                Name = "Name",
                Address = "calle 7sur",
                CodeInternal = "123456789",
                Price = 200000.5,
                IdOwner = 1,
                TypeProperty = TypeProperty.Building,
                Year = 2020
            };

            var response = await propertyController.Update(propertyEditModel);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetPropertyFiltersTest()
        {

            var response = await propertyController.GetPropertyFilters(null, null, 1, 10);
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.IsType<List<PropertyModel>>(result?.Value);
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
        public static Owner GeOwner() => new()
        {
            Address = "calle 7sur",
            Birhday = System.DateTime.Now,
            IdOwner = 1,
            Name = "Name",
            Photo = "Foto.img"
        };
        public static FiltersModel FiltersModel() => new()
        {

            Page = 1,
            Size = 10
        };


        public static List<Property> GetPropertyList()
        {
            List<Property> properties = new();
            Property propertyModel = new()
            {
                Name = "Name",
                Address = "calle 7sur",
                CodeInternal = "123456789",
                Price = 10,
                IdOwner = 1,
                TypeProperty = TypeProperty.Building,
                Year = 2022
            };
            propertyModel.PropertyImages?.Add(new()
            {
                File = "test.img",
                Enabled = true
            });
            for (int i = 0; i <= 2; i++)
            {
                propertyModel.IdProperty = i;
                properties.Add(propertyModel);
            }
            return properties;
        }
    }

}
