using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    [Serializable]
    public class Variable :IComparable
    {
        /// <summary>
        /// Имя переменной
        /// </summary>
        protected string name;
        /// <summary>
        /// Допустимые значения
        /// </summary>
        protected ValueDomain domain;
        /// <summary>
        /// тип переменной
        /// </summary>
        protected VarType myType;
        protected string question;

        protected string reasoning;

        #region Свойства
        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        public string Reasoning
        {
            get { return reasoning; }
            set { reasoning = value; }
        }


        public virtual VarType MyType
        {
            set { myType = value; }
            get { return myType; }
        }
        public ValueDomain Domain
        {
            get { return domain; }
            set { domain = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region Конструктор
        public Variable()
        {
        }

        public Variable(string name)
        {
            this.name = name;
        }

        public Variable(string name, ValueDomain domain)
        {
            this.name = name;
            this.domain = domain;
        }
        #endregion


        public override string ToString()
        {
            return name + " (" + domain.Name + ")";
        }

        /// <summary>
        /// Сравнение переменных - по их имени
        /// </summary>
        public int CompareTo(object obj)
        {
            return this.name.CompareTo(((Variable)obj).Name);
        }
    }


}
