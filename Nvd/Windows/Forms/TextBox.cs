namespace Nvd.Windows.Forms
{
    public class TextBox : System.Windows.Forms.TextBox
    {
        private textBoxList list;
        public TextBox() : base()
        {

        }
        /// <summary>
        /// This constructor adds a filling list to your textbox
        /// </summary>
        /// <param name="baseForm">The form that textbox is in it. Normally you should write "this"</param>
        /// <param name="location">The location of the list. It's better to put textbox location from Designer + highth of textbox added to Y</param>
        public TextBox(System.Windows.Forms.Form baseForm, System.Drawing.Point location) : base()
        {
            this.baseForm = baseForm;
            list = new textBoxList(baseForm, this);
            list.Location = location;
            list.Visible = false;
            baseForm.Controls.Add(list);
        }

        private System.Windows.Forms.Form baseForm;

        /// <summary>
        /// The list searches inside this object list."new object[]{"text1","text2",...};"
        /// </summary>
        public object[] ListItems;


        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Down)
            {
                baseForm.ActiveControl = list;
                list.SelectedIndex = 0;
                return;
            }

            base.OnKeyUp(e);

            if (list != null)
            {
                list.Items.Clear();
                list.Visible = false;
                if (string.IsNullOrWhiteSpace(this.Text)) return;

                //int maxLength = 0;
                foreach (string item in ListItems)
                {
                    if (item.ToLower().StartsWith(this.Text.ToLower()))
                    {
                        if (!list.Visible) list.Visible = true;
                        //if (item.Length > maxLength) maxLength = item.Length;
                        list.Items.Add(item);
                        //list.Size = new System.Drawing.Size((maxLength + 1) * (int)System.Math.Round(list.Font.SizeInPoints), (list.Items.Count + 1) * list.Font.Height);
                        list.Size = new System.Drawing.Size(this.Size.Width, (list.Items.Count + 1) * list.Font.Height);
                    }
                }
            }
        }



        class textBoxList : System.Windows.Forms.ListBox
        {
            public textBoxList(System.Windows.Forms.Form baseForm, TextBox textbox) : base()
            {
                this.baseForm = baseForm;
                this.textbox = textbox;
            }

            TextBox textbox;
            System.Windows.Forms.Form baseForm;
            protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
            {
                base.OnKeyUp(e);
                if (e.KeyData == System.Windows.Forms.Keys.Enter)
                {
                    textbox.Text = (string)this.SelectedItem;
                    this.Items.Clear();
                    this.Visible = false;
                }
            }

            protected override void OnDoubleClick(System.EventArgs e)
            {
                base.OnDoubleClick(e);
                textbox.Text = (string)this.SelectedItem;
                this.Items.Clear();
                this.Visible = false;
            }
        }
    }

}
