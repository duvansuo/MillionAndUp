using AutoFixture;
using MillionAndUp.Domain;
using MillionAndUp.Infraestructure.Data;

namespace MillionAndUp.Api.DataSQL
{
    public static class OwnerDataSql
    {
        public static void Seed(this Context Context)
        {
            if (!Context.Owners.Any())
            {
                Fixture fixture = new();
                fixture.Customize<Owner>(x => x.Without(o => o.Properties).Without(o => o.IdOwner));
                List<Owner> owner = fixture.CreateMany<Owner>(10).ToList();
                Context.AddRange(owner);
                Context.SaveChanges();
            }
        }
    }
}