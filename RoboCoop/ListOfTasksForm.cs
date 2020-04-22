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
    public partial class ListOfTasksForm : Form
    {
        public ListOfTasksForm()
        {
            InitializeComponent();
        }

        private void ListOfTasksForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Form1.dbRobot.Tasks;
            //In SQL
            //select Code,name from Task where duratuion>=5.5;
            //In Linq
            /*var lstTasks=(from x in Form1.dbRobot.Tasks
                          where x.duration>=5.5
                          orderby x.name descending
                          select new{ code=x.Code,
                            name=x.name
                    }
                          
            ).ToList();*/

        }
    }
}
