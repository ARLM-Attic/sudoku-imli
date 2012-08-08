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
            this.components = new System.ComponentModel.Container();
            this.adressBookDataSet = new AddressBook.AdressBookDataSet();
            this.adressBookDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NameList = new System.Windows.Forms.DataGridView();
            this.AdressList = new System.Windows.Forms.DataGridView();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.InformationPage = new System.Windows.Forms.TabPage();
            this.AddPage = new System.Windows.Forms.TabPage();
            this.InformationNameLabel = new System.Windows.Forms.Label();
            this.InformationName = new System.Windows.Forms.Label();
            this.InformationSurname = new System.Windows.Forms.Label();
            this.InformationSurnameLabel = new System.Windows.Forms.Label();
            this.ContactsDICLabel = new System.Windows.Forms.Label();
            this.ContactsDIC = new System.Windows.Forms.Label();
            this.InformationIC = new System.Windows.Forms.Label();
            this.InformationICLabel = new System.Windows.Forms.Label();
            this.ContactDetailsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InformationIcDetailLabel = new System.Windows.Forms.Label();
            this.EditPage = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.AddInformationLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.AddNameLabel = new System.Windows.Forms.Label();
            this.AddSurnameLabel = new System.Windows.Forms.Label();
            this.AddIcLabel = new System.Windows.Forms.Label();
            this.AddDICLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.AddPeronButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adressBookDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressBookDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdressList)).BeginInit();
            this.Tabs.SuspendLayout();
            this.InformationPage.SuspendLayout();
            this.AddPage.SuspendLayout();
            this.EditPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // adressBookDataSet
            // 
            this.adressBookDataSet.DataSetName = "AdressBookDataSet";
            this.adressBookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adressBookDataSetBindingSource
            // 
            this.adressBookDataSetBindingSource.DataSource = this.adressBookDataSet;
            this.adressBookDataSetBindingSource.Position = 0;
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
            this.Tabs.Controls.Add(this.tabPage3);
            this.Tabs.Location = new System.Drawing.Point(444, 36);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(319, 594);
            this.Tabs.TabIndex = 3;
            // 
            // InformationPage
            // 
            this.InformationPage.BackColor = System.Drawing.Color.DarkSeaGreen;
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
            // AddPage
            // 
            this.AddPage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.AddPage.Controls.Add(this.label7);
            this.AddPage.Controls.Add(this.label6);
            this.AddPage.Controls.Add(this.label5);
            this.AddPage.Controls.Add(this.AddPeronButton);
            this.AddPage.Controls.Add(this.textBox7);
            this.AddPage.Controls.Add(this.textBox6);
            this.AddPage.Controls.Add(this.label9);
            this.AddPage.Controls.Add(this.AddDICLabel);
            this.AddPage.Controls.Add(this.AddIcLabel);
            this.AddPage.Controls.Add(this.AddSurnameLabel);
            this.AddPage.Controls.Add(this.AddNameLabel);
            this.AddPage.Controls.Add(this.textBox5);
            this.AddPage.Controls.Add(this.textBox4);
            this.AddPage.Controls.Add(this.textBox3);
            this.AddPage.Controls.Add(this.textBox2);
            this.AddPage.Controls.Add(this.textBox1);
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
            // InformationNameLabel
            // 
            this.InformationNameLabel.AutoSize = true;
            this.InformationNameLabel.Location = new System.Drawing.Point(80, 40);
            this.InformationNameLabel.Name = "InformationNameLabel";
            this.InformationNameLabel.Size = new System.Drawing.Size(38, 13);
            this.InformationNameLabel.TabIndex = 3;
            this.InformationNameLabel.Text = "Jméno";
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
            // InformationSurname
            // 
            this.InformationSurname.AutoSize = true;
            this.InformationSurname.Location = new System.Drawing.Point(140, 66);
            this.InformationSurname.Name = "InformationSurname";
            this.InformationSurname.Size = new System.Drawing.Size(35, 13);
            this.InformationSurname.TabIndex = 5;
            this.InformationSurname.Text = "label3";
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
            // ContactDetailsLabel
            // 
            this.ContactDetailsLabel.AutoSize = true;
            this.ContactDetailsLabel.Location = new System.Drawing.Point(38, 20);
            this.ContactDetailsLabel.Name = "ContactDetailsLabel";
            this.ContactDetailsLabel.Size = new System.Drawing.Size(39, 13);
            this.ContactDetailsLabel.TabIndex = 11;
            this.ContactDetailsLabel.Text = "Detaily";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
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
            // EditPage
            // 
            this.EditPage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.EditPage.Controls.Add(this.label8);
            this.EditPage.Controls.Add(this.label10);
            this.EditPage.Controls.Add(this.label11);
            this.EditPage.Controls.Add(this.button1);
            this.EditPage.Controls.Add(this.textBox8);
            this.EditPage.Controls.Add(this.textBox9);
            this.EditPage.Controls.Add(this.label12);
            this.EditPage.Controls.Add(this.label13);
            this.EditPage.Controls.Add(this.label14);
            this.EditPage.Controls.Add(this.label15);
            this.EditPage.Controls.Add(this.label16);
            this.EditPage.Controls.Add(this.textBox10);
            this.EditPage.Controls.Add(this.textBox11);
            this.EditPage.Controls.Add(this.textBox12);
            this.EditPage.Controls.Add(this.textBox13);
            this.EditPage.Controls.Add(this.textBox14);
            this.EditPage.Controls.Add(this.label17);
            this.EditPage.Location = new System.Drawing.Point(4, 22);
            this.EditPage.Name = "EditPage";
            this.EditPage.Padding = new System.Windows.Forms.Padding(3);
            this.EditPage.Size = new System.Drawing.Size(311, 568);
            this.EditPage.TabIndex = 2;
            this.EditPage.Text = "Editovat záznam";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(311, 568);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Smazat Záznam";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(25, 118);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(131, 118);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 12;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(25, 254);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 13;
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
            // AddSurnameLabel
            // 
            this.AddSurnameLabel.AutoSize = true;
            this.AddSurnameLabel.Location = new System.Drawing.Point(128, 55);
            this.AddSurnameLabel.Name = "AddSurnameLabel";
            this.AddSurnameLabel.Size = new System.Drawing.Size(48, 13);
            this.AddSurnameLabel.TabIndex = 15;
            this.AddSurnameLabel.Text = "Příjmení";
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
            // AddDICLabel
            // 
            this.AddDICLabel.AutoSize = true;
            this.AddDICLabel.Location = new System.Drawing.Point(128, 102);
            this.AddDICLabel.Name = "AddDICLabel";
            this.AddDICLabel.Size = new System.Drawing.Size(25, 13);
            this.AddDICLabel.TabIndex = 17;
            this.AddDICLabel.Text = "DIČ";
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
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(131, 254);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 19;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(25, 293);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 20;
            // 
            // AddPeronButton
            // 
            this.AddPeronButton.Location = new System.Drawing.Point(156, 159);
            this.AddPeronButton.Name = "AddPeronButton";
            this.AddPeronButton.Size = new System.Drawing.Size(75, 23);
            this.AddPeronButton.TabIndex = 21;
            this.AddPeronButton.Text = "Přidat";
            this.AddPeronButton.UseVisualStyleBackColor = true;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Město";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "PSČ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Město";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Ulice";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Přidat";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(21, 285);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 37;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(127, 246);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Adresa";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(124, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "DIČ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "IČ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(124, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Příjmení";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Jméno";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(21, 246);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 30;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(127, 110);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 20);
            this.textBox11.TabIndex = 29;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(21, 110);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 20);
            this.textBox12.TabIndex = 28;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(127, 63);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 20);
            this.textBox13.TabIndex = 27;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(21, 63);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 20);
            this.textBox14.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Osoba";
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
            ((System.ComponentModel.ISupportInitialize)(this.adressBookDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressBookDataSetBindingSource)).EndInit();
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

        private AdressBookDataSet adressBookDataSet;
        private System.Windows.Forms.BindingSource adressBookDataSetBindingSource;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label AddDICLabel;
        private System.Windows.Forms.Label AddIcLabel;
        private System.Windows.Forms.Label AddSurnameLabel;
        private System.Windows.Forms.Label AddNameLabel;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label AddInformationLabel;
        private System.Windows.Forms.Button AddPeronButton;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label17;
    }
}

