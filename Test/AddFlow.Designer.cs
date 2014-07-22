namespace Test
{
    partial class AddFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFlow));
            this.axAddFlow1 = new AxAddFlow4Lib.AxAddFlow();
            ((System.ComponentModel.ISupportInitialize)(this.axAddFlow1)).BeginInit();
            this.SuspendLayout();
            // 
            // axAddFlow1
            // 
            this.axAddFlow1.Location = new System.Drawing.Point(12, 12);
            this.axAddFlow1.Name = "axAddFlow1";
            this.axAddFlow1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAddFlow1.OcxState")));
            this.axAddFlow1.Size = new System.Drawing.Size(496, 384);
            this.axAddFlow1.TabIndex = 0;
            // 
            // AddFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 480);
            this.Controls.Add(this.axAddFlow1);
            this.Name = "AddFlow";
            this.Text = "AddFlow";
            ((System.ComponentModel.ISupportInitialize)(this.axAddFlow1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAddFlow4Lib.AxAddFlow axAddFlow1;
    }
}