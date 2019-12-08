using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace _2DFDTD.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>Событие происходит в момент, когда объект модели-представления меняет одно из своих свойств</summary>
        /// <remarks>Параметр события хранит имя свойств, которое изменилось</remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Сгенерировать событие изменения свойства</summary>
        /// <param name="PropertyName">
        /// Имя изменившегося свойства
        /// (если передать пустую ссылку - null, то будет взято имя свойства/метода из которого был вызван данный метод)
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        /// <summary>Метод-хелпер, позволяющий упростить процесс установки значения полей, в которых свойства хранят свои значения</summary>
        /// <typeparam name="T">Тип данных свойства/поля</typeparam>
        /// <param name="Field">Ссылка на поле</param>
        /// <param name="Value">Устанавливаемое значение</param>
        /// <param name="PropertyName">
        /// Имя изменившегося свойства
        /// (если передать пустую ссылку - null, то будет взято имя свойства/метода из которого был вызван данный метод)
        /// </param>
        /// <returns>Истина, если значение свойства установлено успешно. Ложь, если была попытка установить значение, которое уже было установлено</returns>
        protected virtual bool Set<T>(ref T Field, T Value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(Field, Value)) return false;
            Field = Value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
