namespace ItcastCater
{
    partial class FrmChangeMember
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
            this.dtEndServerTime = new System.Windows.Forms.DateTimePicker();
            this.labId = new System.Windows.Forms.Label();
            this.cmbMemType = new System.Windows.Forms.ComboBox();
            this.rdoWomen = new System.Windows.Forms.RadioButton();
            this.rdoMan = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtMemDiscount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMemPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBirs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemIntegral = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmemMoney = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtEndServerTime
            // 
            this.dtEndServerTime.Location = new System.Drawing.Point(339, 172);
            this.dtEndServerTime.Name = "dtEndServerTime";
            this.dtEndServerTime.Size = new System.Drawing.Size(158, 21);
            this.dtEndServerTime.TabIndex = 75;
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Location = new System.Drawing.Point(422, 208);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(0, 12);
            this.labId.TabIndex = 74;
            this.labId.Visible = false;
            // 
            // cmbMemType
            // 
            this.cmbMemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemType.FormattingEnabled = true;
            this.cmbMemType.Location = new System.Drawing.Point(84, 153);
            this.cmbMemType.Name = "cmbMemType";
            this.cmbMemType.Size = new System.Drawing.Size(152, 20);
            this.cmbMemType.TabIndex = 73;
            // 
            // rdoWomen
            // 
            this.rdoWomen.AutoSize = true;
            this.rdoWomen.Location = new System.Drawing.Point(141, 106);
            this.rdoWomen.Name = "rdoWomen";
            this.rdoWomen.Size = new System.Drawing.Size(35, 16);
            this.rdoWomen.TabIndex = 72;
            this.rdoWomen.TabStop = true;
            this.rdoWomen.Text = "女";
            this.rdoWomen.UseVisualStyleBackColor = true;
            // 
            // rdoMan
            // 
            this.rdoMan.AutoSize = true;
            this.rdoMan.Location = new System.Drawing.Point(84, 106);
            this.rdoMan.Name = "rdoMan";
            this.rdoMan.Size = new System.Drawing.Size(35, 16);
            this.rdoMan.TabIndex = 71;
            this.rdoMan.TabStop = true;
            this.rdoMan.Text = "男";
            this.rdoMan.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(297, 203);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtMemDiscount
            // 
            this.txtMemDiscount.Location = new System.Drawing.Point(339, 144);
            this.txtMemDiscount.Name = "txtMemDiscount";
            this.txtMemDiscount.Size = new System.Drawing.Size(152, 21);
            this.txtMemDiscount.TabIndex = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 68;
            this.label9.Text = "折扣:";
            // 
            // txtMemPhone
            // 
            this.txtMemPhone.Location = new System.Drawing.Point(339, 108);
            this.txtMemPhone.Name = "txtMemPhone";
            this.txtMemPhone.Size = new System.Drawing.Size(152, 21);
            this.txtMemPhone.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 61;
            this.label8.Text = "会员电话:";
            // 
            // txtBirs
            // 
            this.txtBirs.Location = new System.Drawing.Point(339, 66);
            this.txtBirs.Name = "txtBirs";
            this.txtBirs.Size = new System.Drawing.Size(152, 21);
            this.txtBirs.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 62;
            this.label7.Text = "生日:";
            // 
            // txtMemIntegral
            // 
            this.txtMemIntegral.Location = new System.Drawing.Point(339, 28);
            this.txtMemIntegral.Name = "txtMemIntegral";
            this.txtMemIntegral.ReadOnly = true;
            this.txtMemIntegral.Size = new System.Drawing.Size(152, 21);
            this.txtMemIntegral.TabIndex = 64;
            this.txtMemIntegral.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 60;
            this.label6.Text = "积分:";
            // 
            // txtmemMoney
            // 
            this.txtmemMoney.Location = new System.Drawing.Point(84, 187);
            this.txtmemMoney.Name = "txtmemMoney";
            this.txtmemMoney.Size = new System.Drawing.Size(152, 21);
            this.txtmemMoney.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 59;
            this.label5.Text = "卡余额:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 58;
            this.label4.Text = "会员等级:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "会员性别:";
            // 
            // txtMemName
            // 
            this.txtMemName.Location = new System.Drawing.Point(84, 63);
            this.txtMemName.Name = "txtMemName";
            this.txtMemName.Size = new System.Drawing.Size(152, 21);
            this.txtMemName.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 56;
            this.label2.Text = "会员姓名:";
            // 
            // txtMemNum
            // 
            this.txtMemNum.Location = new System.Drawing.Point(84, 25);
            this.txtMemNum.Name = "txtMemNum";
            this.txtMemNum.Size = new System.Drawing.Size(152, 21);
            this.txtMemNum.TabIndex = 55;
            this.txtMemNum.Text = "编号自动生成";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "会员编号:";
            // 
            // FrmChangeMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(521, 257);
            this.Controls.Add(this.dtEndServerTime);
            this.Controls.Add(this.labId);
            this.Controls.Add(this.cmbMemType);
            this.Controls.Add(this.rdoWomen);
            this.Controls.Add(this.rdoMan);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtMemDiscount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMemPhone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBirs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMemIntegral);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtmemMoney);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMemNum);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FrmChangeMember";
            this.Text = "FrmChangeMember";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtEndServerTime;
        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.ComboBox cmbMemType;
        private System.Windows.Forms.RadioButton rdoWomen;
        private System.Windows.Forms.RadioButton rdoMan;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtMemDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMemPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBirs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMemIntegral;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmemMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemNum;
        private System.Windows.Forms.Label label1;
    }
}