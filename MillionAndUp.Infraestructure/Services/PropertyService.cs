using MillionAndUp.Domain;
using MillionAndUp.Domain.Interfaces.Repository;
using MillionAndUp.Infraestructure.Interfaces;

namespace MillionAndUp.Infraestructure.Services
{
    public class PropertyService : IServiceProperty
    {

        private readonly IRepository<Property, int> repositoryProperty;
        private readonly IRepository<Owner, int> repositoryOwner;
        private readonly IReposityImage<PropertyImage> repositoryPropertyImage;

        public PropertyService(IRepository<Property, int> repositoryProperty, IRepository<Owner, int> repositoryOwner,
                               IReposityImage<PropertyImage> repositoryPropertyImage)
        {
            this.repositoryProperty = repositoryProperty;
            this.repositoryOwner = repositoryOwner;
            this.repositoryPropertyImage = repositoryPropertyImage;
        }

        public async Task<Property> Add(Property property)
        {
            try
            {
                var validateOwner = await repositoryOwner.GetId(property.IdOwner);
                if (validateOwner == null) throw new NullReferenceException("Owner id does not exist");
                var result = await repositoryProperty.Add(property);
                await repositoryProperty.Save();
                var SaveImages = AddImages(property.PropertyImages.ToList());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(Property property)
        {
            try
            {
                var propertyResult = await ValidateExist(property);
                propertyResult.Name = property.Name;
                propertyResult.Address = property.Address;
                propertyResult.Year = property.Year;
                propertyResult.Price = property.Price;
                propertyResult.CodeInternal = property.CodeInternal;
                propertyResult.TypeProperty = property.TypeProperty;
                propertyResult.IdOwner = property.IdOwner;
                await repositoryProperty.Update(propertyResult);
                return await repositoryProperty.Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Property>> GetAll()
        {
            try
            {
                var result = await repositoryProperty.GetAll();
                await repositoryProperty.Save();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Property> GetId(int id)
        {
            try
            {
                var result = await repositoryProperty.GetId(id);
                await repositoryProperty.Save();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ChangePrice(int id, double Price)
        {
            try
            {
                var validateProperty = await repositoryProperty.GetId(id);
                if (validateProperty == null) throw new NullReferenceException("Property id does not exist.");
                validateProperty.Price = Price;
                repositoryProperty.Update(validateProperty);
                var result = await repositoryProperty.Save();
                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task AddImages(List<PropertyImage> propertyImages)
        {
            try
            {
                await repositoryPropertyImage.AddRangeAsync(propertyImages);
                await repositoryPropertyImage.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<Property> ValidateExist(Property property)
        {
            try
            {
                var validateProperty = await repositoryProperty.GetId(property.IdProperty);
                if (validateProperty == null) throw new NullReferenceException("Property id does not exist.");
                var validateOwner = await repositoryOwner.GetId(property.IdOwner);
                if (validateOwner == null) throw new NullReferenceException("Owner id does not exist");
                return validateProperty;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
