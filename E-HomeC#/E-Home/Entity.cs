using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Home
{
    public class Entity
    {
        public string paramName = null;
        public string paramValue = null;
        public Entity(string paramName, string paramValue)
        {
            this.paramName = paramName;
            this.paramValue = paramValue;
        }
    }
}
