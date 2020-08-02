using System.ComponentModel;

namespace DataBase.BL
{
    /// <summary>
    /// Все модели должны наследовать этот класс. Позволяет следить за обновлением в WPF
    /// </summary>
    public abstract class NotifyPropertyChanged_Default : INotifyPropertyChanged
    {
        public NotifyPropertyChanged_Default() { }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
