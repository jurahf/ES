using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public interface IЗапросПеременной
    {
        Fact Запросить(Variable v, ExpertSystem es);
    }
}
