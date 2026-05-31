namespace MauiAppEventos.Views
{
    public partial class SobrePage : ContentPage
    {
        public SobrePage()
        {
            InitializeComponent();
        }

        private async void Button_Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
