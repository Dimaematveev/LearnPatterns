using System.ComponentModel;

namespace DataBase.BL
{
    /// <summary>
    /// Все модели должны наследовать этот класс. Позволяет следить за обновлением в WPF.
    /// </summary>
    public abstract class BD_Default : INotifyPropertyChanged
    {
        abstract public int ID { get; set; }
        abstract public bool IsDelete { get; set; }
        abstract public BD_Default Copy();
        abstract public void Fill(BD_Default bd_Default);
        public BD_Default() { }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
