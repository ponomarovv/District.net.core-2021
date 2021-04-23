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
            
            serviceCollection.AddSingleton<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddSingleton<DistrictDbContext, DistrictDbContext>();

            //Services
            serviceCollection.AddTransient<IApartmentService, ApartmentService>();
            serviceCollection.AddTransient<IPersonService, PersonService>();
            serviceCollection.AddTransient<IBuildingService, BuildingService>();
            serviceCollection.AddTransient<IEntranceService, EntranceService>();


            //Mappers
            serviceCollection.AddTransient<IBackMapper<Apartment, ApartmentModel>, ApartmentMapper>();
            serviceCollection.AddTransient<IBackMapper<Person, PersonModel>, PersonMapper>();
            serviceCollection.AddTransient<IBackMapper<Building, BuildingModel>, BuildingMapper>(); 
            serviceCollection.AddTransient<IBackMapper<Entrance, EntranceModel>, EntranceMapper>();





            // Build the IServiceProvider and return it
            return serviceCollection.BuildServiceProvider();
        }
    }
}
