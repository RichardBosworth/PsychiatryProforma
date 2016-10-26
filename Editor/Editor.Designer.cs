namespace Editor
{
    partial class Form1
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
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booleanElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maskedElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choiceElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labResultElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.normalContextMenuStrip.SuspendLayout();
            this.groupContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(323, 49);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(436, 522);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 49);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(305, 522);
            this.treeView.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "File...";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // normalContextMenuStrip
            // 
            this.normalContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemToolStripMenuItem});
            this.normalContextMenuStrip.Name = "normalContextMenuStrip";
            this.normalContextMenuStrip.Size = new System.Drawing.Size(144, 26);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete item...";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteItemToolStripMenuItem_Click);
            // 
            // groupContextMenuStrip
            // 
            this.groupContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.toolStripMenuItem1});
            this.groupContextMenuStrip.Name = "normalContextMenuStrip";
            this.groupContextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stringElementToolStripMenuItem,
            this.booleanElementToolStripMenuItem,
            this.groupElementToolStripMenuItem,
            this.maskedElementToolStripMenuItem,
            this.choiceElementToolStripMenuItem,
            this.listElementToolStripMenuItem,
            this.labResultElementToolStripMenuItem,
            this.labelElementToolStripMenuItem});
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addItemToolStripMenuItem.Text = "Add...";
            // 
            // stringElementToolStripMenuItem
            // 
            this.stringElementToolStripMenuItem.Name = "stringElementToolStripMenuItem";
            this.stringElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.stringElementToolStripMenuItem.Text = "String Element";
            this.stringElementToolStripMenuItem.Click += new System.EventHandler(this.stringElementToolStripMenuItem_Click);
            // 
            // booleanElementToolStripMenuItem
            // 
            this.booleanElementToolStripMenuItem.Name = "booleanElementToolStripMenuItem";
            this.booleanElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.booleanElementToolStripMenuItem.Text = "Boolean Element";
            this.booleanElementToolStripMenuItem.Click += new System.EventHandler(this.booleanElementToolStripMenuItem_Click);
            // 
            // groupElementToolStripMenuItem
            // 
            this.groupElementToolStripMenuItem.Name = "groupElementToolStripMenuItem";
            this.groupElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.groupElementToolStripMenuItem.Text = "Group Element";
            this.groupElementToolStripMenuItem.Click += new System.EventHandler(this.groupElementToolStripMenuItem_Click);
            // 
            // maskedElementToolStripMenuItem
            // 
            this.maskedElementToolStripMenuItem.Name = "maskedElementToolStripMenuItem";
            this.maskedElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.maskedElementToolStripMenuItem.Text = "Masked Element";
            this.maskedElementToolStripMenuItem.Click += new System.EventHandler(this.maskedElementToolStripMenuItem_Click);
            // 
            // choiceElementToolStripMenuItem
            // 
            this.choiceElementToolStripMenuItem.Name = "choiceElementToolStripMenuItem";
            this.choiceElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.choiceElementToolStripMenuItem.Text = "Choice Element";
            this.choiceElementToolStripMenuItem.Click += new System.EventHandler(this.choiceElementToolStripMenuItem_Click);
            // 
            // listElementToolStripMenuItem
            // 
            this.listElementToolStripMenuItem.Name = "listElementToolStripMenuItem";
            this.listElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.listElementToolStripMenuItem.Text = "List Element";
            this.listElementToolStripMenuItem.Click += new System.EventHandler(this.listElementToolStripMenuItem_Click);
            // 
            // labResultElementToolStripMenuItem
            // 
            this.labResultElementToolStripMenuItem.Name = "labResultElementToolStripMenuItem";
            this.labResultElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.labResultElementToolStripMenuItem.Text = "Lab Result Element";
            this.labResultElementToolStripMenuItem.Click += new System.EventHandler(this.labResultElementToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Delete item...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // labelElementToolStripMenuItem
            // 
            this.labelElementToolStripMenuItem.Name = "labelElementToolStripMenuItem";
            this.labelElementToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.labelElementToolStripMenuItem.Text = "Label Element";
            this.labelElementToolStripMenuItem.Click += new System.EventHandler(this.labelElementToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 583);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Proforma Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.normalContextMenuStrip.ResumeLayout(false);
            this.groupContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip normalContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip groupContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stringElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booleanElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maskedElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem choiceElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labResultElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelElementToolStripMenuItem;
    }
}

