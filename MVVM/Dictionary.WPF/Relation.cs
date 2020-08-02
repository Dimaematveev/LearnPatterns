using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace Dictionary.WPF
{
    /// <summary>
    /// Связь названия словаря с Представлением, с Изменением/Добавлением, с Базой
    /// </summary>
    public class Relation
    {
        

        public string Text { get; }
        public UserControl ViewControl { get; }
        public Window AddEditWindow { get; }
        public DbSet TableDb { get; }
        public object NewObject { get; }

        public Relation(string text, UserControl viewControl, Window addEditWindow, DbSet tableDb, object newObject)
        {
            Text = text;
            ViewControl = viewControl;
            AddEditWindow = addEditWindow;
            TableDb = tableDb;
            NewObject = newObject;
        }
    }
}
