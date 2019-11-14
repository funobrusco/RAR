namespace RAR.ViewModel
{
    public class ResultStoredViewModel<T>
    {
        public ResultStoredViewModel(T entita, string messaggioErrore)
        {
            Entita = entita;
            MessaggioErrore = messaggioErrore;
        }

        public ResultStoredViewModel()
        {
        }

        public T Entita { get; set; }
        public string MessaggioErrore { get; set; }

        public void ImpostaErrore(int numeroErrore, string messaggio)
        {
            MessaggioErrore = string.Format("({0}) - {1}", numeroErrore, messaggio);
        }

        public bool Errore() => !string.IsNullOrEmpty(MessaggioErrore);
    }
}
