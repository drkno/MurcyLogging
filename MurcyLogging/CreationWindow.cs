using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Agilefantasy;

namespace MurcyLogging
{
    public partial class MainWindow : Form
    {
        private AgilefantSession session;

        public MainWindow(AgilefantSession newSession)
        {
            this.session = newSession;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void AddSection(string sectionName, string sectionDescription, string hashTag)
        {
            var section = new Section(sectionName, sectionDescription, hashTag);
            section.RemoveSection += RemoveSection;

            flowLayoutPanel.Controls.Add(section);
        }

        private void RemoveSection(Section sender)
        {
            flowLayoutPanel.Controls.Remove(sender);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxAddSection.SelectedIndex)
            {
                case 0: AddSection("Implemented", "Code was written that implemented some functionality.", "#implement"); break;
                case 1: AddSection("Documented", "Documentation eg User Guide or JavaDoc was written.", "#document"); break;
                case 2: AddSection("Fixed", "A bug was fixed.", "#fix"); break;
                case 3: AddSection("Tested", "Unit tests and integration tests written.", "#test"); break;
                case 4: AddSection("Manually Tested", "Manual testing performed and the manual test plan used.", "#testmanual"); break;
                case 5: AddSection("Refactored", "Refactoring carried out due to code-test-refactor process.", "#refactor"); break;
                case 6: AddSection("Detailed Description", "Extended comment about what you did in this session.", "#detail"); break;
                case 7: AddSection("Chore (misc)", "Misc tasks eg. Jenkins", "#chore"); break;
            }
            comboBoxAddSection.SelectedIndex = -1;
        }

        private void GenerateClick(object sender, EventArgs e)
        {
            var story = comboBoxStory.SelectedItem;
            var task = comboBoxTask.SelectedItem;
            var peer = multiselectComboBoxPeer.Text;
            var commits = multiselectComboBoxCommits.Text;
            var sections = (from object control in flowLayoutPanel.Controls select control.ToString()).ToArray();
            var generateForm = new GenerateWindow(story, task, peer, commits, sections);
            generateForm.ShowDialog();
        }
    }
}
