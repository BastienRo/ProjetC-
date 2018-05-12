using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Isen.DotNet.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SeedData> _logger;
        private readonly ICityRepository _cityRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IDepartementRepository _departementRepository;
        private readonly ICommuneRepository _communeRepository;
        private readonly IPointOfInterestRepository _pointsRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IAdresseRepository _adresseRepository;

        public SeedData(
            ApplicationDbContext context,
            ILogger<SeedData> logger,
            ICityRepository cityRepository,
            IPersonRepository personRepository,
            IDepartementRepository departementRepository,
            ICommuneRepository communeRepository,
            IAdresseRepository adresseRepository,
            ICategorieRepository categorieRepository,
            IPointOfInterestRepository pointsRepository)
        {
            _context = context;
            _logger = logger;
            _cityRepository = cityRepository;
            _personRepository = personRepository;
            _communeRepository = communeRepository;
            _adresseRepository = adresseRepository;
            _categorieRepository = categorieRepository;
            _pointsRepository = pointsRepository;
            _departementRepository = departementRepository;
        }

        public void DropDatabase()
        {
            var deleted = _context.Database.EnsureDeleted();
            var not = deleted ? "" : "not ";
            _logger.LogWarning($"Database was {not}dropped.");
        }

        public void CreateDatabase()
        {
            var created = _context.Database.EnsureCreated();
            var not = created ? "" : "not ";
            _logger.LogWarning($"Database was {not}created.");
        }

        public void AddCities()
        {
            if (_cityRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding cities");

            var cities = new List<City>
            {
                new City { Name = "Toulon" },
                new City { Name = "Marseille" },
                new City { Name = "Nice" },
                new City { Name = "Paris" },
                new City { Name = "Epinal" }
            };
            _cityRepository.UpdateRange(cities);
            _cityRepository.Save();

            _logger.LogWarning("Added cities");
        }

        public void AddPersons()
        {
            if (_personRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding persons");

            var persons = new List<Person>
            {
                new Person
                {
                    FirstName = "Calendau",
                    LastName = "GUQUET",
                    BirthDate = new DateTime(1980,2,28),
                    City = _cityRepository.Single("Toulon")
                },
                new Person
                {
                    FirstName = "John",
                    LastName = "APPLESEED",
                    BirthDate = new DateTime(1971,12,14),
                    City = _cityRepository.Single("Marseille")
                },
                new Person
                {
                    FirstName = "Steve",
                    LastName = "JOBS",
                    BirthDate = new DateTime(1949,2,24),
                    City = _cityRepository.Single("Marseille")
                }
            };
            _personRepository.UpdateRange(persons);
            _personRepository.Save();

            _logger.LogWarning("Added persons");
        }

        public void AddDepartements()
        {
            if (_departementRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding departements");

            var departements = new List<Departement>{};
            string json = File.ReadAllText("../Isen.DotNet.Library/json/departements.json");
            departements = JsonConvert.DeserializeObject<List<Departement>>(json);
            
            _departementRepository.UpdateRange(departements);
            _departementRepository.Save();

            _logger.LogWarning("Added departements");
        }

        public void AddCommunes()
        {
            if (_communeRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding communes");

            var communes = new List<Commune>{};
            string json = File.ReadAllText("../Isen.DotNet.Library/json/communes.json");
            communes = JsonConvert.DeserializeObject<List<Commune>>(json);

            foreach (var item in communes)
            {
                item.Departement = _departementRepository.Code(item.CodeDepartement);
            }

            _communeRepository.UpdateRange(communes);
            _communeRepository.Save();

            _logger.LogWarning("Added communes");
        }

        public void AddAdresses()
        {
            if (_adresseRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding adresses");

            var adresses = new List<Adresse>{};
            /*string json = File.ReadAllText("../Isen.DotNet.Library/json/adresses.json");
            adresses = JsonConvert.DeserializeObject<List<Adresse>>(json);

            foreach (var item in adresses)
            {
                item.Commune = _communeRepository.Single(item.NameCommune);
            }*/

            _adresseRepository.UpdateRange(adresses);
            _adresseRepository.Save();

            _logger.LogWarning("Added adresses");
        }

        public void AddCategories()
        {
            if (_categorieRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding categories");

            var categories = new List<Categorie>{};
            string json = File.ReadAllText("../Isen.DotNet.Library/json/categories.json");
            categories = JsonConvert.DeserializeObject<List<Categorie>>(json);

            _categorieRepository.UpdateRange(categories);
            _categorieRepository.Save();

            _logger.LogWarning("Added categories");
        }

        public void AddPoints()
        {
            if (_pointsRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding points");

            var points = new List<PointOfInterest>{};
            string json = File.ReadAllText("../Isen.DotNet.Library/json/pointsofinterests.json");
            points = JsonConvert.DeserializeObject<List<PointOfInterest>>(json);

            foreach (var item in points)
            {
                item.Categorie = _categorieRepository.Single(item.NameCategorie);
                item.Adresse.Commune = _communeRepository.Single(item.Adresse.NameCommune);
            }

            _pointsRepository.UpdateRange(points);
            _pointsRepository.Save();

            _logger.LogWarning("Added points");
        }
    }
}