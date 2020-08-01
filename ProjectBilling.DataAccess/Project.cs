namespace ProjectBilling.DataAccess
{
    /// <summary> Интерфейс Проект </summary>
    public interface IProject
    {
        /// <summary>ID Проекта </summary>
        int ID { get; set; }
        /// <summary> Имя проекта </summary>
        string Name { get; set; }
        /// <summary> Сметная стоимость </summary>
        double Estimate { get; set; }
        /// <summary> Реальная стоимость </summary>
        double Actual { get; set; }
        /// <summary> Метод обновления Полей проекта </summary>
        /// <param name="project">Интерфейс проекта от которого будет обновление </param>
        void Update(IProject project);
    }
    /// <summary> Класс Проект </summary>
    public class Project : IProject
    {
        /// <summary>ID Проекта </summary>
        public int ID { get; set; }
        /// <summary> Имя проекта </summary>
        public string Name { get; set; }
        /// <summary> Сметная стоимость </summary>
        public double Estimate { get; set; }
        /// <summary> Реальная стоимость </summary>
        public double Actual { get; set; }
        /// <summary> Метод обновления Полей проекта </summary>
        /// <param name="project">Интерфейс проекта от которого будет обновление </param>
        public void Update(IProject project)
        {
            Name = project.Name;
            Estimate = project.Estimate;
            Actual = project.Actual;
        }
    }
}