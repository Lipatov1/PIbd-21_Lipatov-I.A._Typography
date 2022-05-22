
namespace TypographyView
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplenishWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImplementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentPrintedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonCreateOrder = new System.Windows.Forms.Button();
            this.ButtonIssuedOrder = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.DoWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImplementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WarehousComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersByDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReferencesToolStripMenuItem,
            this.ReportsToolStripMenuItem,
            this.DoWorkToolStripMenuItem,
            this.ReplenishWarehouseToolStripMenuItem,
            this.messageToolStripMenuItem,
            this.CreateBackupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ReferencesToolStripMenuItem
            // 
            this.ReferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentsToolStripMenuItem,
            this.PrintedsToolStripMenuItem,
            this.ClientsToolStripMenuItem,
            this.ImplementersToolStripMenuItem,
            this.WarehouseToolStripMenuItem});
            this.ReferencesToolStripMenuItem.Name = "ReferencesToolStripMenuItem";
            this.ReferencesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.ReferencesToolStripMenuItem.Text = "Справочники";
            // 
            // componentsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            this.componentsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.componentsToolStripMenuItem.Text = "Компоненты";
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // PrintedsToolStripMenuItem
            // 
            this.PrintedsToolStripMenuItem.Name = "PrintedsToolStripMenuItem";
            this.PrintedsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.PrintedsToolStripMenuItem.Text = "Печатная продукция";
            this.PrintedsToolStripMenuItem.Click += new System.EventHandler(this.PrintedsToolStripMenuItem_Click);
            // 
            // ClientsToolStripMenuItem
            // 
            this.ClientsToolStripMenuItem.Name = "ClientsToolStripMenuItem";
            this.ClientsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ClientsToolStripMenuItem.Text = "Клиенты";
            this.ClientsToolStripMenuItem.Click += new System.EventHandler(this.ClientsToolStripMenuItem_Click);
            // 
            // WarehouseToolStripMenuItem
            // 
            this.WarehouseToolStripMenuItem.Name = "WarehouseToolStripMenuItem";
            this.WarehouseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.WarehouseToolStripMenuItem.Text = "Склады";
            this.WarehouseToolStripMenuItem.Click += new System.EventHandler(this.WarehouseToolStripMenuItem_Click);
            // 
            // ReplenishWarehouseToolStripMenuItem
            // 
            this.ReplenishWarehouseToolStripMenuItem.Name = "ReplenishWarehouseToolStripMenuItem";
            this.ReplenishWarehouseToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.ReplenishWarehouseToolStripMenuItem.Text = "Пополнение склада";
            this.ReplenishWarehouseToolStripMenuItem.Click += new System.EventHandler(this.ReplenishWarehouseToolStripMenuItem_Click);
            // 
            // ImplementersToolStripMenuItem
            // 
            this.ImplementersToolStripMenuItem.Name = "ImplementersToolStripMenuItem";
            this.ImplementersToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ImplementersToolStripMenuItem.Text = "Исполнители";
            this.ImplementersToolStripMenuItem.Click += new System.EventHandler(this.ImplementersToolStripMenuItem_Click);
            // 
            // ReportsToolStripMenuItem
            // 
            this.ReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListComponentsToolStripMenuItem,
            this.ComponentPrintedsToolStripMenuItem,
            this.ListOrdersToolStripMenuItem,
            this.ListWarehouseToolStripMenuItem,
            this.WarehousComponentsToolStripMenuItem,
            this.OrdersByDateToolStripMenuItem});
            this.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem";
            this.ReportsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ReportsToolStripMenuItem.Text = "Отчеты";
            // 
            // ListComponentsToolStripMenuItem
            // 
            this.ListComponentsToolStripMenuItem.Name = "ListComponentsToolStripMenuItem";
            this.ListComponentsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ListComponentsToolStripMenuItem.Text = "Список компонентов";
            this.ListComponentsToolStripMenuItem.Click += new System.EventHandler(this.ListComponentsToolStripMenuItem_Click);
            // 
            // ComponentPrintedsToolStripMenuItem
            // 
            this.ComponentPrintedsToolStripMenuItem.Name = "ComponentPrintedsToolStripMenuItem";
            this.ComponentPrintedsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ComponentPrintedsToolStripMenuItem.Text = "Компоненты по изделиям";
            this.ComponentPrintedsToolStripMenuItem.Click += new System.EventHandler(this.ComponentPrintedsToolStripMenuItem_Click);
            // 
            // ListOrdersToolStripMenuItem
            // 
            this.ListOrdersToolStripMenuItem.Name = "ListOrdersToolStripMenuItem";
            this.ListOrdersToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ListOrdersToolStripMenuItem.Text = "Список заказов";
            this.ListOrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // DoWorkToolStripMenuItem
            // 
            this.DoWorkToolStripMenuItem.Name = "DoWorkToolStripMenuItem";
            this.DoWorkToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.DoWorkToolStripMenuItem.Text = "Запуск работ";
            this.DoWorkToolStripMenuItem.Click += new System.EventHandler(this.DoWorkToolStripMenuItem_Click);
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.messageToolStripMenuItem.Text = "Письма";
            this.messageToolStripMenuItem.Click += new System.EventHandler(this.messageToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(849, 337);
            this.dataGridView.TabIndex = 1;
            // 
            // ButtonCreateOrder
            // 
            this.ButtonCreateOrder.Location = new System.Drawing.Point(862, 140);
            this.ButtonCreateOrder.Name = "ButtonCreateOrder";
            this.ButtonCreateOrder.Size = new System.Drawing.Size(127, 23);
            this.ButtonCreateOrder.TabIndex = 2;
            this.ButtonCreateOrder.Text = "Создать заказ";
            this.ButtonCreateOrder.UseVisualStyleBackColor = true;
            this.ButtonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // ButtonIssuedOrder
            // 
            this.ButtonIssuedOrder.Location = new System.Drawing.Point(862, 180);
            this.ButtonIssuedOrder.Name = "ButtonIssuedOrder";
            this.ButtonIssuedOrder.Size = new System.Drawing.Size(127, 23);
            this.ButtonIssuedOrder.TabIndex = 5;
            this.ButtonIssuedOrder.Text = "Заказ выдан";
            this.ButtonIssuedOrder.UseVisualStyleBackColor = true;
            this.ButtonIssuedOrder.Click += new System.EventHandler(this.ButtonIssuedOrder_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Location = new System.Drawing.Point(862, 220);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(127, 23);
            this.ButtonRef.TabIndex = 6;
            this.ButtonRef.Text = "Обновить список";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // CreateBackupToolStripMenuItem
            // 
            this.CreateBackupToolStripMenuItem.Name = "CreateBackupToolStripMenuItem";
            this.CreateBackupToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.CreateBackupToolStripMenuItem.Text = "Создать бекап";
            this.CreateBackupToolStripMenuItem.Click += new System.EventHandler(this.CreateBackupToolStripMenuItem_Click);
            // 
            // ListWarehouseToolStripMenuItem
            // 
            this.ListWarehouseToolStripMenuItem.Name = "ListWarehouseToolStripMenuItem";
            this.ListWarehouseToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ListWarehouseToolStripMenuItem.Text = "Список складов";
            this.ListWarehouseToolStripMenuItem.Click += new System.EventHandler(this.ListWarehouseToolStripMenuItem_Click);
            // 
            // WarehousComponentsToolStripMenuItem
            // 
            this.WarehousComponentsToolStripMenuItem.Name = "WarehousComponentsToolStripMenuItem";
            this.WarehousComponentsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.WarehousComponentsToolStripMenuItem.Text = "Склады по компонентам";
            this.WarehousComponentsToolStripMenuItem.Click += new System.EventHandler(this.WarehousComponentsToolStripMenuItem_Click);
            // 
            // OrdersByDateToolStripMenuItem
            // 
            this.OrdersByDateToolStripMenuItem.Name = "OrdersByDateToolStripMenuItem";
            this.OrdersByDateToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.OrdersByDateToolStripMenuItem.Text = "Список заказов по датам";
            this.OrdersByDateToolStripMenuItem.Click += new System.EventHandler(this.OrdersByDateToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 361);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonIssuedOrder);
            this.Controls.Add(this.ButtonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Типография";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ReferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonCreateOrder;
        private System.Windows.Forms.Button ButtonIssuedOrder;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStripMenuItem PrintedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentPrintedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImplementersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplenishWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WarehousComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersByDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateBackupToolStripMenuItem;
    }
}