using System.Windows;
using ProjectBilling.Business;

namespace ProjectBilling.UI.MVP
{
    public partial class MainWindow : Window
    {
        private IProjectsModel model = null;

        public MainWindow()
        {
            InitializeComponent();
            model = new ProjectsModel();
        }

        private void showProjectsButton_Click(object sender,
            RoutedEventArgs e)
        {
            ProjectsView view = new ProjectsView();
            ProjectsPresenter presenter
                = new ProjectsPresenter(view, model);
            view.Owner = this;
            view.Show();
        }
    }
}