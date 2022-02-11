
namespace testlog
{
    partial class temp2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("地理系", 0, 0);
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("测绘系", 1, 1);
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("软件工程系");
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("地理与信息工程学院", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode67,
            treeNode68,
            treeNode69});
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("男", 0, 0);
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("女", 1, 1);
            System.Windows.Forms.TreeNode treeNode73 = new System.Windows.Forms.TreeNode("B1", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode71,
            treeNode72});
            System.Windows.Forms.TreeNode treeNode74 = new System.Windows.Forms.TreeNode("男", 0, 0);
            System.Windows.Forms.TreeNode treeNode75 = new System.Windows.Forms.TreeNode("女", 1, 1);
            System.Windows.Forms.TreeNode treeNode76 = new System.Windows.Forms.TreeNode("B2", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode74,
            treeNode75});
            System.Windows.Forms.TreeNode treeNode77 = new System.Windows.Forms.TreeNode("全部", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode70,
            treeNode73,
            treeNode76});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tree1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtStuNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtStuName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tree1
            // 
            this.Tree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree1.Location = new System.Drawing.Point(3, 24);
            this.Tree1.Margin = new System.Windows.Forms.Padding(4);
            this.Tree1.Name = "Tree1";
            treeNode67.ImageIndex = 0;
            treeNode67.Name = "nodeX1";
            treeNode67.SelectedImageIndex = 0;
            treeNode67.Text = "地理系";
            treeNode68.ImageIndex = 1;
            treeNode68.Name = "nodeX2";
            treeNode68.SelectedImageIndex = 1;
            treeNode68.Text = "测绘系";
            treeNode69.Name = "NodeX3";
            treeNode69.Text = "软件工程系";
            treeNode70.ImageIndex = 2;
            treeNode70.Name = "nodeY1";
            treeNode70.SelectedImageIndex = 2;
            treeNode70.Text = "地理与信息工程学院";
            treeNode71.ImageIndex = 0;
            treeNode71.Name = "nodeNan";
            treeNode71.SelectedImageIndex = 0;
            treeNode71.Text = "男";
            treeNode72.ImageIndex = 1;
            treeNode72.Name = "nodeNv";
            treeNode72.SelectedImageIndex = 1;
            treeNode72.Text = "女";
            treeNode73.ImageIndex = 2;
            treeNode73.Name = "nodeB1";
            treeNode73.SelectedImageIndex = 2;
            treeNode73.Text = "B1";
            treeNode74.ImageIndex = 0;
            treeNode74.Name = "nodeNan";
            treeNode74.SelectedImageIndex = 0;
            treeNode74.Text = "男";
            treeNode75.ImageIndex = 1;
            treeNode75.Name = "nodeNv";
            treeNode75.SelectedImageIndex = 1;
            treeNode75.Text = "女";
            treeNode76.ImageIndex = 2;
            treeNode76.Name = "nodeB2";
            treeNode76.SelectedImageIndex = 2;
            treeNode76.Text = "B2";
            treeNode77.ImageIndex = 2;
            treeNode77.Name = "AllNodes";
            treeNode77.SelectedImageIndex = 2;
            treeNode77.Text = "全部";
            this.Tree1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode77});
            this.Tree1.Size = new System.Drawing.Size(268, 166);
            this.Tree1.TabIndex = 1;
            this.Tree1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree1_NodeMouseDoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column3,
            this.Column5,
            this.Column2,
            this.Column6,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1086, 637);
            this.dataGridView1.TabIndex = 5;
            // 
            // txtStuNo
            // 
            this.txtStuNo.Location = new System.Drawing.Point(86, 42);
            this.txtStuNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtStuNo.Name = "txtStuNo";
            this.txtStuNo.Size = new System.Drawing.Size(148, 28);
            this.txtStuNo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "学号";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(180, 603);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(116, 34);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // txtStuName
            // 
            this.txtStuName.Location = new System.Drawing.Point(86, 91);
            this.txtStuName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStuName.Name = "txtStuName";
            this.txtStuName.Size = new System.Drawing.Size(148, 28);
            this.txtStuName.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "姓名";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 603);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 34);
            this.button1.TabIndex = 17;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Tree1);
            this.groupBox1.Location = new System.Drawing.Point(25, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 193);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询学院学情";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtStuNo);
            this.groupBox2.Controls.Add(this.txtStuName);
            this.groupBox2.Location = new System.Drawing.Point(28, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 126);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学生学情查询（可选择按学号或按姓名查询）";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(28, 393);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 74);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "班级学情查询";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "班级";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 42);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 28);
            this.textBox2.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Location = new System.Drawing.Point(25, 492);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 74);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "专业学情查询";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "专业";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 42);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 28);
            this.textBox1.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.btnSelect);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(326, 664);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(326, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1092, 664);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "学号";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.Width = 105;
            // 
            // Column1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column1.FillWeight = 110.7647F;
            this.Column1.HeaderText = "姓名";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 105;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 123.913F;
            this.Column3.HeaderText = "专业";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 105;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 93.33292F;
            this.Column5.HeaderText = "班级";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 105;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 87.85164F;
            this.Column2.HeaderText = "已修学分";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 105;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 82.33897F;
            this.Column6.HeaderText = "平均学分绩点";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 105;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 101.7988F;
            this.Column4.HeaderText = "排名";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 105;
            // 
            // temp2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 664);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.MaximumSize = new System.Drawing.Size(1440, 720);
            this.MinimumSize = new System.Drawing.Size(1440, 720);
            this.Name = "temp2";
            this.Text = "temp2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Tree1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtStuNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtStuName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}