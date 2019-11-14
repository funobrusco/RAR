//using RAR.DAL.Model.Tabella;
//using System.Threading.Tasks;

//namespace RAR.DAL.Utility
//{
//    public class ContextResolverService
//    {
//        public IRARContext Context { get; private set; }
//        public ContextResolverService(IRARContext context)
//        {
//            Context = context;
//        }

//        public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider, IHostingEnvironment env)
//        {
//            var result = false;

//            using (var scope1 = serviceProvider.CreateScope())
//            using (var db1 = scope1.ServiceProvider.GetService<RARContext>())
//            {
//                result = await db1.Database.EnsureCreatedAsync();
//                if (result)
//                {

//                    InsertTestData(serviceProvider, env);
//                }
//            }
//        }

//    }
//}
