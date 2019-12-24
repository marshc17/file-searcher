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
using FileSearcher.Configuration;
using FileSearcher.FileSearch.SearchAlgorithms;
using FileSearcher.FileSearch.FileNameMatchingAlgorithms;

namespace FileSearcher.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Text = AppConfiguration.AppTitle;

            InitializeFoldersListView();
            InitializeSearchTermsListView();
            InitializeRadioButtons();
            UpdateSearchButtonState();
        }

        private void InitializeRadioButtons()
        {
            depthFirstSearchRadioButton.Tag = SearchType.DepthFirstSearch;
            breadthFirstSearchRadioButton.Tag = SearchType.BreadthFirstSearch;
        }

        private void InitializeFoldersListView()
        {
            foldersListView.Columns.Add(new ColumnHeader()
            {
                Text = string.Empty
            });

            foldersListView.HeaderStyle = ColumnHeaderStyle.None;
            foldersListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void InitializeSearchTermsListView()
        {
            searchTermsListView.Columns.Add("Search Term");
            searchTermsListView.Columns.Add("Type");

            searchTermsListView.HeaderStyle = ColumnHeaderStyle.None;
            searchTermsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

            searchTermsListView.Items.Add(new ListViewItem(new string[]
            {
                searchTermDialog.SearchTerm.SearchTermText,         // Column 1
                searchTermDialog.SearchTermTypeUserFriendlyName     // Column 2
            })
            {
                Tag = searchTermDialog.SearchTerm                   // Save the actual SearchTerm to the tag behind the scenes to retrieve later
            });

            searchTermsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            UpdateSearchButtonState();
        }

        private void removeSearchTermButton_Click(object sender, EventArgs e)
        {
            RemoveSelectedItemsFromListView(searchTermsListView);
            UpdateSearchButtonState();

            // Hide the headers if the last item was cleared out.
            if (searchTermsListView.Items.Count == 0)
            {
                searchTermsListView.HeaderStyle = ColumnHeaderStyle.None;
            }
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

            var searchType = searchTypeGroupBox.GetSelectedRadioButtonAsEnumValueFromTag<SearchType>();

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
