namespace Accounting_Soft
{
    using Accounting_Soft.ChildForms;
    using System;
    using System.Windows.Forms;

    public partial class mainform_form : Form
    {
        private Form currentChildForm;

        public mainform_form()
        {
            InitializeComponent();
            OpenChildForm(new home_form());
        }

        private void OpenChildForm(Form childForm)
        {

            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Payments_page(object sender, EventArgs e)
        {
            OpenChildForm(new payments_form());
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new home_form());
        }

        private void PosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new pos_form());
        }

        private void InventryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new inventory_form());
        }

        private void AccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new account_form());
        }

        private void MiscellaneousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new miscellaneous_form());
        }

        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new profile_form());
        }

        private void CompanyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new companyProfile_form());
        }

        private void BankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new bankAccounts_form());
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new setting_form());
        }

        private void ToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new tools_form());
        }

        private void AboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new aboutUs_form());
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log_reg_page objMain = new log_reg_page();
            this.Hide();
            objMain.Show();
        }
    }
}
