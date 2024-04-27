using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using TrelloApp.Helpers;
using TrelloApp.ViewModels;
using TrelloApp.ViewModels.Repository;
using TrelloApp.Views.Utils;
using TrelloDBLayer;

namespace TrelloApp.Views
{
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
            var vm = new LoginViewModel(FindResource("UserRepository") as IUserRepository,
                                        FindResource("Navigation") as INavigator);
            DataContext = vm;
        }

        private void BtnCreateDatabase_Click(object sender, RoutedEventArgs e)
        {
            // Вынести в вм, как команду и биндить на ErrorMessage
            var db = new TrelloDataClassesDataContext(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            if (db.DatabaseExists())
            {
                db.DeleteDatabase();
                // ErrorMessage
                //MessageBox.Show("База даних вже створена. Видаляємо! Можете продовжувати роботу.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            db.CreateDatabase();
        }

        private void ThemesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, "/Views/ResourcesTrello/Themes/", null);
        }

        private void LanguagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxUtils.HandleSelectionChanged(sender, e, null, "/Views/ResourcesTrello/Languages/");
        }
    }
}
