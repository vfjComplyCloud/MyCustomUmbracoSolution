using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCustomUmbracoSolution.Handlers;
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace MyCustomUmbracoSolution
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="webHostEnvironment">The Web Host Environment</param>
        /// <param name="config">The Configuration</param>
        /// <remarks>
        /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337
        /// </remarks>
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }



        /// <summary>
        /// Configures the services
        /// </summary>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
#pragma warning disable IDE0022 // Use expression body for methods
            IUmbracoBuilder umbraco = services
                .AddUmbraco(_env, _config)
                .AddBackOffice()
                .AddWebsite()
                .AddComposers();

            umbraco.Dashboards().Remove<ContentDashboard>().Remove<SettingsDashboard>();

            //The following 3 should result in "Active" being false
            umbraco.AddNotificationHandler<ContentUnpublishedNotification, LogWhenUnpublishedHandler>()
                   .AddNotificationHandler<ContentDeletedNotification, LogWhenDeletedFromSettingsHandler>()
                   .AddNotificationHandler<ContentMovedToRecycleBinNotification, LogWhenMovedToRecycleBinHandler>()
            //The following 2 should result in "Active" being true
                   .AddNotificationHandler<ContentPublishedNotification, LogWhenPublishedHandler>()
                   .AddNotificationHandler<ContentMovingNotification, LogWhenRestoredFromRecycleBinHandler>()
                   .Build();

#pragma warning restore IDE0022 // Use expression body for methods

        }

        /// <summary>
        /// Configures the application
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseUmbraco()
                .WithMiddleware(u =>
                {
                    u.UseBackOffice();
                    u.UseWebsite();
                })
                .WithEndpoints(u =>
                {
                    u.UseInstallerEndpoints();
                    u.UseBackOfficeEndpoints();
                    u.UseWebsiteEndpoints();
                });
        }
    }
}
