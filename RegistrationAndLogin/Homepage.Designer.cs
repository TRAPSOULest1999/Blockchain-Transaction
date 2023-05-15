namespace RegistrationAndLogin
{
    partial class Homepage
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
            this.lblSender = new System.Windows.Forms.Label();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.textBoxFromAddr = new System.Windows.Forms.TextBox();
            this.textBoxToAddr = new System.Windows.Forms.TextBox();
            this.textBoxAmt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl1Password = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.btnSubmitReq = new System.Windows.Forms.Button();
            this.lbl1Response = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Location = new System.Drawing.Point(30, 62);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(74, 13);
            this.lblSender.TabIndex = 0;
            this.lblSender.Text = "From Address:";
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(40, 89);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(64, 13);
            this.lblReceiver.TabIndex = 1;
            this.lblReceiver.Text = "To Address:";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Location = new System.Drawing.Point(55, 116);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(46, 13);
            this.lblAmt.TabIndex = 2;
            this.lblAmt.Text = "Amount:";
            // 
            // textBoxFromAddr
            // 
            this.textBoxFromAddr.Location = new System.Drawing.Point(107, 55);
            this.textBoxFromAddr.Name = "textBoxFromAddr";
            this.textBoxFromAddr.Size = new System.Drawing.Size(401, 20);
            this.textBoxFromAddr.TabIndex = 3;
            // 
            // textBoxToAddr
            // 
            this.textBoxToAddr.Location = new System.Drawing.Point(107, 82);
            this.textBoxToAddr.Name = "textBoxToAddr";
            this.textBoxToAddr.Size = new System.Drawing.Size(400, 20);
            this.textBoxToAddr.TabIndex = 4;
            // 
            // textBoxAmt
            // 
            this.textBoxAmt.Location = new System.Drawing.Point(107, 109);
            this.textBoxAmt.Name = "textBoxAmt";
            this.textBoxAmt.Size = new System.Drawing.Size(401, 20);
            this.textBoxAmt.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(107, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(400, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // lbl1Password
            // 
            this.lbl1Password.AutoSize = true;
            this.lbl1Password.Location = new System.Drawing.Point(76, 143);
            this.lbl1Password.Name = "lbl1Password";
            this.lbl1Password.Size = new System.Drawing.Size(25, 13);
            this.lbl1Password.TabIndex = 7;
            this.lbl1Password.Text = "Pin:";
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(107, 224);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(58, 13);
            this.lblResponse.TabIndex = 8;
            this.lblResponse.Text = "Response:";
            // 
            // btnSubmitReq
            // 
            this.btnSubmitReq.Location = new System.Drawing.Point(110, 163);
            this.btnSubmitReq.Name = "btnSubmitReq";
            this.btnSubmitReq.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitReq.TabIndex = 9;
            this.btnSubmitReq.Text = "Submit Request";
            this.btnSubmitReq.UseVisualStyleBackColor = true;
            this.btnSubmitReq.Click += new System.EventHandler(this.btnSubmitReq_Click);
            // 
            // lbl1Response
            // 
            this.lbl1Response.AutoSize = true;
            this.lbl1Response.Location = new System.Drawing.Point(107, 253);
            this.lbl1Response.Name = "lbl1Response";
            this.lbl1Response.Size = new System.Drawing.Size(66, 13);
            this.lbl1Response.TabIndex = 10;
            this.lbl1Response.Text = "Status Here:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(713, 62);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Exit";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lbl1Response);
            this.Controls.Add(this.btnSubmitReq);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.lbl1Password);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxAmt);
            this.Controls.Add(this.textBoxToAddr);
            this.Controls.Add(this.textBoxFromAddr);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.lblReceiver);
            this.Controls.Add(this.lblSender);
            this.Name = "Homepage";
            this.Text = "Homepage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.TextBox textBoxFromAddr;
        private System.Windows.Forms.TextBox textBoxToAddr;
        private System.Windows.Forms.TextBox textBoxAmt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbl1Password;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Button btnSubmitReq;
        private System.Windows.Forms.Label lbl1Response;
        private System.Windows.Forms.Button btnLogout;
    }
}