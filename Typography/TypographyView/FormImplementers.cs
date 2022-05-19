﻿using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;
using Unity;

namespace TypographyView {
    public partial class FormImplementers : Form {
        private readonly IImplementerLogic logic;

        public FormImplementers(IImplementerLogic logic) {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            var form = Program.Container.Resolve<FormImplementer>();

            if (form.ShowDialog() == DialogResult.OK) {
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e) {
            if (dataGridView.SelectedRows.Count == 1) {
                var form = Program.Container.Resolve<FormImplementer>();
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
                        logic.Delete(new ImplementerBindingModel { Id = id });
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

        private void FormImplementers_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                Program.ConfigGrid(logic.Read(null), dataGridView);
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}