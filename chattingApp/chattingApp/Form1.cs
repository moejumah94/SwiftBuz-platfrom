using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace chattingApp
{
    public partial class Form1 : Form
    {

        List<Panel> panels;

        public bool LoginSuccessful { get; private set; }
        public string LoggedEmployee { get; private set; }

        public  string connectionString = "Server=remotemysql.com;Database=yS7P132OVX;Uid=yS7P132OVX;Pwd=SaMkdRD3Tp;";
        private string callerPanel;

        public Form1()
        {
            InitializeComponent();
            panels = new List<Panel>();
            panels.Add(panel_guest_log_1);
            panels.Add(panel_Menu_Page_1);
            panels.Add(panel_services_1);
            panels.Add(panel_s_directory_1);
            panels.Add(panel_s_speak_HR);
            panels.Add(panel_s_forms_1);
            panels.Add(panel_w_login_1);
            panels.Add(panel_welcome_login_1);

            //initialize with "panel_Menu_Page_1"

            this.MakeOnePanelVisible("panel_Menu_Page_1");



            


            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                MySqlCommand mySqlCommand = new MySqlCommand("select user_id from employee", mySqlConnection);
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    comboBox_employees.Items.Add(mySqlDataReader[0].ToString());
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
     
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //send to Welcome Login if credentials are correct

            if (textBox_username.Text == "" && textBox_password.Text == "")
            {
                Welcome_login_1 welcome_Login_1 = new Welcome_login_1();
                welcome_Login_1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong Credentials!");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MakeOnePanelVisible(string panelName)
        {
            foreach (Panel panel in panels)
            {
                if (panel.Name == panelName)
                {
                    panel.Visible = true;
                    panel.Location = new Point(10, 10);
                }
                else panel.Visible = false;
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            LoggedEmployee = "";
            LoginSuccessful = false;

            
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                MySqlCommand mySqlCommand = new MySqlCommand("select user_id,passwordd from employee", mySqlConnection);
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    
                    if (mySqlDataReader[0].ToString() == textBox_username.Text && mySqlDataReader[1].ToString() == textBox_password.Text)
                    {
                        LoginSuccessful = true;
                        LoggedEmployee = mySqlDataReader[0].ToString();
                        MakeOnePanelVisible("panel_welcome_login_1");
                        label_welcome_username.Text = "Welcome," + LoggedEmployee;

                        textBox_username.Text = "";
                        textBox_password.Text = "";
                    }
                }

                if (LoginSuccessful == false)
                {
                    MessageBox.Show("Wrong username or password!");
                    textBox_username.Text = "";
                    textBox_password.Text = "";
                    return;
                }
            


        }

        private void button_not_a_user_click_here_Click(object sender, EventArgs e)
        {
            MakeOnePanelVisible("panel_guest_log_1");
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            MakeOnePanelVisible("panel_Menu_Page_1");
        }

        private void button_Back1_Click(object sender, EventArgs e)
        {
            MakeOnePanelVisible("panel_Menu_Page_1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            MakeOnePanelVisible("panel_w_login_1");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            MakeOnePanelVisible("panel_welcome_login_1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
            MakeOnePanelVisible("panel_services_1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            MakeOnePanelVisible("panel_welcome_login_1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MakeOnePanelVisible("panel_s_directory_1");

            int ITy = 0;
            int HRy = 0;
            int Othery = 0;

            using (MySqlConnection mySqlConnection = new MySqlConnection(this.connectionString))
            { 
                MySqlCommand mySqlCommand = new MySqlCommand("select * from employee", mySqlConnection);
                mySqlConnection.Open();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    if (int.Parse(mySqlDataReader[4].ToString()) == 1)
                    {
                        Label label = new Label();
                        label.Text = mySqlDataReader[1].ToString();
                        label.Location = new Point(0, ITy);
                        ITy += 20;
                        panel_IT_dept.Controls.Add(label);
                        
                    }
                    else if (int.Parse(mySqlDataReader[4].ToString()) == 2)
                    {
                        Label label = new Label();
                        label.Text = mySqlDataReader[1].ToString();
                        label.Location = new Point(0, HRy);
                        HRy += 20;
                        panel_HR_dept.Controls.Add(label);
                        


                    }
                    else if (int.Parse(mySqlDataReader[4].ToString()) == 3)
                    {
                        Label label = new Label();
                        label.Text = mySqlDataReader[1].ToString();
                        label.Location = new Point(0, Othery);
                        Othery += 20;
                        panel_other_dept.Controls.Add(label);
                        
                    }

                }




            }
        }


       

        private void button15_Click(object sender, EventArgs e)
        {
            MakeOnePanelVisible("panel_Menu_Page_1");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MakeOnePanelVisible("panel_welcome_login_1");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
            MakeOnePanelVisible("panel_welcome_login_1");
        }

        private void button20_Click(object sender, EventArgs e)
        {
           MakeOnePanelVisible("panel_services_1");
        }

        private void button_speak_to_hr_Click(object sender, EventArgs e)
        {
            this.callerPanel = "panel_guest_log_1";
            MakeOnePanelVisible("panel_s_speak_HR");


        }

        private void button7_Click(object sender, EventArgs e)
        {
            string insertQry = string.Format("INSERT INTO `messagee` (`message_id`, `message_content`, `sender_id`, `reciver_id`)" +
                " VALUES (NULL, '{0}', '{1}', '{2}')", richTextBox1.Text, this.LoggedEmployee, comboBox_employees.SelectedItem.ToString());

        using(MySqlConnection mySqlConnection = new MySqlConnection(this.connectionString))
                {
                MySqlCommand mySqlCommand = new MySqlCommand(insertQry,mySqlConnection);
                mySqlConnection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sent Successfully!");
                    richTextBox1.Text = "";

                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        void temp()
        {
            

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.callerPanel = "panel_services_1";
            MakeOnePanelVisible("panel_s_speak_HR");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            MakeOnePanelVisible("panel_s_forms_1");
        }

        private void panel_w_login_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
           
            MakeOnePanelVisible("panel_services_1");
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (this.callerPanel == "panel_services_1")
            {
                MakeOnePanelVisible("panel_services_1");
            }
            else if (this.callerPanel == "panel_guest_log_1")
            {
                MakeOnePanelVisible("panel_guest_log_1");
            }
        }
    }
}
