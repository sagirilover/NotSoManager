using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NotSoManager
{
    class FileSystem
    {
        public static Dictionary<string, Account> Accounts = new Dictionary<string, Account>();
        public static string cfgPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/sagirimanager/";
        public static string cfgName = "data.sagiri";

        public static void Init()
        {
            if (!Directory.Exists(cfgPath))
                Directory.CreateDirectory(cfgPath);
            
            if (!File.Exists(cfgPath + cfgName))
                File.Create(cfgPath + cfgName);

            Load();
        }

        public static void Load()
        {
            try
            {
                JObject jo = JObject.Parse(File.ReadAllText(cfgPath + cfgName));
                Accounts = JsonConvert.DeserializeObject<Dictionary<string, Account>>(File.ReadAllText(cfgPath + cfgName));
            }
            catch (Exception ex)
            {

            }
        }

        public static void Save()
        {
            JObject jo = new JObject();
            foreach(KeyValuePair<string,Account> acc in Accounts)
                jo[acc.Key] = JsonConvert.SerializeObject(acc.Value);
            
            File.WriteAllText(cfgPath + cfgName, JsonConvert.SerializeObject(Accounts));
        }
    }
}
