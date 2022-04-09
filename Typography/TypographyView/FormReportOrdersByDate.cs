﻿using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
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
                    logic.SaveOrdersByDateToPdfFile(new ReportBindingModel {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonMake_Click(object sender, EventArgs e) {
            try {
                var dataSource = logic.GetOrdersByDate();
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