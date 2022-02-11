﻿using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace TypographyView {
    public partial class FormCreateOrder : Form {
        private readonly IPrintedLogic _logicP;
        private readonly IOrderLogic _logicO;

        public FormCreateOrder(IPrintedLogic logicP, IOrderLogic logicO) {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e) {
            try {
                List<PrintedViewModel> list = _logicP.Read(null);

                if (list != null) {
                    comboBoxPrinted.DisplayMember = "PackageName";
                    comboBoxPrinted.ValueMember = "Id";
                    comboBoxPrinted.DataSource = list;
                    comboBoxPrinted.SelectedItem = null;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum() {
            if (comboBoxPrinted.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text)) {
                try {
                    int id = Convert.ToInt32(comboBoxPrinted.SelectedValue);
                    PrintedViewModel Printed = _logicP.Read(new PrintedBindingModel {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * Printed?.Price ?? 0).ToString();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e) {
            CalcSum();
        }

        private void ComboBoxPrinted_SelectedIndexChanged(object sender, EventArgs e) {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBoxCount.Text)) {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxPrinted.SelectedValue == null) {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

            try {
                _logicO.CreateOrder(new CreateOrderBindingModel {
                    PrintedId = Convert.ToInt32(comboBoxPrinted.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}