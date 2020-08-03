using Dictionary.WPF.EditAdd;
using System;
using System.Collections;
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
        public Func<object, IEditAddViewWindows> FuncAddEditWindow { get; }
        public DbSet TableDb { get; }
        public Func<object> FuncNewObject { get; }

        public Relation(string text, UserControl viewControl, Func<object, IEditAddViewWindows> funcAddEditWindow, DbSet tableDb, Func<object> funcNewObject)
        {
            Text = text;
            ViewControl = viewControl;
            FuncAddEditWindow = funcAddEditWindow;
            TableDb = tableDb;
            FuncNewObject = funcNewObject;
        }
    }
}
