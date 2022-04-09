﻿using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;
using Unity;

namespace TypographyView {
    public partial class FormMain : Form {
        private readonly IOrderLogic _orderLogic;
        private readonly IReportLogic _reportLogic;

        public FormMain(IOrderLogic orderLogic, IReportLogic reportLogic) {
            InitializeComponent();
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
        }

        private void FormMain_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                var list = _orderLogic.Read(null);

                if (list != null) {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComponentsToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormComponents>();
            form.ShowDialog();
        }

        private void PrintedsToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormPrinteds>();
            form.ShowDialog();
        }
                
        private void ListComponentsToolStripMenuItem_Click(object sender, EventArgs e) {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                _reportLogic.SavePrintedsToWordFile(new ReportBindingModel {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ComponentPrintedsToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormReportPrintedComponents>();
            form.ShowDialog();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void WarehouseToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormWarehouses>();
            form.ShowDialog();
        }

        private void ReplenishWarehouseToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormReplenishWarehouse>();
            form.ShowDialog();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                try {
                    _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel {
                        OrderId = id
                    });

                    LoadData();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonOrderReady_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                try {
                    _orderLogic.FinishOrder(new ChangeStatusBindingModel {
                        OrderId = id
                    });

                    LoadData();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonIssuedOrder_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                try {
                    _orderLogic.DeliveryOrder(new ChangeStatusBindingModel {
                        OrderId = id
                    });

                    LoadData();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e) {
            LoadData();
        }
    }
}