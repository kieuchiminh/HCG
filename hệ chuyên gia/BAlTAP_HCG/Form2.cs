using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace BTL_HCG_Nhom8
{
    public partial class Form2 : Form
    {
        private List<Node> nodeList = new List<Node>();
        private List<Rule> ruleList = new List<Rule>();
        private List<Node> conclusionNodeList = new List<Node>();
        private List<Node> supposeNodeList = new List<Node>();
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
        private void ShowError(string error)
        {
            MessageBox.Show(this, "Chương trình gặp lỗi: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadFromFile();
            for (int i = 0; i < nodeList.Count; i++)
            {
                lstNode.Items.Add(nodeList[i]);
            }
            for (int i = 0; i < ruleList.Count; i++)
            {
                lstRule.Items.Add(ruleList[i]);
            }
        }
        private void LoadFromFile()
        {
            try
            {
                Stream s = File.OpenRead("nodes.txt");
                StreamReader sr = new StreamReader(s);
                string str = sr.ReadLine();
                while (!string.IsNullOrEmpty(str))
                {
                    Node newNode = new Node();
                    int index = str.IndexOf(" ");
                    string name = str.Substring(0, index);
                    newNode.Name = name;
                    string text = str.Substring(index + 1, str.Length - index - 1);
                    newNode.Text = text;
                    newNode.Value = -1;
                    nodeList.Add(newNode);
                    if (newNode.Name[0] == 'c')
                    {
                        conclusionNodeList.Add(newNode);
                    }
                    else
                    {
                        supposeNodeList.Add(newNode);
                    }
                    str = sr.ReadLine();
                }
                sr.Close();
                s.Close();

                s = File.OpenRead("rules.txt");
                sr = new StreamReader(s);
                str = sr.ReadLine();
                while (!string.IsNullOrEmpty(str))
                {
                    Rule newRule = new Rule();
                    int index = str.IndexOf(" ");
                    string name = str.Substring(0, index);
                    newRule.Name = name;
                    string suppose = str.Substring(index + 1, str.IndexOf("=") - index - 1);
                    newRule.Suppose = suppose;
                    string conclusion = str.Substring(str.IndexOf(">") + 1, str.Length - str.IndexOf(">") - 1);
                    newRule.Conclusion = conclusion;
                    ruleList.Add(newRule);
                    str = sr.ReadLine();
                }
                sr.Close();
                s.Close();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void lstRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = lstRule.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    Rule rule = (Rule)lstRule.SelectedItem;
                    string str = string.Empty;
                    str += "Luật " + rule.Name + ": Nếu " + rule.Suppose + " thì " + rule.Conclusion;
                    //thay cac node name bang node text
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        str = str.Replace(nodeList[i].Name, nodeList[i].Text.ToLower());
                    }
                    //thay dau & thanh chu va
                    str = str.Replace("&", " và ");
                    //thay dấu | thành chữ hoặc
                    str = str.Replace("|", " hoặc ");
                    //thay dấu ~ thành không phải
                    str = str.Replace("~", " không phải ");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btnthemnut_Click(object sender, EventArgs e)
        {

            string nodeExpression = txtNode.Text;
            if (nodeExpression.Length > 5 && nodeExpression.IndexOf(' ') >= 0)
            {
                Node node = new Node();
                node.Value = -1;
                node.Name = nodeExpression.Substring(0, nodeExpression.IndexOf(' '));
                node.Text = nodeExpression.Substring(nodeExpression.IndexOf(' ') + 1, nodeExpression.Length - nodeExpression.IndexOf(' ') - 1);
                string check = "";
                for (int i = 0; i<nodeList.Count; i++)
                {
                if (node.Name == nodeList[i].Name)
                {
                check="error";
                }
                }
                if(check !="error")
                {
                lstNode.Items.Add(node);
                nodeList.Add(node);
                txtNode.Text = string.Empty;
                StreamWriter sw = new StreamWriter("nodes.txt", true, Encoding.Unicode);
                sw.Write(Environment.NewLine + nodeExpression);
                sw.Close();
                }
                else
                {
                    MessageBox.Show("Bạn nhập Node đã trùng với CSDL !!!");
                }
            }
            else
            {
            MessageBox.Show("Bạn nhập Node chưa đúng !!!");
            }
        }

        private void btnxoanut_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa nút này?", "Xóa nút", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                int selectedIndex = lstNode.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    Node node = (Node)lstNode.SelectedItem;
                    nodeList.Remove(node);
                    lstNode.Items.Remove(node);
                    string str = string.Empty;
                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        if (i == nodeList.Count - 1)
                        {
                            str += nodeList[i].Name + " " + nodeList[i].Text;
                        }
                        else
                        {
                            str += nodeList[i].Name + " " + nodeList[i].Text + Environment.NewLine;
                        }
                    }

                    //ghi vao file
                    StreamWriter sw = new StreamWriter("nodes.txt", false, Encoding.Unicode);
                    sw.Write(str);
                    sw.Close();

                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btnthemluat_Click(object sender, EventArgs e)
        {
                string ruleExpression = txtRule.Text;
                if (ruleExpression.Length > 5 && ruleExpression.IndexOf(' ') >= 0 && ruleExpression.IndexOf("=>") >= 0)
                {
                    Rule rule = new Rule();
                    rule.Name = ruleExpression.Substring(0, ruleExpression.IndexOf(' '));
                    string check = "";

                    rule.Suppose = ruleExpression.Substring(ruleExpression.IndexOf(' ') + 1, ruleExpression.IndexOf('=') - ruleExpression.IndexOf(' ') - 1);
                    rule.Conclusion = ruleExpression.Substring(ruleExpression.IndexOf('>') + 1, ruleExpression.Length - ruleExpression.IndexOf('>') - 1);
                    for (int i = 0; i < ruleList.Count; i++)
                    {
                        if (rule.Name == ruleList[i].Name)
                        {
                            check = "error";
                        }
                    }
                    if (check != "error")
                    {
                        lstRule.Items.Add(rule);
                        ruleList.Add(rule);

                        StreamWriter swinstr1 = new StreamWriter("rules.txt", true, Encoding.Unicode);
                        swinstr1.Write(Environment.NewLine + ruleExpression);
                        swinstr1.Close();
                    }
                        else
                    {
                    MessageBox.Show("Bạn nhập Luật trùng với CSDL !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn nhập chưa đúng Luật !!!");
                }
            }

        private void btnxoaluat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa luật này?", "Xóa luật", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                int selectedIndex = lstRule.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    Rule rule = (Rule)lstRule.SelectedItem;
                    ruleList.Remove(rule);
                    lstRule.Items.Remove(rule);
                    string str = string.Empty;
                    for (int i = 0; i < ruleList.Count; i++)
                    {
                        if (i == ruleList.Count - 1)
                        {
                            str += ruleList[i].Name + " " + ruleList[i].Suppose + "=>" + ruleList[i].Conclusion;
                        }
                        else
                        {
                            str += ruleList[i].Name + " " + ruleList[i].Suppose + "=>" + ruleList[i].Conclusion + Environment.NewLine;
                        }
                    }
                    //ghi vao file
                    StreamWriter sw = new StreamWriter("rules.txt", false, Encoding.Unicode);
                    sw.Write(str);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void txtRuleText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            Node nodeed = (Node)lstNode.SelectedItem;
            //MessageBox.Show(nodeed.ToString());            
            nodeList.Remove(nodeed);
            lstNode.Items.Remove(nodeed);
            string str = string.Empty;
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (i == nodeList.Count - 1)
                {
                    str += nodeList[i].Name + " " + nodeList[i].Text;
                }
                else
                {
                    str += nodeList[i].Name + " " + nodeList[i].Text + Environment.NewLine;
                }
            }

            //ghi vao file
            StreamWriter swdl = new StreamWriter("nodes.txt", false, Encoding.Unicode);
            swdl.Write(str);
            swdl.Close();

            string nodeExpression = txtNode.Text.Trim();
            if (nodeExpression.Length > 5 && nodeExpression.IndexOf(' ') >= 0)
            {
                Node nodeinst = new Node();
                nodeinst.Value = -1;
                nodeinst.Name = nodeExpression.Substring(0, nodeExpression.IndexOf(' '));
                nodeinst.Text = nodeExpression.Substring(nodeExpression.IndexOf(' ') + 1, nodeExpression.Length - nodeExpression.IndexOf(' ') - 1);
                string check = "";
                for (int i = 0; i < nodeList.Count; i++)
                {
                    if (nodeinst.Name == nodeList[i].Name)
                    {
                        check = "error";
                    }
                }
                //MessageBox.Show(check.ToString());                
                if (check != "error")
                {
                    lstNode.Items.Add(nodeinst);
                    nodeList.Add(nodeinst);
                    txtNode.Text = string.Empty;
                    StreamWriter swinstno = new StreamWriter("nodes.txt", true, Encoding.Unicode);
                    swinstno.Write(Environment.NewLine + nodeExpression);
                    swinstno.Close();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn tên Node khác vì bị trùng với CSDL!");
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            Rule ruleed1 = (Rule)lstRule.SelectedItem;
            ruleList.Remove(ruleed1);
            lstRule.Items.Remove(ruleed1);
            string str = string.Empty;
            for (int i = 0; i < ruleList.Count; i++)
            {
                if (i == ruleList.Count - 1)
                {
                    str += ruleList[i].Name + " " + ruleList[i].Suppose + "=>" + ruleList[i].Conclusion;
                }
                else
                {
                    str += ruleList[i].Name + " " + ruleList[i].Suppose + "=>" + ruleList[i].Conclusion + Environment.NewLine;
                }
            }
            //ghi vao file
            StreamWriter swdlr = new StreamWriter("rules.txt", false, Encoding.Unicode);
            swdlr.Write(str);
            swdlr.Close();

            string ruleExpression = txtRule.Text.Trim();
            if (ruleExpression.Length > 5 && ruleExpression.IndexOf(' ') >= 0 && ruleExpression.IndexOf("=>") >= 0)
            {
                Rule ruleinst2 = new Rule();
                ruleinst2.Name = ruleExpression.Substring(0, ruleExpression.IndexOf(' '));
                ruleinst2.Suppose = ruleExpression.Substring(ruleExpression.IndexOf(' ') + 1, ruleExpression.IndexOf('=') - ruleExpression.IndexOf(' ') - 1);
                ruleinst2.Conclusion = ruleExpression.Substring(ruleExpression.IndexOf('>') + 1, ruleExpression.Length - ruleExpression.IndexOf('>') - 1);

                lstRule.Items.Add(ruleinst2);
                ruleList.Add(ruleinst2);

                StreamWriter swinstr = new StreamWriter("rules.txt", true, Encoding.Unicode);
                swinstr.Write(Environment.NewLine + ruleExpression);
                swinstr.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đúng luật của Rule!");
            }                 

        }

        private void lstNode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}