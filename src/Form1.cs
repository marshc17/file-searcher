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
    public partial class FileSearcherForm : Form
    {
        public FileSearcherForm()
        {
            InitializeComponent();
            InitializeFolderListView();
        }

        private void InitializeFolderListView()
        {
            foldersListView.Columns.Add(new ColumnHeader()
            {
                Text = string.Empty
            });

            foldersListView.HeaderStyle = ColumnHeaderStyle.None;
            foldersListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
        }

        private void removeFolderButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in foldersListView.SelectedItems)
            {
                foldersListView.Items.Remove(listViewItem);
            }
        }
    }
}
