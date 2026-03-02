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
using Microsoft.Win32;
using Seleznev2502;
using System.IO;


namespace Seleznev2702Test
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private User CurrentUser;
        public Profile(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            if (user != null)
            {
                try
                {
                    var fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, user.AvatarPath);
                    Avatar.Source = new BitmapImage(new Uri(fullPath));
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                    Avatar.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "user_avatars/default.jpg"));
                }
                
                
                SurnameTBL.Text = user.Surname;
                NameTBL.Text = user.Name;
                PatronymicTBL.Text = user.Patronymic;
                GenderTBL.Text = user.Gender.ToString();
                AgeTBL.Text = user.Age.ToString();
                EmailTBL.Text = user.Email;
                RoleTBL.Text = user.RoleName.ToString();
                PositionTBL.Text = user.PositionName.ToString();
            }
            try
            {
                using (Context context = new Context())
                {
                    AllUsersDG.ItemsSource = context.Users.ToList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ChangeAvatarBtn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title="Выберите аватарку",
            };
            if (dlg.ShowDialog() != true)
            {
                return;
            }
            var ext = System.IO.Path.GetExtension(dlg.FileName).ToLowerInvariant();
            var allowed = new HashSet<string> { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };

            if (!allowed.Contains(ext))
            {
                MessageBox.Show("Можно загрузить только изображение (jpg/png/bmp/gif/webp).",
                    "Не картинка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            using (Context context = new Context())
            {
                var user = context.Users.First(u => u.Id == CurrentUser.Id);
                var appdir = AppDomain.CurrentDomain.BaseDirectory;
                var avatardir = System.IO.Path.Combine(appdir, "user_avatars");
                Directory.CreateDirectory(avatardir);

                var extension = System.IO.Path.GetExtension(dlg.FileName);
                var filename = $"user{CurrentUser.Id}avatar{extension}";

                var destFullPath = System.IO.Path.Combine(avatardir, filename);

                File.Copy(dlg.FileName, destFullPath, true);

                user.AvatarPath = System.IO.Path.Combine("user_avatars", filename);
                context.SaveChanges();
                Avatar.Source = Avatar.Source = new BitmapImage(new Uri(destFullPath));
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        
    }
}
