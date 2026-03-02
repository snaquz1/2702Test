using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Seleznev2502;

namespace Seleznev2702Test
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                try
                {
                    var user = context.Users.First(x => LoginTB.Text == x.Login);
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (user.Password == PasswordTB.Text)
                    {
                        Profile profile = new Profile(user);
                        profile.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            Registration registartion = new Registration();
            registartion.Show();
            this.Close();
        }
    }
}
