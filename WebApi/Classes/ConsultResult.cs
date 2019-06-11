using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Classes
{
    public class ConsultResultDto
    {
        public FactDto Fact { get; set; }
        public List<RuleDto> Explain { get; set; }

        public ConsultResultDto(Fact fact, List<Rule> rules)
        {
            Fact = new FactDto(fact);
            Explain = rules.Select(x => new RuleDto(x)).ToList();
        }
    }


    public class FactDto
    {
        public string VarName { get; set; }
        public string Value { get; set; }

        public FactDto(Fact fact)
        {
            VarName = fact.V.Name;
            Value = fact.Weight;
        }
    }

    public class RuleDto
    {
        public List<string> Conditions { get; set; }
        public string Result { get; set; }
        public string Explaining { get; set; }

        public RuleDto(Rule rule)
        {
            Conditions = rule.Reasons.Select(r => r.ToString()).ToList();
            Result = rule.Result.ToString();
            Explaining = rule.Reasoning;
        }
    }

}