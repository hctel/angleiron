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
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleName = "header";
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, -6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 106);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "ANGLEIRON";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel2.Location = new System.Drawing.Point(1, 459);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 64);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // SaveForLaterButton
            // 
            this.SaveForLaterButton.AccessibleName = "SaveForLater";
            this.SaveForLaterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveForLaterButton.Location = new System.Drawing.Point(719, 459);
            this.SaveForLaterButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveForLaterButton.Name = "SaveForLaterButton";
            this.SaveForLaterButton.Size = new System.Drawing.Size(162, 58);
            this.SaveForLaterButton.TabIndex = 2;
            this.SaveForLaterButton.Text = "Save for later";
            this.SaveForLaterButton.UseVisualStyleBackColor = true;
            this.SaveForLaterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderButton
            // 
            this.OrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderButton.Location = new System.Drawing.Point(885, 459);
            this.OrderButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(157, 58);
            this.OrderButton.TabIndex = 3;
            this.OrderButton.Text = "Order";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // lockersPanel
            // 
            this.lockersPanel.Location = new System.Drawing.Point(413, 443);
            this.lockersPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lockersPanel.Name = "lockersPanel";
            this.lockersPanel.Size = new System.Drawing.Size(135, 139);
            this.lockersPanel.TabIndex = 4;
            this.lockersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.lockerPanel_Paint);
            // 
            // SummaryPanel
            // 
            this.SummaryPanel.Location = new System.Drawing.Point(1035, 225);
            this.SummaryPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SummaryPanel.Name = "SummaryPanel";
            this.SummaryPanel.Size = new System.Drawing.Size(133, 64);
            this.SummaryPanel.TabIndex = 5;
            this.SummaryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SummaryPanel_Paint);
            // 
            // LockersLabel
            // 
            this.LockersLabel.AutoSize = true;
            this.LockersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockersLabel.Location = new System.Drawing.Point(271, 189);
            this.LockersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LockersLabel.Name = "LockersLabel";
            this.LockersLabel.Size = new System.Drawing.Size(157, 42);
            this.LockersLabel.TabIndex = 0;
            this.LockersLabel.Text = "Lockers";
            this.LockersLabel.Click += new System.EventHandler(this.LockersLabel_Click);
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SummaryLabel.Location = new System.Drawing.Point(657, 211);
            this.SummaryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(183, 42);
            this.SummaryLabel.TabIndex = 6;
            this.SummaryLabel.Text = "Summary";
            this.SummaryLabel.Click += new System.EventHandler(this.SummaryLabel_Click);
            // 
            // ColorGroup
            // 
            this.ColorGroup.Location = new System.Drawing.Point(36, 532);
            this.ColorGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ColorGroup.Name = "ColorGroup";
            this.ColorGroup.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ColorGroup.Size = new System.Drawing.Size(133, 64);
            this.ColorGroup.TabIndex = 7;
            this.ColorGroup.TabStop = false;
            this.ColorGroup.Text = "Colors";
            this.ColorGroup.Enter += new System.EventHandler(this.ColorGroup_Enter);
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLabel.Location = new System.Drawing.Point(152, 501);
            this.ColorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(99, 31);
            this.ColorLabel.TabIndex = 0;
            this.ColorLabel.Text = "Colors";
            this.ColorLabel.Click += new System.EventHandler(this.ColorLabel_Click);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Location = new System.Drawing.Point(867, 291);
            this.ContainerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(133, 64);
            this.ContainerPanel.TabIndex = 8;
            this.ContainerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ContainerPanel_Paint);
            // 
            // ImagePanel
            // 
            this.ImagePanel.Location = new System.Drawing.Point(423, 291);
            this.ImagePanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(133, 64);
            this.ImagePanel.TabIndex = 9;
            this.ImagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ImagePanel_Paint);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 644);
            this.Controls.Add(this.ImagePanel);
            this.Controls.Add(this.ContainerPanel);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Panel ImagePanel;
    }
}

