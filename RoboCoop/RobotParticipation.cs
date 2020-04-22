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
    public partial class RobotParticipation : Form
    {
        public RobotParticipation()
        {
            InitializeComponent();
        }

        private void RobotParticipation_Load(object sender, EventArgs e)
        {
            //In SQL oracle
            /*Select r.name,t.name, tr.startDate
                from Robot r join TaskRobot tr on r.Id=tr.IdRobot
                */
            var results = (from r in Form1.dbRobot.Robots
                        join tr in Form1.dbRobot.TaskRobots on r.Id equals tr.IdRobot
                        join t in Form1.dbRobot.Tasks  on tr.CodeTask  equals t.Code
                        orderby r.name descending, t.name 
                                       // or ascending
                       select new {
                           RobotName=r.name,
                           TaskName=t.name,
                           StartOn=tr.StartDate,
                           EndOn=tr.EndDate
                       }
                        ).ToList();
            dataGridView1.DataSource = results;
            dataGridView1.Columns[0].HeaderText = "Nom du Robot";
            dataGridView1.Columns[1].HeaderText = "Nom de la Tache";
            dataGridView1.Columns[2].HeaderText = "Date du Debut";
            dataGridView1.Columns[3].HeaderText = "Date du Fin";
            dataGridView1.Refresh();

            /*
            var q = (from product in dataContext.Products
                     join order in dataContext.Orders on product.ProductId equals order.ProductId
                     join cust in dataContext.Customers on order.CustomerId equals cust.CustomerId
                     orderby order.OrderId
                     select new
                     {
                         order.OrderId,
                         product.ProductId,
                         product.ProductName,
                         product.Price,
                         order.Quantity,
                         Customer = cust.Name
                     }).ToList();

            var q = (from product in dataContext.Products
                     join order in dataContext.Orders on product.ProductId equals order.ProductId
                     join cust in dataContext.Customers on new
                     {
                         custid = order.CustomerId,
                         pid = order.ProductId
                     }
equals new
{
custid = cust.CustomerId,
pid = cust.ProductId
}
                     orderby order.OrderId
                     select new
                     {
                         order.OrderId,
                         product.ProductId,
                         product.ProductName,
                         product.Price,
                         order.Quantity,
                         Customer = cust.Name
                     }).ToList();
                     */
        }
    }
}
