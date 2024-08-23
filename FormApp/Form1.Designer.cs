namespace FormApp
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
            this.btn_saveContact = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_firstName = new System.Windows.Forms.TextBox();
            this.txt_lastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_phoneNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_saveContact
            // 
            this.btn_saveContact.Location = new System.Drawing.Point(265, 205);
            this.btn_saveContact.Name = "btn_saveContact";
            this.btn_saveContact.Size = new System.Drawing.Size(75, 23);
            this.btn_saveContact.TabIndex = 0;
            this.btn_saveContact.Text = "تایید";
            this.btn_saveContact.UseVisualStyleBackColor = true;
            this.btn_saveContact.Click += new System.EventHandler(this.saveContactClickHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(575, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام";
            this.label1.UseCompatibleTextRendering = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(575, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام خانوادگی";
            // 
            // txt_firstName
            // 
            this.txt_firstName.Location = new System.Drawing.Point(387, 67);
            this.txt_firstName.Name = "txt_firstName";
            this.txt_firstName.Size = new System.Drawing.Size(157, 22);
            this.txt_firstName.TabIndex = 3;
            this.txt_firstName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_lastName
            // 
            this.txt_lastName.Location = new System.Drawing.Point(387, 109);
            this.txt_lastName.Name = "txt_lastName";
            this.txt_lastName.Size = new System.Drawing.Size(157, 22);
            this.txt_lastName.TabIndex = 4;
            this.txt_lastName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(575, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "شماره تماس";
            // 
            // txt_phoneNumber
            // 
            this.txt_phoneNumber.Location = new System.Drawing.Point(387, 156);
            this.txt_phoneNumber.Name = "txt_phoneNumber";
            this.txt_phoneNumber.Size = new System.Drawing.Size(157, 22);
            this.txt_phoneNumber.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_phoneNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_lastName);
            this.Controls.Add(this.txt_firstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_saveContact);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "فرم ثبت نام";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_saveContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_firstName;
        private System.Windows.Forms.TextBox txt_lastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_phoneNumber;
    }
}

