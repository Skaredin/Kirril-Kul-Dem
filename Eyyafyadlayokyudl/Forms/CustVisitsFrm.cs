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
    public partial class CustVisitsFrm : TempFrm
    {
        string Flag;
        public CustVisitsFrm(string Flag = null)
        {
            this.Flag = Flag;
            InitializeComponent();
        }

        private void CustVisitsFrm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.КолДок". При необходимости она может быть перемещена или удалена.
            this.колДокTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.КолДок);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eyyafyadlayokyudlDataSet.ClientService". При необходимости она может быть перемещена или удалена.
            this.clientServiceTableAdapter.Fill(this.eyyafyadlayokyudlDataSet.ClientService);

            clientServiceBindingSource.Filter = $"ClientID='{Flag}'";
        }
    }
}
