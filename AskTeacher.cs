using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace RFIDProject
{
    public partial class AskTeacher : Form
    {
        public AskTeacher()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
             MySqlConnection con = null;
                MySqlDataReader reader = null;
                MySqlDataReader reader2 = null;
                string MyconnectionString = "Server=localhost;Database=mysql;username=adil1;password=adilrocks;";
                con = new MySqlConnection(MyconnectionString);
                con.Open();
               // this.Text = Globals.iniVar.sResult1;
                string abc;
                abc = this.Text;
                //MessageBox.Show("Result:askteacher" + abc);
            String inc="1";
            if(radioButton1.Checked)
            {
            inc="1";
            Globals.iniVar.inc_cr = inc;
            }
            if(radioButton2.Checked)

            {inc="2";
            Globals.iniVar.inc_cr = inc;

            }


            String cmdText = "UPDATE teacher SET totalcr = totalcr + " + inc + " where name = '" + Globals.iniVar.teacher_name + "'";
                         MySqlCommand cmd = new MySqlCommand(cmdText, con);


                         String cmdText1 = "SELECT subject FROM  teacher WHERE name =  '" + Globals.iniVar.teacher_name + "'";
                            MySqlCommand cmd1 = new MySqlCommand(cmdText1, con);
                           
                           reader = cmd1.ExecuteReader();


                            if (reader.Read())
                            {
                                Globals.iniVar.teacher_subject = reader.GetString(0);
                               //MessageBox.Show(subject1);

                            }

                            string selectbagde = "not slected";
                            if (radioButton3.Checked)
                            {

                                selectbagde = "electrical2k11";



                               // MessageBox.Show(selectbagde);

                               /* String cmdText1 = "SELECT name,reg no,attandance status FROM  electrical 2k11 WHERE rfid =  '" +teacher + "'";
                                MySqlCommand cmd1 = new MySqlCommand(cmdText1, con);
                                
                                //MessageBox.Show("After Read");
                                reader = cmd1.ExecuteReader();
                                */
                            
                            }
                            if (radioButton4.Checked)
                            {

                                selectbagde = "electrical2k12";
                                MessageBox.Show(selectbagde);
                            }
                            if (radioButton5.Checked)
                            {

                                selectbagde = "electrical2k13";
                                MessageBox.Show(selectbagde);

                            }
                            if (radioButton6.Checked)
                            {

                                selectbagde = "electrical2k14";

                            }
                            if (radioButton7.Checked)
                            {

                                selectbagde = "mechanical2k11";

                            }
                            if (radioButton8.Checked)
                            {

                                selectbagde = "mechanical2k12";

                            } if (radioButton9.Checked)
                            {

                                selectbagde = "mechanical2k13";

                            } if (radioButton10.Checked)
                            {

                                selectbagde = "mechanical2k14";

                            }
                            if (radioButton11.Checked)
                            {

                                selectbagde = "cs2k12";

                            }
                            if (radioButton12.Checked)
                            {

                                selectbagde = "cs2k13";

                            }
                            if (radioButton13.Checked)
                            {

                                selectbagde = "cs2k14";

                            }
                            reader.Close();
                           /*
                            String cmdText2 = "SELECT  `rfid`FROM `electrical 2k11` WHERE name='adil'";
                            MySqlCommand cmd2 = new MySqlCommand(cmdText2, con);
                            //string reader1;
                           
                           // reader.NextResult();

                            reader2 = cmd2.ExecuteReader();
                             
                            if (reader2.Read())
                            {
                               
                                string rfid1 = reader2.GetString(0);
                                MessageBox.Show(rfid1);
                                //MessageBox.Show(rfid1);
                            }
                            * */
                            gridview f2 = new gridview();
                            f2.Show();
                          
                            this.Hide();

        
        }

        private void AskTeacher_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_teacher f3=new add_teacher();
            f3.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addstudent f4 = new addstudent();
            f4.Show();
        }

       
    }
}
