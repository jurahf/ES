using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ЭС
{
    public class ЗапросПеременнойЧерезФорму : IЗапросПеременной
    {
        public Fact Запросить(Variable g, ExpertSystem es)
        {
            frmQuestion fq = new frmQuestion(g, es);
            fq.ShowDialog();
            Fact f = new Fact(g, es.res as string, Rightly.Yes);
            return f;
        }
    }
}
