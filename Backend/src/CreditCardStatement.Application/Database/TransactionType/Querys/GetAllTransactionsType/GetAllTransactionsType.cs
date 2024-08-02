using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Application.Database.TransactionType.Querys.GetAllTransactionsType
{
    public class GetAllTransactionsType: IGetAllTransactionsType
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetAllTransactionsType(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllTransactionsTypeModel>> Execute()
        {
            var result = await _databaseService.TransactionType.ToListAsync();
            return _mapper.Map<List<GetAllTransactionsTypeModel>>(result);
        }
    }

}
