using GameClass;

namespace DesktopF1Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // begin championship
            Championship.InitChampionship();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabControlPilot_LoadData();
            TabControlTrack_LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TabControlTrack_LoadData()
        {
            // output 
            this.dataGridView1.BorderStyle = BorderStyle.None;
            this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.DataSource = Championship.GetAllTracks();
            this.dataGridView1.Columns["ID"].Visible = false;
            this.dataGridView1.Columns["Distance"].Visible = false;
            this.dataGridView1.Columns["IsCityTrack"].Visible = false;

            this.dataGridView1.Columns["Name"].Width = 200;
            this.dataGridView1.Columns["Name"].HeaderText = "Track";


            this.dataGridView1.Columns["Country"].Width = 215;

            this.dataGridView1.Columns["laps"].Width = 60;
            this.dataGridView1.Columns["laps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void TabControlPilot_LoadData()
        {
            var pilotList = Championship.GetAllPilots().ToList();
            this.dataGridView2.BorderStyle = BorderStyle.None;
            this.dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.DataSource = pilotList;
            this.dataGridView2.ReadOnly = true;

            this.dataGridView2.Columns["Surname"].Visible = false;
            this.dataGridView2.Columns["Name"].Visible = false;
            this.dataGridView2.Columns["ShortName"].Visible = false;
            this.dataGridView2.Columns["Races"].Visible = false;
            this.dataGridView2.Columns["Team"].Visible = false;

            this.dataGridView2.Columns["Number"].DisplayIndex = 0;
            this.dataGridView2.Columns["Number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.Columns["Number"].Width = 52;

            this.dataGridView2.Columns["FullName"].DisplayIndex = 1;
            this.dataGridView2.Columns["FullName"].Width = 224;

            this.dataGridView2.Columns["Country"].DisplayIndex = 3;
            this.dataGridView2.Columns["Country"].Width = 150;

            this.dataGridView2.Columns["Age"].DisplayIndex = 4;
            this.dataGridView2.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.Columns["Age"].Width = 50;

            this.dataGridView2.Columns.Add(new DataGridViewColumn()
            {
                HeaderText = "Team",
                Name = "TeamStr",
                CellTemplate = new DataGridViewTextBoxCell(),
                DisplayIndex = 2,
                Width = 330
            });
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells["TeamStr"].Value = pilotList[i].Team.FullName;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  main button in window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            (int nowTrack, RaceWeekendStatus status) = Championship.GetWeekendStatus();
            switch (status)
            {
                case RaceWeekendStatus.BeforeChampionshipStart:
                    // Choose track, start weekend - go to qualification:
                    label10.Text = "Formula 1 Championship 2024";
                    Championship.NextStage();
                    button2.Text = "Start Qualification!";
                    tabControl1.SelectedIndex = 1;
                    break;

                case RaceWeekendStatus.BeforeWeekendStart:
                case RaceWeekendStatus.FinishQ1:
                case RaceWeekendStatus.FinishQ2:
                    // go to qualification tab:
                    Championship.NextStage();
                    tabControl1.SelectedIndex = 1;
                    break;

                case RaceWeekendStatus.FinishQ3:
                    // turn to Race:
                    if (tabControl1.SelectedIndex != 2)     // ���� �� �� ����� �� �������,
                        tabControl1.SelectedIndex = 2;      // �� ��������� �� ������� �����
                    else
                    {                                       // � ���� �� �� ������� ����� - �� �������� ���� �����
                        tabControl1.SelectedIndex = 2;
                        Championship.NextStage();
                        // ����� ����� ���� ���������� ����������
                        FillInRacePage();
                        button2.Text = "Go to Tournament tables";
                    }
                    break;

                case RaceWeekendStatus.FinishRace:
                    if (button2.Text.ToLower() == "start next weekend")
                    {
                        button2.Text = "Start Qualification";
                        Championship.NextStage();
                        tabControl1.SelectedIndex = 1;      // ������������ �� ������������
                    }
                    else
                    {
                        // go to tournament tab
                        tabControl1.SelectedIndex = 3;
                        FillInTournamentPage();
                        button2.Text = "Start next weekend";
                    }
                    break;

                case RaceWeekendStatus.FinishChampionship:
                    button2.IsAccessible = false;   // ���� ����� ������ ������ ����������, ���� ����������� ��� ������, �� ����� ���� ������� ��������� ����������.
                    break;

                default:
                    this.label2.Text = "No choose racing weekend!";
                    break;

            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            (int nowTrack, RaceWeekendStatus status) = Championship.GetWeekendStatus();
            switch (status)
            {
                case RaceWeekendStatus.BeforeWeekendStart:
                    // make Q1:
                    Championship.MakeQualification(nowTrack);
                    // print result
                    PrintQ1Result(nowTrack, this.listBox2, 1);
                    button1.Text = "Start Q2!";
                    break;

                case RaceWeekendStatus.FinishQ1:
                    // make Q2:
                    Championship.MakeQualification(nowTrack);
                    // print result
                    PrintQ1Result(nowTrack, this.listBox3, 2);
                    button1.Text = "Start Q3!";
                    break;

                case RaceWeekendStatus.FinishQ2:
                    // make Q3:
                    Championship.MakeQualification(nowTrack);
                    // print result
                    PrintQ1Result(nowTrack, this.listBox4, 3);
                    button1.Text = "Next to Race!";
                    button2.Text = "Next to Race!";
                    break;

                case RaceWeekendStatus.FinishQ3:
                    // turn to race page
                    tabControl1.SelectedIndex = 2;
                    break;

                case RaceWeekendStatus.FinishRace:
                    if (button2.Text.ToLower() == "start next weekend")
                    {
                        button2.Text = "Start Qualification";
                        Championship.NextStage();
                        tabControl1.SelectedIndex = 1;      // ������������ �� ������������
                    }
                    break;

                default:
                    this.label2.Text = "No choose racing weekend!";
                    break;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(tabControl1.SelectedIndex.ToString(), "ok");
            /// tabControl1.SelectedIndex - 0 ... 3.
            /// index 0 - page: "Pilot & Teams"
            /// index 1 - page: "Qualification"
            /// index 2 - page: "Race"
            /// index 3 - page: "Tournament"
            (int nowTrack, RaceWeekendStatus status) = Championship.GetWeekendStatus();     // �������� ������� ������ ����������
            if (status == RaceWeekendStatus.BeforeChampionshipStart)                        // ���� ��������� ��� �� �����, �� � ������ ��� ������
                return;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    /// empty - ��� �� ���� ������ ������
                    break;
                case 1:
                    FillInQualificationPage();
                    break;
                case 2:
                    FillInRacePage();
                    break;
                case 3:
                    FillInTournamentPage();
                    break;
            }
        }


        private void FillInTournamentPage()
        {
            this.dataGridView3.BorderStyle = BorderStyle.None;
            this.dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.DataSource = Championship.GetPilotsStanding();
            var currentSize = this.dataGridView3.Font.Size;
            var normalFont = new Font(this.dataGridView3.Font.FontFamily, currentSize, FontStyle.Regular);
            this.dataGridView3.Columns["pos"].Width = 50;
            this.dataGridView3.Columns["name"].Width = 270;
            this.dataGridView3.Columns["pnum"].Width = 40;
            this.dataGridView3.Columns["pnum"].HeaderText = "#";
            this.dataGridView3.Columns["pnum"].DefaultCellStyle.Font = normalFont;
            this.dataGridView3.Columns["point"].Width = 90;
            this.dataGridView3.Columns["point"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView3.Columns["top"].Width = 60;
            this.dataGridView3.Columns["top"].DefaultCellStyle.Font = normalFont;
            this.dataGridView3.Columns["top"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView3.Columns["team"].Width = 210;
            this.dataGridView3.Columns["team"].DefaultCellStyle.Font = normalFont;
            //listBox8.Items.Clear();
            //listBox8.Items.Add("Pilots championship standings");
            //listBox8.Items.Add("");
            //foreach (var str in Championship.GetPilotsStanding())
            //    listBox8.Items.Add(str);

            label12.Text = "Team position";
            this.dataGridView4.BorderStyle = BorderStyle.None;
            this.dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.DataSource = Championship.GetTeamsStanding();
            this.dataGridView4.Columns["pos"].Width = 50;
            this.dataGridView4.Columns["name"].Width = 275;
            this.dataGridView4.Columns["point"].Width = 92;
            this.dataGridView4.Columns["point"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView4.Columns["last"].Width = 60;
            this.dataGridView4.Columns["last"].DefaultCellStyle.Font = normalFont;
            this.dataGridView4.Columns["last"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //listBox9.Items.Clear();
            //listBox9.Items.Add("Teams position");
            //listBox9.Items.Add("");
            //foreach (var str in Championship.GetTeamsStanding())
            //    listBox9.Items.Add(str);

            var tracks = Championship.GetAllTracks().ToList();
            (int nowTrack, RaceWeekendStatus status) = Championship.GetWeekendStatus();
            label11.Text = $"After {tracks.FindIndex(x => x.ID == nowTrack) + 1} races from {tracks.Count()} in championship.";
        }




        private void FillInQualificationPage()
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            (int nowTrack, RaceWeekendStatus status) = Championship.GetWeekendStatus();
            switch (status)
            {
                case RaceWeekendStatus.FinishQ1:
                    // print result
                    PrintQ1Result(nowTrack, this.listBox2, 1);
                    button1.Text = "Start Q2!";
                    break;

                case RaceWeekendStatus.FinishQ2:
                    // print result
                    PrintQ1Result(nowTrack, this.listBox2, 1);
                    PrintQ1Result(nowTrack, this.listBox3, 2);
                    button1.Text = "Start Q3!";
                    break;

                case RaceWeekendStatus.FinishQ3:
                case RaceWeekendStatus.FinishRace:
                    // print result
                    PrintQ1Result(nowTrack, this.listBox2, 1);
                    PrintQ1Result(nowTrack, this.listBox3, 2);
                    PrintQ1Result(nowTrack, this.listBox4, 3);
                    button1.Text = "Next to Race!";
                    break;

                default:
                    // print result
                    var track = Championship.GetAllTracks().FirstOrDefault(t => t.ID == nowTrack);
                    if (track != null)
                    {
                        label2.Text = $"Qualification on {track.Name} track in {track.Country}";
                        button1.Text = "Start Q1!";
                        button1.Enabled = true;
                    }
                    else
                        label2.Text = "No qualifications now";
                    break;
            }

        }

        private void FillInRacePage()
        {
            (int nowTrack, RaceWeekendStatus status) = Championship.GetWeekendStatus();
            if (status == RaceWeekendStatus.FinishQ3 || status == RaceWeekendStatus.FinishRace)
            {
                // pre race - ������� ����, ������� ���� �� �����
                var track = Championship.GetAllTracks().FirstOrDefault(t => t.ID == nowTrack);
                label4.Text = $"F1 race on {track.Name} track in {track.Country}";
                label6.Text = "Sunny weather";
                label7.Text = $"{track.laps} laps, distance: {track.Distance / 1000},{track.Distance % 1000} m.";
                label8.Text = "";
                label9.Text = "";
                listBox6.Items.Clear();
                listBox7.Items.Clear();

                // ������� ������ ������� � ������ ������������
                var result = Championship.GetRaceResultForTrack(nowTrack);
                var pilots = Championship.GetAllPilots();
                int pp = 1;
                foreach (var res in result.Q3Result)
                {
                    var pilot = pilots.First(x => x.Number == res.PID);
                    listBox6.Items.Add($"{pp++}\t#{res.PID} {pilot.FullName} {pilot.Team.Name}");
                }

                foreach (var res in result.Q2Result.Skip(10).Take(5))
                {
                    var pilot = pilots.First(x => x.Number == res.PID);
                    listBox6.Items.Add($"{pp++}\t#{res.PID} {pilot.FullName} {pilot.Team.Name}");
                }

                foreach (var res in result.Q1Result.Skip(15).Take(5))
                {
                    var pilot = pilots.First(x => x.Number == res.PID);
                    listBox6.Items.Add($"{pp++}\t#{res.PID} {pilot.FullName} {pilot.Team.Name}");
                }

                if (status == RaceWeekendStatus.FinishRace)
                {
                    // after race - print winner info
                    var winner = pilots.First(x => x.Number == result.RaceRes[0].PID);  // "hh\\:mm:\\ss\\.fff"
                    label8.Text = $"Time: {result.RaceRes[0].TimeResult.ToString(@"h\:mm\:ss\.fff")}, average speed {string.Format("{0:F2}", (track.Distance / (result.RaceRes[0].TimeResult.TotalMilliseconds / 1000)) * 3.6)} km/h";
                    label9.Text = $"Winner: {winner.FullName} {winner.Team.Name}";

                    // print other pilots info
                    for (int i = 1; i < result.RaceRes.Count(); i++)
                    {
                        var pilot = pilots.First(x => x.Number == result.RaceRes[i].PID);
                        if (result.RaceRes[i].IsDNF() == true)
                        {
                            listBox7.Items.Add($"Pos: {i + 1} - {pilot.FullName} - {pilot.Team.Name} - DNF");
                            listBox7.Items.Add($"\t\tcrash on lap {result.RaceRes[i].LapNumDNF}");
                        }
                        else
                        {
                            listBox7.Items.Add($"Pos: {i + 1} - {pilot.FullName} - {pilot.Team.Name}");
                            listBox7.Items.Add($"\t\t+{(result.RaceRes[i].TimeResult - result.RaceRes[0].TimeResult).ToString(@"m\:ss\.fff")}");
                        }
                    }
                }
            }
            else
            {
                // no race
                listBox6.Items.Clear();
                listBox7.Items.Clear();
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void PrintQ1Result(int trId, ListBox lb, int segment)
        {
            lb.Items.Clear();

            var result = Championship.GetRaceResultForTrack(trId);
            if (result == null)
            {
                lb.Items.Add("No result for this stage");
                return;
            }

            lb.Items.Add($"Result of Segment #{segment}");
            lb.Items.Add("");
            var pilots = Championship.GetAllPilots();
            int pos = 1;
            List<StageResultPilot> segmentRes;
            if (segment == 1)
                segmentRes = result.Q1Result;
            else if (segment == 2)
                segmentRes = result.Q2Result;
            else
                segmentRes = result.Q3Result;
            foreach (var res in segmentRes)
            {
                lb.Items.Add($"#{pos++}\t{res.TimeResult.ToString(@"mm\:ss\:fff")}\t{pilots.First(x => x.Number == res.PID).ShortName} - {res.PID}");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
