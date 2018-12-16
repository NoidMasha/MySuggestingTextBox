using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuggestingTextBox
{
    class BaseTextBox:System.Windows.Forms.TextBox
    {
        private textBoxList list;
        public BaseTextBox() : base()
        {

        }

        public BaseTextBox(System.Windows.Forms.Form BaseForm) :base()
        {
            list = new textBoxList();
            BaseForm.Controls.Add(list);
        }

        public System.Drawing.Point ListLocation { set { list.Location = value; } }
        public System.Drawing.Size ListSize { set { list.Size = value; } }
        public object[] ListItems { set { list.Items.AddRange(value); } }
        public int ListItemsCount { get { return list.Items.Count; } }
        public int ListItemHighth { get { return list.Font.Height; } }

        private void UpdateList(string toSearchText, System.Drawing.Point listLocation)
        {
            if (list.IsDisposed || list == null || string.IsNullOrWhiteSpace(toSearchText) || list.Items.Count == 0) return;


        }

        class textBoxList:System.Windows.Forms.ListBox
        {
            public textBoxList():base()
            {

            }
        }
    }
    
}
