﻿using System;
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
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.orderSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commandeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Stock_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.completeButton = new System.Windows.Forms.Button();
            this.PartListDataGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            this.commandeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.QuantityReceivedBox = new System.Windows.Forms.TextBox();
            this.stockIDBox = new System.Windows.Forms.TextBox();
            this.stockReceivedButton = new System.Windows.Forms.Button();
            this.buyButton = new System.Windows.Forms.Button();
            this.back_stock_button = new System.Windows.Forms.Button();
            this.stockDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).BeginInit();
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
            this.OrdersDataGridView.Size = new System.Drawing.Size(944, 424);
            this.OrdersDataGridView.TabIndex = 0;
            this.OrdersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_3);
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
            // Button_View
            // 
            this.Button_View.HeaderText = "View";
            this.Button_View.MinimumWidth = 6;
            this.Button_View.Name = "Button_View";
            this.Button_View.Text = "View";
            this.Button_View.ToolTipText = "View";
            this.Button_View.UseColumnTextForButtonValue = true;
            // 
            // orderSummaryBindingSource
            // 
            this.orderSummaryBindingSource.DataSource = typeof(merchandapp.OrderSummary);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Stock_button);
            this.panel1.Controls.Add(this.OrdersDataGridView);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 467);
            this.panel1.TabIndex = 1;
            // 
            // Stock_button
            // 
            this.Stock_button.Location = new System.Drawing.Point(842, 430);
            this.Stock_button.Name = "Stock_button";
            this.Stock_button.Size = new System.Drawing.Size(99, 34);
            this.Stock_button.TabIndex = 1;
            this.Stock_button.Text = "Stock";
            this.Stock_button.UseVisualStyleBackColor = true;
            this.Stock_button.Click += new System.EventHandler(this.stock_button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.completeButton);
            this.panel2.Controls.Add(this.PartListDataGridView);
            this.panel2.Controls.Add(this.backButton);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 467);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // completeButton
            // 
            this.completeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeButton.Location = new System.Drawing.Point(789, 3);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(152, 42);
            this.completeButton.TabIndex = 2;
            this.completeButton.Text = "Complete";
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // PartListDataGridView
            // 
            this.PartListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PartListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartListDataGridView.Location = new System.Drawing.Point(256, 51);
            this.PartListDataGridView.Name = "PartListDataGridView";
            this.PartListDataGridView.RowHeadersWidth = 51;
            this.PartListDataGridView.RowTemplate.Height = 24;
            this.PartListDataGridView.Size = new System.Drawing.Size(685, 413);
            this.PartListDataGridView.TabIndex = 1;
            this.PartListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartListDataGridView_CellContentClick);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(134, 42);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // commandeBindingSource1
            // 
            this.commandeBindingSource1.DataSource = typeof(merchandapp.Form1.Commande);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.QuantityReceivedBox);
            this.panel3.Controls.Add(this.stockIDBox);
            this.panel3.Controls.Add(this.stockReceivedButton);
            this.panel3.Controls.Add(this.buyButton);
            this.panel3.Controls.Add(this.back_stock_button);
            this.panel3.Controls.Add(this.stockDataGridView);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(944, 467);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Stock ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Quantity Received";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // QuantityReceivedBox
            // 
            this.QuantityReceivedBox.Location = new System.Drawing.Point(256, 430);
            this.QuantityReceivedBox.Name = "QuantityReceivedBox";
            this.QuantityReceivedBox.Size = new System.Drawing.Size(100, 22);
            this.QuantityReceivedBox.TabIndex = 5;
            this.QuantityReceivedBox.TextChanged += new System.EventHandler(this.QuantityReceivedBox_TextChanged);
            // 
            // stockIDBox
            // 
            this.stockIDBox.Location = new System.Drawing.Point(424, 430);
            this.stockIDBox.Name = "stockIDBox";
            this.stockIDBox.Size = new System.Drawing.Size(100, 22);
            this.stockIDBox.TabIndex = 4;
            this.stockIDBox.TextChanged += new System.EventHandler(this.stockIDBox_TextChanged);
            // 
            // stockReceivedButton
            // 
            this.stockReceivedButton.Location = new System.Drawing.Point(597, 410);
            this.stockReceivedButton.Name = "stockReceivedButton";
            this.stockReceivedButton.Size = new System.Drawing.Size(96, 42);
            this.stockReceivedButton.TabIndex = 3;
            this.stockReceivedButton.Text = "Stock Received";
            this.stockReceivedButton.UseVisualStyleBackColor = true;
            this.stockReceivedButton.Click += new System.EventHandler(this.stockReceivedButton_Click);
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(845, 3);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(96, 42);
            this.buyButton.TabIndex = 2;
            this.buyButton.Text = "Buy";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // back_stock_button
            // 
            this.back_stock_button.Location = new System.Drawing.Point(3, 3);
            this.back_stock_button.Name = "back_stock_button";
            this.back_stock_button.Size = new System.Drawing.Size(96, 42);
            this.back_stock_button.TabIndex = 1;
            this.back_stock_button.Text = "Back";
            this.back_stock_button.UseVisualStyleBackColor = true;
            this.back_stock_button.Click += new System.EventHandler(this.back_stock_button_Click);
            // 
            // stockDataGridView
            // 
            this.stockDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stockDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockDataGridView.Location = new System.Drawing.Point(3, 51);
            this.stockDataGridView.Name = "stockDataGridView";
            this.stockDataGridView.RowHeadersWidth = 51;
            this.stockDataGridView.RowTemplate.Height = 24;
            this.stockDataGridView.Size = new System.Drawing.Size(938, 341);
            this.stockDataGridView.TabIndex = 0;
            this.stockDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PartListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandeBindingSource1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataGridView)).EndInit();
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
        private Button Stock_button;
        private Panel panel3;
        private DataGridView stockDataGridView;
        private Button back_stock_button;
        private Button buyButton;
        private Button stockReceivedButton;
        private Label label1;
        private TextBox QuantityReceivedBox;
        private TextBox stockIDBox;
        private Label label2;
    }
}

