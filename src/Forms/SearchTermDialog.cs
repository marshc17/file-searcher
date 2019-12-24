using FileSearcher.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSearcher.FileSearch;
using FileSearcher.FileSearch.FileNameMatchingAlgorithms;

namespace FileSearcher.Forms
{
    public partial class SearchTermDialog : Form
    {
        public SearchTerm SearchTerm { get; set; }
        public string SearchTermTypeUserFriendlyName { get; set; }

        public SearchTermDialog()
        {
            InitializeComponent();
            InitializeRadioButtons();

            const int fixedHeight = 185;
            MinimumSize = new Size(200, fixedHeight);
            MaximumSize = new Size(int.MaxValue, fixedHeight);
        }

        private void InitializeRadioButtons()
        {
            textRadioButton.Tag = SearchTermType.Text;
            regularExpressionRadioButton.Tag = SearchTermType.RegularExpression;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SearchTerm = new SearchTerm()
            {
                SearchTermText = searchTermTextBox.Text,
                SearchTermType = searchTermTypeGroupBox.GetSelectedRadioButtonAsEnumValueFromTag<SearchTermType>()
            };

            SearchTermTypeUserFriendlyName = searchTermTypeGroupBox.GetSelectedRadioButton().Text;

            Close();
        }
    }
}
