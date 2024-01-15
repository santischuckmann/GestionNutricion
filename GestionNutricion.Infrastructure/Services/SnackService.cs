using AutoMapper;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.DTOs.PlanSnack;
using GestionNutricion.Infrastructure.Query.Handlers;

namespace GestionNutricion.Infrastructure.Services
{
    public class SnackService
    {
        private readonly ISnackHandler _snackHandler;
        private readonly SnackQueryHandler _queryHandler;
        private readonly IMapper _mapper;
        public SnackService(
            ISnackHandler snackHandler,
            SnackQueryHandler queryHandler,
            IMapper mapper)
        {
            _snackHandler = snackHandler ?? throw new ArgumentNullException(nameof(snackHandler));
            _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PlanSnackDto> AddSnack(PlanSnackInsertionDto newSnackDto)
        {
            var snack = _mapper.Map<Snack>(newSnackDto);

            await _snackHandler.AddSnack(snack);

            var snackDto = _mapper.Map<PlanSnackDto>(snack);

            return snackDto;
        }

        public async Task<IEnumerable<string>> GetSnacks(int snackTimeId)
        {
            var snacks = await Task.Run(() => _queryHandler.GetSnacks(snackTimeId));

            return snacks;
        }
    }
}
