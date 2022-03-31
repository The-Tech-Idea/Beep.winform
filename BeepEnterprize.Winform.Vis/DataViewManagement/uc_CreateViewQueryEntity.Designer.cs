namespace BeepEnterprize.Winform.Vis.DataViewManagement
{
    partial class uc_CreateViewQueryEntity
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataViewDataSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewDataSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataViewDataSourceBindingSource
            // 
            this.dataViewDataSourceBindingSource.AllowNew = true;
            this.dataViewDataSourceBindingSource.DataSource = typeof(TheTechIdea.Beep.DataBase.DMDataView);
            // 
            // uc_CreateViewQueryEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "uc_CreateViewQueryEntity";
            this.Size = new System.Drawing.Size(615, 584);
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewDataSourceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource dataViewDataSourceBindingSource;
    }
}
