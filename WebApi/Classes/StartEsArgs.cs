using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Classes
{
    public class StartEsArgs
    {
        public string FileName { get; set; }
        public string Goal { get; set; }
        public List<VariableValue> VarValues { get; set; }
    }

    public class VariableValue
    {
        public string Variable { get; set; }
        public string Value { get; set; }
    }
}