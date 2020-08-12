using System.Windows.Controls;

namespace Dictionary.BL.ViewDictionary
{
    //TODO:Никто не использует
    /// <summary>
    /// Интерфейс для Пользовательских элементов управления. Просмотр
    /// </summary>
    public interface IViewControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        UserControl GetEditAddUserControl();
    }
}
