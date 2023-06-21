using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.DTOs;
using GestionNutricion.Infrastructure.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace GestionNutricion.Infrastructure.Services
{
    public class SnackService : ISnackService
    {
        private readonly ISnackRepository _snackRepository;
        private readonly ISnackHandler _snackHandler;
        public SnackService(ISnackRepository snackRepository, ISnackHandler snackHandler)
        {
            _snackRepository = snackRepository ?? throw new ArgumentNullException(nameof(snackRepository));
            _snackHandler = snackHandler ?? throw new ArgumentNullException(nameof(snackHandler));
        }

        public async Task<SnackDto> AddSnack(SnackDto snackDto)
        {
            Snack snack = new Snack()
            {
                Food = snackDto.Food,
                IntakeHour = snackDto.IntakeHour,
            };

            await _snackHandler.AddSnack(snack);

            return snackDto;
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
