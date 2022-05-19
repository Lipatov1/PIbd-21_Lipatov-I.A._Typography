using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System;

namespace TypographyView {
    public partial class FormReportOrdersByDate : Form {
        private readonly ReportViewer reportViewer;
        private readonly IReportLogic logic;

        public FormReportOrdersByDate(IReportLogic logic) {
            InitializeComponent();
            this.logic = logic;

            reportViewer = new ReportViewer {
                Dock = DockStyle.Fill
            };

            reportViewer.LocalReport.LoadReportDefinition(new FileStream("ReportOrdersByDate.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            Controls.Add(panel);
        }

        private void buttonToPdf_Click(object sender, EventArgs e) {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    MethodInfo method = logic.GetType().GetMethod("SaveOrdersByDateToPdfFile");
                    method.Invoke(logic, new object[] { new ReportBindingModel { FileName = dialog.FileName } });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonMake_Click(object sender, EventArgs e) {
            try {
                MethodInfo method = logic.GetType().GetMethod("GetOrdersByDate");
                var dataSource = (List<ReportOrdersByDateViewModel>)method.Invoke(logic, null);
                var source = new ReportDataSource("DataSetOrdersByDate", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}