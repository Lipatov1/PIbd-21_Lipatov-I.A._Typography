
namespace TypographyView
{
    partial class FormMessage
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
            this.labelSenderName = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.RichTextBoxBody = new System.Windows.Forms.RichTextBox();
            this.buttonReply = new System.Windows.Forms.Button();
            this.richTextBoxReply = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonCalcel = new System.Windows.Forms.Button();
            this.SenderName = new System.Windows.Forms.Label();
            this.DateDelivery = new System.Windows.Forms.Label();
            this.Subject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSenderName
            // 
            this.labelSenderName.AutoSize = true;
            this.labelSenderName.Location = new System.Drawing.Point(12, 9);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(81, 15);
            this.labelSenderName.TabIndex = 0;
            this.labelSenderName.Text = "Отправитель:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(12, 49);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(68, 15);
            this.labelSubject.TabIndex = 1;
            this.labelSubject.Text = "Заголовок:";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(12, 29);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(79, 15);
            this.labelDateDelivery.TabIndex = 3;
            this.labelDateDelivery.Text = "Дата письма:";
            // 
            // RichTextBoxBody
            // 
            this.RichTextBoxBody.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RichTextBoxBody.Cursor = System.Windows.Forms.Cursors.Default;
            this.RichTextBoxBody.Location = new System.Drawing.Point(12, 76);
            this.RichTextBoxBody.Name = "RichTextBoxBody";
            this.RichTextBoxBody.ReadOnly = true;
            this.RichTextBoxBody.Size = new System.Drawing.Size(776, 150);
            this.RichTextBoxBody.TabIndex = 5;
            this.RichTextBoxBody.Text = "";
            // 
            // buttonReply
            // 
            this.buttonReply.Location = new System.Drawing.Point(713, 232);
            this.buttonReply.Name = "buttonReply";
            this.buttonReply.Size = new System.Drawing.Size(75, 23);
            this.buttonReply.TabIndex = 6;
            this.buttonReply.Text = "Ответить";
            this.buttonReply.UseVisualStyleBackColor = true;
            this.buttonReply.Click += new System.EventHandler(this.buttonReply_Click);
            // 
            // richTextBoxReply
            // 
            this.richTextBoxReply.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxReply.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBoxReply.Location = new System.Drawing.Point(12, 261);
            this.richTextBoxReply.Name = "richTextBoxReply";
            this.richTextBoxReply.Size = new System.Drawing.Size(776, 150);
            this.richTextBoxReply.TabIndex = 7;
            this.richTextBoxReply.Text = "";
            this.richTextBoxReply.Visible = false;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(632, 417);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Visible = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonCalcel
            // 
            this.buttonCalcel.Location = new System.Drawing.Point(713, 417);
            this.buttonCalcel.Name = "buttonCalcel";
            this.buttonCalcel.Size = new System.Drawing.Size(75, 23);
            this.buttonCalcel.TabIndex = 9;
            this.buttonCalcel.Text = "Отмена";
            this.buttonCalcel.UseVisualStyleBackColor = true;
            this.buttonCalcel.Visible = false;
            this.buttonCalcel.Click += new System.EventHandler(this.buttonCalcel_Click);
            // 
            // SenderName
            // 
            this.SenderName.AutoSize = true;
            this.SenderName.Location = new System.Drawing.Point(99, 9);
            this.SenderName.Name = "SenderName";
            this.SenderName.Size = new System.Drawing.Size(10, 15);
            this.SenderName.TabIndex = 10;
            this.SenderName.Text = " ";
            // 
            // DateDelivery
            // 
            this.DateDelivery.AutoSize = true;
            this.DateDelivery.Location = new System.Drawing.Point(97, 29);
            this.DateDelivery.Name = "DateDelivery";
            this.DateDelivery.Size = new System.Drawing.Size(10, 15);
            this.DateDelivery.TabIndex = 11;
            this.DateDelivery.Text = " ";
            // 
            // Subject
            // 
            this.Subject.AutoSize = true;
            this.Subject.Location = new System.Drawing.Point(86, 49);
            this.Subject.Name = "Subject";
            this.Subject.Size = new System.Drawing.Size(10, 15);
            this.Subject.TabIndex = 12;
            this.Subject.Text = " ";
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.Subject);
            this.Controls.Add(this.DateDelivery);
            this.Controls.Add(this.SenderName);
            this.Controls.Add(this.buttonCalcel);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.richTextBoxReply);
            this.Controls.Add(this.buttonReply);
            this.Controls.Add(this.RichTextBoxBody);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelSenderName);
            this.Name = "FormMessage";
            this.Text = "Письмо";
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSenderName;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelDateDelivery;
        private System.Windows.Forms.RichTextBox RichTextBoxBody;
        private System.Windows.Forms.Button buttonReply;
        private System.Windows.Forms.RichTextBox richTextBoxReply;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonCalcel;
        private System.Windows.Forms.Label SenderName;
        private System.Windows.Forms.Label DateDelivery;
        private System.Windows.Forms.Label Subject;
    }
}