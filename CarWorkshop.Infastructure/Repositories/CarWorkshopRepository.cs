using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Infastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infastructure.Repositories
{
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        private CarWorkshopDbContext _dbContext;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
            => _dbContext.SaveChangesAsync();
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop) 
        {
            _dbContext.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
        {
            try
            {
                var carWorkshops = await _dbContext.CarWorkshops.ToListAsync();
                return carWorkshops;
            }
            catch (Exception ex)
            {
                // Obsługa błędów - możesz zalogować błąd lub podjąć inne działania w przypadku wystąpienia wyjątku
                Console.WriteLine($"Wystąpił błąd podczas pobierania warsztatów samochodowych: {ex.Message}");
                return Enumerable.Empty<Domain.Entities.CarWorkshop>(); // Zwróć pustą kolekcję w przypadku błędu
            }
        }

        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
            => await _dbContext.CarWorkshops.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.CarWorkshop?> GetByName(string name) 
            => _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower()); 
    }
}
