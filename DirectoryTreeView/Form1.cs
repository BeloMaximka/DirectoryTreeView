using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DirectoryTreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string folder;
            while (true)
                if (dlg.ShowDialog() == DialogResult.OK)
                    break;
            folder = dlg.SelectedPath;
            TreeNode root = new TreeNode(folder);
            LoadFilesAndDirectories(root, folder);
            treeView1.Nodes.Add(root);
        }

        public void LoadFilesAndDirectories(TreeNode node, string directory)
        {
            foreach (string path in Directory.GetDirectories(directory))
            {
                string name = path.Remove(0, path.LastIndexOf("\\") + 1);
                TreeNode current = new TreeNode(name);
                LoadFilesAndDirectories(current, path);
                node.Nodes.Add(current);
            }
            foreach (string path in Directory.GetFiles(directory))
            {
                string name = path.Remove(0, path.LastIndexOf("\\") + 1);
                node.Nodes.Add(name);
            }
        }
    }
}
