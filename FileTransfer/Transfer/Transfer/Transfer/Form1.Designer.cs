namespace Transfer
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
            FileBtn = new Button();
            FileNameBox = new TextBox();
            TransferBtn = new Button();
            UrlBtn = new Button();
            SuspendLayout();
            // 
            // FileBtn
            // 
            FileBtn.Location = new Point(17, 12);
            FileBtn.Name = "FileBtn";
            FileBtn.Size = new Size(117, 25);
            FileBtn.TabIndex = 0;
            FileBtn.Text = "파일 선택";
            FileBtn.UseVisualStyleBackColor = true;
            FileBtn.Click += FileBtnClick;
            // 
            // FileNameBox
            // 
            FileNameBox.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FileNameBox.Location = new Point(140, 12);
            FileNameBox.Name = "FileNameBox";
            FileNameBox.Size = new Size(439, 25);
            FileNameBox.TabIndex = 1;
            // 
            // TransferBtn
            // 
            TransferBtn.Location = new Point(708, 12);
            TransferBtn.Name = "TransferBtn";
            TransferBtn.Size = new Size(117, 25);
            TransferBtn.TabIndex = 2;
            TransferBtn.Text = "파일 전송";
            TransferBtn.UseVisualStyleBackColor = true;
            TransferBtn.Click += TransferClick;
            // 
            // UrlBtn
            // 
            UrlBtn.Location = new Point(585, 12);
            UrlBtn.Name = "UrlBtn";
            UrlBtn.Size = new Size(117, 25);
            UrlBtn.TabIndex = 3;
            UrlBtn.Text = "주소 입력";
            UrlBtn.UseVisualStyleBackColor = true;
            UrlBtn.Click += UrlBtnClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 51);
            Controls.Add(UrlBtn);
            Controls.Add(TransferBtn);
            Controls.Add(FileNameBox);
            Controls.Add(FileBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button FileBtn;
        private TextBox FileNameBox;
        private Button TransferBtn;
        private Button UrlBtn;
    }
}