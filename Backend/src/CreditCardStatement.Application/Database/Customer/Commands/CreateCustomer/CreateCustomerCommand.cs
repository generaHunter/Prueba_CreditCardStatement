using AutoMapper;
using CreditCardStatement.Application.Database.Customer.CommonModel;
using CreditCardStatement.Domain.Entities.Customer;

namespace CreditCardStatement.Application.Database.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand: ICreateCustomerCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CommonCustomerModel> Execute(CommonCustomerModel model) {
            var entity = _mapper.Map<CustomerEntity>(model);
            var resultData  = await _databaseService.Customer.AddAsync(entity);
            var resulrProcess = await _databaseService.SaveAsync();

            if (resulrProcess)
            {
                model.CustomerId = resultData.Entity.CustomerId;
            }

            return model;
        }
    }
}
