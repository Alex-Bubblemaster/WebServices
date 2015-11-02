namespace ArtistsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class CountriesController : ApiController
    {
        private readonly ArtistsSystemDbContext db;

        public CountriesController()
        {
            this.db = new ArtistsSystemDbContext();
        }
        public IHttpActionResult Get()
        {
            var countries = db.Countries
                .AsQueryable()
                .ProjectTo<CountryRequestModel>()
                .ToList();

            return this.Ok(countries);
        }

        public IHttpActionResult Get(int id)
        {
            var country = db.Countries
                .ProjectTo<CountryRequestModel>()
                .FirstOrDefault(c => c.Id == id);
                

            if (country == null)
            {
                return this.NotFound();
            }

            return this.Ok(country);
        }

        public IHttpActionResult Post(CountryRequestModel countryToAdd)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var dbCountry = new Country
            {
                Name = countryToAdd.Name
            };

            db.Countries.Add(dbCountry);
            db.SaveChanges();

            return this.Ok(string.Format("{0} was added to Countries database!", countryToAdd.Name));
        }

        [HttpPut]
        public IHttpActionResult Update(CountryRequestModel targetCountry)
        {
            var countryToUpdate = db.Countries
               .FirstOrDefault(c => c.Id == targetCountry.Id);

            if (countryToUpdate == null)
            {
                return this.NotFound();
            }

            countryToUpdate.Name = targetCountry.Name;
            db.SaveChanges();

            return this.Ok(string.Format("The name of the country with id {0}, was successfully updated to {1}", targetCountry.Id, targetCountry.Name));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var countryToDelete = db.Countries
                .FirstOrDefault(c => c.Id == id);

            if (countryToDelete == null)
            {
                return this.NotFound();
            }

            db.Countries.Remove(countryToDelete);
            db.SaveChanges();
            return this.Ok(string.Format("{0} was deleted!", countryToDelete.Name));
        }
    }
}
