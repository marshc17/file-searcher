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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Text = AppConfiguration.AppTitle;

            InitializeListView(foldersListView);
            InitializeListView(searchTermsListView);
            InitializeRadioButtons();
            UpdateSearchButtonState();
        }

        private void InitializeRadioButtons()
        {
            depthFirstSearchRadioButton.Tag = SearchType.DepthFirstSearch;
            breadthFirstSearchRadioButton.Tag = SearchType.BreadthFirstSearch;
        }

        private void InitializeListView(ListView listView)
        {
            listView.Columns.Add(new ColumnHeader()
            {
                Text = string.Empty
            });

            listView.HeaderStyle = ColumnHeaderStyle.None;
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void addFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                foldersListView.Items.Add(new ListViewItem(folderBrowserDialog.SelectedPath));
            }

            UpdateSearchButtonState();
        }

        private void removeFolderButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItemsFromListView(foldersListView);
            UpdateSearchButtonState();
        }

        private void addSearchTermButton_Click(object sender, EventArgs e)
        {
            var searchTermDialog = new SearchTermDialog();
            searchTermDialog.ShowDialog();

            if (searchTermDialog.DialogResult != DialogResult.OK)
            {
                return;
            }

            searchTermsListView.Items.Add(new ListViewItem()
            {
                Text = searchTermDialog.SearchTerm.SearchTermText,
                Tag = searchTermDialog.SearchTerm
            });

            UpdateSearchButtonState();
        }

        private void removeSearchTermButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItemsFromListView(searchTermsListView);
            UpdateSearchButtonState();
        }

        private void RemoveSelectedItemsFromListView(ListView listView)
        {
            foreach (ListViewItem listViewItem in listView.SelectedItems)
            {
                listView.Items.Remove(listViewItem);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var rootFolderPaths = foldersListView
                .Items
                .OfType<ListViewItem>()
                .Select(listViewItem => listViewItem.Text);

            var searchTerms = searchTermsListView
                .Items
                .OfType<ListViewItem>()
                .Select(listViewItem => (SearchTerm)listViewItem.Tag);

            var searchType = searchTypeGroupBox.GetSelectedRadioBoxAsEnumValueFromTag<SearchType>();

            var searchForm = new SearchForm(rootFolderPaths, searchTerms, searchType);

            searchForm.FormClosed += new FormClosedEventHandler((object eventSender, FormClosedEventArgs eventArgs) => {
                Close();
            });

            Hide();
            searchForm.Show();
        }

        private void UpdateSearchButtonState()
        {
            searchButton.Enabled = foldersListView.Items.Count > 0 && searchTermsListView.Items.Count > 0;
        }
    }
}
