﻿//
// Main website for TVRename is http://tvrename.com
//
// Source code available at http://code.google.com/p/tvrename/
//
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
//


namespace TVRename
{
    partial class AddEditSeasEpFinders
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
            this.components = (new System.ComponentModel.Container());
            System.ComponentModel.ComponentResourceManager resources = (new System.ComponentModel.ComponentResourceManager(typeof(AddEditSeasEpFinders)));
            this.bnOK = (new System.Windows.Forms.Button());
            this.bnCancel = (new System.Windows.Forms.Button());
            this.bnDelete = (new System.Windows.Forms.Button());
            this.bnAdd = (new System.Windows.Forms.Button());
            this.lvPreview = (new System.Windows.Forms.ListView());
            this.columnHeader1 = (new System.Windows.Forms.ColumnHeader());
            this.columnHeader2 = (new System.Windows.Forms.ColumnHeader());
            this.columnHeader3 = (new System.Windows.Forms.ColumnHeader());
            this.bnBrowse = (new System.Windows.Forms.Button());
            this.folderBrowser = (new System.Windows.Forms.FolderBrowserDialog());
            this.label1 = (new System.Windows.Forms.Label());
            this.cbShowList = (new System.Windows.Forms.ComboBox());
            this.label2 = (new System.Windows.Forms.Label());
            this.txtFolder = (new System.Windows.Forms.TextBox());
            this.tmrFillPreview = (new System.Windows.Forms.Timer(this.components));
            this.chkTestAll = (new System.Windows.Forms.CheckBox());
            this.bnDefaults = (new System.Windows.Forms.Button());
            this.Grid1 = (new SourceGrid.Grid());
            this.SuspendLayout();
            // 
            // bnOK
            // 
            this.bnOK.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bnOK.Location = new System.Drawing.Point(741, 560);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 6;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            this.bnOK.Click += bnOK_Click;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(822, 560);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 7;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnDelete
            // 
            this.bnDelete.Location = new System.Drawing.Point(93, 266);
            this.bnDelete.Name = "bnDelete";
            this.bnDelete.Size = new System.Drawing.Size(75, 23);
            this.bnDelete.TabIndex = 5;
            this.bnDelete.Text = "&Delete";
            this.bnDelete.UseVisualStyleBackColor = true;
            this.bnDelete.Click += bnDelete_Click;
            // 
            // bnAdd
            // 
            this.bnAdd.Location = new System.Drawing.Point(12, 266);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(75, 23);
            this.bnAdd.TabIndex = 4;
            this.bnAdd.Text = "&Add";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += bnAdd_Click;
            // 
            // lvPreview
            // 
            this.lvPreview.Anchor = (System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lvPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.columnHeader1, this.columnHeader2, this.columnHeader3 });
            this.lvPreview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPreview.Location = new System.Drawing.Point(12, 295);
            this.lvPreview.Name = "lvPreview";
            this.lvPreview.Size = new System.Drawing.Size(885, 259);
            this.lvPreview.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPreview.TabIndex = 8;
            this.lvPreview.UseCompatibleStateImageBehavior = false;
            this.lvPreview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 335;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Season";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Episode";
            // 
            // bnBrowse
            // 
            this.bnBrowse.Location = new System.Drawing.Point(591, 266);
            this.bnBrowse.Name = "bnBrowse";
            this.bnBrowse.Size = new System.Drawing.Size(75, 23);
            this.bnBrowse.TabIndex = 9;
            this.bnBrowse.Text = "&Browse...";
            this.bnBrowse.UseVisualStyleBackColor = true;
            this.bnBrowse.Click += new System.EventHandler(bnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(672, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Show:";
            // 
            // cbShowList
            // 
            this.cbShowList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShowList.FormattingEnabled = true;
            this.cbShowList.Location = new System.Drawing.Point(715, 268);
            this.cbShowList.Name = "cbShowList";
            this.cbShowList.Size = new System.Drawing.Size(182, 21);
            this.cbShowList.TabIndex = 11;
            this.cbShowList.SelectedIndexChanged += new System.EventHandler(cbShowList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Test Folder:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(391, 268);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(194, 20);
            this.txtFolder.TabIndex = 12;
            this.txtFolder.TextChanged += new System.EventHandler(txtFolder_TextChanged);
            // 
            // tmrFillPreview
            // 
            this.tmrFillPreview.Interval = 500;
            this.tmrFillPreview.Tick += new System.EventHandler(tmrFillPreview_Tick);
            // 
            // chkTestAll
            // 
            this.chkTestAll.AutoSize = true;
            this.chkTestAll.Checked = true;
            this.chkTestAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestAll.Location = new System.Drawing.Point(255, 270);
            this.chkTestAll.Name = "chkTestAll";
            this.chkTestAll.Size = new System.Drawing.Size(61, 17);
            this.chkTestAll.TabIndex = 13;
            this.chkTestAll.Text = "Test All";
            this.chkTestAll.UseVisualStyleBackColor = true;
            this.chkTestAll.CheckedChanged += new System.EventHandler(chkTestAll_CheckedChanged);
            // 
            // bnDefaults
            // 
            this.bnDefaults.Location = new System.Drawing.Point(174, 266);
            this.bnDefaults.Name = "bnDefaults";
            this.bnDefaults.Size = new System.Drawing.Size(75, 23);
            this.bnDefaults.TabIndex = 14;
            this.bnDefaults.Text = "D&efaults";
            this.bnDefaults.UseVisualStyleBackColor = true;
            this.bnDefaults.Click += new System.EventHandler(bnDefaults_Click);
            // 
            // Grid1
            // 
            this.Grid1.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.Grid1.BackColor = System.Drawing.SystemColors.Window;
            this.Grid1.Location = new System.Drawing.Point(13, 13);
            this.Grid1.Name = "Grid1";
            this.Grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.Grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.Grid1.Size = new System.Drawing.Size(884, 247);
            this.Grid1.TabIndex = 15;
            this.Grid1.TabStop = true;
            this.Grid1.ToolTipText = "";
            // 
            // AddEditSeasEpFinders
            // 
            this.AcceptButton = this.bnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(909, 595);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.bnDefaults);
            this.Controls.Add(this.chkTestAll);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.cbShowList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnBrowse);
            this.Controls.Add(this.lvPreview);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnDelete);
            this.Controls.Add(this.bnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(917, 430);
            this.ShowInTaskbar = false;
            this.Text = "Filename Processors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Timer tmrFillPreview;

        private System.Windows.Forms.CheckBox chkTestAll;
        private System.Windows.Forms.Button bnDefaults;
        private SourceGrid.Grid Grid1;

        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnDelete;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.ListView lvPreview;
        private System.Windows.Forms.Button bnBrowse;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbShowList;
    }
}