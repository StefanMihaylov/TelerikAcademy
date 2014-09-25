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
using System.Windows.Threading;

using MongoChat.Data;
using MongoChat.Model;
using MongoDB.Driver;

namespace MongoChat.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string MongoUrl = "mongodb://Student:Student@ds035260.mongolab.com:35260/telerik-academy";
        public const string MongoDatabaseName = "telerik-academy";

        private Chat chat;

        public MainWindow()
        {
            InitializeComponent();

            this.chat = new Chat(MongoUrl, MongoDatabaseName);

            // http://www.c-sharpcorner.com/uploadfile/mahesh/timer-in-wpf/
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            PostsSelection.Visibility = Visibility.Hidden;
        }

        public string Username { get; private set; }
        public DateTime LoginDate { get; private set; }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            ICollection<ChatPost> posts;

            if (PostsSelection.SelectedIndex == 0)
            {
                posts = chat.GetAllPost();
            }
            else
            {
                posts = chat.GetLatestPost(this.LoginDate);
            }

            var messages = posts.Select(m => string.Format("[ {0} ] {1} : {2}", m.Date.ToString("hh:mm:ss"), m.User, m.Message));

            ListBoxMessages.Items.Clear();
            foreach (var message in messages)
            {
                ListBoxMessages.Items.Add(message);
            }

            CommandManager.InvalidateRequerySuggested();
            ListBoxMessages.Items.MoveCurrentToLast();
            ListBoxMessages.SelectedItem = ListBoxMessages.Items.CurrentItem;
            ListBoxMessages.ScrollIntoView(ListBoxMessages.Items.CurrentItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Username))
            {
                var user = TextBoxUserName.Text;
                if (!string.IsNullOrWhiteSpace(user))
                {
                    this.Username = user;
                    TextBoxUserName.Text = "";
                    LoginBtn.Content = "Logout";
                    WelcomeText.Content = string.Format("Welcome, {0}!", user);
                    TextBoxUserName.Visibility = Visibility.Hidden;
                    this.LoginDate = DateTime.Now.ToUniversalTime();
                    PostsSelection.Visibility = Visibility.Visible;
                }
            }
            else
            {
                this.Username = null;
                LoginBtn.Content = "Login";
                WelcomeText.Content = string.Format("Enter your name: ");
                TextBoxUserName.Visibility = Visibility.Visible;
                PostsSelection.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = TextBoxNewMessage.Text;
            if (this.Username != null && !string.IsNullOrWhiteSpace(message))
            {
                chat.AddPost(this.Username, message);
                TextBoxNewMessage.Text = "";
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
