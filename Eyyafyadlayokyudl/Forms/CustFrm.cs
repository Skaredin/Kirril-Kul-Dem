using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eyyafyadlayokyudl.Forms
{
    public partial class CustFrm : TempFrm
    {
        int pageSize = 10; // размер страницы
        int pageNumber = 0; // текущая страница
        int countRows = 0;
        int countRowsPage = 0;

        string connectionString = @"Data Source=SBD\MSSQL;Initial Catalog=Eyyafyadlayokyudl;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        StringBuilder sb = new StringBuilder();

        public CustFrm()
        {
            InitializeComponent();
        }

        bool flag = false;
        private string GetSql()
        {
            return $"SELECT  ID, FirstName, LastName, Patronymic, Birthday, RegistrationDate, Phone, Email, GenderCode, '' as Count FROM Client {sb.ToString()} ORDER BY Id OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
                "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }

        private int GetSqlCount()
        {
            int numRows;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT count(*) FROM Client {sb.ToString()}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                numRows = Convert.ToInt32(command.ExecuteScalar());
            }
            return numRows;
        }

        int numRows = 0;
        private void FormLoad()
        {
            clientDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);
                ds = new DataSet();
                adapter.Fill(ds, "Client");
                ds.Tables["Client"].Columns.Add("LastDate", typeof(DateTime));
                clientDataGridView.DataSource = ds.Tables[0];
            }



            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.Gender);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.Tag". При необходимости она может быть перемещена или удалена.
            this.tagTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.Tag);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.TagOfClient". При необходимости она может быть перемещена или удалена.
            this.tagOfClientTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.TagOfClient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.Количество". При необходимости она может быть перемещена или удалена.
            this.количествоTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.Количество);

            var Combo = new List<combo>();
            Combo.Add(new combo() { page = "10", name = "10" });
            Combo.Add(new combo() { page = "50", name = "50" });
            Combo.Add(new combo() { page = "200", name = "200" });
            Combo.Add(new combo() { page = GetSqlCount().ToString(), name = "Все" });
            comboBox1.DataSource = Combo;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "page";
            comboBox1.SelectedValue = "10";

            countRows = clientDataGridView.Rows.Count;
            numRows = GetSqlCount();
            label1.Text = countRows + " из " + numRows;

            foreach (DataGridViewColumn item in clientDataGridView.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            tagOfClientBindingSource.Filter = $"ClientID=-5";
            flag = true;

            sb = new StringBuilder("");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;

            LoadCD();
        }

        private void LoadCD()
        {
            int i = 0;
            for (i = 0; i < clientDataGridView.RowCount; i++)
            {
                int id2 = Convert.ToInt32(clientDataGridView.Rows[i].Cells[0].Value);
                Количество count = EyyafyadlayokyudlEntities.GetContext().Количество.Where(p => p.ID == id2).FirstOrDefault();
                clientDataGridView.Rows[i].Cells[9].Value = count.Expr1.ToString();
                clientDataGridView.Rows[i].Cells[10].Value = count.Expr2.ToString();
            }
        }

        private void CustFrm_Load(object sender, EventArgs e)
        {
            FormLoad();
            Clear();
        }

        private void clientDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show(e.Exception.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Client"].Rows.Count < pageSize) return;
            pageNumber++;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Client"].Rows.Clear();

                adapter.Fill(ds, "Client");
            }

            if (clientDataGridView.Rows.Count != 0 && flag)
            {
                countRowsPage = clientDataGridView.Rows.Count;
                countRows += countRowsPage;
                numRows = GetSqlCount();

                label1.Text = countRows + " из " + numRows;
                LoadCD();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;
            pageNumber--;

            countRowsPage = clientDataGridView.Rows.Count;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Client"].Rows.Clear();

                adapter.Fill(ds, "Client");
            }

            if (clientDataGridView.Rows.Count != 0 && flag)
            {
                if (pageNumber >= 0)
                    countRows -= countRowsPage;
                countRowsPage = clientDataGridView.Rows.Count;
                numRows = GetSqlCount();

                LoadCD();
                label1.Text = countRows + " из " + numRows;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != "" && flag)
            {
                pageSize = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            }

            pageNumber = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Client"].Rows.Clear();

                adapter.Fill(ds, "Client");
            }
            countRowsPage = 0;
            countRows = clientDataGridView.Rows.Count;

            numRows = GetSqlCount();
            label1.Text = countRows + " из " + numRows;

            Clear();
            LoadCD();
        }

        private void clientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tagOfClientBindingSource.Filter = $"ClientID={clientDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()}";

                foreach (DataGridViewRow item in tagOfClientDataGridView.Rows)
                {
                    int id = Convert.ToInt32(item.Cells[1].Value);
                    item.Cells[2].Style.ForeColor = System.Drawing.Color.FromName(EyyafyadlayokyudlEntities.GetContext().Tags.Where(p => p.ID == id).FirstOrDefault().Color);
                }

                tagOfClientDataGridView.ClearSelection();
            }
            catch { }
        }

        private void tagOfClientDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tagOfClientDataGridView.ClearSelection();
        }

        private void Clear()
        {
            pageNumber = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Client"].Rows.Clear();

                adapter.Fill(ds, "Client");
            }

            countRowsPage = 0;
            countRows = clientDataGridView.Rows.Count;

            numRows = GetSqlCount();
            label1.Text = countRows + " из " + numRows;
            LoadCD();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sb = new StringBuilder("");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;

            Clear();
        }

        public void UpdateFilter()
        {
            sb = new StringBuilder("where ");

            if (comboBox2.Text != "")
                sb.Append($"GenderCode = '{comboBox2.Text}'");
            else
                sb.Append($"GenderCode is not null");

            if (textBox1.Text != "")
                sb.Append($" and FirstName = '{textBox1.Text}'");
            else
                sb.Append($" and FirstName is not null");

            if (textBox2.Text != "")
                sb.Append($" and LastName = '{textBox2.Text}'");
            else
                sb.Append($" and LastName is not null");

            if (textBox3.Text != "")
                sb.Append($" and Patronymic = '{textBox3.Text}'");
            else
                sb.Append($" and Patronymic is not null");

            if (textBox4.Text != "")
                sb.Append($" and Email = '{textBox4.Text}'");
            else
                sb.Append($" and Email is not null");

            if (textBox5.Text != "")
                sb.Append($" and Phone = '{textBox5.Text}'");
            else
                sb.Append($" and Phone is not null");

            if (checkBox1.Checked)
                sb.Append($" and month(Birthday) = '{System.DateTime.Today.Month}'");
            else
                sb.Append($" and month(Birthday) is not null");

            pageNumber = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Client"].Rows.Clear();

                adapter.Fill(ds, "Client");
            }

            countRowsPage = 0;
            countRows = clientDataGridView.Rows.Count;

            numRows = GetSqlCount();
            label1.Text = countRows + " из " + numRows;
            LoadCD();
            Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (e.KeyChar == '\'' || (e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-' && e.KeyChar != ' ' && !Char.IsDigit(number) && !Char.IsControl(number)))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            clientDataGridView.Sort(clientDataGridView.Columns[0], ListSortDirection.Ascending);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                clientDataGridView.Sort(clientDataGridView.Columns[1], ListSortDirection.Ascending);
            if (radioButton2.Checked)
                clientDataGridView.Sort(clientDataGridView.Columns[10], ListSortDirection.Descending);
            if (radioButton3.Checked)
                clientDataGridView.Sort(clientDataGridView.Columns[9], ListSortDirection.Descending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int count2 = -5;
                if (clientDataGridView.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow item in this.clientDataGridView.SelectedRows)
                    {
                        count2 = Convert.ToInt32(item.Cells[0].Value);
                    }


                    if (MessageBox.Show($"Вы точно хотите безвозвратно удалить выбранного клиента?", "Удаление",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            Client entry = EyyafyadlayokyudlEntities.GetContext().Clients
                                    .Where(o => o.ID == count2)
                                .FirstOrDefault();

                            EyyafyadlayokyudlEntities.GetContext().Clients.Remove(entry);
                            EyyafyadlayokyudlEntities.GetContext().SaveChanges();

                            MessageBox.Show($"Данные удалены!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            pageNumber = 0;

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                adapter = new SqlDataAdapter(GetSql(), connection);

                                ds.Tables["Client"].Rows.Clear();

                                adapter.Fill(ds, "Client");
                            }

                            countRowsPage = 0;
                            countRows = clientDataGridView.Rows.Count;

                            numRows = GetSqlCount();
                            label1.Text = countRows + " из " + numRows;
                            LoadCD();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Нельзя удалить клиента, который посещал услуги более 1 раза", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Необходимо выделить только одну строку", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clientDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form Frm = new AddEditCusFrm(clientDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                Frm.ShowDialog();
            }
            catch { }
        }

        bool flagFrm = false;
        private void CustFrm_Activated(object sender, EventArgs e)
        {
            if (flagFrm)
            {
                FormLoad();

                sb = new StringBuilder("");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox2.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                checkBox1.Checked = false;
                pageNumber = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter(GetSql(), connection);

                    ds.Tables["Client"].Rows.Clear();

                    adapter.Fill(ds, "Client");
                }

                countRowsPage = 0;
                countRows = clientDataGridView.Rows.Count;

                numRows = GetSqlCount();
                label1.Text = countRows + " из " + numRows;
                LoadCD();
            }
            else
                flagFrm = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form Frm = new AddEditCusFrm();
                Frm.ShowDialog();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int count2 = -5;
                if (clientDataGridView.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow item in this.clientDataGridView.SelectedRows)
                    {
                        count2 = Convert.ToInt32(item.Cells[0].Value);
                    }

                    Form Frm = new CustVisitsFrm(count2.ToString());
                    Frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Необходимо выделить только одну строку", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }
    }

    public class combo
    {
        public string page { get; set; }
        public string name { get; set; }
    }
}
