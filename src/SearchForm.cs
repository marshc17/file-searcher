using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcher
{
    public partial class SearchForm : Form
    {
        private FileSearcher fileSearcher;

        public SearchForm(IEnumerable<string> folderPaths, IEnumerable<SearchTerm> searchTerms, SearchType searchType)
        {
            InitializeComponent();

            Text = AppConfiguration.AppTitle;

            fileSearcher = new FileSearcher(folderPaths, searchTerms, searchType);
            fileSearcher.StartSearch();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pauseResumeButton_Click(object sender, EventArgs e)
        {
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            var result = MessageBox.Show(
                "Are you sure you'd like to cancel this search?",
                AppConfiguration.AppTitle,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
