namespace MauiAppEventos
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.ResumoEventoPage), typeof(Views.ResumoEventoPage));
            Routing.RegisterRoute(nameof(Views.SobrePage), typeof(Views.SobrePage));
        }
    }
}
