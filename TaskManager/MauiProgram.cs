using Microsoft.Extensions.Logging;
using Realms;
using TaskManager.Migrations;
using TaskManager.Services;
using TaskManager.Services.Interfaces;
using TaskManager.ViewModels;
using TaskManager.ViewModels.Interfaces;

namespace TaskManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Nunito-Regular.ttf", "NunitoRegular");
                    fonts.AddFont("Nunito-SemiBold.ttf", "NunitoSemiBold");
                });


            var realmConfig = new RealmConfiguration
            {
                SchemaVersion = 13,
                MigrationCallback = MigrationManager.PerformMigration
            };

            builder.Services.AddSingleton(realmConfig);

            builder.Services.AddScoped<IRealmService, RealmService>();

            builder.Services.AddScoped<INotesViewModel, NotesViewModel>();
            builder.Services.AddScoped<INoteEditorViewModel, NoteEditorViewModel>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
