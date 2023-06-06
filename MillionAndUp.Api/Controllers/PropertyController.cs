using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Api.Application.Models;
using MillionAndUp.Api.Application.Validators;
using MillionAndUp.Domain;
using MillionAndUp.Infraestructure.Interfaces;
using Newtonsoft.Json;
using System;
using System.Drawing;

namespace MillionAndUp.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IServiceProperty<Property> propertyService;
        private readonly IMapper mapper;
        private readonly Validators validators;
        public PropertyController(IServiceProperty<Property> propertyService, IMapper mapper, Validators validators)
        {
            this.propertyService = propertyService;
            this.mapper = mapper;
            this.validators = validators;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PropertyModel propertyModel)
        {
            try
            {
                Property propetry = mapper.Map<Property>(propertyModel);
                await propertyService.Add(propetry);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
            }
        }

        [HttpPatch]
        [Route("ChangePrice")]
        public async Task<IActionResult> ChangePrice(ChangePriceModel changePriceModel)
        {
            try
            {
                var result = await propertyService.ChangePrice(changePriceModel.IdProperty, changePriceModel.Price);
                return Ok(new { Status = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(PropertyEditModel propertyEditModel)
        {
            try
            {
                Property propetry = mapper.Map<Property>(propertyEditModel);
                var result = await propertyService.Update(propetry);
                return Ok(new { Status = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Getid(int id)
        {
            try
            {
                var result = await propertyService.GetId(id);
                PropertyModel propetry = mapper.Map<PropertyModel>(result);
                return Ok(propetry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
            }
        }
        //[HttpGet]
        //[Route("images")]
        //public async Task<IActionResult> GetPropertyWithImages(int id)
        //{
        //    try
        //    {
        //        var result = await propertyService.GetId(id);
        //        PropertyModel propetry = mapper.Map<PropertyModel>(result);
        //        return Ok(propetry);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
        //    }
        //}
        [HttpGet]
        [Route("filters/{page}/{size}")]
        public async Task<IActionResult> GetPropertyFilters([FromQuery] int? year, [FromQuery] string? priceRange, int page, int size)
        {
            try
            {
                var filters = validators.ValidateFilter(year, priceRange, page, size);
                var result = await propertyService.GetFilters(filters);
                List<PropertyModel> properties = mapper.Map<List<PropertyModel>>(result);
                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
            }
        }
    }
}
