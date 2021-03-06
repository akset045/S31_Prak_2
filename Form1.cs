﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
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
            cmd.CommandText = "insert into TAB1 (id, model, march, days, timeL,raz_vrem, price_m, skid) values " + "(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+ textBox6.Text + "','" + textBox7.Text + "','" + textBox10.Text + "')";
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

            
            SqlCommand cmd = new SqlCommand
                ("update TAB1 set model=@a2, march=@a3, days=@a4, timeL=@a5, raz_vrem=@a6, price_m=@a7, skid=@a8 where id=@a1", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@a1", textBox1.Text);
            cmd.Parameters.AddWithValue("@a2", textBox2.Text);
            cmd.Parameters.AddWithValue("@a3", textBox3.Text);
            cmd.Parameters.AddWithValue("@a4", textBox4.Text);
            cmd.Parameters.AddWithValue("@a5", textBox5.Text);
            cmd.Parameters.AddWithValue("@a6", textBox6.Text);
            cmd.Parameters.AddWithValue("@a7", textBox7.Text);
            cmd.Parameters.AddWithValue("@a8", textBox10.Text);

            // cmd.CommandText = "update TAB1 set model='"+ textBox2.Text + "', march = '" + textBox3.Text + "', days='"+ textBox4.Text + "', timeL= '"+ textBox5.Text +"' ,raz_vrem = '"+ textBox6.Text+ "', price_m='"+ textBox7.Text + ", tab1.skid= '" + textBox10.Text + "' where id='" + textBox1.Text + "'";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            disp_d();
            MessageBox.Show("Готово. Данные обновлены.");
        }

        // 77777
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

        /* 88 */
        
    }

    /* 77 */
    
}

