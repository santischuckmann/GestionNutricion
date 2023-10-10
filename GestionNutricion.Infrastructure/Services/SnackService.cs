using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.DTOs.Snack;
using System.Reflection.Metadata.Ecma335;

namespace GestionNutricion.Infrastructure.Services
{
    public class SnackService
    {
        private readonly ISnackHandler _snackHandler;
        private readonly IMapper _mapper;
        public SnackService(
            ISnackHandler snackHandler,
            IMapper mapper)
        {
            _snackHandler = snackHandler ?? throw new ArgumentNullException(nameof(snackHandler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PlanSnackDto> AddSnack(PlanSnackInsertionDto newSnackDto)
        {
            var snack = _mapper.Map<Snack>(newSnackDto);

            await _snackHandler.AddSnack(snack);

            var snackDto = _mapper.Map<PlanSnackDto>(snack);

            return snackDto;
        }

        public async Task<IEnumerable<PlanSnackDto>> GetAllSnacks()
        {
            var rawSnacks = await _snackHandler.GetAllSnacks();

            var snacks = _mapper.Map<IEnumerable<PlanSnackDto>>(rawSnacks);

            return snacks;
        }
    }
}
