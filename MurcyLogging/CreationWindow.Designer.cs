using System.ComponentModel;
using System.Windows.Forms;

namespace MurcyLogging
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxStory = new System.Windows.Forms.ComboBox();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelControls = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxAddSection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.multiselectComboBoxCommits = new MurcyLogging.MultiselectComboBox();
            this.multiselectComboBoxPeer = new MurcyLogging.MultiselectComboBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Story*:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Task*:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Peer Programmed With:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Commits Made:";
            // 
            // comboBoxStory
            // 
            this.comboBoxStory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStory.FormattingEnabled = true;
            this.comboBoxStory.Location = new System.Drawing.Point(192, 5);
            this.comboBoxStory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxStory.Name = "comboBoxStory";
            this.comboBoxStory.Size = new System.Drawing.Size(616, 28);
            this.comboBoxStory.TabIndex = 12;
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Location = new System.Drawing.Point(192, 42);
            this.comboBoxTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTask.Name = "comboBoxTask";
            this.comboBoxTask.Size = new System.Drawing.Size(616, 28);
            this.comboBoxTask.TabIndex = 13;
            // 
            // tableLayoutPanelControls
            // 
            this.tableLayoutPanelControls.AutoScroll = true;
            this.tableLayoutPanelControls.AutoScrollMargin = new System.Drawing.Size(40, 0);
            this.tableLayoutPanelControls.AutoSize = true;
            this.tableLayoutPanelControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelControls.ColumnCount = 2;
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.Controls.Add(this.comboBoxAddSection, 1, 4);
            this.tableLayoutPanelControls.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanelControls.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.multiselectComboBoxCommits, 1, 3);
            this.tableLayoutPanelControls.Controls.Add(this.comboBoxTask, 1, 1);
            this.tableLayoutPanelControls.Controls.Add(this.multiselectComboBoxPeer, 1, 2);
            this.tableLayoutPanelControls.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelControls.Controls.Add(this.comboBoxStory, 1, 0);
            this.tableLayoutPanelControls.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanelControls.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanelControls.Controls.Add(this.flowLayoutPanel, 1, 5);
            this.tableLayoutPanelControls.Controls.Add(this.button1, 1, 6);
            this.tableLayoutPanelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControls.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanelControls.Name = "tableLayoutPanelControls";
            this.tableLayoutPanelControls.RowCount = 7;
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanelControls.Size = new System.Drawing.Size(812, 457);
            this.tableLayoutPanelControls.TabIndex = 14;
            // 
            // comboBoxAddSection
            // 
            this.comboBoxAddSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAddSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddSection.FormattingEnabled = true;
            this.comboBoxAddSection.Items.AddRange(new object[] {
            "Implemented",
            "Documented",
            "Fixed",
            "Tested",
            "Manually Tested",
            "Refactored",
            "Detailed Description",
            "Chore (misc)"});
            this.comboBoxAddSection.Location = new System.Drawing.Point(192, 153);
            this.comboBoxAddSection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAddSection.Name = "comboBoxAddSection";
            this.comboBoxAddSection.Size = new System.Drawing.Size(616, 28);
            this.comboBoxAddSection.TabIndex = 15;
            this.comboBoxAddSection.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Add Section:";
            // 
            // multiselectComboBoxCommits
            // 
            this.multiselectComboBoxCommits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.multiselectComboBoxCommits.FormattingEnabled = true;
            this.multiselectComboBoxCommits.Location = new System.Drawing.Point(192, 116);
            this.multiselectComboBoxCommits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.multiselectComboBoxCommits.Name = "multiselectComboBoxCommits";
            this.multiselectComboBoxCommits.Size = new System.Drawing.Size(616, 28);
            this.multiselectComboBoxCommits.TabIndex = 11;
            // 
            // multiselectComboBoxPeer
            // 
            this.multiselectComboBoxPeer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.multiselectComboBoxPeer.FormattingEnabled = true;
            this.multiselectComboBoxPeer.Location = new System.Drawing.Point(192, 79);
            this.multiselectComboBoxPeer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.multiselectComboBoxPeer.Name = "multiselectComboBoxPeer";
            this.multiselectComboBoxPeer.Size = new System.Drawing.Size(616, 28);
            this.multiselectComboBoxPeer.TabIndex = 8;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(192, 190);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(616, 1);
            this.flowLayoutPanel.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 200);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 17;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenerateClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 457);
            this.Controls.Add(this.tableLayoutPanelControls);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "MurcyLogging";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanelControls.ResumeLayout(false);
            this.tableLayoutPanelControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private MultiselectComboBox multiselectComboBoxPeer;
        private Label label3;
        private Label label4;
        private MultiselectComboBox multiselectComboBoxCommits;
        private ComboBox comboBoxStory;
        private ComboBox comboBoxTask;
        private TableLayoutPanel tableLayoutPanelControls;
        private ComboBox comboBoxAddSection;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel;
        private Button button1;
    }
}

