using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Api.Application.Models;
using MillionAndUp.Domain;
using MillionAndUp.Infraestructure.Interfaces;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MillionAndUp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IServiceImage<PropertyImage> propertyImageService;
        private readonly IMapper mapper;

        public PropertyImageController(IServiceImage<PropertyImage> propertyImageService, IMapper mapper)
        {
            this.propertyImageService = propertyImageService;
            this.mapper = mapper;
        }
        // POST api/<PropertyImageController>
        [HttpPost]
        public async Task<IActionResult> Post(List<PropertyImageModel> propertyImagesModel)
        {
            try
            {
                List<PropertyImage> propertyImages = mapper.Map<List<PropertyImage>>(propertyImagesModel);
                var result = await propertyImageService.AddRangeAsync(propertyImages);
                return Ok(new { Status = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
            }
        }
        [HttpPost]
        [Route("one")]
        public async Task<IActionResult> Post(PropertyImageModel propertyImageModel)
        {
            try
            {
                PropertyImage propertyImage = mapper.Map<PropertyImage>(propertyImageModel);
                var result = await propertyImageService.Add(propertyImage);
                return Ok(new { Status = true, id= result.IdPropertyImage });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(ex));
            }
        }


    }
}
