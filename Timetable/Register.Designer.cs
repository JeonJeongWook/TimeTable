namespace Timetable
{
    partial class Register
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
            this.bt_register = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.lb_id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.bt_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_register
            // 
            this.bt_register.Location = new System.Drawing.Point(175, 246);
            this.bt_register.Name = "bt_register";
            this.bt_register.Size = new System.Drawing.Size(83, 28);
            this.bt_register.TabIndex = 7;
            this.bt_register.Text = "가입완료";
            this.bt_register.UseVisualStyleBackColor = true;
            this.bt_register.Click += new System.EventHandler(this.bt_register_Click);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(228, 146);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(168, 25);
            this.tb_password.TabIndex = 4;
            this.tb_password.UseSystemPasswordChar = true;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(228, 105);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(168, 25);
            this.tb_id.TabIndex = 2;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(137, 149);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(67, 15);
            this.lb_password.TabIndex = 3;
            this.lb_password.Text = "비밀번호";
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Location = new System.Drawing.Point(137, 108);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(52, 15);
            this.lb_id.TabIndex = 1;
            this.lb_id.Text = "아이디";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(159, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "회원가입";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "이름";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(228, 188);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(168, 25);
            this.tb_name.TabIndex = 6;
            // 
            // bt_back
            // 
            this.bt_back.Location = new System.Drawing.Point(281, 246);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(83, 28);
            this.bt_back.TabIndex = 8;
            this.bt_back.Text = "돌아가기";
            this.bt_back.UseVisualStyleBackColor = true;
            this.bt_back.Click += new System.EventHandler(this.bt_back_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 303);
            this.Controls.Add(this.bt_back);
            this.Controls.Add(this.bt_register);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_id);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_register;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label lb_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button bt_back;
    }
}