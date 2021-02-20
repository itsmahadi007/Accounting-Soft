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


namespace Accounting_Soft
{
    /// <summary>
    /// Interaction logic for log_reg_page.xaml
    /// </summary>
    public partial class log_reg_page : Window
    {
        public log_reg_page()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void drag_window(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void username_textbox_Gotfocus(object sender, RoutedEventArgs e)
        {
            if (username_textbox.Text == "User Name ")
            {
                username_textbox.Text = "";
            }
        }

        private void password_passbox_Gotfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (password_passbox.Password == "Password ")
            {
                password_passbox.Password = "";
            }
        }

        private void new_username_textbox_Getfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(new_username_textbox.Text == "Name")
            {
                new_username_textbox.Text = "";
            }
        }

        private void new_email_textbox_Getfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_email_textbox.Text == "Email")
            {
                new_email_textbox.Text = "";
            }
        }

        private void new_number_textbox_Getfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_number_textbox.Text == "Number")
            {
                new_number_textbox.Text = "";
            }
        }

        private void new_password_textbox_Getfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(new_password_textbox.Text == "Enter Password ")
            {
                new_password_textbox.Text = "";
            }
        }

        private void new_re_password_textbox_Getfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(new_re_password_textbox.Text == "Again Enter Password ")
            {
                new_re_password_textbox.Text = "";
            }
        }



    }
}
