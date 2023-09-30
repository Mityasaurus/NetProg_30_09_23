namespace ClientUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConnect = new Button();
            label1 = new Label();
            tb_IP = new TextBox();
            label2 = new Label();
            tb_Port = new TextBox();
            btnGetQuote = new Button();
            tb_quote = new TextBox();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(471, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(140, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 1;
            label1.Text = "IP";
            // 
            // tb_IP
            // 
            tb_IP.Location = new Point(35, 12);
            tb_IP.Name = "tb_IP";
            tb_IP.Size = new Size(166, 23);
            tb_IP.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 16);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // tb_Port
            // 
            tb_Port.Location = new Point(285, 13);
            tb_Port.Name = "tb_Port";
            tb_Port.Size = new Size(124, 23);
            tb_Port.TabIndex = 4;
            // 
            // btnGetQuote
            // 
            btnGetQuote.Location = new Point(35, 70);
            btnGetQuote.Name = "btnGetQuote";
            btnGetQuote.Size = new Size(576, 23);
            btnGetQuote.TabIndex = 5;
            btnGetQuote.Text = "Get random quote";
            btnGetQuote.UseVisualStyleBackColor = true;
            btnGetQuote.Click += btnGetQuote_Click;
            // 
            // tb_quote
            // 
            tb_quote.Enabled = false;
            tb_quote.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tb_quote.Location = new Point(35, 120);
            tb_quote.Multiline = true;
            tb_quote.Name = "tb_quote";
            tb_quote.Size = new Size(576, 179);
            tb_quote.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 328);
            Controls.Add(tb_quote);
            Controls.Add(btnGetQuote);
            Controls.Add(tb_Port);
            Controls.Add(label2);
            Controls.Add(tb_IP);
            Controls.Add(label1);
            Controls.Add(btnConnect);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Label label1;
        private TextBox tb_IP;
        private Label label2;
        private TextBox tb_Port;
        private Button btnGetQuote;
        private TextBox tb_quote;
    }
}