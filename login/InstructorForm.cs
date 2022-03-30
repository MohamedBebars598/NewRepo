using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class InstructorForm : Form
    {
       
        examEntities1 db = new examEntities1();
        string userName;
        int? selectedStdId;

        public InstructorForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            
            var INS=db.Instructors.Where(i=>i.U_UserName==userName).Select(i=>i).FirstOrDefault();

            label4.Text = "Welcome "+INS.Ins_Fname+" "+INS.Ins_Lname;
            var deptID = INS.Dept_ID;
            label6.Text="Department:" + db.Departments.Where(i=>i.Dept_ID==deptID).Select(i=>i.Dept_Name).FirstOrDefault();


            var courses = (from d in db.Courses select d.Crs_Name);
            foreach (var dd in courses)
            {
                comboBox1.Items.Add(dd);
            }


            var stds = db.Students.Select(i => i.Std_ID);

            foreach (var dd in stds)
            {
                comboBox2.Items.Add(dd);
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {

            int? insId = db.Instructors.Where(i => i.U_UserName == userName).Select(i => i.Ins_ID).FirstOrDefault();




            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && selectedStdId != null)
            {
                int questions = int.Parse(textBox1.Text) + int.Parse(textBox2.Text);
                if (questions == 10 && comboBox1.Text != null && insId != null)
                {
                    var s = db.GenerateExameByCourseName(comboBox1.SelectedItem.ToString(), insId, selectedStdId, int.Parse(textBox2.Text), int.Parse(textBox1.Text)).FirstOrDefault();
                    if (s == "true")
                    {
                        MessageBox.Show("exam generated");


                    }
                    else
                    {
                        MessageBox.Show("this  student have Exam and not answerd");
                    }


                }
                else
                {
                    MessageBox.Show("The Sum of MCQ and T/F Must Be 10");
                }

            }
            else
            {
                MessageBox.Show("Please Fill Data");
            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {

            Reports r = new Reports();
            r.Show();
            this.Hide();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //selectedStdId=comboBox2.SelectedItem.ToString();

            //MessageBox.Show(selectedStdId);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStdId = int.Parse(comboBox2.SelectedItem.ToString());




        }


    }
}