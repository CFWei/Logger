using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Logger
{
    public class Recorder:IRecorder
    {
        private static log4net.ILog log;
        private static object _lock = new object();

        public Recorder()
        {
            //預設路徑是跟dll放在一起
            //預設名稱是log4net.config.xml
            string configPathDirectory = System.Environment.CurrentDirectory;
            string configFilePath = Path.Combine(configPathDirectory, "log4net.config.xml");
            log=log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            SetConfigFile(configFilePath);
                       
        }

        public Recorder(string configFilePath)
        {
            log=log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            SetConfigFile(configFilePath);
        }

        public Recorder(string configFilePath,string loggerName)
        {
            log = log4net.LogManager.GetLogger(loggerName);
            SetConfigFile(configFilePath);
        }

        public static void SetConfigFile(String configFilePath)
        {   
            
            if (File.Exists(configFilePath))
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(configFilePath));
            else
                throw new FileNotFoundException("Config File Not Found:" + configFilePath);

        }

        public void Info(string message)
        {
            lock (_lock)
            {
                log.Info(message);
            }
        }

        public void Warn(string message)
        {
            lock (_lock)
            {
                log.Warn(message);
            }
        }

        public void Error(string message)
        {
            lock (_lock)
            {
                log.Error(message);
            }
        }

        public void Debug(string message)
        {
            lock (_lock)
            {
                log.Debug(message);
            }
        }
        
    }
}
