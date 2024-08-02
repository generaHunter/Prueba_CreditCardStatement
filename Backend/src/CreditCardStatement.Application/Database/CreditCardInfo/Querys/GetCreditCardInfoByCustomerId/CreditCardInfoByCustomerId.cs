using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCustomerId
{
    public class CreditCardInfoByCustomerId: ICreditCardInfoByCustomerId
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreditCardInfoByCustomerId(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<CreditCardInfoByCustomerIdModel>> Execute(int CustomerId)
        {
            var result = await _databaseService.CreditCardInfo.Where(x => x.CustomerId == CustomerId).ToListAsync();
            return _mapper.Map<List<CreditCardInfoByCustomerIdModel>>(result);
        }
    }
}
