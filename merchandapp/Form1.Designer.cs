using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace merchandapp
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.Button_View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.commandeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.completeButton = new System.Windows.Forms.Button();
            this.PartListDataGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.commandeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderSummaryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersDataGridView
            // 
            this.OrdersDataGridView.AllowUserToAddRows = false;
            this.OrdersDataGridView.AutoGenerateColumns = false;
            this.OrdersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.orderNameDataGridViewTextBoxColumn,
            this.orderStatusDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.orderStockDataGridViewTextBoxColumn,
            this.Button_View});
            this.OrdersDataGridView.DataSource = this.orderSummaryBindingSource;
            this.OrdersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.OrdersDataGridView.Name = "OrdersDataGridView";
            this.OrdersDataGridView.RowHeadersWidth = 51;
            this.OrdersDataGridView.RowTemplate.Height = 24;
            this.OrdersDataGridView.Size = new System.Drawing.Size(776, 392);
            this.OrdersDataGridView.TabIndex = 0;
            this.OrdersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_3);
            // 
            // Button_View
            // 
            this.Button_View.HeaderText = "View";
            this.Button_View.MinimumWidth = 6;
            this.Button_View.Name = "Button_View";
            this.Button_View.Text = "View";
            this.Button_View.ToolTipText = "View";
            this.Button_View.UseColumnTextForButtonValue = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OrdersDataGridView);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.completeButton);
            this.panel2.Controls.Add(this.PartListDataGridView);
            this.panel2.Controls.Add(this.backButton);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 426);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // completeButton
            // 
            this.completeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeButton.Location = new System.Drawing.Point(578, 3);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(195, 76);
            this.completeButton.TabIndex = 2;
            this.completeButton.Text = "Complete";
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // PartListDataGridView
            // 
            this.PartListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartListDataGridView.Location = new System.Drawing.Point(282, 85);
            this.PartListDataGridView.Name = "PartListDataGridView";
            this.PartListDataGridView.RowHeadersWidth = 51;
            this.PartListDataGridView.RowTemplate.Height = 24;
            this.PartListDataGridView.Size = new System.Drawing.Size(491, 338);
            this.PartListDataGridView.TabIndex = 1;
            this.PartListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartListDataGridView_CellContentClick);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(196, 76);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // commandeBindingSource1
            // 
            this.commandeBindingSource1.DataSource = typeof(merchandapp.Form1.Commande);
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "orderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "orderID";
            this.orderIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            // 
            // orderNameDataGridViewTextBoxColumn
            // 
            this.orderNameDataGridViewTextBoxColumn.DataPropertyName = "orderName";
            this.orderNameDataGridViewTextBoxColumn.HeaderText = "orderName";
            this.orderNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderNameDataGridViewTextBoxColumn.Name = "orderNameDataGridViewTextBoxColumn";
            // 
            // orderStatusDataGridViewTextBoxColumn
            // 
            this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "orderStatus";
            this.orderStatusDataGridViewTextBoxColumn.HeaderText = "orderStatus";
            this.orderStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "orderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "orderDate";
            this.orderDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            // 
            // orderStockDataGridViewTextBoxColumn
            // 
            this.orderStockDataGridViewTextBoxColumn.DataPropertyName = "orderStock";
            this.orderStockDataGridViewTextBoxColumn.HeaderText = "orderStock";
            this.orderStockDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderStockDataGridViewTextBoxColumn.Name = "orderStockDataGridViewTextBoxColumn";
            // 
            // orderSummaryBindingSource
            // 
            this.orderSummaryBindingSource.DataSource = typeof(merchandapp.OrderSummary);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PartListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderSummaryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OrdersDataGridView;
        private System.Windows.Forms.BindingSource commandeBindingSource;
        private Panel panel1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn inStockDataGridViewCheckBoxColumn;
        private Panel panel2;
        private Button backButton;
        private BindingSource commandeBindingSource1;
        private BindingSource orderSummaryBindingSource;
        private Button completeButton;
        private DataGridView PartListDataGridView;
        private DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderStockDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn Button_View;
    }
}

