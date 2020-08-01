using Microsoft.Win32;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Стандартный класс работы с диалоговыми окнами.
    /// </summary>
    public class DefaultDialogService : IDialogService
    {
        /// <summary>
        /// Путь до файла.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Открыть файл в диалоговом окне.
        /// </summary>
        /// <returns> true/false успешное открытие или нет.</returns>
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Сохранить файл в диалоговом окне.
        /// </summary>
        /// <returns> true/false успешное сохранение или нет.</returns>
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Показать сообщение.
        /// </summary>
        /// <param name="message"> Сообщение для вывода.</param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}