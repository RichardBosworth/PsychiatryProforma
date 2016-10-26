using System;
using System.Windows.Forms;
using PsychiatryProforma.InterfaceBuilding.Loading;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace Editor
{
    public partial class Form1 : Form
    {
        private GroupElement _modelBaseGroupElement;

        public Form1()
        {
            InitializeComponent();

            treeView.AfterSelect += TreeViewOnAfterSelect;
        }

        private void TreeViewOnAfterSelect(object sender, TreeViewEventArgs treeViewEventArgs)
        {
            var node = treeViewEventArgs.Node as ElementTreeNode;

            propertyGrid.SelectedObject = node.Element;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                treeView.Nodes.Clear();

                IModelLoader modelLoader = new XmlModelLoader(openFileDialog.FileName);
                _modelBaseGroupElement = modelLoader.LoadModel();

                var elementTreeNode = new ElementTreeNode {Element = _modelBaseGroupElement, Name = _modelBaseGroupElement.Name, Text = _modelBaseGroupElement.Name};
                elementTreeNode.ContextMenuStrip = groupContextMenuStrip;
                ProcessGroupElement(_modelBaseGroupElement, elementTreeNode);

                treeView.Nodes.Add(elementTreeNode);
            }
        }

        private void ProcessGroupElement(GroupElement modelBaseGroupElement, ElementTreeNode parentTreeNode)
        {
            foreach (var element in modelBaseGroupElement.SubElements)
            {
                var elementTreeNode = new ElementTreeNode {Name = element.Name, Text = element.Name, Element = element, ParentGroupElement = modelBaseGroupElement};
                elementTreeNode.ContextMenuStrip = normalContextMenuStrip;
                elementTreeNode.ParentTreeNode = parentTreeNode;

                if (element is GroupElement)
                {
                    var groupElement = element as GroupElement;
                    ProcessGroupElement(groupElement, elementTreeNode);
                    elementTreeNode.ContextMenuStrip = groupContextMenuStrip;
                }

                parentTreeNode.Nodes.Add(elementTreeNode);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            var dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                IModelSaver modelSaver = new XmlModelSaver(saveFileDialog.FileName);
                modelSaver.SaveModel(_modelBaseGroupElement);
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void DeleteItem()
        {
            if (treeView.SelectedNode != null)
            {
                var elementTreeNode = treeView.SelectedNode as ElementTreeNode;
                elementTreeNode?.ParentGroupElement.SubElements.Remove(elementTreeNode.Element);
                elementTreeNode.ParentTreeNode.Nodes.Remove(treeView.SelectedNode);
            }
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void stringElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<StringElement>();
        }

        private void AddElement<T>() where T : Element
        {
            if (treeView.SelectedNode != null)
            {
                var elementTreeNode = treeView.SelectedNode as ElementTreeNode;
                if (elementTreeNode != null)
                {
                    var groupElement = elementTreeNode.Element as GroupElement;

                    var element = Activator.CreateInstance<T>();
                    element.Name = $"New {element.GetType().Name}";
                    groupElement.SubElements.Add(element);

                    var treeNode = new ElementTreeNode();
                    treeNode.ParentTreeNode = elementTreeNode;
                    treeNode.Element = element;
                    treeNode.Name = element.Name;
                    treeNode.Text = element.Name;
                    treeNode.ParentGroupElement = elementTreeNode.Element as GroupElement;


                    treeNode.ContextMenuStrip = element is GroupElement ? groupContextMenuStrip : normalContextMenuStrip;

                    elementTreeNode.Nodes.Add(treeNode);
                    elementTreeNode.Expand();
                    treeView.SelectedNode = treeNode;
                }
            }
        }

        private void booleanElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<BooleanElement>();
        }

        private void groupElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<GroupElement>();
        }

        private void maskedElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<MaskedElement>();
        }

        private void choiceElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<ChoiceElement>();
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var element = (Element) propertyGrid.SelectedObject;
            treeView.SelectedNode.Text = element.Name;
        }
        
        private void listElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<ListElement>();
        }

        private void labResultElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<LabResultElement>();
        }

        private void labelElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement<LabelElement>();
        }
    }
}