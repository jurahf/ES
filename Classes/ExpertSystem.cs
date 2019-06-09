using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using Tools;

namespace Classes
{
    [Serializable]
    public class ExpertSystem
    {        
        /// <summary>
        /// Список всех доменов значений ЭС (имя, домен)
        /// </summary>
        private OrderedDictionary<string, ValueDomain> domains = new OrderedDictionary<string, ValueDomain>();
        /// <summary>
        /// Список всех переменных ЭС (имя, переманная)
        /// </summary>
        private OrderedDictionary<string, Variable> vars = new OrderedDictionary<string, Variable>();
        /// <summary>
        /// Список правил
        /// </summary>
        private OrderedDictionary<string, Rule> rules = new OrderedDictionary<string, Rule>();
        /// <summary>
        /// Цель консультации
        /// </summary>
        private Variable goal;
        /// <summary>
        /// Доказанные факты
        /// </summary>
        private List<Fact> proved = new List<Fact>();

        /// <summary>
        /// Сработавшие правила
        /// </summary>
        private List<Rule> workedRules;
        public string res;

        [NonSerialized]
        private IЗапросПеременной запросПеременной;



        #region Свойства
        public List<Rule> WorkedRules
        {
            get { return workedRules; }
        }

        public List<Fact> Proved
        {
            get { return proved; }
        }

        public Variable Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        public OrderedDictionary<string, ValueDomain> Domains
        {
            get { return domains; }
            set { domains = value; }
        }

        public OrderedDictionary<string, Variable> Vars
        {
            get { return vars; }
            set { vars = value; }
        }

        public OrderedDictionary<string, Rule> Rules
        {
            get { return rules; }
            set { rules = value; }
        }
        #endregion

        #region Конструктор
        public ExpertSystem()
        { 
        }
        #endregion

        /// <summary>
        /// Устанавливает значение переменной-цели на основании имеющихся правил
        /// </summary>
        public Fact GoConsult(IЗапросПеременной запросПеременной)
        {
            this.запросПеременной = запросПеременной;

            proved = new List<Fact>();
            workedRules = new List<Rule>();
            foreach (Rule r in rules.Vals)
                r.Worked = RuleWork.No;
            return Consult(goal);
        }


        /// <summary>
        /// Применение одного правила
        /// </summary>
        /// <param name="r">Это правило</param>
        public Rightly DoRule(Rule r)
        {
            bool verno = true;
            foreach (Fact fact in r.Reasons)
            {
                if (!Fact.ContainsIn(fact, proved.ToArray()))
                {
                    Fact f = Consult(fact.V); // доказываем и записываем факты
                    proved.Add(f);
                    if (f.Truly == Rightly.Yes)
                        verno = (fact.CompareTo(f) == 0);
                    else
                        verno = false;

                    // а аналогичные факты - на NO
                    foreach (string s in f.V.Domain.ListVal)
                    {
                        if (s != f.Weight)
                            proved.Add(new Fact(f.V, s, Rightly.No));
                    }

                    if (!verno)
                        break; // если факт не верен - неверно все правило
                }
                else
                { // факт уже известен
                    if (Fact.GetFromMas(fact, proved.ToArray()).Truly == Rightly.Yes)
                        verno = true;
                    else
                    {
                        verno = false;
                        break;
                    }
                }
            }

            if (verno) // если все верно - делаем вывод
            {
                if (r.Result == null || !r.Result.V.Domain.ListVal.Contains(r.Result.Weight))
                {
                    throw new DomainException("Правило " + r.Name + " пытается присвоить значение не из домена!");
                }
                r.Result.Truly = Rightly.Yes;
                proved.Add(r.Result);
                r.Worked = RuleWork.Signifi; // означилось
                workedRules.Add(r);
                return Rightly.Yes;
            }
            else
            {
                r.Worked = RuleWork.Unsignify; // не означилось
                return Rightly.Unknown;
            }
        }




        /// <summary>
        /// Устанавливает значение переменной на основании имеющихся правил
        /// </summary>
        /// <param name="g">Переменная</param>
        private Fact Consult(Variable g)
        {
            if (g.Domain == null)
                throw new DomainException("У переменной \"" + g.Name + "\" неизвестен домен!");
            if (g.Domain.ListVal.Count == 0)
                throw new DomainException("Домен \"" + g.Domain.Name + "\" не имеет значений!");

            if (g.MyType == VarType.Queried)
            { // запрашиваемая
                return запросПеременной.Запросить(g, this);
            }
            else
            {
                foreach (string s in rules.Keys) // если выводимая
                {
                    if (rules[s].Result != null && rules[s].Result.V.CompareTo(g) == 0)
                    {
                        switch (DoRule(rules[s]))
                        {
                            case Rightly.Unknown:
                                if (g.MyType == VarType.DeductionQueried) // выводимо-запрашиваемая
                                {
                                    return запросПеременной.Запросить(g, this);
                                }
                                continue;
                            default:
                                return rules[s].Result;
                        }
                    }
                }
            }

            return new Fact(g, g.Domain.GetVal(0), Rightly.Unknown);
        }



    }

}
