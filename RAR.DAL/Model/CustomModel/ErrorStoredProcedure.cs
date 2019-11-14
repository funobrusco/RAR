using StoredProcedureEFCore;

namespace RAR.DAL.Model.CustomModel
{
    public class ErrorStoredProcedure
    {
        public ErrorStoredProcedure()
        {
            Error_msg = new Parameter<string>();
            Error_Number = new Parameter<int>();
        }

        public IOutParam<string> Error_msg;
        public IOutParam<int> Error_Number;

        public class Parameter<T> : IOutParam<T>
        {
            public Parameter(T value)
            {
                Value = value;
            }
            public Parameter()
            {
            }

            public T Value { get; set; }
        }
    }
}
