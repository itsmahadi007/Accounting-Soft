namespace Accounting_Soft
{
    using System;
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

        //Windows basic custom functions
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


        //Adjasting textbox behaviur  code starts here
        private void number_textbox_Gotfocus(object sender, RoutedEventArgs e)
        {
            
            if (number_textbox.Text == "Number")
            {
                number_textbox.Text = "";
            }
        }

        private void password_passbox_Gotfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (password_passbox.Password == "Password")
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
            if (new_password_textbox.Text == "Enter Password")
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
        private void number_textbox_lostfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (number_textbox.Text == "")
            {
                number_textbox.Text = "Number";
            }
        }

        private void password_passbox_lostfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (password_passbox.Password == "")
            {
                password_passbox.Password = "Password";
            }
        }

        private void new_username_textbox_lostfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_username_textbox.Text == "")
            {
                new_username_textbox.Text = "Name";
            }
        }

        private void new_email_textbox_lostfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_email_textbox.Text == "")
            {
                new_email_textbox.Text = "Email";
            }
        }

        private void new_number_textbox_lostfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_number_textbox.Text == "")
            {
                new_number_textbox.Text = "Number";
            }
        }

        private void new_password_textbox_lostfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_password_textbox.Text == "")
            {
                new_password_textbox.Text = "Enter Password";
            }
        }

        private void new_re_password_textboxnew_re_password_textbox_lostfocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_re_password_textbox.Text == "")
            {
                new_re_password_textbox.Text = "Again Enter Password ";
            }
        }
        //Adjasting textbox behaviur  code ends here




        private void btn_login(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter(@"select * from userac where Number='" + number_textbox.Text + "' and Password ='" + password_passbox.Password + "'", sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                mainform_form objMain = new mainform_form();
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
            string time;

            DateTime currentDateTime = DateTime.Now;
            time = currentDateTime.ToString();

            int n = new_username_textbox.Text.Length;
            int em = new_email_textbox.Text.Length;
            int num = new_number_textbox.Text.Length;
            int pa = new_password_textbox.Text.Length;
            int rpa = new_re_password_textbox.Text.Length;

            //SqlDataAdapter sda = new SqlDataAdapter(@"select Id from userac where Id = (SELECT max(Id) FROM userac)", sqlcon);
            //sda.Fill(id);


            if (n == 0)
            {
                MessageBox.Show("Name field is empty");
            }
            else if (em == 0)
            {
                MessageBox.Show("Email filed is empty");
            }
            else if (num == 0)
            {
                MessageBox.Show("Number filed is empty");
            }
            else if (pa == 0)
            {
                MessageBox.Show("Password filed is empty");

            }
            else if (rpa == 0)
            {
                MessageBox.Show("Re-Enter the password");
            }
            else if (pa != rpa)
            {
                MessageBox.Show("Password doesn't match");
            }
            else
            {
                //Checking phone number wheather it's existing or not
                SqlCommand cmd_num = new SqlCommand();
                cmd_num.CommandType = CommandType.Text;
                cmd_num.CommandText = "select Number from userac where Number ='" + new_number_textbox.Text + "'";
                cmd_num.Connection = sqlcon;

                sqlcon.Open();
                SqlDataReader num_db = cmd_num.ExecuteReader();
                

                if (num_db.HasRows)
                {
                    sqlcon.Close();
                    MessageBox.Show("This number is already used");
                }
                else
                {
                    sqlcon.Close();
                    //Taking ID  here
                    SqlCommand cmd_id = new SqlCommand();
                    cmd_id.CommandType = CommandType.Text;
                    cmd_id.CommandText = "select Id from userac where Id = (SELECT max(Id) FROM userac)";
                    cmd_id.Connection = sqlcon;
                    sqlcon.Open();
                    SqlDataReader dr = cmd_id.ExecuteReader();
                    dr.Read();
                    int id = dr.GetInt32(0) + 1;
                    sqlcon.Close();

                    //pushing data to the database
                    SqlCommand cmd_signup = new SqlCommand();
                    cmd_signup.CommandType = CommandType.Text;
                    cmd_signup.CommandText = "INSERT INTO userac (Id,Name,Email,Number,Password,time) VALUES('" + id + "','" + new_username_textbox.Text + "','" + new_email_textbox.Text + "','" + new_number_textbox.Text + "','" + new_password_textbox.Text + "','" + time + "');";
                    cmd_signup.Connection = sqlcon;
                    sqlcon.Open();
                    cmd_signup.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Successfully Created");
                }

            }
        }

        
    }
}
