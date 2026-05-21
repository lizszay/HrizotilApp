using HrizotilApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrizotilApp
{
    public partial class FormLogin : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //null, пустая, только пробельные символы
            if (String.IsNullOrWhiteSpace(txtLogin.Text) ||
                String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Введите логин и пароль",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //чтобы не писать отдельно свойство формы, так как ресурсы теперь
            //будут освобождаться после конца блока
            using (var db = new HrizotilAccountingDbContext()) //название класса бд
            {
                var user = db.Users
                    .Where(w => w.Login == txtLogin.Text &&
                        w.Password == txtPassword.Text)
                    .FirstOrDefault();

                if (user != null)
                {
                    CurrentUser = user;
                    IsGuest = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Неверный логин или пароль",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            IsGuest = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
