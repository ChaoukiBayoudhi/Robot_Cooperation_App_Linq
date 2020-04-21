using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboCoop
{
    public partial class Form1 : Form
    {
        internal static RobotDBDataContext dbRobot = new RobotDBDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddTask f1 = new AddTask();
            f1.MdiParent = this; //pour faire le lien avec la fenêtre conteneur
            f1.Show();
        }

        private void listerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListOfTasksForm l1 = new ListOfTasksForm();
            l1.MdiParent = this; //pour faire le lien avec la fenêtre conteneur
            l1.Show();
        }

        private void modifierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteOrModifyTask d1 = new DeleteOrModifyTask("Modify");
            d1.MdiParent = this;
            d1.Show();
        }

        private void suppToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteOrModifyTask d1 = new DeleteOrModifyTask("Delete");
            d1.MdiParent = this;
            d1.Show();
        }

        private void nombreDeTachesParRobotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskPerRobot tp = new TaskPerRobot();
            tp.MdiParent = this;
            tp.Show();
        }

        private void participationDesRobotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RobotParticipation frp = new RobotParticipation();
            frp.MdiParent = this;
            frp.Show();
        }
    }
}
