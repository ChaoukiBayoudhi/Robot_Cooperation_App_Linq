using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboCoop
{
    public partial class TaskPerRobot : Form
    {
        public TaskPerRobot()
        {
            InitializeComponent();
        }

        private void TaskPerRobot_Load(object sender, EventArgs e)
        {
            var results = (from R1 in Form1.dbRobot.TaskRobots
                          group R1  by R1.IdRobot into g
                          orderby g.First().IdRobot descending
                          select new 
                          {
                              IdRobot = g.First().IdRobot,
                              duration = g.Sum(x => (x.EndDate - x.StartDate).TotalMinutes),
                              taskCount = g.Count()
                          }).ToList();
            dataGridView1.DataSource = results;
            dataGridView1.Columns[0].HeaderText = "Id du Robot";
            dataGridView1.Columns[1].HeaderText = "Durée Totale (minutes)";
            dataGridView1.Columns[2].HeaderText = "Nombre de taches";
            dataGridView1.Refresh();
        }
    }
}
