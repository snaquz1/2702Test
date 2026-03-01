using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Seleznev2502;

namespace Seleznev2702Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



            //using (Context context = new Context())
            //{
            //    Role role = new Role();
            //    role.NameRole = "Admin";
            //    role.Description = "Администратор приложения";

            //    Role role1 = new Role();
            //    role1.NameRole = "User";


            //    Position position = new Position();
            //    position.NamePosition = "Стажер";
            //    position.Description = "Проходит стажировку за бесплатно";


            //    context.Roles.Add(role1);
            //    context.Roles.Add(role);
            //    context.Positions.Add(position);


            //    context.SaveChanges();
            //}

            using (Context context = new Context())
            {
                
                var roles = context.Roles.ToList();
                for (int i = 0; i < roles.Count; i++)
                {
                    RoleCB.Items.Add(roles[i].NameRole);
                }
                var positions = context.Positions.ToList();
                for (int i = 0; i < positions.Count; i++)
                {
                    PositionCB.Items.Add(positions[i].NamePosition);
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {

                var user = new User();
                try
                {
                    int.TryParse(AgeTB.Text, out int age);
                    user.Name = NameTB.Text;
                    user.Surname = SurnameNameTB.Text;
                    user.Patronymic = PatronymicTB.Text;
                    if (age <= 0 | age > 120)
                    {
                        MessageBox.Show("Ошибка возраста", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    user.Age = age;
                    user.Login = LoginTB.Text;
                    if (PasswordPB.Password == PasswordPB2.Password)
                    {
                        user.Password = PasswordPB.Password;
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    user.Email = EmailTB.Text;
                    if (GenderCB.SelectedItem != null)
                    {
                        user.Gender = GenderCB.SelectedValue.ToString();
                    }
                    if (RoleCB.SelectedItem != null)
                    {
                        user.RoleName = RoleCB.SelectedValue.ToString();
                    }
                    if (PositionCB.SelectedItem != null)
                    {
                        user.PositionName = PositionCB.SelectedValue.ToString();
                    }
                    
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("Пользователь успешно зарегестрирован", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Profile profile = new Profile(user);
                    profile.Show();
                    this.Close();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
