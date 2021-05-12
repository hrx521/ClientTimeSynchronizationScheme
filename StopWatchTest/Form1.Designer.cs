
namespace StopWatchTest
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
            this.labelNowTime = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonBeginWatch = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNowTime
            // 
            this.labelNowTime.AutoSize = true;
            this.labelNowTime.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNowTime.Location = new System.Drawing.Point(186, 103);
            this.labelNowTime.Name = "labelNowTime";
            this.labelNowTime.Size = new System.Drawing.Size(166, 24);
            this.labelNowTime.TabIndex = 1;
            this.labelNowTime.Text = "labelNowTime";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "2050-12-23";
            // 
            // buttonBeginWatch
            // 
            this.buttonBeginWatch.Location = new System.Drawing.Point(296, 176);
            this.buttonBeginWatch.Name = "buttonBeginWatch";
            this.buttonBeginWatch.Size = new System.Drawing.Size(100, 26);
            this.buttonBeginWatch.TabIndex = 0;
            this.buttonBeginWatch.Text = "BeginWatch";
            this.buttonBeginWatch.UseVisualStyleBackColor = true;
            this.buttonBeginWatch.Click += new System.EventHandler(this.buttonBeginWatch_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(21, 367);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(77, 12);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "labelMessage";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 458);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelNowTime);
            this.Controls.Add(this.buttonBeginWatch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelNowTime;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonBeginWatch;
        private System.Windows.Forms.Label labelMessage;
    }
}

