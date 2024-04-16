using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

 
namespace GestionDeProhet
{
    public partial class Form2 : Form
    {
     
        public Form2()
        {
            InitializeComponent();
            displayEmployeeData();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String code = project_code.Text.Trim();
            String description = project_description.Text.Trim();
            DateTime date = project_date.Value;
            projectData project = new projectData(code,description,date);
            project.persist(project);
            displayEmployeeData();
            clearFields();


        }
        public void displayEmployeeData()
        {
            projectData project = new projectData();
            List<projectData> listData = project.taskList();
            dataGridView1.DataSource = listData;
           
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void project_description_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void project_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void project_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            String code = project_code.Text.Trim();
            String description = project_description.Text.Trim();
            DateTime date = project_date.Value;
            projectData project = new projectData(code, description, date);

            project.delete(project);
            displayEmployeeData();
            clearFields();

        }
        public void clearFields()
        {
            project_code.Text = "";
            project_description.Text = "";
            project_date.Value =DateTime.Now;
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            String code = project_code.Text.Trim();
            String description = project_description.Text.Trim();
            DateTime date = project_date.Value;
            projectData project = new projectData(code, description, date);
            project.update(project);
            displayEmployeeData();
            clearFields();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            String code = project_code.Text.Trim();
            String description = project_description.Text.Trim();
            DateTime date = project_date.Value;
            projectData project = new projectData(code, description, date);

            project.delete(project);
            displayEmployeeData();
            clearFields();
        }

        private void project_code_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            String code = project_code.Text.Trim();
            String description = project_description.Text.Trim();
            DateTime date = project_date.Value;
            projectData project = new projectData(code, description, date);
            project.persist(project);
            displayEmployeeData();
            clearFields();
        }

        private void project_description_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void project_date_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Click_1(object sender, EventArgs e)
        {
            String code = project_code.Text.Trim();
            String description = project_description.Text.Trim();
            DateTime date = project_date.Value;
            projectData project = new projectData(code, description, date);
            project.update(project);
            displayEmployeeData();
            clearFields();
        }

        private void Tasks_Click(object sender, EventArgs e)
        {
 
        }
    }
}
