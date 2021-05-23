using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eyyafyadlayokyudl.Forms
{
    public partial class AddEditCusFrm : TempFrm
    {
        string Flag;
        int str;

        public AddEditCusFrm(string Flag = null)
        {
            this.Flag = Flag;
            InitializeComponent();
        }

        private void AddEditCusFrm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.Tag". При необходимости она может быть перемещена или удалена.
            this.tagTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.Tag);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.TagOfClient". При необходимости она может быть перемещена или удалена.
            this.tagOfClientTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.TagOfClient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.Client);



            if (Flag != null)
            {
                clientBindingSource.Filter = $"ID='{Flag}'";
                tagOfClientBindingSource.Filter = $"ClientID='{Flag}'";

                iDTextBox.Visible = true;
                label1.Visible = true;

                if (genderCodeTextBox.Text == "м")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;

                birthdayDateTimePicker.Value = birthdayDateTimePicker.Value.AddDays(1);
                birthdayDateTimePicker.Value = birthdayDateTimePicker.Value.AddDays(-1);
                registrationDateDateTimePicker.Value = registrationDateDateTimePicker.Value.AddDays(1);
                registrationDateDateTimePicker.Value = registrationDateDateTimePicker.Value.AddDays(-1);

                this.Text = "Изменение клиента";
            }
            else
            {
                clientBindingSource.AddNew();

                DataRowView f = (DataRowView)clientBindingSource.Current;
                str = Convert.ToInt32(f["ID"].ToString());

                tagOfClientBindingSource.Filter = $"ClientID='{str}'";

                radioButton1.Checked = true;

                birthdayDateTimePicker.Value = birthdayDateTimePicker.Value.AddDays(1);
                birthdayDateTimePicker.Value = birthdayDateTimePicker.Value.AddDays(-1);
                registrationDateDateTimePicker.Value = System.DateTime.Today.AddDays(-1);
                registrationDateDateTimePicker.Value = System.DateTime.Today.AddDays(1);

                this.Text = "Добавление клиента";
            }
        }

        private void Save()
        {
            try
            {
                if (MessageBox.Show("Сохранить изменения и выйти?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Validate();
                    this.clientBindingSource.EndEdit();
                    this.tagOfClientBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.eyyafyadlayokyudlDataSet);

                    if (Flag != null)
                    {
                        int temp = Convert.ToInt32(Flag);
                        var temp3 = EyyafyadlayokyudlEntities.GetContext().Clients.Where(p => p.ID == temp).FirstOrDefault();
                        var temp2 = temp3.Tags.ToList();
                        foreach (Tag i in temp2)
                        {
                            temp3.Tags.Remove(i);
                        }

                        tagOfClientDataGridView.AllowUserToAddRows = false;

                        foreach (DataGridViewRow i in tagOfClientDataGridView.Rows)
                        {
                            int temp4 = Convert.ToInt32(i.Cells[1].Value);

                            var temp5 = EyyafyadlayokyudlEntities.GetContext().Tags.Where(p => p.ID == temp4).FirstOrDefault();
                            temp3.Tags.Add(temp5);
                        }
                        EyyafyadlayokyudlEntities.GetContext().SaveChanges();
                    }
                    else
                    {
                        int temp = Convert.ToInt32(str);
                        var temp3 = EyyafyadlayokyudlEntities.GetContext().Clients.Where(p => p.ID == temp).FirstOrDefault();

                        tagOfClientDataGridView.AllowUserToAddRows = false;

                        foreach (DataGridViewRow i in tagOfClientDataGridView.Rows)
                        {
                            int temp4 = Convert.ToInt32(i.Cells[1].Value);

                            var temp5 = EyyafyadlayokyudlEntities.GetContext().Tags.Where(p => p.ID == temp4).FirstOrDefault();
                            temp3.Tags.Add(temp5);
                        }
                        EyyafyadlayokyudlEntities.GetContext().SaveChanges();
                    }

                    MessageBox.Show("Успешно сохранено", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения\n{ex.Message.ToString()}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text != "" && lastNameTextBox.Text != ""
                && patronymicTextBox.Text != "" && birthdayDateTimePicker.Text != "" && registrationDateDateTimePicker.Text != ""
                && emailTextBox.Text != "" && phoneTextBox.Text != "" && genderCodeTextBox.Text != "")
            {

                if (emailTextBox.Text.IndexOf('@') > 0 && emailTextBox.Text.IndexOf('.') > 0 &&
                emailTextBox.Text.IndexOf('@') < emailTextBox.Text.IndexOf('.'))
                {
                    Save();
                }
                else
                {
                    MessageBox.Show("Необходимо ввести корректный Email", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
                MessageBox.Show("Необходимо заполнить все поля", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsLetter(number) && !Char.IsWhiteSpace(number) && e.KeyChar != '-' && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == '\'' || (e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-' && e.KeyChar != ' ' && !Char.IsDigit(number) && !Char.IsControl(number)))
            {
                e.Handled = true;
            }
        }

        bool flagTag = false;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                genderCodeTextBox.Text = "м";
            if (radioButton2.Checked)
                genderCodeTextBox.Text = "ж";
        }

        private void tagOfClientDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!flagTag)
            {
                foreach (DataGridViewRow item in tagOfClientDataGridView.Rows)
                {
                    int id = Convert.ToInt32(item.Cells[1].Value);
                    item.Cells[1].Style.ForeColor = System.Drawing.Color.FromName(EyyafyadlayokyudlEntities.GetContext().Tags.Where(p => p.ID == id).FirstOrDefault().Color);
                }
            }
            else
            {
                if (Flag != null)
                {
                    tagOfClientDataGridView.Rows[tagOfClientDataGridView.RowCount - 2].Cells[0].Value = Flag;
                }
                else
                {
                    if (tagOfClientDataGridView.RowCount > 1)
                    {
                        tagOfClientDataGridView.Rows[tagOfClientDataGridView.RowCount - 2].Cells[0].Value = str;
                    }
                }

            }

            tagOfClientDataGridView.ClearSelection();
        }

        private void tagOfClientDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(tagOfClientDataGridView.Rows[e.RowIndex].Cells[1].Value);
            tagOfClientDataGridView.Rows[e.RowIndex].Cells[1].Style.ForeColor = System.Drawing.Color.FromName(EyyafyadlayokyudlEntities.GetContext().Tags.Where(p => p.ID == id).FirstOrDefault().Color);

            tagOfClientDataGridView.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flagTag = true;
            tagOfClientDataGridView.AllowUserToAddRows = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tagOfClientBindingSource.EndEdit();
            this.tagBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.eyyafyadlayokyudlDataSet);
        }
    }
}
