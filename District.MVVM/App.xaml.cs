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
            var serviceCollection = new ServiceCollection();

            // TODO - Register dependencies
            //Services
            serviceCollection.AddTransient<IApartmentService, ApartmentService>();
            serviceCollection.AddTransient<IPersonService, PersonService>();
            serviceCollection.AddSingleton<IUnitOfWork, UnitOfWork>();

            //Mappers
            serviceCollection.AddTransient<IBackMapper<Apartment, ApartmentModel>, ApartmentMapper>();
            serviceCollection.AddTransient<IBackMapper<Person, PersonModel>, PersonMapper>();
            
            

            // Build the IServiceProvider and return it
            return serviceCollection.BuildServiceProvider();
        }
    }
}
