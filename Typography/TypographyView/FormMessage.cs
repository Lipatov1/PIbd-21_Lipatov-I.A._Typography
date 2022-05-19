using TypographyContracts.BusinessLogicsContracts;
using TypographyBusinessLogic.MailWorker;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Windows.Forms;
using System;

namespace TypographyView {
    public partial class FormMessage : Form {
        public string messageId { set { _messageId = value; } }
        private readonly IMessageInfoLogic messageInfoLogic;
        private readonly IClientLogic clientLogic;
        private readonly AbstractMailWorker mailWorker;
        private string _messageId;

        public FormMessage(IMessageInfoLogic messageInfoLogic, IClientLogic clientLogic, AbstractMailWorker mailWorker) {
            InitializeComponent();
            this.messageInfoLogic = messageInfoLogic;
            this.clientLogic = clientLogic;
            this.mailWorker = mailWorker;
        }
        
        private void FormMessage_Load(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(_messageId)) {
                try {
                    MessageInfoViewModel view = messageInfoLogic.Read(new MessageInfoBindingModel { MessageId = _messageId })?[0];

                    if (view != null) {
                        if (view.Read == false) {
                            messageInfoLogic.CreateOrUpdate(new MessageInfoBindingModel {
                                ClientId = clientLogic.Read(new ClientBindingModel { Login = view.SenderName })[0]?.Id,
                                MessageId = _messageId,
                                FromMailAddress = view.SenderName,
                                Subject = view.Subject,
                                Body = view.Body,
                                DateDelivery = view.DateDelivery,
                                Read = true,
                                Reply = view.Reply
                            });
                        }

                        DateDelivery.Text = view.DateDelivery.ToString();
                        SenderName.Text = view.SenderName;
                        RichTextBoxBody.Text = view.Body;
                        Subject.Text = view.Subject;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonReply_Click(object sender, EventArgs e) {
            buttonReply.Visible = false;
            buttonSend.Visible = true;
            buttonCalcel.Visible = true;
            richTextBoxReply.Visible = true;
            this.Height = 486;
        }

        private void buttonSend_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(richTextBoxReply.Text)) {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                mailWorker.MailSendAsync(new MailSendInfoBindingModel {
                    MailAddress = SenderName.Text,
                    Text = richTextBoxReply.Text,
                    Subject = "Re: " + Subject.Text
                });

                messageInfoLogic.CreateOrUpdate(new MessageInfoBindingModel {
                    ClientId = clientLogic.Read(new ClientBindingModel { Login = SenderName.Text })[0]?.Id,
                    MessageId = _messageId,
                    FromMailAddress = SenderName.Text,
                    Subject = Subject.Text,
                    Body = RichTextBoxBody.Text,
                    DateDelivery = DateTime.Parse(DateDelivery.Text),
                    Read = true,
                    Reply = richTextBoxReply.Text
                });

                MessageBox.Show("Письмо успешно отправлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCalcel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
