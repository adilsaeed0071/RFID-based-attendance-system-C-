using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace RFIDProject
{
    public partial class addstudent2 : Form
    {
        static String student_rfid;





        public addstudent2()
        { 
            InitializeComponent();
            addnewstudent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = null;
            MySqlDataReader reader = null;
            //   MySqlDataReader reader2 = null;
            string MyconnectionString = "Server=localhost;Database=mysql;username=adil1;password=adilrocks;";
            con = new MySqlConnection(MyconnectionString);
            con.Open();

            String cmdText1 = "INSERT INTO  `mysql`.`" + Globals.iniVar.bagde + "` (`name`, `rfid`, `regno`, `wireless`, `network`, `management`, `ecnomics`, `status`)VALUES ('" + textBox2.Text + "', '" + student_rfid + "', '" + textBox3.Text + "','0','0','0','0','A')";

            MySqlCommand cmd1 = new MySqlCommand(cmdText1, con);

            reader = cmd1.ExecuteReader();
            MessageBox.Show("student added successfully");

            this.Hide();


           // FormDispose(this);
        }

        void addnewstudent()
        {

            Thread t1 = new Thread(() =>
            {
              
                // while loop reading rfid
                bool found = false;

                //AskTeacher frm= new AskTeacher(techer_rfid);


                while (!found)
                {




                    {
                       /*
                        TcpClient tcpc = new TcpClient();
                        Byte[] read = new Byte[32];   // read buffer

                        // Try to connect to the server
                        tcpc.Connect("192.168.16.254", 8080);

                        // Get a NetworkStream object
                        Stream s;
                        s = tcpc.GetStream();

                        // Read the stream and convert it to ASII
                        int bytes = s.Read(read, 0, read.Length);
                         student_rfid = Encoding.ASCII.GetString(read);
                        

                       */
                        student_rfid = "5510965";

                        // teacher_rfid = "5510965";
                        //Globals.iniVar.sResult1 = student_rfid;
                        //MessageBox.Show(Globals.iniVar.sResult1);
                        //MessageBox.Show("In try");
                        LabelText(this.label4, student_rfid);
                        MessageBox.Show("abc");

                        found = true;

                        

                    }

                }


                Thread.Sleep(3000);




            });





            t1.Start();





        }


        delegate void LabelTextCallback(Label bt, String text);
        void LabelText(Label bt, String text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (bt.InvokeRequired)
            {
                LabelTextCallback d = new LabelTextCallback(LabelText);
                this.Invoke(d, new object[] { bt, text });
            }
            else
            {
                bt.Text = text;
            }
        }

    }
}
