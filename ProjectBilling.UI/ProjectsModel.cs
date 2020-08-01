using System;
using System.Collections.Generic;
using System.Linq;
using ProjectBilling.DataAccess;

namespace ProjectBilling.Business.MVC
{
    /// <summary> Интерфейс Модели для использования нашим представлением. </summary>
    public interface IProjectsModel
    {
        /// <summary> Список проектов </summary>
        IEnumerable<Project> Projects { get; set; }
        /// <summary> Событие для уведомления экземпляра класса Project об обновлении. </summary>
        event EventHandler<ProjectEventArgs> ProjectUpdated;

        /// <summary> Обновление проекта из данных</summary>
        /// <param name="project"> Проект из которого будет обновление в текущий проект </param>
        void UpdateProject(Project project);
    }

    /// <summary> Класс Модели для использования нашим представлением. </summary>
    public class ProjectsModel : IProjectsModel
    {
        /// <summary> Список проектов </summary>
        public IEnumerable<Project> Projects { get; set; }

        /// <summary> Событие для уведомления экземпляра класса Project об обновлении. </summary>
        public event EventHandler<ProjectEventArgs> ProjectUpdated = delegate { };

        /// <summary> Пустой конструктор. Заполняем Список проектов из DataServiceStub </summary>
        public ProjectsModel()
        {
            Projects = new DataServiceStub().GetProjects();
        }

        //TODO разобраться в событии
        private void RaiseProjectUpdated(Project project)
        {
            ProjectUpdated(this, new ProjectEventArgs(project));
        }

        /// <summary> Обновление проекта из данных</summary>
        /// <param name="project"> Проект из которого будет обновление в текущий проект </param>
        public void UpdateProject(Project project)
        {
            Project selectedProject = Projects.Where(p => p.ID == project.ID)
                                              .FirstOrDefault() as Project;
            selectedProject.Name = project.Name;
            selectedProject.Estimate = project.Estimate;
            selectedProject.Actual = project.Actual;
            RaiseProjectUpdated(selectedProject);
        }
    }

    /// <summary> Класс для события </summary>
    public class ProjectEventArgs : EventArgs
    {
        /// <summary> Проект </summary>
        public Project Project { get; set; }

        /// <summary> Конструктор инициализирует Проект </summary>
        /// <param name="project"> Проект </param>
        public ProjectEventArgs(Project project)
        {
            Project = project;
        }
    }
}