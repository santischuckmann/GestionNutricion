using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.DTOs;
using GestionNutricion.Infrastructure.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace GestionNutricion.Infrastructure.Services
{
    public class SnackService : ISnackService
    {
        private readonly ISnackRepository _snackRepository;
        public SnackService(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository ?? throw new ArgumentNullException(nameof(snackRepository));
        }
        public async Task<IEnumerable<SnackDto>> GetAllSnacks()
        {
            var rawSnacks = await _snackRepository.GetAll();

            var snacks = new List<SnackDto>();

            foreach (var rawSnack in rawSnacks)
            {
                snacks.Add(new SnackDto()
                {
                    Id = rawSnack.Id,
                    Food = rawSnack.Food,
                    IntakeHour = rawSnack.IntakeHour,
                });
            }

            return snacks;
        }
    }
}
