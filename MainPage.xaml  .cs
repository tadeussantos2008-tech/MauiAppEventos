using MauiAppEventos.Models;

namespace MauiAppEventos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Define datas iniciais
            dp_inicio.Date = DateTime.Today;
            dp_termino.Date = DateTime.Today.AddDays(1);

            // Atualiza preview inicial
            AtualizarPreview();
        }

        // Atualiza label do Stepper de participantes
        private void OnParticipantesChanged(object sender, ValueChangedEventArgs e)
        {
            int v = (int)e.NewValue;
            lbl_participantes.Text = v == 1 ? "1 participante" : $"{v} participantes";
            AtualizarPreview();
        }

        // Atualiza preview quando as datas mudam
        private void OnDataChanged(object sender, DateChangedEventArgs e)
        {
            AtualizarPreview();
        }

        // Atualiza preview quando o custo muda
        private void OnCustoChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarPreview();
        }

        // Calcula e exibe preview em tempo real usando DateTime e TimeSpan
        private void AtualizarPreview()
        {
            // Calcula duração com TimeSpan
            TimeSpan duracao = dp_termino.Date - dp_inicio.Date;
            int dias = duracao.Days;

            if (dias >= 0)
            {
                string duracaoTexto = dias == 0 ? "Mesmo dia"
                                    : dias == 1 ? "1 dia"
                                    : $"{dias} dias";
                lbl_duracao_preview.Text = duracaoTexto;
                border_duracao.IsVisible = true;
            }
            else
            {
                border_duracao.IsVisible = false;
            }

            // Calcula custo total em tempo real
            if (double.TryParse(txt_custo.Text?.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out double custo) && custo > 0)
            {
                int participantes = (int)stp_participantes.Value;
                int diasCalculo = dias > 0 ? dias : 1;
                double total = participantes * custo * diasCalculo;
                lbl_custo_preview.Text = total.ToString("C", new System.Globalization.CultureInfo("pt-BR"));
                border_custo.IsVisible = true;
            }
            else
            {
                border_custo.IsVisible = false;
            }
        }

        // Botão Cadastrar — async/await conforme Agenda 15
        private async void Button_Cadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Validações
                if (string.IsNullOrWhiteSpace(txt_nome.Text))
                {
                    await DisplayAlert("Atenção", "Informe o nome do evento.", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_local.Text))
                {
                    await DisplayAlert("Atenção", "Informe o local do evento.", "OK");
                    return;
                }

                if (dp_termino.Date < dp_inicio.Date)
                {
                    await DisplayAlert("Atenção",
                        "A data de término não pode ser anterior à data de início.", "OK");
                    return;
                }

                if (!double.TryParse(txt_custo.Text?.Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double custo) || custo <= 0)
                {
                    await DisplayAlert("Atenção", "Informe um custo por participante válido.", "OK");
                    return;
                }

                // Cria o objeto Evento (Model) e define o BindingContext
                Evento evento = new Evento
                {
                    Nome = txt_nome.Text,
                    Local = txt_local.Text,
                    DataInicio = dp_inicio.Date,
                    DataTermino = dp_termino.Date,
                    NumParticipantes = (int)stp_participantes.Value,
                    CustoPorParticipante = custo
                };

                // Navega para a tela de resumo passando o objeto via BindingContext
                // Uso de async/await conforme Agenda 15
                await Navigation.PushAsync(new Views.ResumoEventoPage
                {
                    BindingContext = evento
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Fechar");
            }
        }

        private async void Button_Sobre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.SobrePage());
        }
    }
}
