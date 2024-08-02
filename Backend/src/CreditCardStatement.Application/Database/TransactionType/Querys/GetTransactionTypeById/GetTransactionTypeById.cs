using AutoMapper;

namespace CreditCardStatement.Application.Database.TransactionType.Querys.GetTransactionTypeById
{
    public class GetTransactionTypeById: IGetTransactionTypeById
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetTransactionTypeById(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetTransactionTypeByIdModel> Execute(int id)
        {
            var result = await _databaseService.TransactionType.FindAsync(id);
            return _mapper.Map<GetTransactionTypeByIdModel>(result);
        }
    }
}
