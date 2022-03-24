using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;

namespace TypographyView {
    public partial class FormReportPrintedComponents : Form {
        private readonly IReportLogic _logic;

        public FormReportPrintedComponents(IReportLogic logic)  {
            InitializeComponent();
            _logic = logic;
        }

        private void FormReportProductComponents_Load(object sender, EventArgs e) {
            try {
                var dict = _logic.GetPrintedComponent();
      
                if (dict != null) {
                    dataGridView.Rows.Clear();

                    foreach (var elem in dict) {
                        dataGridView.Rows.Add(new object[] { elem.ComponentName, "", "" });

                        foreach (var listElem in elem.Printeds) {
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

        private void ButtonSaveToExcel_Click(object sender, EventArgs e) {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    _logic.SavePrintedComponentToExcelFile(new ReportBindingModel {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}