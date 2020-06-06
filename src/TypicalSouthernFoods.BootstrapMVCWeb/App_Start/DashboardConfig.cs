using System.Web.Routing;
using DevExpress.DashboardWeb;
using DevExpress.DashboardWeb.Mvc;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.EntityFramework;

namespace TypicalSouthernFoods.Web
{
    public class DashboardConfig
    {
        public static void RegisterService(RouteCollection routes)
        {
            routes.MapDashboardRoute("DashboardControl");
            //routes.MapDashboardRoute("DashboardMain", "DashboardMain", new[] { "MvcDashboard_ServerSideApi" });

            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            DashboardConfigurator.Default.SetDashboardStorage(dashboardFileStorage);

            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            // Registers an Entity Framework data source.
            DashboardEFDataSource efDataSource = new DashboardEFDataSource("EF Data Source");
            efDataSource.ConnectionParameters = new EFConnectionParameters(typeof(Persistence.EntitiesDataModel));
            dataSourceStorage.RegisterDataSource("efDataSource", efDataSource.SaveToXml());

            DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage);
        }
    }
}