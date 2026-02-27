using Seleznev2502;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                    user.Gender = GenderCB.SelectedItem.ToString();
                    user.RoleName = RoleCB.SelectedItem.ToString();
                    user.PositionName = PositionCB.SelectedItem.ToString();
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("Пользователь успешно зарегестрирован", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    

                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
    }
}
