using System.Windows;

namespace Dictionary.BL.EditAdd
{
    /// <summary>
    /// Интерфейс для Добавления/Изменения элементов
    /// </summary>
    public interface IEditAddViewWindows
    {
        /// <summary>
        /// Получить изменяемое поле
        /// </summary>
        /// <returns></returns>
        object GetDic_Device();
        /// <summary>
        /// Получить это окно
        /// </summary>
        /// <returns></returns>
        Window GetWindow();
    }
}
