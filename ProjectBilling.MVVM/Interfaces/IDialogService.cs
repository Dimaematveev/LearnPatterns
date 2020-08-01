/// <summary>
/// Интерфейс работы с диалоговыми окнами.
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Показать сообщение.
    /// </summary>
    /// <param name="message"> Сообщение для вывода.</param>
    void ShowMessage(string message);
    /// <summary>
    /// Путь к выбранному файлу.
    /// </summary>
    string FilePath { get; set; }
    /// <summary>
    /// Открыть файл в диалоговом окне.
    /// </summary>
    /// <returns> true/false успешное открытие или нет.</returns>
    bool OpenFileDialog();
    /// <summary>
    /// Сохранить файл в диалоговом окне.
    /// </summary>
    /// <returns> true/false успешное сохранение или нет.</returns>
    bool SaveFileDialog(); 
}