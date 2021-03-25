
namespace Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_URL = new System.Windows.Forms.TextBox();
            this.btn_extract = new System.Windows.Forms.Button();
            this.lb_Result = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.lbl_imageLable = new System.Windows.Forms.Label();
            this.btn_ClearSelection = new System.Windows.Forms.Button();
            this.btn_DownloadImages = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL: https://";
            // 
            // tb_URL
            // 
            this.tb_URL.Location = new System.Drawing.Point(125, 29);
            this.tb_URL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_URL.Name = "tb_URL";
            this.tb_URL.Size = new System.Drawing.Size(344, 23);
            this.tb_URL.TabIndex = 1;
            // 
            // btn_extract
            // 
            this.btn_extract.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_extract.Location = new System.Drawing.Point(517, 20);
            this.btn_extract.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_extract.Name = "btn_extract";
            this.btn_extract.Size = new System.Drawing.Size(82, 36);
            this.btn_extract.TabIndex = 2;
            this.btn_extract.Text = "Extract";
            this.btn_extract.UseVisualStyleBackColor = true;
            this.btn_extract.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_Result
            // 
            this.lb_Result.BackColor = System.Drawing.SystemColors.Info;
            this.lb_Result.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_Result.FormattingEnabled = true;
            this.lb_Result.HorizontalScrollbar = true;
            this.lb_Result.ItemHeight = 15;
            this.lb_Result.Location = new System.Drawing.Point(6, 29);
            this.lb_Result.Name = "lb_Result";
            this.lb_Result.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_Result.Size = new System.Drawing.Size(774, 289);
            this.lb_Result.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btn_SelectAll);
            this.groupBox1.Controls.Add(this.lbl_imageLable);
            this.groupBox1.Controls.Add(this.btn_ClearSelection);
            this.groupBox1.Controls.Add(this.btn_DownloadImages);
            this.groupBox1.Controls.Add(this.lb_Result);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(42, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(786, 435);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IMG URLs";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_SelectAll.Location = new System.Drawing.Point(646, 353);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(134, 23);
            this.btn_SelectAll.TabIndex = 8;
            this.btn_SelectAll.Text = "Select all";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // lbl_imageLable
            // 
            this.lbl_imageLable.AutoSize = true;
            this.lbl_imageLable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_imageLable.Location = new System.Drawing.Point(6, 327);
            this.lbl_imageLable.Name = "lbl_imageLable";
            this.lbl_imageLable.Size = new System.Drawing.Size(20, 17);
            this.lbl_imageLable.TabIndex = 7;
            this.lbl_imageLable.Text = "   ";
            // 
            // btn_ClearSelection
            // 
            this.btn_ClearSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_ClearSelection.Location = new System.Drawing.Point(646, 324);
            this.btn_ClearSelection.Name = "btn_ClearSelection";
            this.btn_ClearSelection.Size = new System.Drawing.Size(134, 23);
            this.btn_ClearSelection.TabIndex = 6;
            this.btn_ClearSelection.Text = "Clear selection";
            this.btn_ClearSelection.UseVisualStyleBackColor = true;
            this.btn_ClearSelection.Click += new System.EventHandler(this.btn_ClearSelection_Click);
            // 
            // btn_DownloadImages
            // 
            this.btn_DownloadImages.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_DownloadImages.Location = new System.Drawing.Point(646, 382);
            this.btn_DownloadImages.Name = "btn_DownloadImages";
            this.btn_DownloadImages.Size = new System.Drawing.Size(134, 48);
            this.btn_DownloadImages.TabIndex = 5;
            this.btn_DownloadImages.Text = "Save images";
            this.btn_DownloadImages.UseVisualStyleBackColor = true;
            this.btn_DownloadImages.Click += new System.EventHandler(this.btn_DownloadImages_ClickAsync);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_extract;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 527);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_extract);
            this.Controls.Add(this.tb_URL);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(873, 566);
            this.MinimumSize = new System.Drawing.Size(873, 566);
            this.Name = "Form1";
            this.Text = "Image finder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_URL;
        private System.Windows.Forms.Button btn_extract;
        private System.Windows.Forms.ListBox lb_Result;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_DownloadImages;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_ClearSelection;
        private System.Windows.Forms.Label lbl_imageLable;
        private System.Windows.Forms.Button btn_SelectAll;
    }
}

