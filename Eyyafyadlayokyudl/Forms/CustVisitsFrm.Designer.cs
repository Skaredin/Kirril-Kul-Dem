namespace Eyyafyadlayokyudl.Forms
{
    partial class CustVisitsFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.eyyafyadlayokyudlDataSet = new Eyyafyadlayokyudl.EyyafyadlayokyudlDataSet();
            this.clientServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientServiceTableAdapter = new Eyyafyadlayokyudl.EyyafyadlayokyudlDataSetTableAdapters.ClientServiceTableAdapter();
            this.tableAdapterManager = new Eyyafyadlayokyudl.EyyafyadlayokyudlDataSetTableAdapters.TableAdapterManager();
            this.clientServiceDataGridView = new System.Windows.Forms.DataGridView();
            this.колДокBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.колДокTableAdapter = new Eyyafyadlayokyudl.EyyafyadlayokyudlDataSetTableAdapters.КолДокTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.eyyafyadlayokyudlDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientServiceDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.колДокBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // eyyafyadlayokyudlDataSet
            // 
            this.eyyafyadlayokyudlDataSet.DataSetName = "EyyafyadlayokyudlDataSet";
            this.eyyafyadlayokyudlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientServiceBindingSource
            // 
            this.clientServiceBindingSource.DataMember = "ClientService";
            this.clientServiceBindingSource.DataSource = this.eyyafyadlayokyudlDataSet;
            // 
            // clientServiceTableAdapter
            // 
            this.clientServiceTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AttachedProductTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClientServiceTableAdapter = this.clientServiceTableAdapter;
            this.tableAdapterManager.ClientTableAdapter = null;
            this.tableAdapterManager.DocumentByServiceTableAdapter = null;
            this.tableAdapterManager.GenderTableAdapter = null;
            this.tableAdapterManager.ManufacturerTableAdapter = null;
            this.tableAdapterManager.ProductPhotoTableAdapter = null;
            this.tableAdapterManager.ProductSaleTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = null;
            this.tableAdapterManager.ServicePhotoTableAdapter = null;
            this.tableAdapterManager.ServiceTableAdapter = null;
            this.tableAdapterManager.TagOfClientTableAdapter = null;
            this.tableAdapterManager.TagTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Eyyafyadlayokyudl.EyyafyadlayokyudlDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // clientServiceDataGridView
            // 
            this.clientServiceDataGridView.AllowUserToAddRows = false;
            this.clientServiceDataGridView.AllowUserToDeleteRows = false;
            this.clientServiceDataGridView.AutoGenerateColumns = false;
            this.clientServiceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientServiceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column1});
            this.clientServiceDataGridView.DataSource = this.clientServiceBindingSource;
            this.clientServiceDataGridView.Location = new System.Drawing.Point(12, 12);
            this.clientServiceDataGridView.Name = "clientServiceDataGridView";
            this.clientServiceDataGridView.ReadOnly = true;
            this.clientServiceDataGridView.Size = new System.Drawing.Size(694, 220);
            this.clientServiceDataGridView.TabIndex = 1;
            // 
            // колДокBindingSource
            // 
            this.колДокBindingSource.DataMember = "КолДок";
            this.колДокBindingSource.DataSource = this.eyyafyadlayokyudlDataSet;
            // 
            // колДокTableAdapter
            // 
            this.колДокTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ClientID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ClientID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ServiceID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ServiceID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "StartTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "StartTime";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn5.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ClientID";
            this.Column1.DataSource = this.колДокBindingSource;
            this.Column1.DisplayMember = "Expr1";
            this.Column1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column1.HeaderText = "CountDoc";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.ValueMember = "ClientID";
            // 
            // CustVisitsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 246);
            this.Controls.Add(this.clientServiceDataGridView);
            this.Name = "CustVisitsFrm";
            this.Text = "Посещения клиента";
            this.Load += new System.EventHandler(this.CustVisitsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eyyafyadlayokyudlDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientServiceDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.колДокBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EyyafyadlayokyudlDataSet eyyafyadlayokyudlDataSet;
        private System.Windows.Forms.BindingSource clientServiceBindingSource;
        private EyyafyadlayokyudlDataSetTableAdapters.ClientServiceTableAdapter clientServiceTableAdapter;
        private EyyafyadlayokyudlDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView clientServiceDataGridView;
        private System.Windows.Forms.BindingSource колДокBindingSource;
        private EyyafyadlayokyudlDataSetTableAdapters.КолДокTableAdapter колДокTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
    }
}