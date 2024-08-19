namespace DesktopF1Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPilots = new TabPage();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            label2 = new Label();
            button1 = new Button();
            listBox4 = new ListBox();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            tabPage3 = new TabPage();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            listBox7 = new ListBox();
            listBox6 = new ListBox();
            tabPage4 = new TabPage();
            dataGridView3 = new DataGridView();
            label11 = new Label();
            label10 = new Label();
            button2 = new Button();
            dataGridView4 = new DataGridView();
            label12 = new Label();
            tabControl1.SuspendLayout();
            tabPilots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPilots);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Font = new Font("Constantia", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            tabControl1.ItemSize = new Size(90, 20);
            tabControl1.Location = new Point(28, 51);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1396, 647);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPilots
            // 
            tabPilots.Controls.Add(dataGridView2);
            tabPilots.Controls.Add(dataGridView1);
            tabPilots.Controls.Add(label3);
            tabPilots.Controls.Add(label1);
            tabPilots.Location = new Point(4, 24);
            tabPilots.Name = "tabPilots";
            tabPilots.Padding = new Padding(3);
            tabPilots.Size = new Size(1388, 619);
            tabPilots.TabIndex = 0;
            tabPilots.Text = "Pilots & Teams";
            tabPilots.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(38, 45);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 26;
            dataGridView2.Size = new Size(806, 551);
            dataGridView2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(880, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(475, 551);
            dataGridView1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Constantia", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(1052, 3);
            label3.Name = "label3";
            label3.Size = new Size(153, 39);
            label3.TabIndex = 3;
            label3.Text = "F1 Tracks";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Constantia", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(359, 3);
            label1.Name = "label1";
            label1.Size = new Size(141, 39);
            label1.TabIndex = 0;
            label1.Text = "F1 Pilots";
            label1.Click += label1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(listBox4);
            tabPage2.Controls.Add(listBox3);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1388, 619);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Qualification";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Constantia", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.Location = new Point(46, 23);
            label2.Name = "label2";
            label2.Size = new Size(294, 33);
            label2.TabIndex = 4;
            label2.Text = "No Qualification now.";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(507, 547);
            button1.Name = "button1";
            button1.Size = new Size(362, 30);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 23;
            listBox4.Location = new Point(924, 66);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(418, 464);
            listBox4.TabIndex = 2;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 23;
            listBox3.Location = new Point(472, 66);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(418, 464);
            listBox3.TabIndex = 1;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 23;
            listBox2.Location = new Point(19, 66);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(418, 464);
            listBox2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(listBox7);
            tabPage3.Controls.Add(listBox6);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1388, 619);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Race";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Constantia", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label9.ForeColor = Color.DarkRed;
            label9.Location = new Point(784, 103);
            label9.Name = "label9";
            label9.Size = new Size(180, 33);
            label9.TabIndex = 8;
            label9.Text = "Winner: ____";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Constantia", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(756, 52);
            label8.Name = "label8";
            label8.Size = new Size(0, 29);
            label8.TabIndex = 7;
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Constantia", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(1075, 19);
            label7.Name = "label7";
            label7.Size = new Size(0, 29);
            label7.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Constantia", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(792, 26);
            label6.Name = "label6";
            label6.Size = new Size(172, 29);
            label6.TabIndex = 5;
            label6.Text = "track weather";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Constantia", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(246, 67);
            label5.Name = "label5";
            label5.Size = new Size(259, 33);
            label5.TabIndex = 4;
            label5.Text = "Race Start position";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Constantia", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(60, 19);
            label4.Name = "label4";
            label4.Size = new Size(479, 39);
            label4.TabIndex = 3;
            label4.Text = "Race on Trackname in Country";
            // 
            // listBox7
            // 
            listBox7.FormattingEnabled = true;
            listBox7.ItemHeight = 23;
            listBox7.Location = new Point(717, 149);
            listBox7.Name = "listBox7";
            listBox7.Size = new Size(608, 418);
            listBox7.TabIndex = 2;
            // 
            // listBox6
            // 
            listBox6.FormattingEnabled = true;
            listBox6.ItemHeight = 23;
            listBox6.Location = new Point(60, 103);
            listBox6.Name = "listBox6";
            listBox6.Size = new Size(622, 464);
            listBox6.TabIndex = 1;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(dataGridView4);
            tabPage4.Controls.Add(dataGridView3);
            tabPage4.Controls.Add(label11);
            tabPage4.Controls.Add(label10);
            tabPage4.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1388, 619);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Tournament";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(33, 114);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(737, 452);
            dataGridView3.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Constantia", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(579, 59);
            label11.Name = "label11";
            label11.Size = new Size(201, 26);
            label11.TabIndex = 7;
            label11.Text = "Race Start position";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Constantia", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(511, 20);
            label10.Name = "label10";
            label10.Size = new Size(386, 39);
            label10.TabIndex = 4;
            label10.Text = "Empty tournament table";
            label10.Click += label10_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(1049, 713);
            button2.Name = "button2";
            button2.Size = new Size(303, 84);
            button2.TabIndex = 2;
            button2.Text = "Start Championship!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(868, 160);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(477, 406);
            dataGridView4.TabIndex = 9;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Constantia", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(1017, 114);
            label12.Name = "label12";
            label12.Size = new Size(201, 26);
            label12.TabIndex = 10;
            label12.Text = "Race Start position";
            label12.Click += label12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1455, 820);
            Controls.Add(button2);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Formula 1 Championship";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPilots.ResumeLayout(false);
            tabPilots.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPilots;
        private TabPage tabPage2;
        private Button button2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label label1;
        private Button button1;
        private ListBox listBox4;
        private ListBox listBox3;
        private ListBox listBox2;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label4;
        private ListBox listBox7;
        private ListBox listBox6;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label10;
        private DataGridView dataGridView1;
        private Label label11;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Label label12;
        private DataGridView dataGridView4;
    }
}
