namespace tfm
{
    partial class ctlAirSystems
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
            this.tmrAir = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrAir
            // 
            this.tmrAir.Interval = 500;
            this.tmrAir.Tick += new System.EventHandler(this.tmrAir_Tick);
            // 
            // ctlAirSystems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctlAirSystems";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrAir;
    }
}
