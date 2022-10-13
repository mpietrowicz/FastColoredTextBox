using System.Text.RegularExpressions;
using FastColoredTextBoxNS;

namespace TestApp
{
    public partial class Form1 : Form
    {
        Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        Style BoldStyle = new TextStyle(null, null, FontStyle.Bold);

        public Form1()
        {
            InitializeComponent();

     
        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            var  range = (sender as FastColoredTextBox).VisibleRange;//or (sender as 
            //FastColoredTextBox).Range

            //clear style of changed range
            range.ClearStyle(GreenStyle);
            //comment highlighting
            range.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | 
                                                               RegexOptions.RightToLeft);

            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum)\s+(?<range>[\w_]+?)\b");
            e.ChangedRange.ClearFoldingMarkers();
            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");
        }
    }
}