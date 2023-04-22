using Agile.Business.Abstract.ReadServices;
using Agile.Business.Abstract.WriteServices;
using Agile.Business.Concrete.ReadManager;
using Agile.Business.Concrete.WriteManager;
using Agile.Business.CrossCuttingConcern.Validators.CompanyValidator;
using Agile.Business.CrossCuttingConcern.Validators.CustomerValidator;
using Agile.Business.CrossCuttingConcern.Validators.OrderValidator;
using Agile.Business.CrossCuttingConcern.Validators.ProductValidator;
using Agile.Business.CrossCuttingConcern.Validators.SendMailValidator;
using Agile.DataAccess.Abstract.ReadDALs;
using Agile.DataAccess.Abstract.WriteDALs;
using Agile.DataAccess.Concrete.EntityFramework.ReadDALs;
using Agile.DataAccess.Concrete.EntityFramework.WriteDALs;
using Agile.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Agile.Business.CrossCuttingConcern.DependencyResolver.ServiceDependency
{   
    public static class ContainerDependencies    
    {        
        public static void ServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<ICompanyReadDal, CompanyReadDal>();
            services.AddScoped<ICompanyReadService, CompanyReadManager>();
            services.AddScoped<ICompanyWriteDal, CompanyWriteDal>();
            services.AddScoped<ICompanyWriteService, CompanyWriteManager>();

            services.AddScoped<ICustomerReadDal, CustomerReadDal>();
            services.AddScoped<ICustomerReadService, CustomerReadManager>();
            services.AddScoped<ICustomerWriteDal, CustomerWriteDal>();
            services.AddScoped<ICustomerWriteService, CustomerWriteManager>();

            services.AddScoped<IOrderReadDal, OrderReadDal>();
            services.AddScoped<IOrderReadService, OrderReadManager>();
            services.AddScoped<IOrderWriteDal, OrderWriteDal>();
            services.AddScoped<IOrderWriteService, OrderWriteManager>();

            services.AddScoped<IProductReadDal, ProductReadDal>();
            services.AddScoped<IProductReadService, ProductReadManager>();
            services.AddScoped<IProductWriteDal, ProductWriteDal>();
            services.AddScoped<IProductWriteService, ProductWriteManager>();

            services.AddScoped<ISendMailReadDal, SendMailReadDal>();
            services.AddScoped<ISendMailReadService, SendMailReadManager>();
            services.AddScoped<ISendMailWriteDal, SendMailWriteDal>();
            services.AddScoped<ISendMailWriteService, SendMailWriteManager>();


            services.AddScoped<IValidator<Company>, CompanyValidator>();
            services.AddScoped<IValidator<Customer>, CustomerValidator>();
            services.AddScoped<IValidator<Order>, OrderValidator>();
            services.AddScoped<IValidator<Product>, ProductValidator>();
            services.AddScoped<IValidator<SendMail>, SendMailValidator>();
        }
    }
}
