using System.Windows;
using ProjectBilling.Business;

namespace ProjectBilling.UI.MVP
{
    public partial class MainWindow : Window
    {

        private IProjectsModel model = null;
        /// <summary>
        /// Создаем новую модель
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            model = new ProjectsModel();
        }

        /// <summary>
        /// Нажатие кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            //Создаем представление
            ProjectsView view = new ProjectsView();
            //Создаем Presenter с нашим представлением и моделью
            ProjectsPresenter presenter = new ProjectsPresenter(view, model);
            view.Owner = this;
            view.Show();
        }
    }
}