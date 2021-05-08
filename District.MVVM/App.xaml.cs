using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using District.Bl.Abstract.IMappers;
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Mappers;
using District.Bl.Impl.Services;
using District.Dal;
using District.Dal.Abstact;
using District.Dal.Impl;
using District.Entities.Tables;
using District.Models.Models;
using District.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace District.MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Container = ConfigureDependencyInjection();
        }

        public IServiceProvider Container { get; }

        IServiceProvider ConfigureDependencyInjection()
        {
            // Create new service collection which generates the IServiceProvider
            IServiceCollection serviceCollection = new ServiceCollection();

            // TODO - Register dependencies
            serviceCollection.AddDbContext<DistrictDbContext>(options =>
                options.UseNpgsql(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            serviceCollection.AddSingleton<IUnitOfWork, UnitOfWork>(); 
            
            //Services
            serviceCollection.AddSingleton<IApartmentService, ApartmentService>();
            serviceCollection.AddSingleton<IPersonService, PersonService>();
            serviceCollection.AddSingleton<IBuildingService, BuildingService>();
            serviceCollection.AddSingleton<IEntranceService, EntranceService>();
            
            //Mappers
            serviceCollection.AddSingleton<IBackMapper<Apartment, ApartmentModel>, ApartmentMapper>();
            serviceCollection.AddSingleton<IBackMapper<Person, PersonModel>, PersonMapper>();
            serviceCollection.AddSingleton<IBackMapper<Building, BuildingModel>, BuildingMapper>(); 
            serviceCollection.AddSingleton<IBackMapper<Entrance, EntranceModel>, EntranceMapper>();

            //AddTransient

            serviceCollection.AddSingleton<DistrictViewModel>();
            serviceCollection.AddSingleton<MainWindow>();

            // Build the IServiceProvider and return it
            return serviceCollection.BuildServiceProvider();
        }
    }
}
