using System;
using ProjectBilling.Business.MVC;
using ProjectBilling.DataAccess;
using System.Windows;

namespace ProjectBilling.UI.MVC
{
    public interface IProjectsController
    {
        /// <summary> отображать представление (реализованное классом ProjectsView) конечному пользователю с указанием главного окна </summary>
        /// <param name="owner">гравное окно</param>
        void ShowProjectsView(Window owner);
        /// <summary> метод обновления данных проекта, который вызывает прототип IProjectsModel  </summary>
        /// <param name="project"> Данные для обновления </param>
        void Update(Project project);
    }

    public class ProjectsController : IProjectsController
    {
        /// <summary>
        /// Модель представления
        /// </summary>
        private readonly IProjectsModel _model;

        /// <summary>
        /// Задает модель представления
        /// </summary>
        /// <param name="projectModel"> Модель представления </param>
        public ProjectsController(IProjectsModel projectModel)
        {
            if (projectModel == null)
                throw new ArgumentNullException("projectModel");
            _model = projectModel;
        }

        /// <summary> отображать представление (реализованное классом ProjectsView) конечному пользователю с указанием главного окна </summary>
        /// <param name="owner">гравное окно</param>
        public void ShowProjectsView(Window owner)
        {
            ProjectsView view = new ProjectsView(this, _model);
            view.Owner = owner;
            view.Show();
        }

        /// <summary> метод обновления данных проекта, который вызывает прототип IProjectsModel  </summary>
        /// <param name="project"> Данные для обновления </param>
        public void Update(Project project)
        {
            _model.UpdateProject(project);
        }
    }
}