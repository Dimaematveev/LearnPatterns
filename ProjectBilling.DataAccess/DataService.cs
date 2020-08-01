using System.Collections.Generic;

namespace ProjectBilling.DataAccess
{
    /// <summary> Интерфейс данных </summary>
    public interface IDataService
    {
        /// <summary> Вывод списка Проектов </summary>
        /// <returns> список проектов </returns>
        IList<Project> GetProjects();
    }

    /// <summary> Класс данных </summary>
    public class DataServiceStub : IDataService
    {
        /// <summary> Вывод списка Проектов </summary>
        /// <returns> список проектов </returns>
        public IList<Project> GetProjects()
        {
            List<Project> projects = new List<Project>()
            {
                new Project()
                {
                    ID = 0,
                    Name = "Halloway",
                    Estimate = 500
                },
                new Project()
                {
                    ID = 1,
                    Name = "Jones",
                    Estimate = 1500
                },
                new Project()
                {
                    ID = 2,
                    Name = "Smith",
                    Estimate = 2000
                }
            };

            return projects;
        }
    }
}