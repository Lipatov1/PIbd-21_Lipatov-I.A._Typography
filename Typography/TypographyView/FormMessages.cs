using TypographyContracts.BusinessLogicsContracts;
using System.Windows.Forms;
using System;

namespace TypographyView {
    public partial class FormMessages : Form {
        private readonly IMessageInfoLogic logic;

        public FormMessages(IMessageInfoLogic logic) {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormMessages_Load(object sender, EventArgs e) {
            var list = logic.Read(null);

            if (list != null) {
                dataGridViewMessages.DataSource = list;
                dataGridViewMessages.Columns[0].Visible = false;
                dataGridViewMessages.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}