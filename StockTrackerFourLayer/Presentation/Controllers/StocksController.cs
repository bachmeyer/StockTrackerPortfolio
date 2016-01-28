using StockTrackerFourLayer.Services;
using StockTrackerFourLayer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StockTrackerFourLayer.Presentation.Controllers
{
    public class StocksController : ApiController
    {
        private StockService _stockService;

        public StocksController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Route("api/stocks/search/{searchTerms}")]
        public IList<StockDTO> Search(string searchTerms)
        {
            return _stockService.Search(searchTerms);
        }

        [HttpGet]
        [Route("api/stocks/{ticker}")]
        public ExpandedStockDTO GetStock(string ticker)
        {//User.Identity.Name is for the current logged in user in any four v  layer project
            return _stockService.GetStockWithTransactions(ticker, User.Identity.Name);
        }

        [HttpPost]
        [Authorize]
        [Route("api/trade/buy")]
        public IHttpActionResult Buy(TransactionDTO transaction)
        {

            if (ModelState.IsValid && _stockService.CheckExists(transaction.Ticker))
            {
                return Ok(_stockService.Buy(transaction.Ticker, transaction.Quantity, User.Identity.Name));
            }
            return BadRequest();

        }

        [HttpPost]
        [Authorize]
        [Route("api/trade/sell")]
        public IHttpActionResult Sell(TransactionDTO transaction)
        {
            if (ModelState.IsValid)
            {
                return Ok(_stockService.Sell(transaction.Ticker, transaction.Quantity, User.Identity.Name));
            }
            return BadRequest();
        }
    }
}