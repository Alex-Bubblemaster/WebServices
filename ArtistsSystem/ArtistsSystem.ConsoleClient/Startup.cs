namespace ArtistsSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Models;
    using Data;
    using Data.Migrations;
    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsSystemDbContext, Configuration>());
            ArtistsSystemDbContext.Create().Database.Initialize(true);

            Console.WriteLine("Loading server...");
            Thread.Sleep(2000);

            var countriesConnection = "http://localhost:59705/api/countries";
            GetJsonCountries(new Uri(countriesConnection));
            Thread.Sleep(2000);

            PostCountry(countriesConnection, "Bulgaria");
            PostCountry(countriesConnection, "Russia");
            PutCountry(countriesConnection + "/9", "Indonesia");
            DeleteCoutry(countriesConnection);
            Console.ReadLine();
        }

        public static async Task<string> GetResponseString(Uri connection)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(connection);
                var contents = await response.Content.ReadAsStringAsync();

                return contents;
            }
        }

        // GET All countries
        private static void GetJsonCountries(Uri connection)
        {
            using (var client = new HttpClient())
            {
                var countriesJson = GetResponseString(connection).Result;
                var countries = JsonConvert.DeserializeObject<IEnumerable<CountryRequestModel>>(countriesJson);

                Console.WriteLine("Printing countries...");
                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }

        // POST a country
        private static async void PostCountry(string connection, string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(connection);
                var countryToAdd = new CountryRequestModel
                {
                    Name = name,
                    Id = 10
                };

                var result = await client.PostAsJsonAsync(connection, countryToAdd);
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
            }
        }

        // PUT request doesn't work for some reason
        private static async void PutCountry(string connection, string name)
        {
            using (var client = new HttpClient())
            {
                var countryToUpdate = new CountryRequestModel
                {
                    Name = name
                };

                client.BaseAddress = new Uri(connection);
                var response = await client.PutAsJsonAsync(connection, countryToUpdate);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("{0} added sccuessfully!", countryToUpdate.Name);
                }
                else
                {
                    Console.WriteLine("Awww that's awkward... Nothing has been added!");
                }
            }
        }

        // DELETE request doesn't work for some reason
        private static async void DeleteCoutry(string connection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(connection);
                var response = await client.DeleteAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success!");
                }
                else
                { 
                    Console.Write("Awww that's also awkward... Nothing has been deleted!");
                }
            }
        }
    }
}