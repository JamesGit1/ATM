namespace ATM_Sim
{
    partial class BankSystem
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
            this.newATM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newATM
            // 
            this.newATM.Location = new System.Drawing.Point(172, 123);
            this.newATM.Name = "newATM";
            this.newATM.Size = new System.Drawing.Size(75, 58);
            this.newATM.TabIndex = 0;
            this.newATM.Text = "New ATM";
            this.newATM.UseVisualStyleBackColor = true;
            this.newATM.Click += new System.EventHandler(this.newATM_Click);
            // 
            // BankSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 450);
            this.Controls.Add(this.newATM);
            this.Name = "BankSystem";
            this.Text = "Bank System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newATM;
    }
}