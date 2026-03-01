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

namespace Seleznev2702Test
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile(User user)
        {
            InitializeComponent();
            if (user != null)
            {
                SurnameTBL.Text = user.Surname;
                NameTBL.Text = user.Name;
                PatronymicTBL.Text = user.Patronymic;
                GenderTBL.Text = user.Gender.ToString();
                AgeTBL.Text = user.Age.ToString();
                EmailTBL.Text = user.Email;
                RoleTBL.Text = user.RoleName.ToString();
                PositionTBL.Text = user.PositionName.ToString();
            }
        }
    }
}
