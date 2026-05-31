namespace MauiAppEventos.Models
{
    // Model Evento - representa os dados do evento cadastrado
    // Aplica conceitos da Agenda 15: BindingContext, DateTime, TimeSpan
    public class Evento
    {
        // Propriedades básicas do evento
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumParticipantes { get; set; }
        public double CustoPorParticipante { get; set; }

        // Propriedade calculada com TimeSpan — duração em dias
        public int DuracaoDias
        {
            get
            {
                TimeSpan diferenca = DataTermino - DataInicio;
                return diferenca.Days;
            }
        }

        // Propriedade calculada — custo total do evento
        public double CustoTotal
        {
            get
            {
                return NumParticipantes * CustoPorParticipante * (DuracaoDias > 0 ? DuracaoDias : 1);
            }
        }

        // Propriedade formatada para exibição da duração
        public string DuracaoFormatada
        {
            get
            {
                if (DuracaoDias == 0)
                    return "Mesmo dia";
                if (DuracaoDias == 1)
                    return "1 dia";
                return $"{DuracaoDias} dias";
            }
        }
    }
}
