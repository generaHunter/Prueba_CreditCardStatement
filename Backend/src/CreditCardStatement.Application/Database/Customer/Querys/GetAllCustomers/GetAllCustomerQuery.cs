using AutoMapper;
using CreditCardStatement.Application.Database.Customer.CommonModel;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Application.Database.Customer.Querys.GetAllCustomers
{
    public class GetAllCustomerQuery: IGetAllCustomerQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetAllCustomerQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<CommonCustomerModel>> Execute()
        {
            var result = await _databaseService.Customer.ToListAsync();

            return _mapper.Map<List<CommonCustomerModel>>(result);
        }
    }
}
