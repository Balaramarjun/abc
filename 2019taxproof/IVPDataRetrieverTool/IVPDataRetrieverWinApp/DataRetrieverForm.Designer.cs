namespace IVPDataRetriever.WinApp
{
    partial class DataRetrieverForm
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
            this.txtRepositoryPath = new System.Windows.Forms.TextBox();
            this.lblRepositoryPath = new System.Windows.Forms.Label();
            this.chkboxOnlyManagedSolutions = new System.Windows.Forms.CheckBox();
            this.lblOnlyManagedSolutions = new System.Windows.Forms.Label();
            this.btnGenerateFile = new System.Windows.Forms.Button();
            this.btnOpenFD = new System.Windows.Forms.Button();
            this.lblGenerateExcel = new System.Windows.Forms.Label();
            this.chkboxGenerateExcel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtRepositoryPath
            // 
            this.txtRepositoryPath.Location = new System.Drawing.Point(198, 56);
            this.txtRepositoryPath.Name = "txtRepositoryPath";
            this.txtRepositoryPath.Size = new System.Drawing.Size(554, 20);
            this.txtRepositoryPath.TabIndex = 0;
            // 
            // lblRepositoryPath
            // 
            this.lblRepositoryPath.AutoSize = true;
            this.lblRepositoryPath.Location = new System.Drawing.Point(69, 63);
            this.lblRepositoryPath.Name = "lblRepositoryPath";
            this.lblRepositoryPath.Size = new System.Drawing.Size(82, 13);
            this.lblRepositoryPath.TabIndex = 1;
            this.lblRepositoryPath.Text = "Repository Path";
            // 
            // chkboxOnlyManagedSolutions
            // 
            this.chkboxOnlyManagedSolutions.AutoSize = true;
            this.chkboxOnlyManagedSolutions.Location = new System.Drawing.Point(198, 125);
            this.chkboxOnlyManagedSolutions.Name = "chkboxOnlyManagedSolutions";
            this.chkboxOnlyManagedSolutions.Size = new System.Drawing.Size(15, 14);
            this.chkboxOnlyManagedSolutions.TabIndex = 2;
            this.chkboxOnlyManagedSolutions.UseVisualStyleBackColor = true;
            // 
            // lblOnlyManagedSolutions
            // 
            this.lblOnlyManagedSolutions.AutoSize = true;
            this.lblOnlyManagedSolutions.Location = new System.Drawing.Point(57, 126);
            this.lblOnlyManagedSolutions.Name = "lblOnlyManagedSolutions";
            this.lblOnlyManagedSolutions.Size = new System.Drawing.Size(122, 13);
            this.lblOnlyManagedSolutions.TabIndex = 3;
            this.lblOnlyManagedSolutions.Text = "Only Managed Solutions";
            // 
            // btnGenerateFile
            // 
            this.btnGenerateFile.Location = new System.Drawing.Point(198, 162);
            this.btnGenerateFile.Name = "btnGenerateFile";
            this.btnGenerateFile.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateFile.TabIndex = 4;
            this.btnGenerateFile.Text = "Generate";
            this.btnGenerateFile.UseVisualStyleBackColor = true;
            this.btnGenerateFile.Click += new System.EventHandler(this.BtnGenerateFile_Click);
            // 
            // btnOpenFD
            // 
            this.btnOpenFD.AccessibleName = "";
            this.btnOpenFD.Location = new System.Drawing.Point(758, 53);
            this.btnOpenFD.Name = "btnOpenFD";
            this.btnOpenFD.Size = new System.Drawing.Size(27, 23);
            this.btnOpenFD.TabIndex = 5;
            this.btnOpenFD.Text = "...";
            this.btnOpenFD.UseVisualStyleBackColor = true;
            this.btnOpenFD.Click += new System.EventHandler(this.BtnOpenFD_Click);
            // 
            // lblGenerateExcel
            // 
            this.lblGenerateExcel.AutoSize = true;
            this.lblGenerateExcel.Location = new System.Drawing.Point(74, 96);
            this.lblGenerateExcel.Name = "lblGenerateExcel";
            this.lblGenerateExcel.Size = new System.Drawing.Size(77, 13);
            this.lblGenerateExcel.TabIndex = 6;
            this.lblGenerateExcel.Text = "GenerateExcel";
            // 
            // chkboxGenerateExcel
            // 
            this.chkboxGenerateExcel.AutoSize = true;
            this.chkboxGenerateExcel.Location = new System.Drawing.Point(198, 92);
            this.chkboxGenerateExcel.Name = "chkboxGenerateExcel";
            this.chkboxGenerateExcel.Size = new System.Drawing.Size(15, 14);
            this.chkboxGenerateExcel.TabIndex = 7;
            this.chkboxGenerateExcel.UseVisualStyleBackColor = true;
            // 
            // StatusRetriever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 197);
            this.Controls.Add(this.chkboxGenerateExcel);
            this.Controls.Add(this.lblGenerateExcel);
            this.Controls.Add(this.btnOpenFD);
            this.Controls.Add(this.btnGenerateFile);
            this.Controls.Add(this.lblOnlyManagedSolutions);
            this.Controls.Add(this.chkboxOnlyManagedSolutions);
            this.Controls.Add(this.lblRepositoryPath);
            this.Controls.Add(this.txtRepositoryPath);
            this.Name = "StatusRetriever";
            this.Text = "Status Retriever";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRepositoryPath;
        private System.Windows.Forms.Label lblRepositoryPath;
        private System.Windows.Forms.CheckBox chkboxOnlyManagedSolutions;
        private System.Windows.Forms.Label lblOnlyManagedSolutions;
        private System.Windows.Forms.Button btnGenerateFile;
        private System.Windows.Forms.Button btnOpenFD;
        private System.Windows.Forms.Label lblGenerateExcel;
        private System.Windows.Forms.CheckBox chkboxGenerateExcel;
    }
}

