using AutoMapper;
using CreditCardStatement.Application.Database.Customer.CommonModel;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Application.Database.Customer.Querys.GetCustomerById
{
    public class GetCustomerByIdQuery: IGetCustomerByIdQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetCustomerByIdQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CommonCustomerModel> Execute(int CustomerId)
        {
          var result = await _databaseService.Customer.Where(x => x.CustomerId == CustomerId).FirstOrDefaultAsync();
            return _mapper.Map<CommonCustomerModel>(result);
        }
    }
}
