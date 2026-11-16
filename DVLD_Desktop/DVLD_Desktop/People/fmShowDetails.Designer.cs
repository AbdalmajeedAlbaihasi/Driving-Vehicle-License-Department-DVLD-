namespace DVLD_Desktop_Net8
{
    partial class fmShowDetails
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
            button1 = new Button();
            ucShowDetails1 = new DVLD_Desktop_Net8.User_Control.ucShowPesronDetails();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.MouseDownBackColor = Color.Blue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.Image = Properties.Resources.Close_32;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(691, 348);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(117, 32);
            button1.TabIndex = 19;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ucShowDetails1
            // 
            ucShowDetails1.BackColor = Color.White;
            ucShowDetails1.Location = new Point(3, 3);
            ucShowDetails1.Name = "ucShowDetails1";
            ucShowDetails1.Size = new Size(779, 259);
            ucShowDetails1.TabIndex = 20;
            ucShowDetails1.Load += ucShowDetails1_Load_1;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(ucShowDetails1);
            panel1.Location = new Point(14, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 272);
            panel1.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(339, 24);
            label1.Name = "label1";
            label1.Size = new Size(151, 30);
            label1.TabIndex = 22;
            label1.Text = "Person Details";
            // 
            // fmShowDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(834, 412);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "fmShowDetails";
            Text = "fmShowDetails";
            Load += fmShowDetails_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private DVLD_Desktop_Net8.User_Control.ucShowPesronDetails ucShowDetails1;
        private Panel panel1;
        private Label label1;
    }
}