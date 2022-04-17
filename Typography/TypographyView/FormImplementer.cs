using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Windows.Forms;
using System;

namespace TypographyView {
    public partial class FormImplementer : Form {
        public int Id { set { id = value; } }
        private readonly IImplementerLogic logic;
        private int? id;

        public FormImplementer(IImplementerLogic logic) {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormImplementer_Load(object sender, EventArgs e) {
            if (id.HasValue) {
                try {
                    ImplementerViewModel view = logic.Read(new ImplementerBindingModel { Id = id.Value })?[0];

                    if (view != null) {
                        textBoxFIO.Text = view.FIO;
                        textBoxWorkingTime.Text = view.WorkingTime.ToString();
                        textBoxPauseTime.Text = view.PauseTime.ToString();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(textBoxFIO.Text)) {
                MessageBox.Show("Заполните ФИО исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(textBoxWorkingTime.Text)) {
                MessageBox.Show("Заполните время работы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(textBoxPauseTime.Text)) {
                MessageBox.Show("Заполните время отдыха", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                logic.CreateOrUpdate(new ImplementerBindingModel {
                    Id = id,
                    FIO = textBoxFIO.Text,
                    WorkingTime = Convert.ToInt32(textBoxWorkingTime.Text),
                    PauseTime = Convert.ToInt32(textBoxPauseTime.Text)
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