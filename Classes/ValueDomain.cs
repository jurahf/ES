using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace Classes
{
    [Serializable]
    public class ValueDomain
    {
        /// <summary>
        /// Список значений домена
        /// </summary>
        private List<string> listVal = new List<string>();
        private string name = "Noname";

        #region Конструктор
        public ValueDomain()
        {
        }
        public ValueDomain(string name)
        {
            this.name = name;
        }
        #endregion

        #region Свойства
        public List<string> ListVal
        {
            get { return listVal; }
            set { listVal = value; }
        }

        public int Count
        {
            get { return listVal.Count; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion


        /// <summary>
        /// Возвращает значение с определенного места
        /// </summary>
        /// <param name="pos">Место в домене</param>
        public string GetVal(int pos)
        {
            if ((pos > listVal.Count - 1) || (pos < 0))
                throw new DomainException("Индекс находился вне границ списка значений");
            return listVal[pos];
        }


        /// <summary>
        /// Добавляет значение на определенное место
        /// </summary>
        /// <param name="val">Значение</param>
        /// <param name="pos">Место в домене</param>
        public void AddVal(string val, int pos)
        {
            if (listVal.Contains(val))
                throw new DomainException("Попытка добавить повторяющееся значение в домен");
            if ((pos > listVal.Count) || (pos < 0))
                throw new DomainException("Индекс находился вне границ списка значений");
            listVal.Add(val);
            Move(listVal.Count - 1, pos);
        }


        /// <summary>
        /// Перемещение существующего значения в домене со сдвигом
        /// </summary>
        /// <param name="oldPos">Старая позиция</param>
        /// <param name="newPos">Новая позиция</param>
        public void Move (int oldPos, int newPos)
        {
            if ((oldPos > listVal.Count - 1) || (newPos > listVal.Count - 1) || (oldPos < 0) || (newPos < 0))
                throw new DomainException("Индекс находился вне границ списка значений");

            string pr = listVal[oldPos];
            if (oldPos > newPos)
            {
                for (int i = oldPos; i > newPos; i--)
                    listVal[i] = listVal[i - 1];
            }
            else 
            {
                for (int i = oldPos; i < newPos; i++)
                    listVal[i] = listVal[i + 1];
            }
            listVal[newPos] = pr;
        }


        /// <summary>
        /// Перемещение существующего значения в домене со сдвигом
        /// </summary>
        /// <param name="val">Перемещаемое значение</param>
        /// <param name="newPos">Новая позиция</param>
        public void Move(string val, int newPos)
        {
            if (listVal.Contains(val))
                Move(listVal.IndexOf(val), newPos);
            else
                throw new DomainException("Список значений не содержит требуемого элемента");
        }


        /// <summary>
        /// Удаление значения с определенной позиции
        /// </summary>
        /// <param name="pos">Место в домене</param>
        public void Remove(int pos)
        {
            if ((pos > listVal.Count - 1) || (pos < 0))
                throw new DomainException("Индекс находился вне границ списка значений");
            listVal.RemoveAt(pos);
        }


        /// <summary>
        /// Удаление определенного значения из домена
        /// </summary>
        /// <param name="val">Удаляемое значение</param>
        public void Remove(string val)
        {
            if (listVal.Contains(val))
                listVal.Remove(val);
            else
                throw new DomainException("Список значений не содержит требуемого элемента");
        }

        /// <summary>
        /// Проверяет, есть ли данное значение в домене
        /// </summary>
        /// <param name="val">Проверяемое значение</param>
        public bool InDomain(string val)
        {
            return listVal.Contains(val);
        }


        /// <summary>
        /// Возвращает индекс элемента в списке значение
        /// </summary>
        /// <param name="val">Значение</param>
        public int IndexOf(string val)
        {
            return listVal.IndexOf(val);
        }


        public override string ToString()
        {
            string res = "";
            if (listVal.Count > 0)
            {
                for (int i = 0; i < listVal.Count - 1; i++)
                    res += listVal[i] + " ";
                res += listVal[listVal.Count - 1];
            }
            else
                res = "Empty";
            return res;
        }


    }
}
