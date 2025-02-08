namespace clientapp
{
    partial class Window
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SaveForLaterButton = new System.Windows.Forms.Button();
            this.OrderButton = new System.Windows.Forms.Button();
            this.lockersPanel = new System.Windows.Forms.Panel();
            this.SummaryPanel = new System.Windows.Forms.Panel();
            this.LockersLabel = new System.Windows.Forms.Label();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.ColorGroup = new System.Windows.Forms.GroupBox();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleName = "header";
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1573, 166);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SansSerif", 28.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 88);
            this.label1.TabIndex = 0;
            this.label1.Text = "ANGLEIRON";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel2.Location = new System.Drawing.Point(1, 717);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // SaveForLaterButton
            // 
            this.SaveForLaterButton.AccessibleName = "SaveForLater";
            this.SaveForLaterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveForLaterButton.Location = new System.Drawing.Point(1078, 717);
            this.SaveForLaterButton.Name = "SaveForLaterButton";
            this.SaveForLaterButton.Size = new System.Drawing.Size(243, 91);
            this.SaveForLaterButton.TabIndex = 2;
            this.SaveForLaterButton.Text = "Save for later";
            this.SaveForLaterButton.UseVisualStyleBackColor = true;
            this.SaveForLaterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderButton
            // 
            this.OrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderButton.Location = new System.Drawing.Point(1327, 717);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(235, 91);
            this.OrderButton.TabIndex = 3;
            this.OrderButton.Text = "Order";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // lockersPanel
            // 
            this.lockersPanel.Location = new System.Drawing.Point(620, 692);
            this.lockersPanel.Name = "lockersPanel";
            this.lockersPanel.Size = new System.Drawing.Size(203, 217);
            this.lockersPanel.TabIndex = 4;
            this.lockersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.lockerPanel_Paint);
            // 
            // SummaryPanel
            // 
            this.SummaryPanel.Location = new System.Drawing.Point(1552, 352);
            this.SummaryPanel.Name = "SummaryPanel";
            this.SummaryPanel.Size = new System.Drawing.Size(200, 100);
            this.SummaryPanel.TabIndex = 5;
            this.SummaryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SummaryPanel_Paint);
            // 
            // LockersLabel
            // 
            this.LockersLabel.AutoSize = true;
            this.LockersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockersLabel.Location = new System.Drawing.Point(406, 296);
            this.LockersLabel.Name = "LockersLabel";
            this.LockersLabel.Size = new System.Drawing.Size(245, 67);
            this.LockersLabel.TabIndex = 0;
            this.LockersLabel.Text = "Lockers";
            this.LockersLabel.Click += new System.EventHandler(this.LockersLabel_Click);
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SummaryLabel.Location = new System.Drawing.Point(985, 330);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(385, 89);
            this.SummaryLabel.TabIndex = 6;
            this.SummaryLabel.Text = "Summary";
            this.SummaryLabel.Click += new System.EventHandler(this.SummaryLabel_Click);
            // 
            // ColorGroup
            // 
            this.ColorGroup.Location = new System.Drawing.Point(54, 832);
            this.ColorGroup.Name = "ColorGroup";
            this.ColorGroup.Size = new System.Drawing.Size(200, 100);
            this.ColorGroup.TabIndex = 7;
            this.ColorGroup.TabStop = false;
            this.ColorGroup.Text = "Colors";
            this.ColorGroup.Enter += new System.EventHandler(this.ColorGroup_Enter);
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLabel.Location = new System.Drawing.Point(228, 783);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(204, 68);
            this.ColorLabel.TabIndex = 0;
            this.ColorLabel.Text = "Colors";
            this.ColorLabel.Click += new System.EventHandler(this.ColorLabel_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1879, 1007);
            this.Controls.Add(this.ColorLabel);
            this.Controls.Add(this.ColorGroup);
            this.Controls.Add(this.SummaryLabel);
            this.Controls.Add(this.LockersLabel);
            this.Controls.Add(this.SummaryPanel);
            this.Controls.Add(this.lockersPanel);
            this.Controls.Add(this.OrderButton);
            this.Controls.Add(this.SaveForLaterButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Window";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SaveForLaterButton;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Panel lockersPanel;
        private System.Windows.Forms.Panel SummaryPanel;
        private System.Windows.Forms.Label LockersLabel;
        private System.Windows.Forms.Label SummaryLabel;
        private System.Windows.Forms.GroupBox ColorGroup;
        private System.Windows.Forms.Label ColorLabel;
    }
}

