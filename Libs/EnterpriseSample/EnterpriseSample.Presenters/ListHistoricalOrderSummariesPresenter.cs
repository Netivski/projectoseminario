using EnterpriseSample.Core.DataInterfaces;
using EnterpriseSample.Core.Domain;
using EnterpriseSample.Presenters.ViewInterfaces;
using ProjectBase.Utils;

namespace EnterpriseSample.Presenters
{
    public class ListHistoricalOrderSummariesPresenter
    {
        public ListHistoricalOrderSummariesPresenter(IListObjectsView<HistoricalOrderSummary> view, 
            IHistoricalOrderSummaryDao historicalOrderSummaryDao) {
            Check.Require(view != null, "view may not be null");
            Check.Require(historicalOrderSummaryDao != null, "historicalOrderSummaryDao may not be null");

            this.view = view;
            this.historicalOrderSummaryDao = historicalOrderSummaryDao;
        }

        public void InitViewWith(string customerId) {
            Check.Require(!string.IsNullOrEmpty(customerId), "customerId may not be empty");

            view.ObjectsToList = historicalOrderSummaryDao.GetCustomerOrderHistoryFor(customerId);
        }

        private IListObjectsView<HistoricalOrderSummary> view;
        private IHistoricalOrderSummaryDao historicalOrderSummaryDao;
    }
}
