namespace StockTrackerFourLayer.Controllers {

    export class ResearchController {

        public stocks;

        constructor(private $http: ng.IHttpService) { }



        public updateStocks(searchTerm: string): void {

            this.stocks = [];

            if (searchTerm) {
                this.$http.get(`/api/stocks/search/${searchTerm}`)
                    .then((response) => {
                        this.stocks = response.data;
                    });
            }
        }
    }
}