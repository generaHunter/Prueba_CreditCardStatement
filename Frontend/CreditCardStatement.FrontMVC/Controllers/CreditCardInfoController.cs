using CreditCardStatement.FrontMVC.Helpers;
using CreditCardStatement.FrontMVC.Models.CreditCardInfo;
using CreditCardStatement.FrontMVC.Models.CreditCardTransactions;
using CreditCardStatement.FrontMVC.Models.Details;
using CreditCardStatement.FrontMVC.Models.TransactionsType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace CreditCardStatement.FrontMVC.Controllers
{
    public class CreditCardInfoController : Controller
    {
        private readonly ApiService _apiService;

        public CreditCardInfoController(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index(int customerId)
        {
            if (customerId > 0)
            {
                CommonCreditCardInfoViewModel model = new CommonCreditCardInfoViewModel { CustomerId = customerId, creditCardInfos = null };
                var responseApi = await _apiService.GetAsync($"creditCardInfo/getCreditCardInfoByCustomerId/{customerId}");
                if (responseApi.Success)
                {

                    var customers = ((JArray)responseApi.Data).ToObject<List<CreditCardInfoViewModel>>();
                    if (customers.Count > 0)
                    {
                        model.creditCardInfos = customers;
                        return View(model);
                    }
                }
                 return View(model);
            }
            // Handle error case
            return RedirectToAction("Index", "Customer");
        }

        // GET: CreditCardInfo/Details/5
        public async Task<IActionResult> Details(int creditCardInfoId, int customerId)
        {
            if (creditCardInfoId > 0)
            {
                CommonDetailViewModel commonDetail = new CommonDetailViewModel();

                var responseApiTypeTransaction = await _apiService.GetAsync($"transactionType/GetAllTransactionsType");
                if (responseApiTypeTransaction.Success)
                {
                    var transactionTypes = ((JArray)responseApiTypeTransaction.Data).ToObject<List<TransactionTypeViewModel>>();
                    var listTransactionType = transactionTypes.Select(tt => new SelectListItem
                    {
                        Value = tt.TransactionTypeId.ToString(),
                        Text = tt.TransactionTypeName
                    });

                    commonDetail.TransactionTypes = listTransactionType;
                }

                var responseApi = await _apiService.GetAsync($"creditCardInfo/getCreditCardInfoById/{creditCardInfoId}");
                
                if (responseApi.Success)
                {
                    var creditCardInfo = (responseApi.Data).ToObject<CreditCardInfoViewModel>();
                    commonDetail.CreditCardInfo = creditCardInfo;


                    var responseApiTransactions = await _apiService.GetAsync($"creditCardTransaction/getCreditCardTransactionsByCardInfoId/{creditCardInfoId}");

                    if (responseApiTransactions.Success)
                    {
                        var transactions = ((JArray)responseApiTransactions.Data).ToObject<List<CreditCardTransactionViewModel>>();
                        commonDetail.CreditCardTransactions = transactions;
                    }

                    return View(commonDetail);
                }
            }

            return RedirectToAction("Index", new { customerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreditCardInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.AvailableBalance = model.CreditLimit;

                var validateCardNumber = await _apiService.GetAsync($"creditCardInfo/validateCreditCardNumber/{model.CardNumber}");

                if (validateCardNumber.Success) {
                    ValidateCreditCardNumberModel validate = (validateCardNumber.Data).ToObject<ValidateCreditCardNumberModel>();

                    if (validate.Exists) {
                        TempData["WarningMessageCreateCard"] = "El numero de tarjeta de credito ya existe";
                        return RedirectToAction("Index", new { model.CustomerId });
                    }
                }

                var responseApi = await _apiService.PostAsync("creditCardInfo/create", model);

                if (responseApi.Success)
                {
                    TempData["SuccessMessageCreateCard"] = "Se creo la tarjeta, correctamente";
                    return RedirectToAction("Index", new { model.CustomerId });
                }
            }
            TempData["ErrorMessageCreateCard"] = "Fallo la creacion de la tarjeta, favor intentar nuevamente";
            return RedirectToAction("Index", new { model.CustomerId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransaction(CreditCardTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var responseApi = await _apiService.PostAsync("creditCardTransaction/create", model);

                if (responseApi.Success)
                {
                    TransactionResultModel result = (responseApi.Data).ToObject<TransactionResultModel>();

                    if (result != null)
                    {
                        if (result.SUCCESS == 1)
                        {
                            TempData["SuccessMessageCreateT"] = result.MESSAGE;
                        }
                        else if (result.SUCCESS == -1)
                        {
                            TempData["ErrorMessageCreateT"] = result.MESSAGE;
                            
                        }

                        return RedirectToAction("Details", new { model.CreditCardInfoId, model.CustomerId });
                    }
                }
            }
            TempData["ErrorMessageCreateT"] = "Fallo transaccion, favor intentar nuevamente";
            return RedirectToAction("Details", new { model.CreditCardInfoId, model.CustomerId });
        }
    }
}
