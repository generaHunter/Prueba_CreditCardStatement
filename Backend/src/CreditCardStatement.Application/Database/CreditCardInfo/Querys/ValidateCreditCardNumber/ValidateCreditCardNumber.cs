using Microsoft.EntityFrameworkCore;

namespace CreditCardStatement.Application.Database.CreditCardInfo.Querys.ValidateCreditCardNumber
{
    public class ValidateCreditCardNumber: IValidateCreditCardNumber
    {
        private readonly IDatabaseService _databaseService;

        public ValidateCreditCardNumber(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public async Task<ValidateCreditCardNumberModel> Execute(string cardNumber)
        {
            ValidateCreditCardNumberModel model = new ValidateCreditCardNumberModel();
            model.Exists = false;
            var result = await _databaseService.CreditCardInfo.FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
            if (result != null) model.Exists = true;

            return model;
        }
    }
}
