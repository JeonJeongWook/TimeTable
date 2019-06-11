namespace Timetable
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_passwd = new System.Windows.Forms.TextBox();
            this.bt_goRegister = new System.Windows.Forms.Button();
            this.bt_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(182, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "로그인";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "아이디";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "비밀번호";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(225, 143);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(168, 25);
            this.tb_id.TabIndex = 2;
            // 
            // tb_passwd
            // 
            this.tb_passwd.Location = new System.Drawing.Point(225, 184);
            this.tb_passwd.Name = "tb_passwd";
            this.tb_passwd.Size = new System.Drawing.Size(168, 25);
            this.tb_passwd.TabIndex = 4;
            // 
            // bt_goRegister
            // 
            this.bt_goRegister.Location = new System.Drawing.Point(282, 253);
            this.bt_goRegister.Name = "bt_goRegister";
            this.bt_goRegister.Size = new System.Drawing.Size(83, 28);
            this.bt_goRegister.TabIndex = 6;
            this.bt_goRegister.Text = "회원가입";
            this.bt_goRegister.UseVisualStyleBackColor = true;
            this.bt_goRegister.Click += new System.EventHandler(this.bt_goRegister_Click);
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(179, 253);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(83, 28);
            this.bt_login.TabIndex = 5;
            this.bt_login.Text = "로그인";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 303);
            this.Controls.Add(this.bt_login);
            this.Controls.Add(this.bt_goRegister);
            this.Controls.Add(this.tb_passwd);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_passwd;
        private System.Windows.Forms.Button bt_goRegister;
        private System.Windows.Forms.Button bt_login;
    }
}