namespace Accounting_Soft
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;
    using System.Windows.Input;

    public partial class log_reg_page : Window
    {
        internal SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Accounting_DB.mdf;Integrated Security=True;Connect Timeout=30");

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
            if (new_username_textbox.Text == "Name")
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
            if (new_password_textbox.Text == "Enter Password ")
            {
                new_password_textbox.Text = "";
            }
        }

        private void new_re_password_textbox_Getfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_re_password_textbox.Text == "Again Enter Password ")
            {
                new_re_password_textbox.Text = "";
            }
        }

        private void btn_login(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter(@"select * from userac where Name='" + username_textbox.Text + "' and Password ='" + password_passbox.Password + "'", sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                MainWindow objMain = new MainWindow();
                this.Hide();
                objMain.Show();
            }
            else
            {
                MessageBox.Show("Incorrect User Name Passward");
            }
        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
           /* int a = 0;
            a = new_username_textbox.SelectionLength;
            int b = 0;
            b = new_password_textbox.SelectionLength;
            if (a > 0 && b > 0)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Login.mdf;Integrated Security=True;Connect Timeout=30");
                sqlcon.Open();
                SqlDataAdapter data = new SqlDataAdapter("INSERT INTO login (Name,Password) VALUES('" + Names.Text + "','" + Passwords.Text + "');", sqlcon);
                data.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Created");
                sqlcon.Close();
                Login objlo = new Login();
                this.Hide();
                objlo.Show();
            }
            else
            {
                MessageBox.Show("Insert Value First");
            }*/
        }
    }
}
