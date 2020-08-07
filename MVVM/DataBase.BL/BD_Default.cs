using System.ComponentModel;

namespace DataBase.BL
{
    /// <summary>
    /// Все модели должны наследовать этот класс. Позволяет следить за обновлением в WPF.
    /// </summary>
    public abstract class BD_Default : INotifyPropertyChanged
    {
        /// <summary> Публичный ID </summary>
        abstract public int ID { get; set; }
        /// <summary> Является удаленным. </summary>
        abstract public bool IsDelete { get; set; }
        /// <summary>
        /// Копирование всех Полей кроме ID в новую переменную.
        /// </summary>
        /// <returns> Новый класс </returns>
        abstract public BD_Default Copy();
        /// <summary>
        /// Заполнить все поля кроме ID, из данного 
        /// </summary>
        /// <param name="bd_Default"> Откуда копируются данные. </param>
        abstract public void Fill(BD_Default bd_Default);
        public BD_Default() { }


        /// <summary>
        /// Событие изменения
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Воспроизводит событие изменения
        /// </summary>
        /// <param name="prop"> Название Свойства которое изменилось. </param>
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
