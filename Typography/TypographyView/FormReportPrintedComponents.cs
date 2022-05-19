using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System;

namespace TypographyView {
    public partial class FormReportPrintedComponents : Form {
        private readonly IReportLogic _logic;

        public FormReportPrintedComponents(IReportLogic logic)  {
            InitializeComponent();
            _logic = logic;
        }

        private void FormReportPrintedComponents_Load(object sender, EventArgs e) {
            try {
                MethodInfo method = _logic.GetType().GetMethod("GetPrintedComponent");
                var dict = (List<ReportPrintedComponentViewModel>)method.Invoke(_logic, null);

                if (dict != null) {
                    dataGridView.Rows.Clear();

                    foreach (var elem in dict) {
                        dataGridView.Rows.Add(new object[] { elem.PrintedName, "", "" });

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

        private void ButtonSaveToExcel_Click(object sender, EventArgs e) {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };

            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    MethodInfo method = _logic.GetType().GetMethod("SavePrintedComponentToExcelFile");
                    method.Invoke(_logic, new object[] { new ReportBindingModel { FileName = dialog.FileName } });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}