using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.BindingModels;
using System.Windows.Forms;
using System;
using Unity;

namespace TypographyView {
    public partial class FormMessages : Form {
        private readonly IMessageInfoLogic logic;
        private bool hasNext = false;
        private readonly int mailsOnPage = 4;
        private int currentPage = 0;

        public FormMessages(IMessageInfoLogic logic) {
            InitializeComponent();
            this.logic = logic;

            if (mailsOnPage < 1) {
                mailsOnPage = 5;
            }
        }

        private void FormMessages_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            try {
                var list = logic.Read(new MessageInfoBindingModel {
                    ToSkip = currentPage * mailsOnPage,
                    ToTake = mailsOnPage + 1
                });

                hasNext = !(list.Count <= mailsOnPage);

                if (hasNext) {
                    buttonNext.Enabled = true;
                }
                else {
                    buttonNext.Enabled = false;
                }

                Program.ConfigGrid(list, dataGridViewMessages);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void buttonPrevious_Click(object sender, EventArgs e) {
            if ((currentPage - 1) >= 0) {
                currentPage--;
                labelPage.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                if (currentPage == 0) {
                    buttonPrevious.Enabled = false;
                }
                LoadData();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e) {
            if (hasNext) {
                currentPage++;
                labelPage.Text = (currentPage + 1).ToString();
                buttonPrevious.Enabled = true;
                LoadData();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e) {
            if (dataGridViewMessages.SelectedRows.Count == 1) {
                var form = Program.Container.Resolve<FormMessage>();
                form.messageId = Convert.ToString(dataGridViewMessages.SelectedRows[0].Cells[0].Value);
                form.ShowDialog();
                LoadData();
            }
        }
    }
}