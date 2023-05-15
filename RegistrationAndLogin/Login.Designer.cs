namespace RegistrationAndLogin
{
    partial class Login
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
            this.lbl1Email = new System.Windows.Forms.Label();
            this.lbl1Pass = new System.Windows.Forms.Label();
            this.txtBox1Email = new System.Windows.Forms.TextBox();
            this.txtBox1Pass = new System.Windows.Forms.TextBox();
            this.btn1Login = new System.Windows.Forms.Button();
            this.lbl1AccQ = new System.Windows.Forms.Label();
            this.btn2Register = new System.Windows.Forms.Button();
            this.lbl1Welcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl1Email
            // 
            this.lbl1Email.AutoSize = true;
            this.lbl1Email.Location = new System.Drawing.Point(139, 103);
            this.lbl1Email.Name = "lbl1Email";
            this.lbl1Email.Size = new System.Drawing.Size(35, 13);
            this.lbl1Email.TabIndex = 0;
            this.lbl1Email.Text = "Email:";
            // 
            // lbl1Pass
            // 
            this.lbl1Pass.AutoSize = true;
            this.lbl1Pass.Location = new System.Drawing.Point(118, 138);
            this.lbl1Pass.Name = "lbl1Pass";
            this.lbl1Pass.Size = new System.Drawing.Size(56, 13);
            this.lbl1Pass.TabIndex = 1;
            this.lbl1Pass.Text = "Password:";
            // 
            // txtBox1Email
            // 
            this.txtBox1Email.Location = new System.Drawing.Point(180, 95);
            this.txtBox1Email.Name = "txtBox1Email";
            this.txtBox1Email.Size = new System.Drawing.Size(356, 20);
            this.txtBox1Email.TabIndex = 2;
            // 
            // txtBox1Pass
            // 
            this.txtBox1Pass.Location = new System.Drawing.Point(180, 131);
            this.txtBox1Pass.Name = "txtBox1Pass";
            this.txtBox1Pass.PasswordChar = '*';
            this.txtBox1Pass.Size = new System.Drawing.Size(356, 20);
            this.txtBox1Pass.TabIndex = 3;
            this.txtBox1Pass.UseSystemPasswordChar = true;
            // 
            // btn1Login
            // 
            this.btn1Login.Location = new System.Drawing.Point(180, 158);
            this.btn1Login.Name = "btn1Login";
            this.btn1Login.Size = new System.Drawing.Size(75, 23);
            this.btn1Login.TabIndex = 4;
            this.btn1Login.Text = "Login";
            this.btn1Login.UseVisualStyleBackColor = true;
            this.btn1Login.Click += new System.EventHandler(this.btn1Login_Click);
            // 
            // lbl1AccQ
            // 
            this.lbl1AccQ.AutoSize = true;
            this.lbl1AccQ.Location = new System.Drawing.Point(180, 188);
            this.lbl1AccQ.Name = "lbl1AccQ";
            this.lbl1AccQ.Size = new System.Drawing.Size(122, 13);
            this.lbl1AccQ.TabIndex = 5;
            this.lbl1AccQ.Text = "Don\'t have an account?";
            // 
            // btn2Register
            // 
            this.btn2Register.Location = new System.Drawing.Point(180, 205);
            this.btn2Register.Name = "btn2Register";
            this.btn2Register.Size = new System.Drawing.Size(75, 23);
            this.btn2Register.TabIndex = 6;
            this.btn2Register.Text = "Register";
            this.btn2Register.UseVisualStyleBackColor = true;
            this.btn2Register.Click += new System.EventHandler(this.btn2Register_Click);
            // 
            // lbl1Welcome
            // 
            this.lbl1Welcome.AutoSize = true;
            this.lbl1Welcome.Location = new System.Drawing.Point(180, 48);
            this.lbl1Welcome.Name = "lbl1Welcome";
            this.lbl1Welcome.Size = new System.Drawing.Size(82, 13);
            this.lbl1Welcome.TabIndex = 7;
            this.lbl1Welcome.Text = "Welcome back,";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl1Welcome);
            this.Controls.Add(this.btn2Register);
            this.Controls.Add(this.lbl1AccQ);
            this.Controls.Add(this.btn1Login);
            this.Controls.Add(this.txtBox1Pass);
            this.Controls.Add(this.txtBox1Email);
            this.Controls.Add(this.lbl1Pass);
            this.Controls.Add(this.lbl1Email);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1Email;
        private System.Windows.Forms.Label lbl1Pass;
        private System.Windows.Forms.TextBox txtBox1Email;
        private System.Windows.Forms.TextBox txtBox1Pass;
        private System.Windows.Forms.Button btn1Login;
        private System.Windows.Forms.Label lbl1AccQ;
        private System.Windows.Forms.Button btn2Register;
        private System.Windows.Forms.Label lbl1Welcome;
    }
}