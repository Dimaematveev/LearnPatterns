using Dictionary.BL.EditAdd;
using System;
using System.Data.Entity;
using System.Windows.Controls;

namespace Dictionary.BL
{
    //TODO:Уменьшить или удалить надо этот класс
    /// <summary>
    /// Связь названия словаря с Представлением, с Изменением/Добавлением, с Базой
    /// </summary>
    public class Relation
    {
        /// <summary>
        /// Текст в представлении
        /// </summary>
        public string Text { get; }
        /// <summary>
        /// Какой Пользовательский элемент открывать
        /// </summary>
        public UserControl ViewControl { get; }
        /// <summary>
        /// Функция для создания окна изменения или добавления
        /// </summary>
        public Func<object, IEditAddViewWindows> FuncAddEditWindow { get; }
        /// <summary>
        /// База данных
        /// </summary>
        public DbSet TableDb { get; }
        /// <summary>
        /// Функция создания нового объекта
        /// </summary>
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
