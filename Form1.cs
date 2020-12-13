using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace S31_Prak_2
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Visual_Studio_Projects\S31_Prak_2\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            disp_d();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into TAB1 (id, model, march, days, timeL,raz_vrem, price_m, skid) values " + "(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+ textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_d();
            MessageBox.Show("Готово. Данные внесены.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from TAB1 where id='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_d();
            MessageBox.Show("Готово. Данные удалены.");
        }

        public void disp_d ()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id, model, march, days, timeL,raz_vrem, price_m, skid from TAB1";
            cmd.ExecuteNonQuery();
            DataTable d1 = new DataTable();
            SqlDataAdapter d2 = new SqlDataAdapter(cmd);
            d2.Fill(d1);
            dataGridView1.DataSource = d1;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update TAB1 set model='"+ textBox2.Text + "', march = '" + textBox3.Text + "', days='"+ textBox4.Text + "', timeL= '"+ textBox5.Text +"' ,raz_vrem = '"+ textBox6.Text+ "', price_m='"+ textBox7.Text + ", skid= '"+ textBox8.Text +"' where id='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_d();
            MessageBox.Show("Готово. Данные обновлены.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID AS 'Номер рейса', (price_m / 2) AS 'Цена для детей' from TAB1";
            cmd.ExecuteNonQuery();
            DataTable d1 = new DataTable();
            SqlDataAdapter d2 = new SqlDataAdapter(cmd);
            d2.Fill(d1);
            dataGridView2.DataSource = d1;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID AS 'Номер рейса', (case when skid > 0 then (price_m - (price_m / 100 * skid)) else price_m end) AS 'Цена для пенсионеров' from tab1";
            cmd.ExecuteNonQuery();
            DataTable d1 = new DataTable();
            SqlDataAdapter d2 = new SqlDataAdapter(cmd);
            d2.Fill(d1);
            dataGridView2.DataSource = d1;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID AS 'Номер рейса', march AS 'Маршрут', raz_vrem AS 'Развина во времени в часах' from TAB1 order by raz_vrem desc";
            cmd.ExecuteNonQuery();
            DataTable d1 = new DataTable();
            SqlDataAdapter d2 = new SqlDataAdapter(cmd);
            d2.Fill(d1);
            dataGridView2.DataSource = d1;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ID AS 'Номер рейса', days AS 'День вылета', CAST(timeL AS char(5)) AS 'Время вылета' from TAB1 order by days ASC, timeL ASC";
            cmd.ExecuteNonQuery();
            DataTable d1 = new DataTable();
            SqlDataAdapter d2 = new SqlDataAdapter(cmd);
            d2.Fill(d1);
            dataGridView2.DataSource = d1;
            con.Close();
        }
    }
}
