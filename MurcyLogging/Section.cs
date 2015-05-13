using System;
using System.Windows.Forms;
using MurcyLogging.Agilefant;

namespace MurcyLogging
{
    public partial class Section : UserControl
    {
        public Action<Section> RemoveSection;

        public Tag Tag { get; private set; }
        public string Content { get { return richTextBox1.Text; } }


        public Section(Tag tag)
        {
            Tag = tag;

            InitializeComponent();

            labelSectionTitle.Text = AgilefantDesciption.GetDescription(tag);
            labelDescription.Text = AgilefantDesciption.GetTitle(tag);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (RemoveSection != null) RemoveSection.Invoke(this);
        }
    }
}
