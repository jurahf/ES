using System;

namespace ЭС
{
    /// <summary>
    /// Как сработало правило
    /// </summary>
    [Serializable]
    public enum RuleWork
    {
        /// <summary>
        /// Не сработало
        /// </summary>
        No,
        /// <summary>
        /// Сработало, вывод признан истинным (означился)
        /// </summary>
        Signifi,    
        /// <summary>
        /// Сработало, не привело к означиванию
        /// </summary>
        Unsignify   
    }

    /// <summary>
    /// Верен ли факт
    /// </summary>
    [Serializable]
    public enum Rightly
    {
        /// <summary>
        /// Факт не установлен
        /// </summary>
        Unknown = 1,    
        /// <summary>
        /// Факт верен
        /// </summary>
        Yes,          
        /// <summary>
        /// Факт неверен
        /// </summary>
        No              
    }


    /// <summary>
    /// Тип переменной
    /// </summary>
    [Serializable]
    public enum VarType
    {
        /// <summary>
        /// Выводимая
        /// </summary>
        Deducted,
        /// <summary>
        /// Запрашиваемая
        /// </summary>
        Queried,
        /// <summary>
        /// Выводимо-запрашиваемая
        /// </summary>
        DeductionQueried
    }


}