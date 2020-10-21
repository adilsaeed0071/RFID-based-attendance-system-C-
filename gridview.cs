using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace RFIDProject
{    
    public partial class gridview : Form
    {
        //BindingSource bs = new BindingSource();
       // BindingSource bs = null;
        static  MySqlConnection con = null;
       // MySqlConnection Con = null;
        MySqlCommand mcmd;
        MySqlDataAdapter name = new MySqlDataAdapter();
        DataSet DS = new DataSet();
        BindingSource bs = new BindingSource();
      MySqlCommand mcmd1;
       // MySqlDataReader ad;
       // MySqlDataReader ad1;
        static int row,col;
        static String rfid;
        static String student_rfid;
        static String st;
        static bool check11 =false;
        MySqlDataReader reader = null;
        bool abc = false;
        public gridview()
        {
            InitializeComponent();
            LoadData();
           
           // tsetup();
        }

        private void gridview_Load(object sender, EventArgs e)
        {
            

        }
        void LoadData()
        {    // this.dataGridView1.Show();

            
            Thread t1 = new Thread(() =>
            {
                
                    MySqlDataAdapter name = new MySqlDataAdapter();
                    DataSet DS = new DataSet();
                    BindingSource bs = new BindingSource();

                    //this.dataGridView1.DataSource = null;
                    // this.dataGridView1.ClearSelection();

                    string MyconnectionString = "Server=localhost;Database=mysql;username=adil1;password=adilrocks;";
                    con = new MySqlConnection(MyconnectionString);
                    con.Open();
                   
                    string query = "SELECT * FROM electrical2k11 ";
                    mcmd = new MySqlCommand(query, con);
                    //mcmd.ExecuteNonQuery();
                  
                    check2(); //delegate calling
                 
                    input_rfid();
                    countcheck();
                  
                    // con.Close();
                  
                
            }
               );
          //  MessageBox.Show("thread start");
            t1.Start();
        }//thread ending

      
            
        /*        

        }

        void gridupdate()
        {
           

            t1.Start();
                        
        } */
         void valuechange()
        {
            rfid = dataGridView1.Rows[row].Cells[1].Value.ToString();
            String newvalue = dataGridView1.Rows[row].Cells[col].Value.ToString();
            String header = dataGridView1.Rows[row].Cells[col].OwningColumn.HeaderText;


            
            mcmd = new MySqlCommand("UPDATE electrical2k11 SET " + header + "='" + newvalue + "' WHERE rfid='" + rfid + "'", con);

            mcmd.ExecuteNonQuery();

            MessageBox.Show(rfid);
            MessageBox.Show(header);

         
            //MessageBox.Show(rfid);
                       
         
                 
        }
       


        void input_rfid()
        {  
            Thread t2 = new Thread(() =>
                {
                    while (!check11)
                    {
                        /*
                             TcpClient tcpc = new TcpClient("localhost", 2048);
                             StreamReader str = new StreamReader(tcpc.GetStream());
                             student_rfid = str.ReadLine(); // Geting rfid from router
                             */
                        try
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                Thread.Sleep(5000);
                                MessageBox.Show("entering in try");
                                

                                student_rfid = "123";
                                mcmd = new MySqlCommand("UPDATE electrical2k11 SET status='P'  WHERE rfid= '" + student_rfid + "'", con);
                                mcmd.ExecuteNonQuery();
                                MessageBox.Show("enter in try1");
                                MessageBox.Show(Globals.iniVar.teacher_subject);
                                mcmd = new MySqlCommand("UPDATE electrical2k11 SET  " + Globals.iniVar.teacher_subject + "=  "+Globals.iniVar.teacher_subject+" +  "+ Globals.iniVar.inc_cr +"   WHERE rfid= '" + student_rfid + "'", con);
                                mcmd.ExecuteNonQuery();
                              MessageBox.Show("enter in try2");
                                //  MessageBox.Show("updated status");
                                // student_rfid = null;
                                if (abc == true)
                                {
                                    Thread.Sleep(100);
                                    abc = false;
                                }

                            }
                            else
                                Thread.Sleep(500);
                            checkopen();
                        }
                        catch (Exception ex)
                        {
                            Thread.Sleep(300);
                           // MessageBox.Show(ex.Message);
                            //MessageBox.Show("showing  no of presents");

                        }
                    }
                });

            t2.Start();


    

        }
        void countcheck()
        {
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    mcmd1 = new MySqlCommand("SELECT COUNT(*) FROM electrical2k11 where status = 'P'", con);

                    reader = mcmd1.ExecuteReader();

                    if (reader.Read())
                    {
                        st = reader.GetString(0);


                        LabelText(this.label1, st + "presenntttt");
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("showing  no of presents");
                }
            }
            
            else
            {
                Thread.Sleep(100);
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.dataGridView1.Hide();
          //  dataGridView1.DataSource = null;
         
           
            valuechange();

          //  bool end= true;
            
           MessageBox.Show("Updated");


        




         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        
      

        }
           

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           



        }

        private void cellEditing(object sender, DataGridViewCellCancelEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
           
        }
        void check2()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(InnerLoadData));
        }

        void InnerLoadData()
        {
            try
            {
                name.SelectCommand = mcmd;
                name.Fill(DS);
                bs.DataSource = DS.Tables[0];
                this.dataGridView1.DataSource = bs;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
               // MessageBox.Show("wait a second");
            }
          
            //name.Update(DS.Tables[0]);
          

           
           
          //  MessageBox.Show("reach editing");
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            check11 = true;
            MessageBox.Show("attandance end");
            bool end = true;
            while (end)
            {
                if (con.State == ConnectionState.Open)
                {

                    mcmd = new MySqlCommand("UPDATE electrical2k11 SET status='A'  WHERE status= 'P'", con);
                    mcmd.ExecuteNonQuery();
                    MessageBox.Show("end attandance");
                    end = false;
                }
                else
                    MessageBox.Show("wait for a while and try again");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Update();
            dataGridView1.DataSource = null;
            dataGridView1.DataBindings.Clear();
            bs.DataSource = null;
            dataGridView1.Update(); ;
            dataGridView1.Refresh();
            abc = true;
            con.Close();
            dataGridView1.Dispose();
            this.Dispose();
            gridview f3 = new gridview();
            f3.Show();
            LoadData();

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

        void checkopen()
        {


            input_rfid();
        }
       

    }
}
