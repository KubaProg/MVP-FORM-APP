using System;
using System.Windows.Forms;
using MVPForm.Presenter;
using MVPForm.View;

namespace WinFormsApp1
{
    public partial class Form1 : Form, IEmployee
    {
        private EmployeePresenter _presenter;

        public Form1()
        {
            InitializeComponent();
            this._presenter = new EmployeePresenter(this);
        }

        public string descriptionText { get => dText.Text; set => dText.Text = value; }

        public event EventHandler SaveAttempted;

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            SaveAttempted?.Invoke(this, EventArgs.Empty);
            listBox.Items.Add("CHUJ");
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            descriptionText = listBox.SelectedItem.ToString();
        }
    }
}
