namespace MauiAppEventos.Views
{
    public partial class ResumoEventoPage : ContentPage
    {
        public ResumoEventoPage()
        {
            InitializeComponent();
        }

        private async void Button_Novo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
