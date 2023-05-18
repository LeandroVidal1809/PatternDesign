using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
   public class Logger
    {

        private static readonly Lazy<Logger> _lazyLogger =  new Lazy<Logger>(() => new Logger());
        public static Logger Instance
        {            
            get { return _lazyLogger.Value; }
        }
        //Lazy is safe to use in Singleton.
        //Without Lazy
        //private static  Logger? _instance;
        //public static Logger Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new Logger();
        //        }
        //        return _instance;
        //    }
        //}


        protected Logger() {}
        
        public void Log(string message) 
        {
            Console.WriteLine($"Message: {message} ");
        }
    }
}
