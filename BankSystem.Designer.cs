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
            this.raceConditionOn = new System.Windows.Forms.RadioButton();
            this.raceComboBox = new System.Windows.Forms.Panel();
            this.RaceConditionOff = new System.Windows.Forms.RadioButton();
            this.raceComboBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // newATM
            // 
            this.newATM.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newATM.Location = new System.Drawing.Point(15, 14);
            this.newATM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newATM.Name = "newATM";
            this.newATM.Size = new System.Drawing.Size(172, 98);
            this.newATM.TabIndex = 0;
            this.newATM.Text = "New ATM";
            this.newATM.UseVisualStyleBackColor = true;
            this.newATM.Click += new System.EventHandler(this.newATM_Click);
            // 
            // raceConditionOn
            // 
            this.raceConditionOn.AutoSize = true;
            this.raceConditionOn.Location = new System.Drawing.Point(3, 6);
            this.raceConditionOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.raceConditionOn.Name = "raceConditionOn";
            this.raceConditionOn.Size = new System.Drawing.Size(125, 21);
            this.raceConditionOn.TabIndex = 0;
            this.raceConditionOn.TabStop = true;
            this.raceConditionOn.Text = "Race Condition";
            this.raceConditionOn.UseVisualStyleBackColor = true;
            // 
            // raceComboBox
            // 
            this.raceComboBox.Controls.Add(this.RaceConditionOff);
            this.raceComboBox.Controls.Add(this.raceConditionOn);
            this.raceComboBox.Location = new System.Drawing.Point(192, 30);
            this.raceComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.raceComboBox.Name = "raceComboBox";
            this.raceComboBox.Size = new System.Drawing.Size(200, 68);
            this.raceComboBox.TabIndex = 2;
            // 
            // RaceConditionOff
            // 
            this.RaceConditionOff.AutoSize = true;
            this.RaceConditionOff.Location = new System.Drawing.Point(3, 33);
            this.RaceConditionOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RaceConditionOff.Name = "RaceConditionOff";
            this.RaceConditionOff.Size = new System.Drawing.Size(147, 21);
            this.RaceConditionOff.TabIndex = 1;
            this.RaceConditionOff.TabStop = true;
            this.RaceConditionOff.Text = "No Race Condition";
            this.RaceConditionOff.UseVisualStyleBackColor = true;
            // 
            // BankSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 127);
            this.Controls.Add(this.raceComboBox);
            this.Controls.Add(this.newATM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "BankSystem";
            this.ShowIcon = false;
            this.Text = "Bank System";
            this.Load += new System.EventHandler(this.BankSystem_Load);
            this.raceComboBox.ResumeLayout(false);
            this.raceComboBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newATM;
        private System.Windows.Forms.RadioButton raceConditionOn;
        private System.Windows.Forms.Panel raceComboBox;
        private System.Windows.Forms.RadioButton RaceConditionOff;
    }
}