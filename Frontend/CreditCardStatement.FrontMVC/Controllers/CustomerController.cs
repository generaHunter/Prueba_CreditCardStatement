using CreditCardStatement.FrontMVC.Helpers;
using CreditCardStatement.FrontMVC.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CreditCardStatement.FrontMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApiService _apiService;

        public CustomerController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var responseApi = await _apiService.GetAsync("customer/getAllCustomers");
            if (responseApi.Success)
            {
                var customers = ((JArray)responseApi.Data).ToObject<List<CustomerViewModel>>();
                return View(customers);
            }
            // Handle error case
            return View(new List<CustomerViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName")] CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                var responseApi = await _apiService.PostAsync("customer/create", customerViewModel);

                if (responseApi.Success)
                {
                    TempData["SuccessMessageCreateCustomer"] = "Se creo el cliente, correctamente";
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["ErrorMessageCreateCustomer"] = "Fallo la creacion del cliente, favor intentar nuevamente";
            return RedirectToAction("Index", customerViewModel);
        }
    }
}
