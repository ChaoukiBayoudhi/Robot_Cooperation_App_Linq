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
    public partial class DeleteOrModifyTask : Form
    {
        private string action;
        
        public DeleteOrModifyTask(string action)
        {
            InitializeComponent();
            this.action = action;
            
        }

        private void DeleteTask_Load(object sender, EventArgs e)
        {
            if (action=="Delete")
            {
                this.Text = "Supprimer une tache";
                this.bt_deleteorModify.Text = "Supprimer";
                //1ère méthode
                //txt_duration.Enabled = false;
                //txt_name.Enabled = false;
               // cmb_status.Enabled = false;
                //2ème méthode
                foreach (Control x in groupBox1.Controls)
                {
                    if (!(x is Label || x is Button))
                        x.Enabled = false;

                }
                txt_code.Enabled = true;
            }
            else
            {
                this.Text = "Modifier une tache";
                this.bt_deleteorModify.Text = "Modifier";
            }
            

        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            if (action == "Delete")
            {   try
                {
                    //1- get the object by code
                    Task t1 = Form1.dbRobot.Tasks.Single<Task>(x => x.Code == int.Parse(txt_code.Text));
                    if (t1 == null)
                    {
                        throw new Exception("veuiller verifier le code: tache n'existe pas");
                    }
                    //2- delete the object from the table
                    Form1.dbRobot.Tasks.DeleteOnSubmit(t1);
                    //3- delete the line from the db
                    Form1.dbRobot.SubmitChanges();
                    MessageBox.Show("Suppression avec succees");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    //1- get the object by code
                    Task t1 = Form1.dbRobot.Tasks.Single<Task>(x => x.Code == int.Parse(txt_code.Text));
                    if (t1 == null)
                    {
                        throw new Exception("veuiller verifier le code: tache n'existe pas");
                    }
                    //2- modify the object from the table
                    t1.name = txt_name.Text;
                    t1.duration = float.Parse(txt_duration.Text);
                    //3- updating the line from the db
                    Form1.dbRobot.SubmitChanges();
                    MessageBox.Show("modification avec succees");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void txt_code_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                //1- get the object by code
                Task t1 = Form1.dbRobot.Tasks.Single<Task>(x => x.Code == int.Parse(txt_code.Text));
                if (t1 == null)
                {
                    throw new Exception("veuiller verifier le code: tache n'existe pas");
                }
                txt_name.Text = t1.name;
                txt_duration.Text = t1.duration.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
