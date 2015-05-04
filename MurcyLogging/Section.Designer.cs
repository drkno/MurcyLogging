namespace MurcyLogging
{
    partial class Section
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelSectionTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(486, 43);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // labelSectionTitle
            // 
            this.labelSectionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSectionTitle.AutoEllipsis = true;
            this.labelSectionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectionTitle.Location = new System.Drawing.Point(3, 4);
            this.labelSectionTitle.Name = "labelSectionTitle";
            this.labelSectionTitle.Size = new System.Drawing.Size(489, 23);
            this.labelSectionTitle.TabIndex = 1;
            this.labelSectionTitle.Text = "[sectionTitle]";
            this.labelSectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.AutoEllipsis = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 29);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(489, 16);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "[description]";
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatAppearance.BorderSize = 0;
            this.buttonRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRemove.Location = new System.Drawing.Point(464, 4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(28, 25);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "X";
            this.buttonRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // Section
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelSectionTitle);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Section";
            this.Size = new System.Drawing.Size(495, 97);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelSectionTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonRemove;
    }
}
