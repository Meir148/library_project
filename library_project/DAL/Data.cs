namespace library_project.DAL
{
    public class Data
    {


        string connectionString = "" +
            "server=DESKTOP-KGQDLVE\\SQLEXPRESS;" +
            "initial catalog= my_library;" +
            "user id=sa; password=1234;" +
            "TrustServerCertificate=Yes";

        private Data()
        {
            Layer = new DataLayer(connectionString);
        }

        public DataLayer Layer { get; set; }


        static Data GetData;

        public static DataLayer Get
        {
            get
            {
                if (GetData == null) { GetData = new Data(); }

                return GetData.Layer;
            }

        }
    }
}
