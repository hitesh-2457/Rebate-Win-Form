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
        Boolean EditMode = false;
        DateTime? FirstNameTxtBx_FirstKeyPress = null;
        DateTime SaveClick = new DateTime();
        public Form1()
        {
            InitializeComponent();
            DateReceivedPicker.MaxDate = DateTime.Today;
            BindObject(new Model());
            ModifyBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            DataListView.Focus();
        }

        private void BindObject(Model model)
        {
            EditMode = false;
            AddBtn.Text = "Add New";

            FirstNameTxtBx.Text = model.FirstName;
            InitialTxtBx.Text = model.Initial;
            LastNameTxtBx.Text = model.LastName;
            GenderComboBx.Text = model.Gender.ToString();
            PhoneNumberTxtBx.Text = model.PhoneNumber;
            EMailTxtBx.Text = model.EMail;
            Address1TxtBx.Text = model.Address1;
            Address2TxtBx.Text = model.Address2;
            CityTxtBx.Text = model.City;
            StateTxtBx.Text = model.State;
            ZipCodeTxtBx.Text = model.ZipCode;
            DateReceivedPicker.Value = DateTime.Today;
            ProofComboBx.Text = model.ProofAttached;
            bsCount = 0;
            FirstNameTxtBx_FirstKeyPress = null;
        }

        private void FetchData(out Model entry)
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
            model.NoBackSpace = bsCount;
            model.TimeFirstChar = FirstNameTxtBx_FirstKeyPress??model.TimeFirstChar;
            model.TimeSaved = SaveClick;

            entry = model;
        }

        private void FeildKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                bsCount++;
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
            DataListView.Items.Add(item);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SaveClick = DateTime.Now;

            if (!validateForm())
                return;
            
            if (EditMode)
            {
                var selectedItem = DataListView.Items[DataListView.SelectedIndices[0]];
                Model updatedEntry = selectedItem.Tag as Model;
                FetchData(out updatedEntry);
                
                selectedItem.Tag = updatedEntry;
                selectedItem.SubItems[0].Text = updatedEntry.FirstName;
                selectedItem.SubItems[1].Text = updatedEntry.LastName;
                selectedItem.SubItems[2].Text = updatedEntry.PhoneNumber;
                DataListView.Refresh();
                BindObject(new Model());
            }
            else
            {
                Model newEntry = new Model();
                FetchData(out newEntry);
                AddToListView(newEntry);
                BindObject(new Model());
            }

            DataListView.Focus();
        }

        private Boolean validateForm()
        {
            var valid = true;
            foreach (Control control in detailsGrp.Controls)
            {
                // Set focus on control
                control.Focus();
                // Validate causes the control's Validating event to be fired,
                // if CausesValidation is True
                if (!Validate())
                {
                    errorProvider.SetError(control, "Invalid Entry for this field.");
                    AddBtn.Enabled = false;
                    valid = false;
                }
            }
            foreach (Control control in addrGrp.Controls)
            {
                // Set focus on control
                control.Focus();
                // Validate causes the control's Validating event to be fired,
                // if CausesValidation is True
                if (!Validate())
                {
                    errorProvider.SetError(control, "Invalid Entry for this field.");
                    AddBtn.Enabled = false;
                    valid = false;
                }
            }
            foreach (Control control in rebateDetailGrp.Controls)
            {
                // Set focus on control
                control.Focus();
                // Validate causes the control's Validating event to be fired,
                // if CausesValidation is True
                if (!Validate())
                {
                    errorProvider.SetError(control, "Invalid Entry for this field.");
                    AddBtn.Enabled = false;
                    valid = false;
                }
            }
            return valid;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            BindObject(new Model());
            DataListView.Focus();
            errorProvider = new ErrorProvider(splitContainer.GetContainerControl() as ContainerControl);
        }

        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            BindSelectedData();
        }

        private void ListData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataListView.SelectedIndices.Count > 0)
            {
                ModifyBtn.Enabled = true;
                DeleteBtn.Enabled = true;
            }
            else
            {
                ModifyBtn.Enabled = false;
                DeleteBtn.Enabled = false;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DataListView.Items.RemoveAt(DataListView.SelectedIndices[0]);
            DataListView.Refresh();
        }

        private void TxtBx_Validating(object sender, CancelEventArgs e)
        {
            var txtBx = sender as TextBox;
            var cancel = false;
            if (txtBx.Text.Length <= 0)
            {
                errorProvider.SetError(txtBx, "This Feild is Required.");
                cancel = true;
            }
            e.Cancel = cancel;
            AddBtn.Enabled = !cancel;
        }

        private void ComboBx_Validating(object sender, CancelEventArgs e)
        {
            var cmbBx = sender as ComboBox;
            var cancel = false;
            if (cmbBx.Text.Length <= 0)
            {
                errorProvider.SetError(cmbBx, "This Feild is Required.");
                cancel = true;
            }
            else if (!cmbBx.Items.Contains(cmbBx.Text))
            {
                errorProvider.SetError(cmbBx, "Invalid Feild Data");
                cancel = true;
            }
            e.Cancel = cancel;
            AddBtn.Enabled = !cancel;
        }

        private void TxtBx_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.errorProvider.SetError(sender as TextBox, string.Empty);
            AddBtn.Enabled = true;
        }

        private void ComboBx_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.errorProvider.SetError(sender as ComboBox, string.Empty);
            AddBtn.Enabled = true;
        }

        private void GenderComboBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            var keyPressed = Char.ToUpper(e.KeyChar);
            if (keyPressed == 'M' || keyPressed == 'F')
            {
                GenderComboBx.SelectedItem = keyPressed;
                GenderComboBx.Text = keyPressed.ToString();
            }
            else
            {
                errorProvider.SetError(sender as ComboBox, "Invalid Data in this Field.");
                AddBtn.Enabled = false;
            }
        }

        private void ProofComboBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            var keyPressed = Char.ToUpper(e.KeyChar);
            if (keyPressed != 'Y' || keyPressed != 'N')
            {
                errorProvider.SetError(sender as ComboBox, "Invalid Data in this Field.");
                AddBtn.Enabled = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            var dataList = new List<Model>();
            ListView.ListViewItemCollection items = DataListView.Items;
            foreach (ListViewItem item in items)
            {
                dataList.Add(item.Tag as Model);
            }
            var dataParser = new DataParser();
            dataParser.writeFile(dataList);
            Application.Exit();
        }

        private void DataListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BindSelectedData();
        }

        private void BindSelectedData()
        {
            BindObject(DataListView.SelectedItems[0].Tag as Model);
            EditMode = true;
            AddBtn.Text = "Update";
            FirstNameTxtBx.Focus();

            errorProvider.SetError(FirstNameTxtBx, String.Empty);
        }

        private void FirstNameTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FirstNameTxtBx_FirstKeyPress == null) FirstNameTxtBx_FirstKeyPress = DateTime.Now;
        }
    }
}
