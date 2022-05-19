using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;
using Unity;

namespace TypographyView {
    public partial class FormMain : Form {
        private readonly IOrderLogic _orderLogic;
        private readonly IReportLogic _reportLogic;
        private readonly IWorkProcess _workProcess;
        private readonly IBackUpLogic _backUpLogic;
        private readonly IImplementerLogic _implementerLogic;

        public FormMain(IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess, IImplementerLogic implementerLogic, IBackUpLogic backUpLogic) {
            InitializeComponent();
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _workProcess = workProcess;
            _implementerLogic = implementerLogic;
            _backUpLogic = backUpLogic;
        }

        private void FormMain_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                Program.ConfigGrid(_orderLogic.Read(null), dataGridView);
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

        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void ImplementersToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormImplementers>();
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

        private void DoWorkToolStripMenuItem_Click(object sender, EventArgs e) {
            _workProcess.DoWork(_implementerLogic, _orderLogic);
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
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

        private void messageToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormMessages>();
            form.ShowDialog();
        }

        private void CreateBackupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (_backUpLogic != null) {
                    var fbd = new FolderBrowserDialog();

                    if (fbd.ShowDialog() == DialogResult.OK) {
                        _backUpLogic.CreateBackUp(new BackUpSaveBinidngModel { FolderName = fbd.SelectedPath });
                        MessageBox.Show("Бекап создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}