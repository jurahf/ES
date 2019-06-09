using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools
{
    [Serializable]
    public class OrderedDictionary<TKey, TVal> :IEnumerable<TKey>
    {
        /// <summary>
        /// Хранилище элементов
        /// </summary>
        private List<TKey> keys = new List<TKey>();
        private List<TVal> vals = new List<TVal>();

        public List<TKey> Keys
        {
            get { return keys; }
        }

        public List<TVal> Vals
        {
            get { return vals; }
        }


        #region Класс-итератор
        private class Iterator : IEnumerator<TKey>
        {
            private int current; // текущий индекс элемента-ключа
            private OrderedDictionary<TKey, TVal> mydict;

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="mydict">Итерируемый объемлющий класс</param>
            public Iterator(OrderedDictionary<TKey, TVal> mydict)
            {
                this.mydict = mydict;
                this.current = -1;
            }



            public TKey Current
            {
                get { return mydict.keys[current]; }
            }


            #region
            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            object System.Collections.IEnumerator.Current
            {
                get { return null; }
            }
            #endregion


            public bool MoveNext()
            {
                ++current;
                if (current < mydict.keys.Count)
                    return true;
                else
                    return false;
            }

            public void Reset()
            {
                current = -1;
            }
        }
        #endregion


        public TVal this[TKey index]
        {
            get 
            {
                if (keys.Contains(index))
                    return vals[keys.IndexOf(index)];
                else
                    throw new IndexOutOfRangeException();
            }
            set { vals[keys.IndexOf(index)] = value; }
        }


        public IEnumerator<TKey> GetEnumerator()
        {
            return new Iterator(this);
        }

        #region
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion


        /// <summary>
        /// Добавление нового элемента в коллекцию
        /// </summary>
        /// <param name="k">Ключ</param>
        /// <param name="v">Элемент</param>
        public bool Add(TKey k, TVal v)
        {
            if (keys.Contains(k))
                return false;
            keys.Add(k);
            vals.Add(v);
            return true;
        }

        public void Add(object o)
        {
            throw new Exception("не не не");
        }

        /// <summary>
        /// Возвращает количество элементов в словаре
        /// </summary>
        public int Count
        {
            get { return keys.Count; }
        }


        /// <summary>
        /// Очищает коллекцию
        /// </summary>
        public void Clear()
        {
            keys.Clear();
            vals.Clear();
        }


        /// <summary>
        /// Проверяет наличие ключа коллекции
        /// </summary>
        /// <param name="k">Искомый ключ</param>
        public bool ContainsKey (TKey k)
        {
            return keys.Contains(k);
        }

        /// <summary>
        /// Проверяет наличие значения в коллекции
        /// </summary>
        /// <param name="v">Искомое значение</param>
        public bool ContainsValue(TVal v)
        {
            return vals.Contains(v);
        }

        /// <summary>
        /// Вставляет данные на определенное место в коллекции
        /// </summary>
        /// <param name="pos">Позиция в коллекции</param>
        /// <param name="k">Ключ</param>
        /// <param name="v">Значение</param>
        public bool Insert(int pos, TKey k, TVal v)
        {
            if (keys.Contains(k))
                return false;
            keys.Insert(pos, k);
            vals.Insert(pos, v);
            return true;
        }


        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="k">Ключ элемента</param>
        public bool Remove(TKey k)
        {
            if (!keys.Contains(k))
                return false;
            vals.RemoveAt(keys.IndexOf(k));
            keys.Remove(k);
            return true;
        }

        /// <summary>
        /// Удаление элемента с определенной позиции
        /// </summary>
        /// <param name="pos">Позиция</param>
        public bool RemoveAt (int pos)
        {
            if (pos < 0 || pos >= keys.Count)
                return false;
            vals.RemoveAt(pos);
            keys.RemoveAt(pos);
            return true;
        }

    }




}
