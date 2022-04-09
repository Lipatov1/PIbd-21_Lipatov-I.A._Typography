using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;

namespace TypographyView {
    public partial class FormClients : Form {
        private readonly IClientLogic logic;

        public FormClients(IClientLogic logic) {
            this.logic = logic;
            InitializeComponent();
        }

        private void LoadData() {
            var list = logic.Read(null);

            if (list != null) {
                dataGridViewClients.DataSource = list;
                dataGridViewClients.Columns[0].Visible = false;
                dataGridViewClients.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FormClients_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            if (dataGridViewClients.SelectedRows.Count == 1) {

                if (MessageBox.Show("Удалить клиента", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes) {
                    int id = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
                    try {
                        logic.Delete(new ClientBindingModel { Id = id });
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}