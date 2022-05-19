using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;
using Unity;

namespace TypographyView {
    public partial class FormWarehouses : Form {
        private readonly IWarehouseLogic _logic;

        public FormWarehouses(IWarehouseLogic logic) {
            InitializeComponent();
            _logic = logic;
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormWarehouse>();

            if (form.ShowDialog() == DialogResult.OK) {
                LoadData();
            }
        }

        private void FormWarehouses_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                Program.ConfigGrid(_logic.Read(null), dataGridView);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                var form = Program.Container.Resolve<FormWarehouse>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                if (form.ShowDialog() == DialogResult.OK) {
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    
                    try {
                        _logic.Delete(new WarehouseBindingModel { Id = id });
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e) {
            LoadData();
        }
    }
}