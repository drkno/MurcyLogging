using System;
using System.Windows.Forms;

namespace MurcyLogging
{
    public partial class Section : UserControl
    {
        public Action<Section> RemoveSection;
        private readonly string _hashTag;

        public Section(string sectionName, string sectionDescription, string hashTag)
        {
            InitializeComponent();
            labelSectionTitle.Text = sectionName;
            labelDescription.Text = sectionDescription;
            _hashTag = hashTag;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (RemoveSection != null) RemoveSection.Invoke(this);
        }

        public override string ToString()
        {
            return _hashTag + " " + richTextBox1.Text;
        }
    }
}
