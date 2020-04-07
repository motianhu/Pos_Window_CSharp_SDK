namespace InvokeDll
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.payBt = new System.Windows.Forms.Button();
            this.qrCodeTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.highPriceBt = new System.Windows.Forms.Button();
            this.orderNoLb = new System.Windows.Forms.Label();
            this.cancelPrepayBt = new System.Windows.Forms.Button();
            this.refundBt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logLb = new System.Windows.Forms.TextBox();
            this.macAddressLb = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.orderPriceTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // payBt
            // 
            this.payBt.Location = new System.Drawing.Point(12, 290);
            this.payBt.Name = "payBt";
            this.payBt.Size = new System.Drawing.Size(168, 67);
            this.payBt.TabIndex = 0;
            this.payBt.Text = "下单(B扫C)";
            this.payBt.UseVisualStyleBackColor = true;
            this.payBt.Click += new System.EventHandler(this.button1_Click);
            // 
            // qrCodeTb
            // 
            this.qrCodeTb.Location = new System.Drawing.Point(25, 199);
            this.qrCodeTb.Name = "qrCodeTb";
            this.qrCodeTb.Size = new System.Drawing.Size(142, 21);
            this.qrCodeTb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "输入用户二维码：";
            // 
            // highPriceBt
            // 
            this.highPriceBt.Location = new System.Drawing.Point(115, 60);
            this.highPriceBt.Name = "highPriceBt";
            this.highPriceBt.Size = new System.Drawing.Size(111, 33);
            this.highPriceBt.TabIndex = 3;
            this.highPriceBt.Text = "获取销售订单";
            this.highPriceBt.UseVisualStyleBackColor = true;
            this.highPriceBt.Click += new System.EventHandler(this.highPriceBt_Click);
            // 
            // orderNoLb
            // 
            this.orderNoLb.AutoSize = true;
            this.orderNoLb.Location = new System.Drawing.Point(115, 119);
            this.orderNoLb.Name = "orderNoLb";
            this.orderNoLb.Size = new System.Drawing.Size(23, 12);
            this.orderNoLb.TabIndex = 4;
            this.orderNoLb.Text = "   ";
            // 
            // cancelPrepayBt
            // 
            this.cancelPrepayBt.Location = new System.Drawing.Point(595, 119);
            this.cancelPrepayBt.Name = "cancelPrepayBt";
            this.cancelPrepayBt.Size = new System.Drawing.Size(168, 67);
            this.cancelPrepayBt.TabIndex = 0;
            this.cancelPrepayBt.Text = "撤单";
            this.cancelPrepayBt.UseVisualStyleBackColor = true;
            this.cancelPrepayBt.Click += new System.EventHandler(this.cancelPrepayBt_Click);
            // 
            // refundBt
            // 
            this.refundBt.Location = new System.Drawing.Point(595, 224);
            this.refundBt.Name = "refundBt";
            this.refundBt.Size = new System.Drawing.Size(168, 67);
            this.refundBt.TabIndex = 0;
            this.refundBt.Text = "退款";
            this.refundBt.UseVisualStyleBackColor = true;
            this.refundBt.Click += new System.EventHandler(this.refundBt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(595, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "请输入退款金额：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(834, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "日志：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logLb);
            this.panel1.Location = new System.Drawing.Point(836, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 482);
            this.panel1.TabIndex = 6;
            // 
            // logLb
            // 
            this.logLb.Location = new System.Drawing.Point(0, 3);
            this.logLb.Multiline = true;
            this.logLb.Name = "logLb";
            this.logLb.Size = new System.Drawing.Size(705, 476);
            this.logLb.TabIndex = 3;
            // 
            // macAddressLb
            // 
            this.macAddressLb.AutoSize = true;
            this.macAddressLb.Location = new System.Drawing.Point(61, 453);
            this.macAddressLb.Name = "macAddressLb";
            this.macAddressLb.Size = new System.Drawing.Size(0, 12);
            this.macAddressLb.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "下单(C扫B)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "销售订单号：";
            // 
            // orderPriceTb
            // 
            this.orderPriceTb.Location = new System.Drawing.Point(115, 18);
            this.orderPriceTb.Name = "orderPriceTb";
            this.orderPriceTb.Size = new System.Drawing.Size(142, 21);
            this.orderPriceTb.TabIndex = 1;
            this.orderPriceTb.Text = "2.01";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "请输入订单金额：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 51);
            this.button2.TabIndex = 7;
            this.button2.Text = "查询支付结果";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 556);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orderNoLb);
            this.Controls.Add(this.highPriceBt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.macAddressLb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderPriceTb);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.qrCodeTb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.refundBt);
            this.Controls.Add(this.cancelPrepayBt);
            this.Controls.Add(this.payBt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button payBt;
        private System.Windows.Forms.TextBox qrCodeTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button highPriceBt;
        private System.Windows.Forms.Label orderNoLb;
        private System.Windows.Forms.Button cancelPrepayBt;
        private System.Windows.Forms.Button refundBt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label macAddressLb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox orderPriceTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox logLb;
    }
}

