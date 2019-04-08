namespace Store.Shared{

    public static class ConnectionSettings{
        private const string V = @"Server=.\sqlexpress;Database=Store;User ID=SA;Password=Drg38914821;";
        private static string connectionString = V;

        public static string ConnectionString { get => connectionString;}
    }
}