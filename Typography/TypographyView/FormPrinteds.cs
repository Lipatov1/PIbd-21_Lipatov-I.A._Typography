using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;
using Unity;

namespace TypographyView {
    public partial class FormPrinteds : Form {
        private readonly IPrintedLogic logic;

        public FormPrinteds(IPrintedLogic _logic) {
            InitializeComponent();
            logic = _logic;
        }

        private void FormPrinteds_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                var list = logic.Read(null);

                if (list != null) {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRef_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormPrinted>();

            if (form.ShowDialog() == DialogResult.OK) {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                var form = Program.Container.Resolve<FormPrinted>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                if (form.ShowDialog() == DialogResult.OK) {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    
                    try {
                        logic.Delete(new PrintedBindingModel { Id = id });
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }
                    LoadData();
                }
            }
        }
    }
}