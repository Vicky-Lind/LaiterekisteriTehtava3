namespace PressureConverter
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            buttonLaske = new Button();
            textBoxkPa = new TextBox();
            textBoxPsi = new TextBox();
            textBoxBar = new TextBox();
            buttonClear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 30);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Paine kPa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 30);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Paine psi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 30);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 4;
            label3.Text = "Paine bar";
            // 
            // buttonLaske
            // 
            buttonLaske.Enabled = false;
            buttonLaske.Location = new Point(407, 138);
            buttonLaske.Name = "buttonLaske";
            buttonLaske.Size = new Size(75, 23);
            buttonLaske.TabIndex = 6;
            buttonLaske.Text = "Laske";
            buttonLaske.UseVisualStyleBackColor = true;
            buttonLaske.Click += buttonLaske_Click;
            // 
            // textBoxkPa
            // 
            textBoxkPa.Location = new Point(42, 58);
            textBoxkPa.Name = "textBoxkPa";
            textBoxkPa.Size = new Size(100, 23);
            textBoxkPa.TabIndex = 7;
            textBoxkPa.TextChanged += textBoxkPa_TextChanged;
            textBoxkPa.Leave += textBoxkPa_Leave;
            // 
            // textBoxPsi
            // 
            textBoxPsi.Enabled = false;
            textBoxPsi.Location = new Point(186, 58);
            textBoxPsi.Name = "textBoxPsi";
            textBoxPsi.Size = new Size(100, 23);
            textBoxPsi.TabIndex = 8;
            // 
            // textBoxBar
            // 
            textBoxBar.Enabled = false;
            textBoxBar.Location = new Point(330, 58);
            textBoxBar.Name = "textBoxBar";
            textBoxBar.Size = new Size(100, 23);
            textBoxBar.TabIndex = 9;
            // 
            // buttonClear
            // 
            buttonClear.Enabled = false;
            buttonClear.Location = new Point(311, 138);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 10;
            buttonClear.Text = "Tyhjennä";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 203);
            Controls.Add(buttonClear);
            Controls.Add(textBoxBar);
            Controls.Add(textBoxPsi);
            Controls.Add(textBoxkPa);
            Controls.Add(buttonLaske);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Pressure Converter";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button buttonLaske;
        private TextBox textBoxkPa;
        private TextBox textBoxPsi;
        private TextBox textBoxBar;
        private Button buttonClear;
    }
}