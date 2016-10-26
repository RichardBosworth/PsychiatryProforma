using System.Windows.Forms;
using PsychiatryProforma.InterfaceBuilding.Model;

namespace Editor
{
    public class ElementTreeNode : TreeNode
    {
        public ElementTreeNode ParentTreeNode { get; set; }

        public GroupElement ParentGroupElement { get; set; }
        public Element Element { get; set; }
    }
}