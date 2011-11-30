using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noesis.Javascript;

namespace YoutubeDesktop
{
    public class JavascriptEnv
    {
        
        public Dictionary<string, object> parameters = new Dictionary<string,object>();
        
        public object returnValue;
        
        public Exception exception;

    }
}
