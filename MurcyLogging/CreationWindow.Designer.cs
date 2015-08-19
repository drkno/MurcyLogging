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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.teamMembersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.peerProgrammedCheckBox = new System.Windows.Forms.CheckBox();
            this.timeSpentBox = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Story*:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Task*:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Log For:*";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Commits Made:";
            // 
            // comboBoxStory
            // 
            this.comboBoxStory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStory.FormattingEnabled = true;
            this.comboBoxStory.Location = new System.Drawing.Point(128, 3);
            this.comboBoxStory.Name = "comboBoxStory";
            this.comboBoxStory.Size = new System.Drawing.Size(412, 21);
            this.comboBoxStory.TabIndex = 12;
            this.comboBoxStory.SelectedValueChanged += new System.EventHandler(this.comboBoxStory_SelectedValueChanged);
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Location = new System.Drawing.Point(128, 27);
            this.comboBoxTask.Name = "comboBoxTask";
            this.comboBoxTask.Size = new System.Drawing.Size(412, 21);
            this.comboBoxTask.TabIndex = 13;
            // 
            // tableLayoutPanelControls
            // 
            this.tableLayoutPanelControls.AutoScroll = true;
            this.tableLayoutPanelControls.AutoScrollMargin = new System.Drawing.Size(40, 0);
            this.tableLayoutPanelControls.AutoSize = true;
            this.tableLayoutPanelControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelControls.ColumnCount = 2;
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.Controls.Add(this.comboBoxAddSection, 1, 7);
            this.tableLayoutPanelControls.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanelControls.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.multiselectComboBoxCommits, 1, 6);
            this.tableLayoutPanelControls.Controls.Add(this.comboBoxTask, 1, 1);
            this.tableLayoutPanelControls.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelControls.Controls.Add(this.comboBoxStory, 1, 0);
            this.tableLayoutPanelControls.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanelControls.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanelControls.Controls.Add(this.flowLayoutPanel, 1, 8);
            this.tableLayoutPanelControls.Controls.Add(this.button1, 1, 9);
            this.tableLayoutPanelControls.Controls.Add(this.teamMembersPanel, 1, 4);
            this.tableLayoutPanelControls.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanelControls.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanelControls.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanelControls.Controls.Add(this.peerProgrammedCheckBox, 1, 5);
            this.tableLayoutPanelControls.Controls.Add(this.timeSpentBox, 1, 2);
            this.tableLayoutPanelControls.Controls.Add(this.datePicker, 1, 3);
            this.tableLayoutPanelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControls.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelControls.Name = "tableLayoutPanelControls";
            this.tableLayoutPanelControls.RowCount = 10;
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanelControls.Size = new System.Drawing.Size(541, 297);
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
            this.comboBoxAddSection.Location = new System.Drawing.Point(128, 223);
            this.comboBoxAddSection.Name = "comboBoxAddSection";
            this.comboBoxAddSection.Size = new System.Drawing.Size(412, 21);
            this.comboBoxAddSection.TabIndex = 15;
            this.comboBoxAddSection.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Add Section:";
            // 
            // multiselectComboBoxCommits
            // 
            this.multiselectComboBoxCommits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.multiselectComboBoxCommits.FormattingEnabled = true;
            this.multiselectComboBoxCommits.Location = new System.Drawing.Point(128, 196);
            this.multiselectComboBoxCommits.Name = "multiselectComboBoxCommits";
            this.multiselectComboBoxCommits.Size = new System.Drawing.Size(412, 21);
            this.multiselectComboBoxCommits.TabIndex = 11;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(128, 249);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(412, 1);
            this.flowLayoutPanel.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenerateClick);
            // 
            // teamMembersPanel
            // 
            this.teamMembersPanel.AutoSize = true;
            this.teamMembersPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.teamMembersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamMembersPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.teamMembersPanel.Location = new System.Drawing.Point(128, 91);
            this.teamMembersPanel.Name = "teamMembersPanel";
            this.teamMembersPanel.Size = new System.Drawing.Size(412, 76);
            this.teamMembersPanel.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Time Spent* (minutes):";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Date:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Peer Programmed?";
            // 
            // peerProgrammedCheckBox
            // 
            this.peerProgrammedCheckBox.AutoSize = true;
            this.peerProgrammedCheckBox.Location = new System.Drawing.Point(128, 173);
            this.peerProgrammedCheckBox.Name = "peerProgrammedCheckBox";
            this.peerProgrammedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.peerProgrammedCheckBox.TabIndex = 23;
            this.peerProgrammedCheckBox.UseVisualStyleBackColor = true;
            // 
            // timeSpentBox
            // 
            this.timeSpentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeSpentBox.Location = new System.Drawing.Point(128, 51);
            this.timeSpentBox.Name = "timeSpentBox";
            this.timeSpentBox.Size = new System.Drawing.Size(412, 20);
            this.timeSpentBox.TabIndex = 24;
            // 
            // datePicker
            // 
            this.datePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePicker.CustomFormat = "yyyy/MM/dd hh:mm";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(128, 71);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(412, 20);
            this.datePicker.TabIndex = 25;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 297);
            this.Controls.Add(this.tableLayoutPanelControls);
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
        private FlowLayoutPanel teamMembersPanel;
        private Label label6;
        private Label label7;
        private Label label8;
        private CheckBox peerProgrammedCheckBox;
        private TextBox timeSpentBox;
        private DateTimePicker datePicker;
    }
}

