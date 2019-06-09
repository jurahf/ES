using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace Classes
{
    [Serializable]
    public class Rule
    {
        /// <summary>
        /// Посылка правила
        /// </summary>
        private List<Fact> reasons = new List<Fact>();
        /// <summary>
        /// Вывод
        /// </summary>
        public Fact Result {get; set;}
        /// <summary>
        /// Отработало ли правило
        /// </summary>
        public RuleWork Worked {get; set;}
        public string Name {get; set;}
        public string Reasoning { get; set; }

        #region Конструктор
        public Rule()
        {
        }
        public Rule(string name)
        {
            this.Name = name;
            Worked = RuleWork.No;
        }

        public Rule(Fact reason, Fact result)
        {
            this.reasons.Add(reason);
            this.Result = result;
            Worked = RuleWork.No;
        }
        #endregion


        public List<Fact> Reasons
        {
            get { return reasons; }
            set { reasons = value; }
        }


        /// <summary>
        /// Добавляет новую посылку в правило
        /// </summary>
        /// <param name="f">Посылка</param>
        /// <param name="pos">Позиция в списке посылок</param>
        public void AddReason(Fact f, int pos)
        {
            if ((pos < 0) || (pos > reasons.Count))
                throw new RuleException("Индекс находился вне границ списка посылок");
            if (this.Contains(f))
                throw new RuleException("Попытка добавить повторяющийся факт в список посылок");
            reasons.Add(f);
            Move(reasons.Count - 1, pos);
        }


        /// <summary>
        /// Возвращает посылку с определенного места
        /// </summary>
        /// <param name="pos">Позиция посылки</param>
        public Fact GetReason(int pos)
        {
            if ((pos < 0) || (pos > reasons.Count - 1))
                throw new RuleException("Индекс находился вне границ списка посылок");
            return reasons[pos];
        }

        public int ReasonCount()
        {
            return reasons.Count;
        }

        /// <summary>
        /// Перемещает посылку в списке со сдвигом
        /// </summary>
        /// <param name="oldPos">Старая позиция</param>
        /// <param name="newPos">Новая позиция</param>
        public void Move(int oldPos, int newPos)
        {
            if ((oldPos > reasons.Count - 1) || (newPos > reasons.Count - 1) || (oldPos < 0) || (newPos < 0))
                throw new RuleException("Индекс находился вне границ списка посылок");

            Fact pr = reasons[oldPos];
            if (oldPos > newPos)
            {
                for (int i = oldPos; i > newPos; i--)
                    reasons[i] = reasons[i - 1];
            }
            else
            {
                for (int i = oldPos; i < newPos; i++)
                    reasons[i] = reasons[i + 1];
            }
            reasons[newPos] = pr;
        }

        /// <summary>
        /// Перемащает посылку в списке со сдвигом
        /// </summary>
        /// <param name="f">Посылка</param>
        /// <param name="newPos">Новая позиция</param>
        public void Move(Fact f, int newPos)
        {
            if (this.Contains(f))
                Move(this.IndexOf(f), newPos);
            else
                throw new RuleException("Запрашиваемая посылка не найдена");
        }


        /// <summary>
        /// Удаляет посылку из списка с определенной позиции
        /// </summary>
        /// <param name="pos">Позиция посылки</param>
        public void Remove(int pos)
        {
            if ((pos > reasons.Count - 1) || (pos < 0))
                throw new RuleException("Индекс находился вне границ списка посылок");
            if (reasons.Count == 1)
                throw new RuleException("Попытка удалить едиственную посылку в правиле");
            reasons.RemoveAt(pos);
        }


        /// <summary>
        /// Удаляет посылку из списка
        /// </summary>
        /// <param name="f">Удаляемая посылка</param>
        public void Remove(Fact f)
        {
            if (reasons.Count == 1)
                throw new RuleException("Попытка удалить едиственную посылку в правиле");
            if (this.Contains(f))
                reasons.RemoveAt(this.IndexOf(f));
            else
                throw new RuleException("Запрашиваемая посылка не найдена");
        }


        /// <summary>
        /// Проверяет, содержит ли список посылок данный факт
        /// </summary>
        /// <param name="f">Искомый факт</param>
        public bool Contains(Fact fact)
        {
            foreach (Fact f in reasons)
                if (f.CompareTo(fact) == 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Возвращает индекс факта в списке посылок
        /// </summary>
        /// <param name="fact">Посылка</param>
        public int IndexOf(Fact fact)
        {
            for (int i = 0; i < reasons.Count; i++)
                if (reasons[i].CompareTo(fact) == 0)
                    return i;
            return -1;
        }


        public override string ToString()
        {
            if (reasons.Count > 0)
            {
                string s = "ЕСЛИ ";
                for (int i = 0; i < reasons.Count - 1; i++)
                    s += "(" + reasons[i].ToString() + ") И ";
                s += "(" + reasons[reasons.Count - 1] + ") ТОГДА ";
                if (Result != null)
                    s += Result.ToString();
                return s;
            }
            else
                return "";
        }


    }

}
