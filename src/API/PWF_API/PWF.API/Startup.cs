namespace PWF.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using PWF.Data.Context;
    using Autofac;
    using System;
    using Autofac.Extensions.DependencyInjection;
    using PWF.Data.UnitOfWork;

    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.1", new Info { Title = "PWF API", Version = "v0.1" });
            });

            var connection = Configuration["ConnectionStrings:SQLServer:PWF"];

            // Create the container builder.
            var builder = new ContainerBuilder();

            // Add services to autofac.
            builder.Populate(services);

            // Add custom registrations
            builder.RegisterInstance<IConfiguration>(Configuration);
            builder.Register(s => PWFContextFactory.Create(connection)).As<IPWFContext>();

            // Add repositories
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0.1/swagger.json", "PWF API v0.1");
            });
        }
    }
}
