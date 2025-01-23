using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSyst
{
    public partial class Form1 : Form
    {
        private StudentManager studentManager = new StudentManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTxt.Text);
                string firstName = nameTxt.Text;
                string lastName = lnameTxt.Text;
                double gpa = double.Parse(gpaTxt.Text);
                string gender = genderComboBox.Text;

                var student = new Student(id, firstName, lastName, gpa, gender);
                studentManager.AddStudent(student);

                MessageBox.Show("Studentis informacia daemata warmatebit");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTxt.Text);
                if (studentManager.DeleteStudent(id))
                {
                    MessageBox.Show("Studentis informacia waishala warmatebit");
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("Studenti ver moidzebna");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTxt.Text);
                string firstName = nameTxt.Text;
                string lastName = lnameTxt.Text;
                double gpa = double.Parse(gpaTxt.Text);
                string gender = genderComboBox.Text;

                if (studentManager.EditStudent(id, firstName, lastName, gpa, gender))
                {
                    MessageBox.Show("Studenti ganaxlda");
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("Studenti ver moidzebna.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            idTxt.Clear();
            nameTxt.Clear();
            lnameTxt.Clear();
            gpaTxt.Clear();
            genderComboBox.SelectedIndex = -1;
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = studentManager.GetAllStudents();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                studentManager.SaveToFile("students.txt");
                MessageBox.Show("Monacemebi shenaxulia!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                studentManager.LoadFromFile("students.txt");
                MessageBox.Show("Monacemebi chaitvirta warmatebit!");
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void searchGpaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double minGPA = double.Parse(gpaSearchTxt.Text); 
                var filteredStudents = studentManager.SearchByGPA(minGPA);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = filteredStudents;

                if (filteredStudents.Count == 0)
                {
                    MessageBox.Show("Studenti ver moidzebna" + minGPA);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Invalid Input");
            }
        }



        private void header_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
