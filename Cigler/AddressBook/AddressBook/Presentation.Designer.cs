namespace AddressBook
{
    partial class Presentation
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
            this.NameList = new System.Windows.Forms.DataGridView();
            this.AdressList = new System.Windows.Forms.DataGridView();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.InformationPage = new System.Windows.Forms.TabPage();
            this.InformationDic = new System.Windows.Forms.Label();
            this.InformationDICLabel = new System.Windows.Forms.Label();
            this.DeleteAdressButton = new System.Windows.Forms.Button();
            this.DeletePersonButton = new System.Windows.Forms.Button();
            this.InformationIcDetailLabel = new System.Windows.Forms.Label();
            this.ContactDetailsLabel = new System.Windows.Forms.Label();
            this.ContactsDICLabel = new System.Windows.Forms.Label();
            this.ContactsDIC = new System.Windows.Forms.Label();
            this.InformationIC = new System.Windows.Forms.Label();
            this.InformationICLabel = new System.Windows.Forms.Label();
            this.InformationSurnameLabel = new System.Windows.Forms.Label();
            this.InformationSurname = new System.Windows.Forms.Label();
            this.InformationName = new System.Windows.Forms.Label();
            this.InformationNameLabel = new System.Windows.Forms.Label();
            this.AddPage = new System.Windows.Forms.TabPage();
            this.AddAdressButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddPersonButton = new System.Windows.Forms.Button();
            this.AddPSCTextBox = new System.Windows.Forms.TextBox();
            this.AddCityTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.AddDICLabel = new System.Windows.Forms.Label();
            this.AddIcLabel = new System.Windows.Forms.Label();
            this.AddSurnameLabel = new System.Windows.Forms.Label();
            this.AddNameLabel = new System.Windows.Forms.Label();
            this.AddStreetTextBox = new System.Windows.Forms.TextBox();
            this.AddDicTextBox = new System.Windows.Forms.TextBox();
            this.AddIcTextBox = new System.Windows.Forms.TextBox();
            this.AddSurnameTextBox = new System.Windows.Forms.TextBox();
            this.AddNameTextBox = new System.Windows.Forms.TextBox();
            this.AddInformationLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EditPage = new System.Windows.Forms.TabPage();
            this.EditAdressButton = new System.Windows.Forms.Button();
            this.EditPSCLabel = new System.Windows.Forms.Label();
            this.EditCityLabel = new System.Windows.Forms.Label();
            this.EditStreetLabel = new System.Windows.Forms.Label();
            this.EditPersonButton = new System.Windows.Forms.Button();
            this.EditPSCTextBox = new System.Windows.Forms.TextBox();
            this.EditCityTextBox = new System.Windows.Forms.TextBox();
            this.EditAdressLabel = new System.Windows.Forms.Label();
            this.EditDICLabel = new System.Windows.Forms.Label();
            this.EditIcLabel = new System.Windows.Forms.Label();
            this.EditSurnameLabel = new System.Windows.Forms.Label();
            this.EditNameLabel = new System.Windows.Forms.Label();
            this.EditStreetTextBox = new System.Windows.Forms.TextBox();
            this.EditDICTextBox = new System.Windows.Forms.TextBox();
            this.EditICTextBox = new System.Windows.Forms.TextBox();
            this.EditSurnameTextBox = new System.Windows.Forms.TextBox();
            this.EditNameTextBox = new System.Windows.Forms.TextBox();
            this.EditPersonLabel = new System.Windows.Forms.Label();
            this.InformationDateValid = new System.Windows.Forms.Label();
            this.InformationDateValidLabel = new System.Windows.Forms.Label();
            this.InformationDateCreatedLabel = new System.Windows.Forms.Label();
            this.InformationDateCreated = new System.Windows.Forms.Label();
            this.InformationCompany = new System.Windows.Forms.Label();
            this.InformationCompanyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NameList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdressList)).BeginInit();
            this.Tabs.SuspendLayout();
            this.InformationPage.SuspendLayout();
            this.AddPage.SuspendLayout();
            this.EditPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameList
            // 
            this.NameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NameList.Location = new System.Drawing.Point(12, 62);
            this.NameList.Name = "NameList";
            this.NameList.RowHeadersVisible = false;
            this.NameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NameList.Size = new System.Drawing.Size(417, 342);
            this.NameList.TabIndex = 1;
            this.NameList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NameList_CellContentClick);
            this.NameList.SelectionChanged += new System.EventHandler(this.NameList_SelectionChanged);
            // 
            // AdressList
            // 
            this.AdressList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdressList.Location = new System.Drawing.Point(12, 425);
            this.AdressList.Name = "AdressList";
            this.AdressList.RowHeadersVisible = false;
            this.AdressList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AdressList.Size = new System.Drawing.Size(321, 123);
            this.AdressList.TabIndex = 2;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.InformationPage);
            this.Tabs.Controls.Add(this.AddPage);
            this.Tabs.Controls.Add(this.EditPage);
            this.Tabs.Location = new System.Drawing.Point(444, 36);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(319, 594);
            this.Tabs.TabIndex = 3;
            // 
            // InformationPage
            // 
            this.InformationPage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.InformationPage.Controls.Add(this.InformationDateValid);
            this.InformationPage.Controls.Add(this.InformationDateValidLabel);
            this.InformationPage.Controls.Add(this.InformationDateCreatedLabel);
            this.InformationPage.Controls.Add(this.InformationDateCreated);
            this.InformationPage.Controls.Add(this.InformationCompany);
            this.InformationPage.Controls.Add(this.InformationCompanyLabel);
            this.InformationPage.Controls.Add(this.InformationDic);
            this.InformationPage.Controls.Add(this.InformationDICLabel);
            this.InformationPage.Controls.Add(this.DeleteAdressButton);
            this.InformationPage.Controls.Add(this.DeletePersonButton);
            this.InformationPage.Controls.Add(this.InformationIcDetailLabel);
            this.InformationPage.Controls.Add(this.ContactDetailsLabel);
            this.InformationPage.Controls.Add(this.ContactsDICLabel);
            this.InformationPage.Controls.Add(this.ContactsDIC);
            this.InformationPage.Controls.Add(this.InformationIC);
            this.InformationPage.Controls.Add(this.InformationICLabel);
            this.InformationPage.Controls.Add(this.InformationSurnameLabel);
            this.InformationPage.Controls.Add(this.InformationSurname);
            this.InformationPage.Controls.Add(this.InformationName);
            this.InformationPage.Controls.Add(this.InformationNameLabel);
            this.InformationPage.Location = new System.Drawing.Point(4, 22);
            this.InformationPage.Name = "InformationPage";
            this.InformationPage.Padding = new System.Windows.Forms.Padding(3);
            this.InformationPage.Size = new System.Drawing.Size(311, 568);
            this.InformationPage.TabIndex = 0;
            this.InformationPage.Text = "Informace";
            // 
            // InformationDic
            // 
            this.InformationDic.AutoSize = true;
            this.InformationDic.Location = new System.Drawing.Point(252, 66);
            this.InformationDic.Name = "InformationDic";
            this.InformationDic.Size = new System.Drawing.Size(35, 13);
            this.InformationDic.TabIndex = 42;
            this.InformationDic.Text = "label2";
            // 
            // InformationDICLabel
            // 
            this.InformationDICLabel.AutoSize = true;
            this.InformationDICLabel.Location = new System.Drawing.Point(252, 40);
            this.InformationDICLabel.Name = "InformationDICLabel";
            this.InformationDICLabel.Size = new System.Drawing.Size(25, 13);
            this.InformationDICLabel.TabIndex = 41;
            this.InformationDICLabel.Text = "DIČ";
            // 
            // DeleteAdressButton
            // 
            this.DeleteAdressButton.Location = new System.Drawing.Point(15, 458);
            this.DeleteAdressButton.Name = "DeleteAdressButton";
            this.DeleteAdressButton.Size = new System.Drawing.Size(103, 23);
            this.DeleteAdressButton.TabIndex = 40;
            this.DeleteAdressButton.Text = "Smazat Adresu";
            this.DeleteAdressButton.UseVisualStyleBackColor = true;
            this.DeleteAdressButton.Click += new System.EventHandler(this.DeleteAdressButton_Click);
            // 
            // DeletePersonButton
            // 
            this.DeletePersonButton.Location = new System.Drawing.Point(176, 256);
            this.DeletePersonButton.Name = "DeletePersonButton";
            this.DeletePersonButton.Size = new System.Drawing.Size(93, 23);
            this.DeletePersonButton.TabIndex = 39;
            this.DeletePersonButton.Text = "Smazat Kontakt";
            this.DeletePersonButton.UseVisualStyleBackColor = true;
            this.DeletePersonButton.Click += new System.EventHandler(this.DeletePersonButton_Click);
            // 
            // InformationIcDetailLabel
            // 
            this.InformationIcDetailLabel.AutoSize = true;
            this.InformationIcDetailLabel.Location = new System.Drawing.Point(38, 266);
            this.InformationIcDetailLabel.Name = "InformationIcDetailLabel";
            this.InformationIcDetailLabel.Size = new System.Drawing.Size(52, 13);
            this.InformationIcDetailLabel.TabIndex = 12;
            this.InformationIcDetailLabel.Text = "Detaily IČ";
            // 
            // ContactDetailsLabel
            // 
            this.ContactDetailsLabel.AutoSize = true;
            this.ContactDetailsLabel.Location = new System.Drawing.Point(38, 20);
            this.ContactDetailsLabel.Name = "ContactDetailsLabel";
            this.ContactDetailsLabel.Size = new System.Drawing.Size(39, 13);
            this.ContactDetailsLabel.TabIndex = 11;
            this.ContactDetailsLabel.Text = "Detaily";
            // 
            // ContactsDICLabel
            // 
            this.ContactsDICLabel.AutoSize = true;
            this.ContactsDICLabel.Location = new System.Drawing.Point(733, 40);
            this.ContactsDICLabel.Name = "ContactsDICLabel";
            this.ContactsDICLabel.Size = new System.Drawing.Size(48, 13);
            this.ContactsDICLabel.TabIndex = 10;
            this.ContactsDICLabel.Text = "Příjmení";
            // 
            // ContactsDIC
            // 
            this.ContactsDIC.AutoSize = true;
            this.ContactsDIC.Location = new System.Drawing.Point(733, 66);
            this.ContactsDIC.Name = "ContactsDIC";
            this.ContactsDIC.Size = new System.Drawing.Size(35, 13);
            this.ContactsDIC.TabIndex = 9;
            this.ContactsDIC.Text = "label3";
            // 
            // InformationIC
            // 
            this.InformationIC.AutoSize = true;
            this.InformationIC.Location = new System.Drawing.Point(211, 66);
            this.InformationIC.Name = "InformationIC";
            this.InformationIC.Size = new System.Drawing.Size(35, 13);
            this.InformationIC.TabIndex = 8;
            this.InformationIC.Text = "label2";
            // 
            // InformationICLabel
            // 
            this.InformationICLabel.AutoSize = true;
            this.InformationICLabel.Location = new System.Drawing.Point(211, 40);
            this.InformationICLabel.Name = "InformationICLabel";
            this.InformationICLabel.Size = new System.Drawing.Size(17, 13);
            this.InformationICLabel.TabIndex = 7;
            this.InformationICLabel.Text = "IČ";
            // 
            // InformationSurnameLabel
            // 
            this.InformationSurnameLabel.AutoSize = true;
            this.InformationSurnameLabel.Location = new System.Drawing.Point(140, 40);
            this.InformationSurnameLabel.Name = "InformationSurnameLabel";
            this.InformationSurnameLabel.Size = new System.Drawing.Size(48, 13);
            this.InformationSurnameLabel.TabIndex = 6;
            this.InformationSurnameLabel.Text = "Příjmení";
            // 
            // InformationSurname
            // 
            this.InformationSurname.AutoSize = true;
            this.InformationSurname.Location = new System.Drawing.Point(140, 66);
            this.InformationSurname.Name = "InformationSurname";
            this.InformationSurname.Size = new System.Drawing.Size(35, 13);
            this.InformationSurname.TabIndex = 5;
            this.InformationSurname.Text = "label3";
            // 
            // InformationName
            // 
            this.InformationName.AutoSize = true;
            this.InformationName.Location = new System.Drawing.Point(80, 66);
            this.InformationName.Name = "InformationName";
            this.InformationName.Size = new System.Drawing.Size(35, 13);
            this.InformationName.TabIndex = 4;
            this.InformationName.Text = "label2";
            // 
            // InformationNameLabel
            // 
            this.InformationNameLabel.AutoSize = true;
            this.InformationNameLabel.Location = new System.Drawing.Point(80, 40);
            this.InformationNameLabel.Name = "InformationNameLabel";
            this.InformationNameLabel.Size = new System.Drawing.Size(38, 13);
            this.InformationNameLabel.TabIndex = 3;
            this.InformationNameLabel.Text = "Jméno";
            // 
            // AddPage
            // 
            this.AddPage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.AddPage.Controls.Add(this.AddAdressButton);
            this.AddPage.Controls.Add(this.label7);
            this.AddPage.Controls.Add(this.label6);
            this.AddPage.Controls.Add(this.label5);
            this.AddPage.Controls.Add(this.AddPersonButton);
            this.AddPage.Controls.Add(this.AddPSCTextBox);
            this.AddPage.Controls.Add(this.AddCityTextBox);
            this.AddPage.Controls.Add(this.label9);
            this.AddPage.Controls.Add(this.AddDICLabel);
            this.AddPage.Controls.Add(this.AddIcLabel);
            this.AddPage.Controls.Add(this.AddSurnameLabel);
            this.AddPage.Controls.Add(this.AddNameLabel);
            this.AddPage.Controls.Add(this.AddStreetTextBox);
            this.AddPage.Controls.Add(this.AddDicTextBox);
            this.AddPage.Controls.Add(this.AddIcTextBox);
            this.AddPage.Controls.Add(this.AddSurnameTextBox);
            this.AddPage.Controls.Add(this.AddNameTextBox);
            this.AddPage.Controls.Add(this.AddInformationLabel);
            this.AddPage.Controls.Add(this.label4);
            this.AddPage.Controls.Add(this.label3);
            this.AddPage.Controls.Add(this.label2);
            this.AddPage.Controls.Add(this.label1);
            this.AddPage.Location = new System.Drawing.Point(4, 22);
            this.AddPage.Name = "AddPage";
            this.AddPage.Padding = new System.Windows.Forms.Padding(3);
            this.AddPage.Size = new System.Drawing.Size(311, 568);
            this.AddPage.TabIndex = 1;
            this.AddPage.Text = "Přidat záznam";
            // 
            // AddAdressButton
            // 
            this.AddAdressButton.Location = new System.Drawing.Point(156, 323);
            this.AddAdressButton.Name = "AddAdressButton";
            this.AddAdressButton.Size = new System.Drawing.Size(75, 23);
            this.AddAdressButton.TabIndex = 25;
            this.AddAdressButton.Text = "Přidat";
            this.AddAdressButton.UseVisualStyleBackColor = true;
            this.AddAdressButton.Click += new System.EventHandler(this.AddAdressButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "PSČ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Město";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ulice";
            // 
            // AddPersonButton
            // 
            this.AddPersonButton.Location = new System.Drawing.Point(156, 159);
            this.AddPersonButton.Name = "AddPersonButton";
            this.AddPersonButton.Size = new System.Drawing.Size(75, 23);
            this.AddPersonButton.TabIndex = 21;
            this.AddPersonButton.Text = "Přidat";
            this.AddPersonButton.UseVisualStyleBackColor = true;
            this.AddPersonButton.Click += new System.EventHandler(this.AddPersonButton_Click);
            // 
            // AddPSCTextBox
            // 
            this.AddPSCTextBox.Location = new System.Drawing.Point(25, 293);
            this.AddPSCTextBox.Name = "AddPSCTextBox";
            this.AddPSCTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddPSCTextBox.TabIndex = 20;
            // 
            // AddCityTextBox
            // 
            this.AddCityTextBox.Location = new System.Drawing.Point(131, 254);
            this.AddCityTextBox.Name = "AddCityTextBox";
            this.AddCityTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddCityTextBox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Adresa";
            // 
            // AddDICLabel
            // 
            this.AddDICLabel.AutoSize = true;
            this.AddDICLabel.Location = new System.Drawing.Point(128, 102);
            this.AddDICLabel.Name = "AddDICLabel";
            this.AddDICLabel.Size = new System.Drawing.Size(25, 13);
            this.AddDICLabel.TabIndex = 17;
            this.AddDICLabel.Text = "DIČ";
            // 
            // AddIcLabel
            // 
            this.AddIcLabel.AutoSize = true;
            this.AddIcLabel.Location = new System.Drawing.Point(22, 102);
            this.AddIcLabel.Name = "AddIcLabel";
            this.AddIcLabel.Size = new System.Drawing.Size(17, 13);
            this.AddIcLabel.TabIndex = 16;
            this.AddIcLabel.Text = "IČ";
            // 
            // AddSurnameLabel
            // 
            this.AddSurnameLabel.AutoSize = true;
            this.AddSurnameLabel.Location = new System.Drawing.Point(128, 55);
            this.AddSurnameLabel.Name = "AddSurnameLabel";
            this.AddSurnameLabel.Size = new System.Drawing.Size(48, 13);
            this.AddSurnameLabel.TabIndex = 15;
            this.AddSurnameLabel.Text = "Příjmení";
            // 
            // AddNameLabel
            // 
            this.AddNameLabel.AutoSize = true;
            this.AddNameLabel.Location = new System.Drawing.Point(22, 55);
            this.AddNameLabel.Name = "AddNameLabel";
            this.AddNameLabel.Size = new System.Drawing.Size(38, 13);
            this.AddNameLabel.TabIndex = 14;
            this.AddNameLabel.Text = "Jméno";
            // 
            // AddStreetTextBox
            // 
            this.AddStreetTextBox.Location = new System.Drawing.Point(25, 254);
            this.AddStreetTextBox.Name = "AddStreetTextBox";
            this.AddStreetTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddStreetTextBox.TabIndex = 13;
            // 
            // AddDicTextBox
            // 
            this.AddDicTextBox.Location = new System.Drawing.Point(131, 118);
            this.AddDicTextBox.Name = "AddDicTextBox";
            this.AddDicTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddDicTextBox.TabIndex = 12;
            // 
            // AddIcTextBox
            // 
            this.AddIcTextBox.Location = new System.Drawing.Point(25, 118);
            this.AddIcTextBox.Name = "AddIcTextBox";
            this.AddIcTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddIcTextBox.TabIndex = 11;
            // 
            // AddSurnameTextBox
            // 
            this.AddSurnameTextBox.Location = new System.Drawing.Point(131, 71);
            this.AddSurnameTextBox.Name = "AddSurnameTextBox";
            this.AddSurnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddSurnameTextBox.TabIndex = 10;
            // 
            // AddNameTextBox
            // 
            this.AddNameTextBox.Location = new System.Drawing.Point(25, 71);
            this.AddNameTextBox.Name = "AddNameTextBox";
            this.AddNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddNameTextBox.TabIndex = 9;
            // 
            // AddInformationLabel
            // 
            this.AddInformationLabel.AutoSize = true;
            this.AddInformationLabel.Location = new System.Drawing.Point(22, 31);
            this.AddInformationLabel.Name = "AddInformationLabel";
            this.AddInformationLabel.Size = new System.Drawing.Size(38, 13);
            this.AddInformationLabel.TabIndex = 8;
            this.AddInformationLabel.Text = "Osoba";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // EditPage
            // 
            this.EditPage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.EditPage.Controls.Add(this.EditAdressButton);
            this.EditPage.Controls.Add(this.EditPSCLabel);
            this.EditPage.Controls.Add(this.EditCityLabel);
            this.EditPage.Controls.Add(this.EditStreetLabel);
            this.EditPage.Controls.Add(this.EditPersonButton);
            this.EditPage.Controls.Add(this.EditPSCTextBox);
            this.EditPage.Controls.Add(this.EditCityTextBox);
            this.EditPage.Controls.Add(this.EditAdressLabel);
            this.EditPage.Controls.Add(this.EditDICLabel);
            this.EditPage.Controls.Add(this.EditIcLabel);
            this.EditPage.Controls.Add(this.EditSurnameLabel);
            this.EditPage.Controls.Add(this.EditNameLabel);
            this.EditPage.Controls.Add(this.EditStreetTextBox);
            this.EditPage.Controls.Add(this.EditDICTextBox);
            this.EditPage.Controls.Add(this.EditICTextBox);
            this.EditPage.Controls.Add(this.EditSurnameTextBox);
            this.EditPage.Controls.Add(this.EditNameTextBox);
            this.EditPage.Controls.Add(this.EditPersonLabel);
            this.EditPage.Location = new System.Drawing.Point(4, 22);
            this.EditPage.Name = "EditPage";
            this.EditPage.Padding = new System.Windows.Forms.Padding(3);
            this.EditPage.Size = new System.Drawing.Size(311, 568);
            this.EditPage.TabIndex = 2;
            this.EditPage.Text = "Editovat záznam";
            // 
            // EditAdressButton
            // 
            this.EditAdressButton.Location = new System.Drawing.Point(152, 323);
            this.EditAdressButton.Name = "EditAdressButton";
            this.EditAdressButton.Size = new System.Drawing.Size(75, 23);
            this.EditAdressButton.TabIndex = 42;
            this.EditAdressButton.Text = "Upravit";
            this.EditAdressButton.UseVisualStyleBackColor = true;
            this.EditAdressButton.Click += new System.EventHandler(this.EditAdressButton_Click);
            // 
            // EditPSCLabel
            // 
            this.EditPSCLabel.AutoSize = true;
            this.EditPSCLabel.Location = new System.Drawing.Point(18, 269);
            this.EditPSCLabel.Name = "EditPSCLabel";
            this.EditPSCLabel.Size = new System.Drawing.Size(28, 13);
            this.EditPSCLabel.TabIndex = 41;
            this.EditPSCLabel.Text = "PSČ";
            // 
            // EditCityLabel
            // 
            this.EditCityLabel.AutoSize = true;
            this.EditCityLabel.Location = new System.Drawing.Point(124, 230);
            this.EditCityLabel.Name = "EditCityLabel";
            this.EditCityLabel.Size = new System.Drawing.Size(36, 13);
            this.EditCityLabel.TabIndex = 40;
            this.EditCityLabel.Text = "Město";
            // 
            // EditStreetLabel
            // 
            this.EditStreetLabel.AutoSize = true;
            this.EditStreetLabel.Location = new System.Drawing.Point(18, 230);
            this.EditStreetLabel.Name = "EditStreetLabel";
            this.EditStreetLabel.Size = new System.Drawing.Size(31, 13);
            this.EditStreetLabel.TabIndex = 39;
            this.EditStreetLabel.Text = "Ulice";
            // 
            // EditPersonButton
            // 
            this.EditPersonButton.Location = new System.Drawing.Point(152, 151);
            this.EditPersonButton.Name = "EditPersonButton";
            this.EditPersonButton.Size = new System.Drawing.Size(75, 23);
            this.EditPersonButton.TabIndex = 38;
            this.EditPersonButton.Text = "Upravit";
            this.EditPersonButton.UseVisualStyleBackColor = true;
            this.EditPersonButton.Click += new System.EventHandler(this.EditPersonButton_Click);
            // 
            // EditPSCTextBox
            // 
            this.EditPSCTextBox.Location = new System.Drawing.Point(21, 285);
            this.EditPSCTextBox.Name = "EditPSCTextBox";
            this.EditPSCTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditPSCTextBox.TabIndex = 37;
            // 
            // EditCityTextBox
            // 
            this.EditCityTextBox.Location = new System.Drawing.Point(127, 246);
            this.EditCityTextBox.Name = "EditCityTextBox";
            this.EditCityTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditCityTextBox.TabIndex = 36;
            // 
            // EditAdressLabel
            // 
            this.EditAdressLabel.AutoSize = true;
            this.EditAdressLabel.Location = new System.Drawing.Point(18, 200);
            this.EditAdressLabel.Name = "EditAdressLabel";
            this.EditAdressLabel.Size = new System.Drawing.Size(40, 13);
            this.EditAdressLabel.TabIndex = 35;
            this.EditAdressLabel.Text = "Adresa";
            // 
            // EditDICLabel
            // 
            this.EditDICLabel.AutoSize = true;
            this.EditDICLabel.Location = new System.Drawing.Point(124, 94);
            this.EditDICLabel.Name = "EditDICLabel";
            this.EditDICLabel.Size = new System.Drawing.Size(25, 13);
            this.EditDICLabel.TabIndex = 34;
            this.EditDICLabel.Text = "DIČ";
            // 
            // EditIcLabel
            // 
            this.EditIcLabel.AutoSize = true;
            this.EditIcLabel.Location = new System.Drawing.Point(18, 94);
            this.EditIcLabel.Name = "EditIcLabel";
            this.EditIcLabel.Size = new System.Drawing.Size(17, 13);
            this.EditIcLabel.TabIndex = 33;
            this.EditIcLabel.Text = "IČ";
            // 
            // EditSurnameLabel
            // 
            this.EditSurnameLabel.AutoSize = true;
            this.EditSurnameLabel.Location = new System.Drawing.Point(124, 47);
            this.EditSurnameLabel.Name = "EditSurnameLabel";
            this.EditSurnameLabel.Size = new System.Drawing.Size(48, 13);
            this.EditSurnameLabel.TabIndex = 32;
            this.EditSurnameLabel.Text = "Příjmení";
            // 
            // EditNameLabel
            // 
            this.EditNameLabel.AutoSize = true;
            this.EditNameLabel.Location = new System.Drawing.Point(18, 47);
            this.EditNameLabel.Name = "EditNameLabel";
            this.EditNameLabel.Size = new System.Drawing.Size(38, 13);
            this.EditNameLabel.TabIndex = 31;
            this.EditNameLabel.Text = "Jméno";
            // 
            // EditStreetTextBox
            // 
            this.EditStreetTextBox.Location = new System.Drawing.Point(21, 246);
            this.EditStreetTextBox.Name = "EditStreetTextBox";
            this.EditStreetTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditStreetTextBox.TabIndex = 30;
            // 
            // EditDICTextBox
            // 
            this.EditDICTextBox.Location = new System.Drawing.Point(127, 110);
            this.EditDICTextBox.Name = "EditDICTextBox";
            this.EditDICTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditDICTextBox.TabIndex = 29;
            // 
            // EditICTextBox
            // 
            this.EditICTextBox.Location = new System.Drawing.Point(21, 110);
            this.EditICTextBox.Name = "EditICTextBox";
            this.EditICTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditICTextBox.TabIndex = 28;
            // 
            // EditSurnameTextBox
            // 
            this.EditSurnameTextBox.Location = new System.Drawing.Point(127, 63);
            this.EditSurnameTextBox.Name = "EditSurnameTextBox";
            this.EditSurnameTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditSurnameTextBox.TabIndex = 27;
            // 
            // EditNameTextBox
            // 
            this.EditNameTextBox.Location = new System.Drawing.Point(21, 63);
            this.EditNameTextBox.Name = "EditNameTextBox";
            this.EditNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.EditNameTextBox.TabIndex = 26;
            // 
            // EditPersonLabel
            // 
            this.EditPersonLabel.AutoSize = true;
            this.EditPersonLabel.Location = new System.Drawing.Point(18, 23);
            this.EditPersonLabel.Name = "EditPersonLabel";
            this.EditPersonLabel.Size = new System.Drawing.Size(38, 13);
            this.EditPersonLabel.TabIndex = 25;
            this.EditPersonLabel.Text = "Osoba";
            // 
            // InformationDateValid
            // 
            this.InformationDateValid.AutoSize = true;
            this.InformationDateValid.Location = new System.Drawing.Point(173, 333);
            this.InformationDateValid.Name = "InformationDateValid";
            this.InformationDateValid.Size = new System.Drawing.Size(35, 13);
            this.InformationDateValid.TabIndex = 48;
            this.InformationDateValid.Text = "label2";
            // 
            // InformationDateValidLabel
            // 
            this.InformationDateValidLabel.AutoSize = true;
            this.InformationDateValidLabel.Location = new System.Drawing.Point(173, 307);
            this.InformationDateValidLabel.Name = "InformationDateValidLabel";
            this.InformationDateValidLabel.Size = new System.Drawing.Size(80, 13);
            this.InformationDateValidLabel.TabIndex = 47;
            this.InformationDateValidLabel.Text = "Datum platnosti";
            // 
            // InformationDateCreatedLabel
            // 
            this.InformationDateCreatedLabel.AutoSize = true;
            this.InformationDateCreatedLabel.Location = new System.Drawing.Point(102, 307);
            this.InformationDateCreatedLabel.Name = "InformationDateCreatedLabel";
            this.InformationDateCreatedLabel.Size = new System.Drawing.Size(81, 13);
            this.InformationDateCreatedLabel.TabIndex = 46;
            this.InformationDateCreatedLabel.Text = "Datum založení";
            // 
            // InformationDateCreated
            // 
            this.InformationDateCreated.AutoSize = true;
            this.InformationDateCreated.Location = new System.Drawing.Point(102, 333);
            this.InformationDateCreated.Name = "InformationDateCreated";
            this.InformationDateCreated.Size = new System.Drawing.Size(35, 13);
            this.InformationDateCreated.TabIndex = 45;
            this.InformationDateCreated.Text = "label3";
            // 
            // InformationCompany
            // 
            this.InformationCompany.AutoSize = true;
            this.InformationCompany.Location = new System.Drawing.Point(42, 333);
            this.InformationCompany.Name = "InformationCompany";
            this.InformationCompany.Size = new System.Drawing.Size(35, 13);
            this.InformationCompany.TabIndex = 44;
            this.InformationCompany.Text = "label2";
            // 
            // InformationCompanyLabel
            // 
            this.InformationCompanyLabel.AutoSize = true;
            this.InformationCompanyLabel.Location = new System.Drawing.Point(42, 307);
            this.InformationCompanyLabel.Name = "InformationCompanyLabel";
            this.InformationCompanyLabel.Size = new System.Drawing.Size(60, 13);
            this.InformationCompanyLabel.TabIndex = 43;
            this.InformationCompanyLabel.Text = "Společnost";
            // 
            // Presentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(908, 675);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.NameList);
            this.Controls.Add(this.AdressList);
            this.Name = "Presentation";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NameList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdressList)).EndInit();
            this.Tabs.ResumeLayout(false);
            this.InformationPage.ResumeLayout(false);
            this.InformationPage.PerformLayout();
            this.AddPage.ResumeLayout(false);
            this.AddPage.PerformLayout();
            this.EditPage.ResumeLayout(false);
            this.EditPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView NameList;
        private System.Windows.Forms.DataGridView AdressList;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage InformationPage;
        private System.Windows.Forms.Label InformationIcDetailLabel;
        private System.Windows.Forms.Label ContactDetailsLabel;
        private System.Windows.Forms.Label ContactsDICLabel;
        private System.Windows.Forms.Label ContactsDIC;
        private System.Windows.Forms.Label InformationIC;
        private System.Windows.Forms.Label InformationICLabel;
        private System.Windows.Forms.Label InformationSurnameLabel;
        private System.Windows.Forms.Label InformationSurname;
        private System.Windows.Forms.Label InformationName;
        private System.Windows.Forms.Label InformationNameLabel;
        private System.Windows.Forms.TabPage AddPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage EditPage;
        private System.Windows.Forms.Label AddDICLabel;
        private System.Windows.Forms.Label AddIcLabel;
        private System.Windows.Forms.Label AddSurnameLabel;
        private System.Windows.Forms.Label AddNameLabel;
        private System.Windows.Forms.TextBox AddStreetTextBox;
        private System.Windows.Forms.TextBox AddDicTextBox;
        private System.Windows.Forms.TextBox AddIcTextBox;
        private System.Windows.Forms.TextBox AddSurnameTextBox;
        private System.Windows.Forms.TextBox AddNameTextBox;
        private System.Windows.Forms.Label AddInformationLabel;
        private System.Windows.Forms.Button AddPersonButton;
        private System.Windows.Forms.TextBox AddPSCTextBox;
        private System.Windows.Forms.TextBox AddCityTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label EditPSCLabel;
        private System.Windows.Forms.Label EditCityLabel;
        private System.Windows.Forms.Label EditStreetLabel;
        private System.Windows.Forms.Button EditPersonButton;
        private System.Windows.Forms.TextBox EditPSCTextBox;
        private System.Windows.Forms.TextBox EditCityTextBox;
        private System.Windows.Forms.Label EditAdressLabel;
        private System.Windows.Forms.Label EditDICLabel;
        private System.Windows.Forms.Label EditIcLabel;
        private System.Windows.Forms.Label EditSurnameLabel;
        private System.Windows.Forms.Label EditNameLabel;
        private System.Windows.Forms.TextBox EditStreetTextBox;
        private System.Windows.Forms.TextBox EditDICTextBox;
        private System.Windows.Forms.TextBox EditICTextBox;
        private System.Windows.Forms.TextBox EditSurnameTextBox;
        private System.Windows.Forms.TextBox EditNameTextBox;
        private System.Windows.Forms.Label EditPersonLabel;
        private System.Windows.Forms.Button AddAdressButton;
        private System.Windows.Forms.Button EditAdressButton;
        private System.Windows.Forms.Button DeleteAdressButton;
        private System.Windows.Forms.Button DeletePersonButton;
        private System.Windows.Forms.Label InformationDic;
        private System.Windows.Forms.Label InformationDICLabel;
        private System.Windows.Forms.Label InformationDateValid;
        private System.Windows.Forms.Label InformationDateValidLabel;
        private System.Windows.Forms.Label InformationDateCreatedLabel;
        private System.Windows.Forms.Label InformationDateCreated;
        private System.Windows.Forms.Label InformationCompany;
        private System.Windows.Forms.Label InformationCompanyLabel;
    }
}

