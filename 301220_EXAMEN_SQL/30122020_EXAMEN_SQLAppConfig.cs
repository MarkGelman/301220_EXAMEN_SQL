using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SQLite;

namespace _301220_EXAMEN_SQL
{
    class _30122020_EXAMEN_SQLAppConfig
    {
        private string m_file_name;
        private JObject m_configRoot;
        internal static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string ConnectionString { get; set; }


        public _30122020_EXAMEN_SQLAppConfig()
        {
            Init("30122020_EXAMEN_SQLConfig.json");
        }

        internal void Init(string file_name)
        {
            m_file_name = file_name;

            if (!File.Exists(m_file_name))
            {
                Console.WriteLine($"File {m_file_name} not exist!");
                Environment.Exit(-1);
            }

            var reader = File.OpenText(m_file_name);
            string json_string = reader.ReadToEnd();
          
            JObject jo = (JObject)JsonConvert.DeserializeObject(json_string);
            m_configRoot = (JObject)jo["30122020_EXAMEN_SQL"];
            ConnectionString = m_configRoot["ConnectionString"].Value<string>();

        }

        static bool TestDbConnection()
        {
            try
            {
                using (var con = new SQLiteConnection(ConnectionString))
                {
                    con.Open();
                    return true;
                }

            }

            catch (Exception ex)
            {
                _log.Error($"Connection failed.Exception: {ex}");
                Console.WriteLine($"Connection failed.Exception: {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
                return false;
            }
        }

        internal static SQLiteConnection GetOpenConnection()
        {
            if (TestDbConnection())
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    return connection;
                }

            }
            Environment.Exit(-1);
            return null;
        }

    }
}
