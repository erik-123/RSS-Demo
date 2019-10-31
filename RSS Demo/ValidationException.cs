using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Demo
{
    class ValidationException: System.Exception
    {
        public ValidationException(string message): base (message) 
        
        { }
    }
}
