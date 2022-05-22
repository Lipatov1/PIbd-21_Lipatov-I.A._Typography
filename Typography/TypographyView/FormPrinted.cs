﻿using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Unity;

namespace TypographyView {
    public partial class FormPrinted : Form {
        public int Id { set { id = value; } }
        private readonly IPrintedLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> PrintedComponents;

        public FormPrinted(IPrintedLogic logic) {
            InitializeComponent();
            _logic = logic;
        }

        private void FormPrinted_Load(object sender, EventArgs e) {
            if (id.HasValue) {
                try {
                    Program.ConfigGrid(_logic.Read(null), dataGridView);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                PrintedComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData() {
            try {
                if (PrintedComponents != null) {
                    dataGridView.Rows.Clear();
                    foreach (var pc in PrintedComponents) {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormPrintedComponent>();

            if (form.ShowDialog() == DialogResult.OK) {
                if (PrintedComponents.ContainsKey(form.Id)) {
                    PrintedComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else {
                    PrintedComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                var form = Program.Container.Resolve<FormPrintedComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = PrintedComponents[id].Item2;

                if (form.ShowDialog() == DialogResult.OK) {
                    PrintedComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        PrintedComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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

        private void ButtonSave_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBoxName.Text)) {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPrice.Text)) {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (PrintedComponents == null || PrintedComponents.Count == 0) {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                _logic.CreateOrUpdate(new PrintedBindingModel {
                    Id = id,
                    PrintedName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    PrintedComponents = PrintedComponents
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