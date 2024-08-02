using AutoMapper;
using CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardNumber;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardInfoId
{
    public class GetCreditCardTransactionsByCardInfoId : IGetCreditCardTransactionsByCardInfoId
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetCreditCardTransactionsByCardInfoId(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<GetCreditCardTransactionsByCardInfoIdModel>> Execute(int cardInfoId)
        {
            var result = await _databaseService.CreditCardTransaction.Where(x => x.CreditCardInfoId == cardInfoId).Include(x => x.TransactionType).ToListAsync();

            return _mapper.Map<List<GetCreditCardTransactionsByCardInfoIdModel>>(result);
        }
    }
}
