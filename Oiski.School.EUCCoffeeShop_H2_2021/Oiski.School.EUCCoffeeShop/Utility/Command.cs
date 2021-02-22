using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oiski.School.EUCCoffeeShop_H2_2021.Utility
{
    /// <summary>
    /// Defines a generic command model
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="Command"/> where the <paramref name="_execute"/> method is provided, as well as a <paramref name="_condition"/>
        /// </summary>
        /// <param name="_execute"></param>
        /// <param name="_condition"></param>
        public Command ( Action<object> _execute, Predicate<object> _condition )
        {
            if ( _execute == null )
            {
                throw new NullReferenceException ("Execute can't be null!");
            }

            execute = _execute;
            condition = _condition;
        }

        /// <summary>
        /// Initialize a new instance of type <see cref="Command"/> where the <paramref name="_execute"/> method is provided
        /// </summary>
        /// <param name="_execute"></param>
        public Command ( Action<object> _execute ) : this (_execute, null)
        {

        }

        private readonly Action<object> execute;
        private readonly Predicate<object> condition;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute ( object _parameter )
        {
            bool con = condition == null || condition (_parameter);
            return con;
        }

        public void Execute ( object _parameter )
        {
            execute.Invoke (_parameter);
        }
    }
}
