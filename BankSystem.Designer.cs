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
            this.newATM.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newATM.Location = new System.Drawing.Point(11, 11);
            this.newATM.Margin = new System.Windows.Forms.Padding(2);
            this.newATM.Name = "newATM";
            this.newATM.Size = new System.Drawing.Size(127, 108);
            this.newATM.TabIndex = 0;
            this.newATM.Text = "New ATM";
            this.newATM.UseVisualStyleBackColor = true;
            this.newATM.Click += new System.EventHandler(this.newATM_Click);
            // 
            // BankSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 134);
            this.Controls.Add(this.newATM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "BankSystem";
            this.ShowIcon = false;
            this.Text = "Bank System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newATM;
    }
}