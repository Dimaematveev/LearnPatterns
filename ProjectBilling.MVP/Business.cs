using System;
using System.Collections.Generic;
using System.Linq;
using ProjectBilling.DataAccess;

namespace ProjectBilling.Business
{
    #region ProjectsEventArgs

    public class ProjectEventArgs : EventArgs
    {
        public Project Project { get; set; }
        public ProjectEventArgs(Project project)
        {
            Project = project;
        }
    }

    #endregion ProjectsEventArgs

    /// <summary>
    /// модель
    /// </summary>
    public interface IProjectsModel
    {
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="project"></param>
        void UpdateProject(Project project);
        /// <summary>
        /// получить все проекты
        /// </summary>
        /// <returns></returns>
        IEnumerable<Project> GetProjects();
        /// <summary>
        /// Получить проект по ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Project GetProject(int Id);
        /// <summary>
        /// Событие возникающее при обновлении данных
        /// </summary>
        event EventHandler<ProjectEventArgs> ProjectUpdated;
    }
    /// <summary>
    /// Класс модели
    /// </summary>
    public class ProjectsModel : IProjectsModel
    {
        /// <summary>
        /// Проект
        /// </summary>
        private IEnumerable<Project> projects = null;

        /// <summary>
        /// Событие обновления
        /// </summary>
        public event EventHandler<ProjectEventArgs> ProjectUpdated = delegate { };

        /// <summary>
        /// Из данных берем Проекты
        /// </summary>
        public ProjectsModel()
        {
            projects = new DataServiceStub().GetProjects();
        }

        /// <summary>
        /// Запускаем событие Обновления с обновляемым бъектом
        /// </summary>
        /// <param name="project"></param>
        public void UpdateProject(Project project)
        {
            ProjectUpdated(this,new ProjectEventArgs(project));
        }

        /// <summary>
        /// Получаем все проекты
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProjects()
        {
            return projects;
        }

        /// <summary>
        /// Получаем проект по ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Project GetProject(int Id)
        {
            return projects.Where(p => p.ID == Id).First() as Project;
        }
    }
}