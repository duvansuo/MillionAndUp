using MillionAndUp.Domain.Interfaces.Repository;
using MillionAndUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionAndUp.Infraestructure.Interfaces;

namespace MillionAndUp.Infraestructure.Services
{
    public class PropertyImageService : IServiceImage<PropertyImage>
    {

        private readonly IReposityImage<PropertyImage> repositoryPropertyImage;
        private readonly IRepository<Property, int> repositoryProperty;

        public PropertyImageService(IReposityImage<PropertyImage> repositoryPropertyImage, IRepository<Property, int> repositoryProperty)
        {
            this.repositoryPropertyImage = repositoryPropertyImage;
            this.repositoryProperty = repositoryProperty;
        }

        public async Task<PropertyImage> Add(PropertyImage propertyImage)
        {
            try
            {
                var validateOwner = await repositoryProperty.GetId(propertyImage.IdProperty);
                if (validateOwner == null) throw new NullReferenceException("Property id does not exist");
                var result = await repositoryPropertyImage.Add(propertyImage);
                await repositoryProperty.Save();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddRangeAsync(List<PropertyImage> propertyImages)
        {
            var propertyids = propertyImages.Select(i => i.IdProperty).Distinct().ToList();
            foreach (var item in propertyids)
            {
                var validateOwner = await repositoryProperty.GetId(item);
                if (validateOwner == null) throw new NullReferenceException($"Property id:{item} does not exist");
            }
            await repositoryPropertyImage.AddRangeAsync(propertyImages);
            await repositoryProperty.Save();
            return true;
        }
    }
}
