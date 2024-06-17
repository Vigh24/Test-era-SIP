namespace EratronicsPhone
{
    partial class ContactsForm
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
            this.ListBoxContacts = new System.Windows.Forms.ListBox();
            this.ButtonAddContact = new System.Windows.Forms.Button();
            this.ButtonDeleteContact = new System.Windows.Forms.Button();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.SuspendLayout();
            // 
            // ListBoxContacts
            // 
            this.ListBoxContacts.Location = new System.Drawing.Point(10, 10);
            this.ListBoxContacts.Name = "ListBoxContacts";
            this.ListBoxContacts.Size = new System.Drawing.Size(200, 290);
            this.ListBoxContacts.TabIndex = 0;
            this.ListBoxContacts.DoubleClick += new System.EventHandler(this.ListBoxContacts_DoubleClick);
            // 
            // ButtonAddContact
            // 
            this.ButtonAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAddContact.Location = new System.Drawing.Point(220, 10);
            this.ButtonAddContact.Name = "ButtonAddContact";
            this.ButtonAddContact.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddContact.TabIndex = 1;
            this.ButtonAddContact.Text = "Add";
            this.ButtonAddContact.UseVisualStyleBackColor = true;
            this.ButtonAddContact.Click += new System.EventHandler(this.ButtonAddContact_Click);
            // 
            // ButtonDeleteContact
            // 
            this.ButtonDeleteContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeleteContact.Location = new System.Drawing.Point(220, 40);
            this.ButtonDeleteContact.Name = "ButtonDeleteContact";
            this.ButtonDeleteContact.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeleteContact.TabIndex = 2;
            this.ButtonDeleteContact.Text = "Delete";
            this.ButtonDeleteContact.UseVisualStyleBackColor = true;
            this.ButtonDeleteContact.Click += new System.EventHandler(this.ButtonDeleteContact_Click);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonPalette1.ButtonSpecs.FormClose.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.kryptonPalette1.ButtonSpecs.FormMax.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.kryptonPalette1.ButtonSpecs.FormMin.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 8;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            this.kryptonPalette1.PalettePaint += new System.EventHandler<ComponentFactory.Krypton.Toolkit.PaletteLayoutEventArgs>(this.kryptonPalette1_PalettePaint);
            // 
            // ContactsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 320);
            this.Controls.Add(this.ButtonDeleteContact);
            this.Controls.Add(this.ButtonAddContact);
            this.Controls.Add(this.ListBoxContacts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ContactsForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.Text = "Contacts";
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}