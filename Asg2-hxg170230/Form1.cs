using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asg2_hxg170230
{
    public partial class Form1 : Form
    {
        int bsCount = 0;
        List<Model> EntryList;
        public Form1()
        {
            InitializeComponent();
            DateReceivedPicker.MaxDate = DateTime.Today;
            BindObject(new Model());
        }

        private void BindObject(Model model)
        {
            FirstNameTxtBx.Text = model.FirstName;
            InitialTxtBx.Text = model.Initial;
            LastNameTxtBx.Text = model.LastName;
            GenderComboBx.SelectedValue = model.Gender.ToString();
            PhoneNumberTxtBx.Text = model.PhoneNumber;
            EMailTxtBx.Text = model.EMail;
            Address1TxtBx.Text = model.Address1;
            Address2TxtBx.Text = model.Address2;
            CityTxtBx.Text = model.City;
            StateTxtBx.Text = model.State;
            ZipCodeTxtBx.Text = model.ZipCode;
            DateReceivedPicker.Value = DateTime.Today;
            ProofComboBx.SelectedValue = model.ProofAttached;
        }

        private Model FetchData()
        {
            Model model = new Model();
            model.FirstName = FirstNameTxtBx.Text;
            model.Initial = InitialTxtBx.Text;
            model.LastName = LastNameTxtBx.Text;
            model.Gender = GenderComboBx.Text.ToString()[0];
            model.PhoneNumber = PhoneNumberTxtBx.Text;
            model.EMail = EMailTxtBx.Text;
            model.Address1 = Address1TxtBx.Text;
            model.Address2 = Address2TxtBx.Text;
            model.City = CityTxtBx.Text;
            model.State = StateTxtBx.Text;
            model.ZipCode = ZipCodeTxtBx.Text;
            model.DateReceived = DateReceivedPicker.Value;
            model.ProofAttached = ProofComboBx.Text.ToString();
            return model;
        }

        private void FeildKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EntryList = new DataParser().parseFile();
            foreach (var entry in EntryList)
            {
                AddToListView(entry);
            }
        }

        private void AddToListView(Model model)
        {
            ListViewItem item = new ListViewItem(new String[] { model.FirstName, model.LastName, model.PhoneNumber });
            item.Tag = model;
            ListData.Items.Add(item);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddToListView(FetchData());
            BindObject(new Model());
        }
    }
}
