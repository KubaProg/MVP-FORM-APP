using System;
using System.Collections.Generic;
using System.Linq;
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
        public string _name { get => name.Text; set => name.Text = value; }
        public string _surname { get => surname.Text; set => surname.Text = value; }
        public string _date { get => date.Text; set => date.Text = value; }
        public string _salary { get => salary.Text; set => salary.Text = value; }
        public string _occupation { get => occupation.Text; set => occupation.Text = value; }
        public string _currentLine { get => listBox.SelectedItem.ToString(); set => salary.Text = salary.Text; }
        public List<String> _listBox { get => listBox.Items.Cast<string>().ToList(); set => listBox.Items.Add(value); }

        public List<string> ListBoxData
        {
            get => listBox.Items.Cast<string>().ToList();
            set
            {
                listBox.Items.Clear();
                if (value != null)
                {
                    listBox.Items.AddRange(value.ToArray());
                }
            }
        }



        public bool _one { get => one.Checked; set => one.Checked = value; }
        public bool _two { get => two.Checked; set => two.Checked = value; }
        public bool _three { get => three.Checked; set => three.Checked = value; }
        

        public event EventHandler Save;
        public event EventHandler Add;
        public event EventHandler Load;
        public event EventHandler Fill;

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save?.Invoke(this, EventArgs.Empty);  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add?.Invoke(this, EventArgs.Empty);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Load?.Invoke(this, EventArgs.Empty);
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill?.Invoke(this, EventArgs.Empty);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
