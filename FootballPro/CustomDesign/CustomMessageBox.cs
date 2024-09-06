using FootballPro.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPro.CustomDesign
{
    public class CustomMessageBox
    {

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, string culture)
        {
            Form form = new Form();
            Label label = new Label();
            Button btn1 = new Button();
            Button btn2 = new Button();

            form.Text = title;
            label.Text = message;

            switch (culture)
            {
                case "en-US":
                    switch (buttons)
                    {
                        case MessageBoxButtons.OKCancel:
                            btn1.Text = Resource_en_US.btnOk;
                            btn2.Text = Resource_en_US.btnCancel;
                            form.AcceptButton = btn1;
                            form.CancelButton = btn2;
                            break;
                        case MessageBoxButtons.YesNo:
                            btn1.Text = Resource_en_US.btnYes;
                            btn2.Text = Resource_en_US.btnNo;
                            form.AcceptButton = btn1;
                            form.CancelButton = btn2;
                            break;
                        default:
                            btn1.Visible = false;
                            btn2.Text = Resource_en_US.btnOk;
                            form.AcceptButton = btn2;
                            break;
                    }
                    break;
                case "hr-HR":
                    switch (buttons)
                    {
                        case MessageBoxButtons.OKCancel:
                            btn1.Text = Resource_hr_HR.btnOk;
                            btn2.Text = Resource_hr_HR.btnCancel;
                            form.AcceptButton = btn1;
                            form.CancelButton = btn2;
                            break;
                        case MessageBoxButtons.YesNo:
                            btn1.Text = Resource_hr_HR.btnYes;
                            btn2.Text = Resource_hr_HR.btnNo;
                            form.AcceptButton = btn1;
                            form.CancelButton = btn2;
                            break;
                        default:
                            btn1.Visible = false;
                            btn2.Text = Resource_hr_HR.btnYes;
                            form.AcceptButton = btn2;
                            break;
                    }
                    break;
                case "de-DE":
                    switch (buttons)
                    {
                        case MessageBoxButtons.OKCancel:
                            btn1.Text = Resource_de_DE.btnOk;
                            btn2.Text = Resource_de_DE.btnCancel;
                            form.AcceptButton = btn1;
                            form.CancelButton = btn2;
                            break;
                        case MessageBoxButtons.YesNo:
                            btn1.Text = Resource_de_DE.btnYes;
                            btn2.Text = Resource_de_DE.btnNo;
                            form.AcceptButton = btn1;
                            form.CancelButton = btn2;
                            break;
                        default:
                            btn1.Visible = false;
                            btn2.Text = Resource_de_DE.btnOk;
                            form.AcceptButton = btn2;
                            break;
                    }
                    break;
            }

            btn1.BackColor = SystemColors.Control;
            btn2.BackColor = SystemColors.Control;
            btn1.ForeColor = SystemColors.ControlText;
            btn2.ForeColor = SystemColors.ControlText;

            btn1.DialogResult = buttons == MessageBoxButtons.YesNo ? DialogResult.Yes : DialogResult.OK;
            btn2.DialogResult = buttons == MessageBoxButtons.YesNo ? DialogResult.No : DialogResult.Cancel;

            form.Font = SystemFonts.MessageBoxFont;
            form.ForeColor = SystemColors.ControlText;
            form.BackColor = SystemColors.Window;

            btn1.SetBounds(75, 70, 75, 30);
            btn2.SetBounds(160, 70, 75, 30);

            label.SetBounds(9, 20, 372, 13);
            label.AutoSize = true;

            form.ClientSize = new Size(300, 120);
            form.Controls.AddRange(new Control[] { label, btn1, btn2 });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;

            form.KeyPreview = true;
            form.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    btn1.PerformClick();

                if (e.KeyCode == Keys.Escape)
                    btn2.PerformClick();
            };

            DialogResult dialogResult = form.ShowDialog();
            form.Dispose();
            return dialogResult;
        }
    }
}
