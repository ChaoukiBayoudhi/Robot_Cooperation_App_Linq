using System;
using System.Windows.Forms;

namespace RoboCoop
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //1- Créer une instance
                Task tache1 = new Task();
                //2- initialisation des propriétés (from graphic controls)
                tache1.name = txt_name.Text;
                tache1.duration = float.Parse(txt_duration.Text);
                tache1.description = rch_description.Text;
                //t1.status=
                //3- ajout de l'objet
                //3.1- insert the object into the table object (Tasks)
                Form1.dbRobot.Tasks.InsertOnSubmit(tache1);
                //3.2- Update the database
                Form1.dbRobot.SubmitChanges();
                MessageBox.Show("Tache ajoutée avec succés...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void AddTask_Load(object sender, EventArgs e)
        {

        }
    }
}
