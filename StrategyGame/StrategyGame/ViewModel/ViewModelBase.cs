using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.ViewModel
{
    // Nézetmodellek absztrakt õsosztálya
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Tulajdonság értékének megváltozása esetén lefutó esemény
        public event PropertyChangedEventHandler PropertyChanged;

        // Tulajdonság értékének megváltoztatását jelzõ metódus
        protected ViewModelBase OnPropertyChanged<TPropertyType>(Expression<Func<TPropertyType>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            return OnPropertyChanged(GetMemberNameFromExpression(expression));
        }

        // Tulajdonság értékének megváltoztatását jelzõ metódus
        protected virtual ViewModelBase OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            return this;
        }

        // Lekérdezi a lambdafüggvény
        private string GetMemberNameFromExpression<T>(Expression<Func<T>> expression)
        {
            if (expression == null) throw new ArgumentException("Getting property name form expression is not supported for this type.");
            var lambda = expression as LambdaExpression;  //Megnézzük, hogy felhasználó lambdafüggvényt adott-e át paraméterként
            if (lambda == null) // ha nem akkor hibát dobunk
                throw new NotSupportedException("Getting property name form expression is not supported for this type.");
            var memberExpression = lambda.Body as MemberExpression; //lekérjük a lambda kifejezésünk törzsét
            if (memberExpression != null)
                return memberExpression.Member.Name;  // ha ez sikerül, akkor a Member.Name tulajdonság fogja tárolni a nevet
            var unary = lambda.Body as UnaryExpression; //ha nem akkor tovább próbálkozunk
            if (unary != null) {
                var member = unary.Operand as MemberExpression;
                if (member != null)
                    return member.Member.Name;
            }
            throw new NotSupportedException("Getting property name form expression is not supported for this type.");
        }
    }

}
