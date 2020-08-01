using System.Collections.Generic;

namespace MVVM
{
    /// <summary>
    /// Интерфейс работы с файлами
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Выводит список Телефонов из файла
        /// </summary>
        /// <param name="filename"> Имя файла</param>
        /// <returns>Список телефонов.</returns>
        List<PhoneViewModel> Open(string filename);
        /// <summary>
        /// Сохраняет список телефонов в файл.
        /// </summary>
        /// <param name="filename"> Имя файла.</param>
        /// <param name="phonesList"> Список телефонов.</param>
        void Save(string filename, List<PhoneViewModel> phonesList);
    }
}