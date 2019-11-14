using StoredProcedureEFCore;

namespace RAR.DAL.Utility
{
    public class ParamExtraFactory
    {
        public ParamExtra CreateParameter(int size)
        {
            return new ParamExtra() { Size = 255 };
        }
    }
}
