using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ProjectBilling.Business.MVC;
using ProjectBilling.DataAccess;

namespace ProjectBilling.UI.MVC
{
    /// <summary>
    /// Представление данных Проекта
    /// </summary>
    public partial class ProjectsView : Window
    {
        /// <summary>
        /// Модель представления
        /// </summary>
        private readonly IProjectsModel _model;
        /// <summary>
        /// Контроллер 
        /// </summary>
        private readonly IProjectsController _controller = null;
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        private const int NONE_SELECTED = -1;

        /// <summary>
        /// Задаем контроллер и модель представления и подтягиваем данные
        /// </summary>
        public ProjectsView(IProjectsController projectsController,IProjectsModel projectsModel)
        {
            InitializeComponent();
            _controller = projectsController;
            _model = projectsModel;


            _model.ProjectUpdated += model_ProjectUpdated;

            ProjectsComboBox.ItemsSource = _model.Projects;
            ProjectsComboBox.DisplayMemberPath = "Name";
            ProjectsComboBox.SelectedValuePath = "ID";
        }


        #region Event Handlers
        /// <summary>
        /// реагирование на событие изменения данных
        /// </summary>
        void model_ProjectUpdated(object sender,ProjectEventArgs e)
        {
            int selectedProjectId = GetSelectedProjectId();

            if (selectedProjectId > NONE_SELECTED)
            {
                ProjectsComboBox.SelectedValue = selectedProjectId;
                if (selectedProjectId == e.Project.ID)
                {
                    UpdateDetails(e.Project);
                }
            }
        }

        /// <summary>
        /// Изменение значения commbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Project project = GetSelectedProject();
            if (project != null)
            {
                EstimatedTextBox.Text = project.Estimate.ToString();
                EstimatedTextBox.IsEnabled = true;
                ActualTextBox.Text = project.Actual.ToString();
                ActualTextBox.IsEnabled = true;
                updateButton.IsEnabled = true;
                UpdateEstimatedColor();
            }
        }
        /// <summary>
        /// Назатие button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender,RoutedEventArgs e)
        {
            Project project = new Project()
            {
                ID = (int)ProjectsComboBox.SelectedValue,
                Name = ProjectsComboBox.Text,
                Estimate = GetDouble(EstimatedTextBox.Text),
                Actual = GetDouble(ActualTextBox.Text)
            };
            _controller.Update(project);
        }

        #endregion Event Handlers

        #region Helpers

        /// <summary>
        /// Цвет при изменении проекта
        /// </summary>
        private void UpdateEstimatedColor()
        {
            double actual= GetDouble(ActualTextBox.Text);
            double estimated= GetDouble(EstimatedTextBox.Text);
            if (actual == 0)
            {
                EstimatedTextBox.Foreground = ActualTextBox.Foreground;
            }
            else if (actual > estimated)
            {
                EstimatedTextBox.Foreground= Brushes.Red;
            }
            else
            {
                EstimatedTextBox.Foreground= Brushes.Green;
            }
        }
        /// <summary>
        /// Если изменился проект то изменяем данные по нему
        /// </summary>
        /// <param name="project"></param>
        private void UpdateDetails(Project project)
        {
            EstimatedTextBox.Text= project.Estimate.ToString();
            ActualTextBox.Text= project.Actual.ToString();
            UpdateEstimatedColor();
        }

        /// <summary>
        /// Получить double 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private double GetDouble(string text)
        {
            return string.IsNullOrEmpty(text) ? 0 : double.Parse(text);
        }

        /// <summary>
        /// Получаем проект из Выбора
        /// </summary>
        /// <returns> Проект </returns>
        private Project GetSelectedProject()
        {
            return ProjectsComboBox.SelectedItem as Project;
        }

        /// <summary>
        /// Получаем ID выбранного проекта
        /// </summary>
        /// <returns> ID </returns>
        private int GetSelectedProjectId()
        {
            Project project = GetSelectedProject();
            return (project == null) ? NONE_SELECTED : project.ID;
        }

        #endregion Helpers
    }
}