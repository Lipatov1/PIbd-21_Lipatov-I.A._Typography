using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;

namespace TypographyView {
    public partial class FormReportWarehouseComponent : Form {
        private readonly IReportLogic logic;

        public FormReportWarehouseComponent(IReportLogic logic) {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e) {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    logic.SaveWarehouseComponentToExcelFile(new ReportBindingModel {
                        FileName = dialog.FileName
                    });

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormWarehouseComponent_Load(object sender, EventArgs e) {
            try {
                var dict = logic.GetWarehouseComponent();

                if (dict != null) {
                    dataGridView.Rows.Clear();

                    foreach (var elem in dict) {
                        dataGridView.Rows.Add(new object[] { elem.WarehouseName, "", "" });

                        foreach (var listElem in elem.Components) {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}