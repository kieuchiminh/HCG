using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace BTL_HCG_Nhom8
{
    public partial class Form1 : Form
    {
        private int first = 0;
        private Node parentNode = null;
        private List<Node> nodeList = new List<Node>();
        private List<Rule> ruleList = new List<Rule>();
        private List<Node> supposeNodeList = new List<Node>();
        private List<Node> conclusionNodeList = new List<Node>();
        private List<Node> knownNodeList = new List<Node>();
        private List<Node> tempNodeList = new List<Node>();
        private List<Road> roadList = new List<Road>();

        private delegate void UpdateTextBoxDeletegate(string str);
        private delegate void UpdateControlsDelegate();
        private Thread processThread = null;
        private object objLock = new object();
        private bool isHasAnswer = false;

        private List<Road> roadListTemp = new List<Road>();
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowError(string error)
        {
            MessageBox.Show(this, "Chương trình gặp lỗi: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        public void Init()
        {
            try
            {
                first = 0;
                parentNode = null;
                nodeList = new List<Node>();
                ruleList = new List<Rule>();
                supposeNodeList = new List<Node>();
                conclusionNodeList = new List<Node>();
                knownNodeList = new List<Node>();
                tempNodeList = new List<Node>();
                roadListTemp = roadList;
                roadList = new List<Road>();
                processThread = null;
                objLock = new object();
                isHasAnswer = false;
                this.Invoke(new UpdateControlsDelegate(UpdateControls));
                LoadFromFile();
                processThread = new Thread(new ThreadStart(Process));
                processThread.Start();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void ProcessNode(Node node, int level)
        {
            try
            {
                Road road = SearchRule(node, level);
                if (road == null)
                {
                    return;
                }
                this.first++;
                bool isExist = false;
                for (int i = 0; i < roadList.Count; i++)
                {
                    if (roadList[i].Node.Name.Equals(road.Node.Name))
                    {
                        isExist = true;
                    }
                }
                if (isExist == false)
                {
                    roadList.Add(road);
                }

                // H ta di xet luat vua tim duoc de cho cac node vao tap dang xet
                tempNodeList.Remove(road.Node);
                ProcessRule(road);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void Process()
        {
            try
            {
                //Voi moi ket luan c, ta duyet qua no
                for (int i = conclusionNodeList.Count - 1; i >= 0; i--)
                {

                    parentNode = conclusionNodeList[i];
                    for (int j = 0; j < ruleList.Count; j++)
                    {
                        // Cho no vao tap dang xet
                        tempNodeList.Add(conclusionNodeList[i]);
                        // Sau do ta di tim luat sinh ra ket luan tren va cho vao tap Vet(roadList)
                        ProcessNode(conclusionNodeList[i], j);
                        // Kiem tra xem node nay co value = 1 chua
                        if (conclusionNodeList[i].Value == 1)
                        {
                            string str = "Theo tôi, " + conclusionNodeList[i].Text.ToLower();
                            Form3 form3 = new Form3(str);
                            form3.ShowDialog();
                            isHasAnswer = true;
                            break;
                        }

                    }
                    if (isHasAnswer)
                    {
                        break;
                    }

                }
                if (isHasAnswer == false)
                {
                    string str = "Thông tin của bạn không khớp luật nào trong cơ sở tri thức!";
                    Form3 form3 = new Form3(str);
                    form3.ShowDialog();
                }
                Init();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ProcessRule(Road road)
        {
            try
            {
                // Ta di xet luat cua road và add cac node o ve trai cua luat vao tap tempNodeList
                Rule rule = road.Rule;
                string suppose = rule.Suppose;
                string[] supposes = suppose.Split('&', '|', '~');
                for (int i = 0; i < supposes.Length; i++)
                {
                    for (int j = 0; j < nodeList.Count; j++)
                    {
                        if (nodeList[j].Name.Equals(supposes[i]))
                        {
                            if (nodeList[j].Value == -1)
                            {
                                tempNodeList.Add(nodeList[j]);
                            }

                        }
                    }
                }
                // Ngoai nhiem vu add ra, ta con phai kiem tra xem ve trai cua luat co phai toan la e khong. neu toan la e thi chay ham Ap dung luat
                for (int i = 0; i < tempNodeList.Count; i++)
                {
                    Node node = tempNodeList[i];
                    if (node.Name[0].Equals('e'))
                    {
                        if (node.Value == -1)
                        {
                            int value = GetNodeValue(node);
                            node.Value = value;
                        }
                    }
                    else
                    {
                        ProcessNode(node, 0);
                    }
                }
                road.Node.Value = CalculateConclusionValue(road);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private int CalculateConclusionValue(Road road)
        {
            try
            {
                string suppose = road.Rule.Suppose;
                for (int i = 0; i < nodeList.Count; i++)
                {
                    suppose = suppose.Replace(nodeList[i].Name, nodeList[i].Value.ToString());
                }
                StringBuilder sb = new StringBuilder(suppose);
                //xu ly dau ~
                for (int i = 0; i < sb.Length - 1; i++)
                {
                    if (sb[i].Equals('~') && sb[i + 1].Equals('0'))
                    {
                        sb[i + 1] = '1';
                    }
                    else
                        if (sb[i].Equals('~') && sb[i + 1].Equals('1'))
                        {
                            sb[i + 1] = '0';
                        }
                }
                sb = sb.Replace("~", "");

                //xu ly dau & |
                while (sb.Length != 1)
                {
                    if (sb[1].Equals('&'))
                    {
                        if (sb[0].Equals('1') && sb[2].Equals('1'))
                        {
                            sb.Replace("1&1", "1");
                        }
                        else
                        {
                            sb.Replace(sb[0].ToString() + sb[1].ToString() + sb[2].ToString(), "0");
                        }
                    }
                    else//chac chan la dau |
                    {
                        if (sb[0].Equals('0') && sb[2].Equals('0'))
                        {
                            sb.Replace("0|0", "0");
                        }
                        else
                        {
                            sb.Replace(sb[0].ToString() + sb[1].ToString() + sb[2].ToString(), "1");
                        }
                    }
                }
                return Int32.Parse(sb.ToString());
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            return 0;
        }

        private void UpdateControls()
        {
            radYes.Checked = true;
        }

        private void UpdateTextBox(string str)
        {
            txtthongtin.Text = str;
        }

        private int GetNodeValue(Node node)
        {
            try
            {
                // phai lay ve ket qua cua node nay la: 1 hoac 0
                lock (objLock)
                {
                    UpdateTextBoxDeletegate updateTextBoxDeleteGate = new UpdateTextBoxDeletegate(UpdateTextBox);
                    txtthongtin.Invoke(updateTextBoxDeleteGate, node.Text);
                    txtthongtin.Text = node.Text;
                    Monitor.Pulse(objLock);
                    Monitor.Wait(objLock);
                }
                if (radYes.Checked)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            return 0;
        }
        private Road SearchRule(Node node, int level)
        {
            try
            {
                string conclusionName = node.Name;
                Road road = new Road();
                // Ta tim luat chua ket luan conclusion vua lay ra ben tren
                for (int i = level; i < ruleList.Count; i++)
                {
                    Rule rule = ruleList[i];
                    string str = rule.Conclusion;
                    if (conclusionName.Equals(str))
                    {
                        road.Node = node;
                        road.Rule = rule;
                        return road;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            return null;
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            lock (objLock)
            {
                Monitor.Pulse(objLock);
            }
        }

        private void ShowWhy()
        {
            try
            {
                string str = string.Empty;
                for (int i = roadListTemp.Count - 1; i >= 0; i--)
                {
                    if (roadListTemp[i].Node.Value == 1)
                    {
                        str += "Theo luật " + roadListTemp[i].Rule.Name + " thì nếu: " + Environment.NewLine + roadListTemp[i].Rule.Suppose + Environment.NewLine + " -> " + roadListTemp[i].Node.Text + Environment.NewLine + Environment.NewLine;
                    }
                }
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

                if (!string.IsNullOrEmpty(str))
                {
                    Form3 form3 = new Form3(str);
                    form3.ShowDialog();
                }
                else
                {
                    Form3 form3 = new Form3("Không có luật nào thỏa mãn !!!");
                    form3.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void nhómSinhViênThựcHiệnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void quảnLýLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void giảiThíchLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWhy();
        }

        private void txtthongtin_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            this.txtthongtin.Clear();
            btnNext.Enabled = true;
            Init();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}