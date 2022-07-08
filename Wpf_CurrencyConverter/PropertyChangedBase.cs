using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf_CurrencyConverter
{
    /// <summary>
    /// Сообщает интерфейсу об изменении к-л из свойств модели
    /// </summary>
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}