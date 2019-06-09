using System;

namespace Tools
{
    /// <summary>
    /// Ошибки при работе с классом ValueDomain
    /// </summary>
    public class DomainException :Exception
    {
        public DomainException()
            :base()
        {
        }

        public DomainException(string msg)
            : base(msg)
        {
        }
    }


    /// <summary>
    /// Ошибки при работе с классом Rule
    /// </summary>
    public class RuleException : Exception
    {
        public RuleException()
            :base()
        {
        }

        public RuleException(string msg)
            : base(msg)
        {
        }
    }

    /// <summary>
    /// Ошибки при работе с классами Variable, DeductionVariable, QueriedVariable
    /// </summary>
    public class VariableException : Exception
    {
        public VariableException()
            : base()
        {
        }

        public VariableException(string msg)
            : base(msg)
        {
        }
    }

}