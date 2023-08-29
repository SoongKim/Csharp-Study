namespace Transfer
{
    partial class UrlForm
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
            UrlBox = new TextBox();
            PortBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // UrlBox
            // 
            UrlBox.Location = new Point(12, 39);
            UrlBox.Name = "UrlBox";
            UrlBox.Size = new Size(382, 23);
            UrlBox.TabIndex = 0;
            UrlBox.Text = "localhost";
            // 
            // PortBox
            // 
            PortBox.Location = new Point(12, 91);
            PortBox.Name = "PortBox";
            PortBox.Size = new Size(382, 23);
            PortBox.TabIndex = 1;
            PortBox.Text = "7251";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(71, 17);
            label1.TabIndex = 2;
            label1.Text = "URL(http) :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(40, 17);
            label2.TabIndex = 3;
            label2.Text = "Port :";
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 130);
            button1.Name = "button1";
            button1.Size = new Size(382, 23);
            button1.TabIndex = 4;
            button1.Text = "설정 완료";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SetClick;
            // 
            // UrlForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 165);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PortBox);
            Controls.Add(UrlBox);
            Name = "UrlForm";
            Text = "파일 전송 URL을 설정합니다.";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UrlBox;
        private TextBox PortBox;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}