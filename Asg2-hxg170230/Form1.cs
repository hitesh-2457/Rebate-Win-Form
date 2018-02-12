using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asg2_hxg170230
{
    /// <summary>
    /// Rebate Form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
        // Global variables to hold the state and one time event data of the form
        DateTime? FirstNameTxtBx_FirstKeyPress = null;
        DateTime SaveClick = new DateTime();
        int bsCount = 0;

        /// <summary>
        /// The List of all the entries read from the file
        /// </summary>
        List<Model> EntryList;
        /// <summary>
        /// Flag to decide the mode of the form (Add or Edit Mode)
        /// </summary>
        Boolean EditMode = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            DateReceivedPicker.MaxDate = DateTime.Today;
            BindObject(new Model());
            ModifyBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            FirstNameTxtBx.Focus();
            updateStatusBar("");
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            EntryList = new DataParser().parseFile();
            foreach (var entry in EntryList)
            {
                AddToListView(entry);
            }
        }

        /// <summary>
        /// Binds the object.
        /// Binds the data to respective fields
        /// </summary>
        /// <param name="model">The model.</param>
        private void BindObject(Model model)
        {
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
            if (!EditMode)
            {
                bsCount = 0;
                FirstNameTxtBx_FirstKeyPress = null;
            }
            else
            {
                bsCount = model.NoBackSpace;
                FirstNameTxtBx_FirstKeyPress = model.TimeFirstChar;
                SaveClick = model.TimeSaved;
            }

            EditMode = false;
            AddBtn.Text = "Add New";
        }

        /// <summary>
        /// Fetches the data from feilds and assign them to the appropriate object.
        /// </summary>
        /// <param name="entry">The entry.</param>
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
            model.ZipCode = ZipCodeTxtBx.Text.Remove(5, 1).Trim();
            model.DateReceived = DateReceivedPicker.Value;
            model.ProofAttached = ProofComboBx.Text.ToString();
            // The time saved, time of first char and number of backspaces 
            // has to be recorded only on addition.
            if (!EditMode)
            {
                model.NoBackSpace = bsCount;
                model.TimeFirstChar = FirstNameTxtBx_FirstKeyPress ?? model.TimeFirstChar;
                model.TimeSaved = SaveClick;
            }
            entry = model;
        }

        /// <summary>
        /// Adds object to ListView.
        /// </summary>
        /// <param name="model">The model.</param>
        private void AddToListView(Model model)
        {
            ListViewItem item = new ListViewItem(new String[] { model.FirstName, model.LastName, model.PhoneNumber });
            item.Tag = model;
            DataListView.Items.Add(item);
        }

        /// <summary>
        /// Handles the Click event of the AddBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            SaveClick = DateTime.Now;

            // check for duplicates before adding to the list
            if (!EditMode && CheckDuplicate())
            {
                AddBtn.Text = "Update";
                EditMode = true;
                return;
            }

            // validate the form data
            if (!validateForm())
            {
                updateStatusBar("Form has Errors, Pleas fix them to continue.");
                return;
            }

            // update on edit
            if (EditMode)
            {
                var selectedItem = DataListView.Items[DataListView.SelectedIndices[0]];
                Model oldEntry = selectedItem.Tag as Model;
                Model newEntry = new Model();
                FetchData(out newEntry);
                newEntry.NoBackSpace = oldEntry.NoBackSpace;
                newEntry.TimeSaved = oldEntry.TimeSaved;
                newEntry.TimeFirstChar = oldEntry.TimeFirstChar;

                selectedItem.Tag = newEntry;
                selectedItem.SubItems[0].Text = newEntry.FirstName;
                selectedItem.SubItems[1].Text = newEntry.LastName;
                selectedItem.SubItems[2].Text = newEntry.PhoneNumber;
                DataListView.Refresh();
                updateStatusBar("Updated Entry with First Name: " + newEntry.FirstName);
                BindObject(new Model());
            }
            // add on new 
            else
            {
                Model newEntry = new Model();
                FetchData(out newEntry);
                AddToListView(newEntry);
                updateStatusBar("Added a new Entry with First Name: " + newEntry.FirstName);
                BindObject(new Model());
            }

            FirstNameTxtBx.Focus();
        }

        // function to validate the form
        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns><see cref="Boolean"/> indicating the success or failure of form validation.</returns>
        private Boolean validateForm()
        {
            var valid = true;
            // list of GroupBox controls
            var ctrls = new List<Control.ControlCollection>() { detailsGrp.Controls, addrGrp.Controls, rebateDetailGrp.Controls };
            // iterate on all the GroupBoxes
            foreach (var ctrl in ctrls)
            {
                // iterate all the controls in each of the groups
                foreach (Control control in ctrl)
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
            }
            return valid;
        }

        /// <summary>
        /// Handles the Click event of the ClearBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            BindObject(new Model());
            errorProvider.Clear();
            AddBtn.Enabled = true;
            updateStatusBar("");
        }

        /// <summary>
        /// Handles the Click event of the ModifyBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            BindSelectedData();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the DataListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void DataListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BindSelectedData();
        }

        /// <summary>
        /// Binds the selected item from the list to the form fields.
        /// </summary>
        private void BindSelectedData()
        {
            BindObject(DataListView.SelectedItems[0].Tag as Model);
            EditMode = true;
            AddBtn.Text = "Update";
            updateStatusBar("Updating Entry with First Name: " + FirstNameTxtBx.Text);
            FirstNameTxtBx.Focus();
            DeleteBtn.Enabled = false;

            // reset all the errors raised by error provider
            errorProvider.SetError(FirstNameTxtBx, String.Empty);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ListData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the DeleteBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var firstName = (DataListView.SelectedItems[0].Tag as Model).FirstName;
            DataListView.Items.RemoveAt(DataListView.SelectedIndices[0]);
            DataListView.Refresh();
            updateStatusBar("Deleted the entry with First Name: " + firstName);
        }

        /// <summary>
        /// Handles the Validating event of the TxtBx control, Makes sure the field has data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Validated event of the TxtBx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TxtBx_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.errorProvider.SetError(sender as TextBox, string.Empty);
            AddBtn.Enabled = true;
        }

        /// <summary>
        /// Handles the Validating event of the MskBx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void MskBx_Validating(object sender, CancelEventArgs e)
        {
            var txtBx = sender as MaskedTextBox;
            var cancel = false;
            if (txtBx.Text.Remove(5, 1).Trim().Length <= 0)
            {
                errorProvider.SetError(txtBx, "This Feild is Required.");
                cancel = true;
            }
            e.Cancel = cancel;
            AddBtn.Enabled = !cancel;
        }

        /// <summary>
        /// Handles the Validated event of the MskBx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MskBx_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.errorProvider.SetError(sender as MaskedTextBox, string.Empty);
            AddBtn.Enabled = true;
        }

        /// <summary>
        /// Handles the Validating event of the ComboBx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void ComboBx_Validating(object sender, CancelEventArgs e)
        {
            var cmbBx = sender as ComboBox;
            var cancel = false;
            // The ComboBox is empty.
            if (cmbBx.Text.Length <= 0)
            {
                errorProvider.SetError(cmbBx, "This Feild is Required.");
                cancel = true;
            }
            // check if the entered value is in the list of possible values
            else if (!cmbBx.Items.Contains(cmbBx.Text))
            {
                errorProvider.SetError(cmbBx, "Invalid Feild Data");
                cancel = true;
            }
            e.Cancel = cancel;
            AddBtn.Enabled = !cancel;
        }

        /// <summary>
        /// Handles the Validated event of the ComboBx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ComboBx_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.errorProvider.SetError(sender as ComboBox, string.Empty);
            AddBtn.Enabled = true;
        }

        /// <summary>
        /// Handles the KeyPress event of the GenderComboBx control, and keeps the data in upper case.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void GenderComboBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBackspaces(sender, e);
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

        /// <summary>
        /// Handles the KeyPress event of the ProofComboBx control, and keep the data in upper case.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void ProofComboBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBackspaces(sender, e);
            var keyPressed = Char.ToUpper(e.KeyChar);
            e.KeyChar = keyPressed;
            if (keyPressed != 'Y' || keyPressed != 'N' || keyPressed != '\b')
            {
                errorProvider.SetError(sender as ComboBox, "Invalid Data in this Field.");
                AddBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Validating event of the EMailTxtBx control, with regex.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void EMailTxtBx_Validating(object sender, CancelEventArgs e)
        {
            TxtBx_Validating(sender, e);
            var reg = @"^([a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{3,})$";
            var emailTxtBx = sender as TextBox;
            if (!Regex.Match(emailTxtBx.Text, reg).Success)
            {
                errorProvider.SetError(emailTxtBx, "Invalid Data in this Field.");
                e.Cancel = true;
                AddBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Checks for duplicates.
        /// </summary>
        /// <returns></returns>
        private Boolean CheckDuplicate()
        {
            var firstName = FirstNameTxtBx.Text;
            var lastName = LastNameTxtBx.Text;
            var phoneNumber = PhoneNumberTxtBx.Text;

            foreach (ListViewItem item in DataListView.Items)
            {
                var dataObj = item.Tag as Model;
                if (dataObj.FirstName.Equals(firstName)
                    && dataObj.LastName.Equals(lastName)
                    && dataObj.PhoneNumber.Equals(phoneNumber))
                {
                    updateStatusBar("Found a entry with same details. " +
                        "Updating Entry with First Name: " + firstName +
                        " Click Update to continue update.");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks the number key press, and make sure only numbers are inputed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void CheckNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBackspaces(sender, e);
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Checks the character key press, make sure only characters are inputed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void CheckCharKeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBackspaces(sender, e);
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Updates the status bar.
        /// </summary>
        /// <param name="message">The message.</param>
        private void updateStatusBar(String message = "")
        {
            statusLabel.Text = message;
        }

        /// <summary>
        /// Handles the KeyPress event of the FirstNameTxtBx control.
        /// Records the time of first char on the first feild.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void FirstNameTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBackspaces(sender, e);
            if (FirstNameTxtBx_FirstKeyPress == null) FirstNameTxtBx_FirstKeyPress = DateTime.Now;
        }

        /// <summary>
        /// Checks the backspaces.
        /// Records number of backspaces used.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void CheckBackspaces(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                bsCount++;
        }

        /// <summary>
        /// Handles the FormClosing event of the Form1 control.
        /// Save all the data on form close.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateStatusBar("Updating the Data file, Please Wait...");
            AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            var dataList = new List<Model>();
            ListView.ListViewItemCollection items = DataListView.Items;
            foreach (ListViewItem item in items)
            {
                dataList.Add(item.Tag as Model);
            }
            var dataParser = new DataParser();
            dataParser.writeFile(dataList);
            updateStatusBar("Updated the Data file, Exiting Application.");
            Application.Exit();
        }
    }
}
