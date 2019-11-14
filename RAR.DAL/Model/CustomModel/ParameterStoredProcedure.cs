namespace RAR.DAL.Model.CustomModel
{
    public class OutputStored<T> : ErrorStoredProcedure
    {
        public T Entita { get; set; }
        public bool Errore
        {
            get
            { return (!string.IsNullOrEmpty(base.Error_msg.Value)); }
        }

        public OutputStored(T _entita)

        {
            Entita = _entita;
        }
    }
}
