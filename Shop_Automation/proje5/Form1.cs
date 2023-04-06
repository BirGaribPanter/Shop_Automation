using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace proje5
{
    public partial class Form1 : Form
    {
        string tarih;
        IDataReader dr;
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        void vericek()//Veritabanından verileri çekme işlem--i
        {

            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database8.accdb");
            da = new OleDbDataAdapter("Select urunler,fiyat,adet,tarih from halprogramı", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "halprogramı");
            DGVall.DataSource = ds.Tables["halprogramı"];
            con.Close();
            DGVall.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;

            DGVall.Columns[0].HeaderText = "urunler";
            DGVall.Columns[1].HeaderText = "fiyat";
            DGVall.Columns[2].HeaderText = "adet";
            DGVall.Columns[3].HeaderText = "tarih";
            
        }

        void temizle()
        {
            dateTimePicker1.Value = Convert.ToDateTime(tarih);
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                temizle();
                MessageBox.Show("ÜRÜN BİLGİSİ GİR!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox2.Text == "")
            {
                temizle();
                MessageBox.Show("ÜRÜN BİLGİSİ GİRİN!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Text == "")
            {
                temizle();
                MessageBox.Show("ÜRÜN BİLGİSİ GİRİN!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else
            {
                cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into halprogramı (urunler,fiyat,adet,tarih) values ('" + textBox1.Text + "','" +int.Parse (textBox2.Text) + "','" + int.Parse(textBox3.Text) + "','" + dateTimePicker1.Value + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                temizle();
                vericek();
                MessageBox.Show("ÜRÜN EKLEME İŞLEMİ BAŞARILI!", "Ekleme İŞlemi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tarih = dateTimePicker1.Value.ToString();
            vericek();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                temizle();
                MessageBox.Show("ÜRÜN BİLGİSİ GİR!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox2.Text == "")
            {
                temizle();
                MessageBox.Show("ÜRÜN BİLGİSİ GİR!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Text == "")
            {
                temizle();
                MessageBox.Show("ÜRÜN BİLGİSİ GİR!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {






                 
                 cmd = new OleDbCommand();
                 con.Open();
                 cmd.Connection = con;
                 cmd.CommandText = "update halprogramı set fiyat='" + textBox2.Text + "',adet='" + textBox3.Text + "',tarih='" + dateTimePicker1.Text + "' where urunler='" + textBox1.Text + "'";
                 cmd.ExecuteNonQuery();
                 con.Close();
                 vericek();
                 temizle();
                 MessageBox.Show("HAL Güncelleme İşlemi Başarılı!", "Güncelleme İŞlemi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }
    }
}
//Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PC\Desktop\projeler\proje5\proje5\bin\Debug\Database8.accdb
