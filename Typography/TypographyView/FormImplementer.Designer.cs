
namespace TypographyView
{
    partial class FormImplementer
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
            this.textBoxWorkingTime = new System.Windows.Forms.TextBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelWorkingTime = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxPauseTime = new System.Windows.Forms.TextBox();
            this.labelPauseTime = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxWorkingTime
            // 
            this.textBoxWorkingTime.Location = new System.Drawing.Point(130, 41);
            this.textBoxWorkingTime.Name = "textBoxWorkingTime";
            this.textBoxWorkingTime.Size = new System.Drawing.Size(220, 23);
            this.textBoxWorkingTime.TabIndex = 9;
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(130, 12);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(220, 23);
            this.textBoxFIO.TabIndex = 8;
            // 
            // labelWorkingTime
            // 
            this.labelWorkingTime.AutoSize = true;
            this.labelWorkingTime.Location = new System.Drawing.Point(12, 44);
            this.labelWorkingTime.Name = "labelWorkingTime";
            this.labelWorkingTime.Size = new System.Drawing.Size(89, 15);
            this.labelWorkingTime.TabIndex = 7;
            this.labelWorkingTime.Text = "Время работы:";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(12, 15);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(112, 15);
            this.labelFIO.TabIndex = 6;
            this.labelFIO.Text = "ФИО исполнителя:";
            // 
            // textBoxPauseTime
            // 
            this.textBoxPauseTime.Location = new System.Drawing.Point(130, 70);
            this.textBoxPauseTime.Name = "textBoxPauseTime";
            this.textBoxPauseTime.Size = new System.Drawing.Size(220, 23);
            this.textBoxPauseTime.TabIndex = 11;
            // 
            // labelPauseTime
            // 
            this.labelPauseTime.AutoSize = true;
            this.labelPauseTime.Location = new System.Drawing.Point(12, 73);
            this.labelPauseTime.Name = "labelPauseTime";
            this.labelPauseTime.Size = new System.Drawing.Size(87, 15);
            this.labelPauseTime.TabIndex = 10;
            this.labelPauseTime.Text = "Время отдыха:";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(182, 99);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 13;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(263, 99);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 12;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 129);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.textBoxPauseTime);
            this.Controls.Add(this.labelPauseTime);
            this.Controls.Add(this.textBoxWorkingTime);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelWorkingTime);
            this.Controls.Add(this.labelFIO);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWorkingTime;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label labelWorkingTime;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.TextBox textBoxPauseTime;
        private System.Windows.Forms.Label labelPauseTime;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
    }
}