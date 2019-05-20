using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ЭС
{
    /// <summary>
    /// Устанавливает связь между переменной и конкретным значением из ее домена
    /// </summary>
    [Serializable]
    public class Fact :IComparable
    {
        /// <summary>
        /// Переменная
        /// </summary>
        private Variable v;
        // отношение - всегда только равенство
        /// <summary>
        /// Значение переменной
        /// </summary>
        private string weight;
        /// <summary>
        /// Истинность факта
        /// </summary>
        private Rightly truly;

        #region Свойства

        public Variable V
        {
            get { return v;}
            set { v = value; }
        }


        public string Weight
        {
            get { return weight; }
            set 
            {
                if (v.Domain.InDomain(value))
                {
                    weight = value;
                    truly = Rightly.Unknown; // считаем неизвестным
                }
                else
                    throw new DomainException("Попытка присвоить переменной значение не из ее домена");
            }
        }


        public Rightly Truly
        {
            get { return truly; }
            set { truly = value; }
        }

        #endregion

        

        #region Конструкторы
        public Fact()
        {
        }

        public Fact(Variable v, string weight)
        {
            this.V = v;
            this.Weight = weight;
            truly = Rightly.Unknown;
        }

        public Fact(Variable v, string weight, Rightly truly) 
            :this(v, weight)
        {
            this.Truly = truly;
        }
        #endregion

        public override string ToString()
        {
            return this.v.Name + " = " + this.weight;// +" (" + truly + ")";
        }

        /// <summary>
        /// Сравнение фактов. Факты равны, если равны переменные и их значения.
        /// </summary>
        public int CompareTo(object obj)
        {
            Fact f = obj as Fact;
            int i = this.V.CompareTo(f.V);
            if (i != 0)
                return i;
            else // переменные одинаковы
                return this.weight.CompareTo(f.Weight);
        }


        /// <summary>
        /// Проверяет, содержится ли факт в среди фактов 
        /// </summary>
        /// <param name="fArr">Искомый факт</param>
        /// <param name="fact">Массив фактов</param>
        internal static bool ContainsIn(Fact fact, params Fact[] fArr)
        {
            foreach (Fact same in fArr)
                if (fact.CompareTo(same) == 0)
                    return true;

            return false;
        }


        /// <summary>
        /// Возвращает ссылку на факт из списка, через ссылку на аналогичный факт
        /// </summary>
        /// <param name="fact"></param>
        /// <param name="proved"></param>
        /// <returns></returns>
        internal static Fact GetFromMas(Fact fact, params Fact[] fArr)
        {
            foreach (Fact same in fArr)
                if (fact.CompareTo(same) == 0)
                    return same;
            return null;
        }
    }

   

}
