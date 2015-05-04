using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MurcyLogging
{
    public class MultiselectComboBox : ComboBox, IMessageFilter
    {
        private readonly Panel _dropDownPanel;
        private readonly CheckedListBox _checkedListBox;
        public ItemCheckEventHandler ItemCheck;

        public MultiselectComboBox()
        {
            _dropDownPanel = new Panel
                             {
                                 AutoSize = true,
                                 AutoSizeMode = AutoSizeMode.GrowOnly
                             };

            _checkedListBox = new CheckedListBox
                              {
                                  Dock = DockStyle.Fill,
                                  CheckOnClick = true
                              };
            _checkedListBox.ItemCheck += CheckedListBoxOnItemCheck;
            _checkedListBox.MouseMove += CheckedListBoxOnMouseMove;
            KeyPress += MultiselectComboBoxKeyPress;

            _dropDownPanel.Controls.Add(_checkedListBox);

            _checkedListBox.Items.Add("a");
            _checkedListBox.Items.Add("b");
            _checkedListBox.Items.Add("c");
            _checkedListBox.Items.Add("d");
            _checkedListBox.Items.Add("e");
            _checkedListBox.Items.Add("f");
            _checkedListBox.Items.Add("g");
            _checkedListBox.Items.Add("h");
            _checkedListBox.Items.Add("i");
        }

        private void MultiselectComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckedListBoxOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var point = _checkedListBox.PointToClient(Cursor.Position);
            var index = _checkedListBox.IndexFromPoint(point);
            if (index < 0) return;
            _checkedListBox.SelectedIndex = index;
        }

        private List<int> GetCheckedIndicies()
        {
            var objects = new List<int>();
            for (var i = 0; i < Items.Count; i++)
            {
                if (!_checkedListBox.GetItemChecked(i)) continue;
                objects.Add(i);
            }
            return objects;
        } 

        private List<object> GetCheckedItems()
        {
            var objects = new List<object>();
            for (var i = 0; i < Items.Count; i++)
            {
                if (!_checkedListBox.GetItemChecked(i)) continue;
                objects.Add(_checkedListBox.Items[i]);
            }
            return objects;
        }

        private void CheckedListBoxOnItemCheck(object sender, ItemCheckEventArgs itemCheckEventArgs)
        {
            var items = GetCheckedItems();
            if (itemCheckEventArgs.NewValue == CheckState.Checked)
            {
                items.Add(Items[itemCheckEventArgs.Index]);
            }
            else
            {
                items.Remove(Items[itemCheckEventArgs.Index]);
            }
            
            Text = string.Join(", ", items);
            if (ItemCheck != null) ItemCheck.Invoke(this, itemCheckEventArgs);
        }

        public new CheckedListBox.ObjectCollection Items
        {
            get { return _checkedListBox.Items; }
        }

        public List<int> CheckedIndices
        {
            get { return GetCheckedIndicies(); }
        }

        public List<object> CheckedItems
        {
            get { return GetCheckedItems(); }
        }

        private void SetPanelProperties()
        {
            _dropDownPanel.Anchor = Anchor;
            _dropDownPanel.BackColor = Color.Transparent;
            _dropDownPanel.Font = Font;
            _dropDownPanel.ForeColor = ForeColor;
            _dropDownPanel.Top = Bottom;
            _dropDownPanel.Left = Left;
            _dropDownPanel.Width = Math.Max(_dropDownPanel.Width, Width);

            _checkedListBox.BackColor = BackColor;
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x0201) || (m.Msg == 0x0203))
            {
                if (DroppedDown) HidePanel();
                else ShowPanel();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if ((m.Msg < 0x0200) || (m.Msg > 0x020A)) return false;
            if (_dropDownPanel.RectangleToScreen(_dropDownPanel.DisplayRectangle).Contains(Cursor.Position))
            {
                return false;
            }
            if ((m.Msg != 0x0201) && (m.Msg != 0x0203)) return true;
            HidePanel();
            return true;
        }

        private new bool DroppedDown 
        {
            get { return _dropDownPanel.Visible; } 
        }

        private void ShowPanel()
        {
            if (!Visible) return;
            SetPanelProperties();
            Parent.Controls.Add(_dropDownPanel);
            _dropDownPanel.Visible = true;
            _dropDownPanel.BringToFront();
            OnDropDown(EventArgs.Empty);
            Application.AddMessageFilter(this);
        }

        private void HidePanel()
        {
            Application.RemoveMessageFilter(this);
            OnDropDownClosed(EventArgs.Empty);
            _dropDownPanel.Visible = false;
            Parent.Controls.Remove(_dropDownPanel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _dropDownPanel.Dispose();
            base.Dispose(disposing);
        }
    }
}
