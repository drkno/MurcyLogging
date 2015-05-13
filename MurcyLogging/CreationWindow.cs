using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agilefantasy;
using Agilefantasy.Story;
using MurcyLogging.Agilefant;
using Tag = MurcyLogging.Agilefant.Tag;

namespace MurcyLogging
{
    public partial class MainWindow : Form
    {
        private readonly ObservableCollection<AgilefantStory> _stories = new ObservableCollection<AgilefantStory>();
        private readonly ObservableCollection<AgilefantTask> _tasks = new ObservableCollection<AgilefantTask>(); 
        private readonly ObservableCollection<AgilefantUser> _users = new ObservableCollection<AgilefantUser>(); 
 
        private AgilefantSession _session;
        private AgilefantClient _client;

        public MainWindow(AgilefantSession newSession)
        {
            this._session = newSession;
            this._client = new AgilefantClient(_session);

            InitializeComponent();

            _stories.CollectionChanged += (sender, args) =>
            {
                comboBoxStory.Items.Clear();
                comboBoxStory.Items.AddRange(_stories.ToArray());
            };
            _tasks.CollectionChanged += (sender, args) =>
            {
                comboBoxTask.Items.Clear();
                comboBoxTask.Items.AddRange(_tasks.ToArray());
            };
            _users.CollectionChanged += (sender, args) =>
            {
                teamMembersPanel.Controls.Clear();
                foreach (var user in _users)
                {
                    var checkBox = new CheckBox();
                    checkBox.Text = user.ToString();
                    checkBox.Tag = user;

                    teamMembersPanel.Controls.Add(checkBox);
                }
            };
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await UpdateStories();
            await UpdateUsers();
        }

        private async Task UpdateStories()
        {
            var sprint = await _client.GetSprint(16);

            _stories.Clear();
            foreach (var story in sprint.RankedStories)
                _stories.Add(story);
        }

        private async Task UpdateUsers()
        {
            var users = await _client.GetUsers();

            _users.Clear();
            foreach (var user in users)
                _users.Add(user);
        }

        private void AddSection(Tag tag)
        {
            var section = new Section(tag);
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
                case 0: AddSection(Agilefant.Tag.Implement); break;
                case 1: AddSection(Agilefant.Tag.Document); break;
                case 2: AddSection(Agilefant.Tag.Fix); break;
                case 3: AddSection(Agilefant.Tag.Test); break;
                case 4: AddSection(Agilefant.Tag.TestManual); break;
                case 5: AddSection(Agilefant.Tag.Refactor); break;
                case 6: AddSection(Agilefant.Tag.Detail); break;
                case 7: AddSection(Agilefant.Tag.Chore); break;
            }
            comboBoxAddSection.SelectedIndex = -1;
        }

        private bool Validate()
        {
            int time;

            var errorBuilder = new StringBuilder();

            if (comboBoxStory.SelectedItem == null)
                errorBuilder.AppendLine("You must select a valid story!");
            if (comboBoxTask.SelectedItem == null)
                errorBuilder.AppendLine("You must select a valid task!");
            if (!int.TryParse(timeSpentBox.Text, out time))
                errorBuilder.AppendLine("You must enter a valid time spent!");
            if (GetSelectedUsers().Count() == 0)
                errorBuilder.AppendLine("You must select at least one user!");
            if (GetSelectedUsers().Count() <= 1 && peerProgrammedCheckBox.Checked)
                errorBuilder.AppendLine("You must have at least two users selected to peer program!");

            if (errorBuilder.Length == 0)
                return true;

            MessageBox.Show("The form has the following errors:\n" + errorBuilder.ToString(), "Uh oh!");
            return false;
        }

        private async void GenerateClick(object sender, EventArgs e)
        {
            if (!Validate()) return;

            var story = comboBoxStory.SelectedItem as IAgilefantLoggable;
            var task = comboBoxTask.SelectedItem as IAgilefantLoggable;

            var users = GetSelectedUsers();

            var logAgainst = story ?? task;

            var commits = multiselectComboBoxCommits.Text;
            var sections = (from object control in flowLayoutPanel.Controls where control is Section select control as Section);


            if (sections.Count() == 0)
            {
                var result =
                    MessageBox.Show(
                        "You haven't added any detail to the message? Are you sure you want to continue (Moffat will not be pleased)?",
                        "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
            }

            var description = new AgilefantDesciption();
            
            //Add the tag for all sections
            foreach (var section in sections)
                description.AddTag(section.Tag, section.Content);

            //If we have two or more users, then it's pair work!
            if (peerProgrammedCheckBox.Checked)
                foreach (var user in users)
                    description.AddPair(user);

            var message = description.Build();
#if DEBUG
            var r = MessageBox.Show("Do you want to push to Agilefant? (the message looks like this:\n" + message, "Are you sure?", MessageBoxButtons.YesNo);
            if (r == DialogResult.No) return;
#endif
             await _client.LogTime(logAgainst, DateTime.Now, 60, message, users);
             MessageBox.Show("Logged (you should be able to see the time on agilefant!)");
        }

        private void comboBoxStory_SelectedValueChanged(object sender, EventArgs e)
        {
            var story = comboBoxStory.SelectedItem as AgilefantStory;
            if (story == null) return;

            _tasks.Clear();
            foreach (var task in story.Tasks)
                _tasks.Add(task);
        }

        private IEnumerable<AgilefantUser> GetSelectedUsers()
        {
            return (from CheckBox control in teamMembersPanel.Controls
             where control.Checked
             select control.Tag as AgilefantUser);
        } 
    }
}
