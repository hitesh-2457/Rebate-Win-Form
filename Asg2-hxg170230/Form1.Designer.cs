﻿namespace Asg2_hxg170230
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.ModifyBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.DataListView = new System.Windows.Forms.ListView();
            this.colHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClearBtn = new System.Windows.Forms.Button();
            this.rebateDetailGrp = new System.Windows.Forms.GroupBox();
            this.ProofComboBx = new System.Windows.Forms.ComboBox();
            this.ProofLabel = new System.Windows.Forms.Label();
            this.DateReceivedLabel = new System.Windows.Forms.Label();
            this.DateReceivedPicker = new System.Windows.Forms.DateTimePicker();
            this.AddBtn = new System.Windows.Forms.Button();
            this.addrGrp = new System.Windows.Forms.GroupBox();
            this.ZipCodeTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.StateTxtBx = new System.Windows.Forms.TextBox();
            this.CityTxtBx = new System.Windows.Forms.TextBox();
            this.Address2TxtBx = new System.Windows.Forms.TextBox();
            this.CityLabel = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.Address1TxtBx = new System.Windows.Forms.TextBox();
            this.ZipCodeLabel = new System.Windows.Forms.Label();
            this.Addr2Label = new System.Windows.Forms.Label();
            this.Addr1Label = new System.Windows.Forms.Label();
            this.detailsGrp = new System.Windows.Forms.GroupBox();
            this.GenderComboBx = new System.Windows.Forms.ComboBox();
            this.EMailTxtBx = new System.Windows.Forms.TextBox();
            this.PhoneNumberTxtBx = new System.Windows.Forms.TextBox();
            this.FirstNameTxtBx = new System.Windows.Forms.TextBox();
            this.LastNameTxtBx = new System.Windows.Forms.TextBox();
            this.InitialTxtBx = new System.Windows.Forms.TextBox();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.InitialLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.EmailAddressLabel = new System.Windows.Forms.Label();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.rebateDetailGrp.SuspendLayout();
            this.addrGrp.SuspendLayout();
            this.detailsGrp.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.errorProvider.SetError(this.splitContainer, resources.GetString("splitContainer.Error"));
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.ModifyBtn);
            this.splitContainer.Panel1.Controls.Add(this.DeleteBtn);
            this.splitContainer.Panel1.Controls.Add(this.DataListView);
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.ClearBtn);
            this.splitContainer.Panel2.Controls.Add(this.rebateDetailGrp);
            this.splitContainer.Panel2.Controls.Add(this.AddBtn);
            this.splitContainer.Panel2.Controls.Add(this.addrGrp);
            this.splitContainer.Panel2.Controls.Add(this.detailsGrp);
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.TabStop = false;
            // 
            // ModifyBtn
            // 
            resources.ApplyResources(this.ModifyBtn, "ModifyBtn");
            this.ModifyBtn.Name = "ModifyBtn";
            this.ModifyBtn.UseVisualStyleBackColor = true;
            this.ModifyBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // DeleteBtn
            // 
            resources.ApplyResources(this.DeleteBtn, "DeleteBtn");
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // DataListView
            // 
            this.DataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeader1,
            this.colHeader2,
            this.colHeader3});
            this.DataListView.FullRowSelect = true;
            this.DataListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            resources.ApplyResources(this.DataListView, "DataListView");
            this.DataListView.MultiSelect = false;
            this.DataListView.Name = "DataListView";
            this.DataListView.UseCompatibleStateImageBehavior = false;
            this.DataListView.View = System.Windows.Forms.View.Details;
            this.DataListView.SelectedIndexChanged += new System.EventHandler(this.ListData_SelectedIndexChanged);
            this.DataListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataListView_MouseDoubleClick);
            // 
            // colHeader1
            // 
            resources.ApplyResources(this.colHeader1, "colHeader1");
            // 
            // colHeader2
            // 
            resources.ApplyResources(this.colHeader2, "colHeader2");
            // 
            // colHeader3
            // 
            resources.ApplyResources(this.colHeader3, "colHeader3");
            // 
            // ClearBtn
            // 
            resources.ApplyResources(this.ClearBtn, "ClearBtn");
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // rebateDetailGrp
            // 
            this.rebateDetailGrp.Controls.Add(this.ProofComboBx);
            this.rebateDetailGrp.Controls.Add(this.ProofLabel);
            this.rebateDetailGrp.Controls.Add(this.DateReceivedLabel);
            this.rebateDetailGrp.Controls.Add(this.DateReceivedPicker);
            resources.ApplyResources(this.rebateDetailGrp, "rebateDetailGrp");
            this.rebateDetailGrp.Name = "rebateDetailGrp";
            this.rebateDetailGrp.TabStop = false;
            // 
            // ProofComboBx
            // 
            this.ProofComboBx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ProofComboBx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ProofComboBx.FormattingEnabled = true;
            this.ProofComboBx.Items.AddRange(new object[] {
            resources.GetString("ProofComboBx.Items"),
            resources.GetString("ProofComboBx.Items1")});
            resources.ApplyResources(this.ProofComboBx, "ProofComboBx");
            this.ProofComboBx.Name = "ProofComboBx";
            this.ProofComboBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProofComboBx_KeyPress);
            this.ProofComboBx.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBx_Validating);
            this.ProofComboBx.Validated += new System.EventHandler(this.ComboBx_Validated);
            // 
            // ProofLabel
            // 
            resources.ApplyResources(this.ProofLabel, "ProofLabel");
            this.ProofLabel.Name = "ProofLabel";
            // 
            // DateReceivedLabel
            // 
            resources.ApplyResources(this.DateReceivedLabel, "DateReceivedLabel");
            this.DateReceivedLabel.Name = "DateReceivedLabel";
            // 
            // DateReceivedPicker
            // 
            this.DateReceivedPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.DateReceivedPicker, "DateReceivedPicker");
            this.DateReceivedPicker.Name = "DateReceivedPicker";
            this.DateReceivedPicker.Value = new System.DateTime(2018, 2, 5, 1, 42, 24, 0);
            this.DateReceivedPicker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckBackspaces);
            // 
            // AddBtn
            // 
            resources.ApplyResources(this.AddBtn, "AddBtn");
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // addrGrp
            // 
            this.addrGrp.Controls.Add(this.ZipCodeTxtBx);
            this.addrGrp.Controls.Add(this.StateTxtBx);
            this.addrGrp.Controls.Add(this.CityTxtBx);
            this.addrGrp.Controls.Add(this.Address2TxtBx);
            this.addrGrp.Controls.Add(this.CityLabel);
            this.addrGrp.Controls.Add(this.StateLabel);
            this.addrGrp.Controls.Add(this.Address1TxtBx);
            this.addrGrp.Controls.Add(this.ZipCodeLabel);
            this.addrGrp.Controls.Add(this.Addr2Label);
            this.addrGrp.Controls.Add(this.Addr1Label);
            resources.ApplyResources(this.addrGrp, "addrGrp");
            this.addrGrp.Name = "addrGrp";
            this.addrGrp.TabStop = false;
            // 
            // ZipCodeTxtBx
            // 
            resources.ApplyResources(this.ZipCodeTxtBx, "ZipCodeTxtBx");
            this.ZipCodeTxtBx.Name = "ZipCodeTxtBx";
            this.ZipCodeTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumberKeyPress);
            this.ZipCodeTxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.MskBx_Validating);
            this.ZipCodeTxtBx.Validated += new System.EventHandler(this.MskBx_Validated);
            // 
            // StateTxtBx
            // 
            this.StateTxtBx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.StateTxtBx, "StateTxtBx");
            this.StateTxtBx.Name = "StateTxtBx";
            this.StateTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharKeyPress);
            this.StateTxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBx_Validating);
            this.StateTxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // CityTxtBx
            // 
            resources.ApplyResources(this.CityTxtBx, "CityTxtBx");
            this.CityTxtBx.Name = "CityTxtBx";
            this.CityTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharKeyPress);
            this.CityTxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBx_Validating);
            this.CityTxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // Address2TxtBx
            // 
            resources.ApplyResources(this.Address2TxtBx, "Address2TxtBx");
            this.Address2TxtBx.Name = "Address2TxtBx";
            this.Address2TxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckBackspaces);
            this.Address2TxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBx_Validating);
            this.Address2TxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // CityLabel
            // 
            resources.ApplyResources(this.CityLabel, "CityLabel");
            this.CityLabel.Name = "CityLabel";
            // 
            // StateLabel
            // 
            resources.ApplyResources(this.StateLabel, "StateLabel");
            this.StateLabel.Name = "StateLabel";
            // 
            // Address1TxtBx
            // 
            resources.ApplyResources(this.Address1TxtBx, "Address1TxtBx");
            this.Address1TxtBx.Name = "Address1TxtBx";
            this.Address1TxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckBackspaces);
            this.Address1TxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBx_Validating);
            this.Address1TxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // ZipCodeLabel
            // 
            resources.ApplyResources(this.ZipCodeLabel, "ZipCodeLabel");
            this.ZipCodeLabel.Name = "ZipCodeLabel";
            // 
            // Addr2Label
            // 
            resources.ApplyResources(this.Addr2Label, "Addr2Label");
            this.Addr2Label.Name = "Addr2Label";
            // 
            // Addr1Label
            // 
            resources.ApplyResources(this.Addr1Label, "Addr1Label");
            this.Addr1Label.Name = "Addr1Label";
            // 
            // detailsGrp
            // 
            this.detailsGrp.Controls.Add(this.GenderComboBx);
            this.detailsGrp.Controls.Add(this.EMailTxtBx);
            this.detailsGrp.Controls.Add(this.PhoneNumberTxtBx);
            this.detailsGrp.Controls.Add(this.FirstNameTxtBx);
            this.detailsGrp.Controls.Add(this.LastNameTxtBx);
            this.detailsGrp.Controls.Add(this.InitialTxtBx);
            this.detailsGrp.Controls.Add(this.GenderLabel);
            this.detailsGrp.Controls.Add(this.InitialLabel);
            this.detailsGrp.Controls.Add(this.LastNameLabel);
            this.detailsGrp.Controls.Add(this.EmailAddressLabel);
            this.detailsGrp.Controls.Add(this.PhoneNumberLabel);
            this.detailsGrp.Controls.Add(this.FirstNameLabel);
            resources.ApplyResources(this.detailsGrp, "detailsGrp");
            this.detailsGrp.Name = "detailsGrp";
            this.detailsGrp.TabStop = false;
            // 
            // GenderComboBx
            // 
            this.GenderComboBx.FormattingEnabled = true;
            this.GenderComboBx.Items.AddRange(new object[] {
            resources.GetString("GenderComboBx.Items"),
            resources.GetString("GenderComboBx.Items1")});
            resources.ApplyResources(this.GenderComboBx, "GenderComboBx");
            this.GenderComboBx.Name = "GenderComboBx";
            this.GenderComboBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GenderComboBx_KeyPress);
            this.GenderComboBx.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBx_Validating);
            this.GenderComboBx.Validated += new System.EventHandler(this.ComboBx_Validated);
            // 
            // EMailTxtBx
            // 
            resources.ApplyResources(this.EMailTxtBx, "EMailTxtBx");
            this.EMailTxtBx.Name = "EMailTxtBx";
            this.EMailTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckBackspaces);
            this.EMailTxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.EMailTxtBx_Validating);
            this.EMailTxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // PhoneNumberTxtBx
            // 
            resources.ApplyResources(this.PhoneNumberTxtBx, "PhoneNumberTxtBx");
            this.PhoneNumberTxtBx.Name = "PhoneNumberTxtBx";
            this.PhoneNumberTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckNumberKeyPress);
            this.PhoneNumberTxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBx_Validating);
            this.PhoneNumberTxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // FirstNameTxtBx
            // 
            resources.ApplyResources(this.FirstNameTxtBx, "FirstNameTxtBx");
            this.FirstNameTxtBx.Name = "FirstNameTxtBx";
            this.FirstNameTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstNameTxtBx_KeyPress);
            this.FirstNameTxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBx_Validating);
            this.FirstNameTxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // LastNameTxtBx
            // 
            resources.ApplyResources(this.LastNameTxtBx, "LastNameTxtBx");
            this.LastNameTxtBx.Name = "LastNameTxtBx";
            this.LastNameTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckBackspaces);
            this.LastNameTxtBx.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBx_Validating);
            this.LastNameTxtBx.Validated += new System.EventHandler(this.TxtBx_Validated);
            // 
            // InitialTxtBx
            // 
            resources.ApplyResources(this.InitialTxtBx, "InitialTxtBx");
            this.InitialTxtBx.Name = "InitialTxtBx";
            this.InitialTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckBackspaces);
            // 
            // GenderLabel
            // 
            resources.ApplyResources(this.GenderLabel, "GenderLabel");
            this.GenderLabel.Name = "GenderLabel";
            // 
            // InitialLabel
            // 
            resources.ApplyResources(this.InitialLabel, "InitialLabel");
            this.InitialLabel.Name = "InitialLabel";
            // 
            // LastNameLabel
            // 
            resources.ApplyResources(this.LastNameLabel, "LastNameLabel");
            this.LastNameLabel.Name = "LastNameLabel";
            // 
            // EmailAddressLabel
            // 
            resources.ApplyResources(this.EmailAddressLabel, "EmailAddressLabel");
            this.EmailAddressLabel.Name = "EmailAddressLabel";
            // 
            // PhoneNumberLabel
            // 
            resources.ApplyResources(this.PhoneNumberLabel, "PhoneNumberLabel");
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            // 
            // FirstNameLabel
            // 
            resources.ApplyResources(this.FirstNameLabel, "FirstNameLabel");
            this.FirstNameLabel.Name = "FirstNameLabel";
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.SizingGrip = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this.splitContainer;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CausesValidation = false;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.StatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Tag = "form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.rebateDetailGrp.ResumeLayout(false);
            this.rebateDetailGrp.PerformLayout();
            this.addrGrp.ResumeLayout(false);
            this.addrGrp.PerformLayout();
            this.detailsGrp.ResumeLayout(false);
            this.detailsGrp.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox addrGrp;
        private System.Windows.Forms.TextBox StateTxtBx;
        private System.Windows.Forms.TextBox CityTxtBx;
        private System.Windows.Forms.TextBox Address2TxtBx;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.TextBox Address1TxtBx;
        private System.Windows.Forms.Label ZipCodeLabel;
        private System.Windows.Forms.Label Addr2Label;
        private System.Windows.Forms.Label Addr1Label;
        private System.Windows.Forms.GroupBox detailsGrp;
        private System.Windows.Forms.TextBox FirstNameTxtBx;
        private System.Windows.Forms.TextBox LastNameTxtBx;
        private System.Windows.Forms.TextBox InitialTxtBx;
        private System.Windows.Forms.Label InitialLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.GroupBox rebateDetailGrp;
        private System.Windows.Forms.ComboBox ProofComboBx;
        private System.Windows.Forms.Label ProofLabel;
        private System.Windows.Forms.Label DateReceivedLabel;
        private System.Windows.Forms.DateTimePicker DateReceivedPicker;
        private System.Windows.Forms.ComboBox GenderComboBx;
        private System.Windows.Forms.TextBox EMailTxtBx;
        private System.Windows.Forms.TextBox PhoneNumberTxtBx;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label EmailAddressLabel;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.Button ModifyBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.ListView DataListView;
        private System.Windows.Forms.ColumnHeader colHeader1;
        private System.Windows.Forms.ColumnHeader colHeader2;
        private System.Windows.Forms.ColumnHeader colHeader3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MaskedTextBox ZipCodeTxtBx;
    }
}

