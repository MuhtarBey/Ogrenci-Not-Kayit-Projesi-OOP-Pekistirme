using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using BLLKulup;

//BLLKULUP ASLINDA BLL İSMİ ÖYLE KALDI 

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }







        private void Form1_Load(object sender, EventArgs e)
        {
            OgrenciListesi();
            KulupListesi();
        }
        void OgrenciListesi()
        {
            List<EntityClassOgrenci> OgrenciListele = LogicClassOgrenci.LISTELE();
            dataGridView1.DataSource = OgrenciListele;
            this.Text = "Öğrenci Listesi";

        }
        void KulupListesi()
        {
            List<EntityClassKulup> OgrKulupListForComboBox = LogicClassKulup.LISTELE();
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = OgrKulupListForComboBox;
            dataGridView1.DataSource = OgrKulupListForComboBox;
            this.Text = "Kulup Listesi";
        }
        void NotListesi()
        {
            List<EntityClassNotlar> NotListele = LogicClassNotlar.LISTELE();
            dataGridView1.DataSource = NotListele;
            this.Text = "Öğrenci Notlar";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTNKAYDET_Click(object sender, EventArgs e)
        {
            EntityClassOgrenci ent = new EntityClassOgrenci();
            ent.AD = TXTAD.Text;
            ent.SOYAD = TXTSOYAD.Text;
            ent.FOTOGRAF = TXTFOTO.Text;
            ent.KULUPID = Convert.ToInt16(comboBox1.SelectedValue);
            LogicClassOgrenci.EKLE(ent);
            MessageBox.Show("YENİ ÖĞRENCİ EKLENDİ!");
            OgrenciListesi();
        }

        private void BTNGUNCELLE_Click(object sender, EventArgs e)
        {
            EntityClassOgrenci ent = new EntityClassOgrenci();
            ent.ID = Convert.ToInt16(TXTID.Text);
            ent.AD = TXTAD.Text;
            ent.SOYAD = TXTSOYAD.Text;
            ent.FOTOGRAF = TXTFOTO.Text;
            ent.KULUPID = Convert.ToInt16(comboBox1.SelectedValue);
            LogicClassOgrenci.GUNCELLE(ent);
            MessageBox.Show("KAYIT GÜNCELLENDİ!");
            OgrenciListesi();
        }

        private void BTNLISTELE_Click(object sender, EventArgs e)
        {
            OgrenciListesi();
        }

        private void BTNGUNCELLE2_Click(object sender, EventArgs e)
        {
            EntityClassNotlar ent = new EntityClassNotlar();
            ent.OGRID = Convert.ToInt16(TXTOGRID.Text);
            ent.SINAV1 = Convert.ToInt16(TXTS1.Text);
            ent.SINAV2 = Convert.ToInt16(TXTS2.Text);
            ent.SINAV3 = Convert.ToInt16(TXTS3.Text);
            ent.PROJE = Convert.ToInt16(TXTPROJE.Text);
            ent.ORTALAMA = Convert.ToInt16(TXTORTALAMA.Text);
            ent.DURUM = TXTDURUM.Text;
            LogicClassNotlar.GUNCELLE(ent);
            NotListesi();
            MessageBox.Show("NOTLAR GÜNCELLENDİ!");

        }


        private void BTNLISTELE2_Click(object sender, EventArgs e)
        {
            NotListesi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.Text == "Öğrenci Listesi")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                TXTID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TXTAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                TXTSOYAD.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                TXTFOTO.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            }
            if(this.Text=="Öğrenci Notlar")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                TXTOGRID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TXTAD.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
                TXTSOYAD.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
                TXTS1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                TXTS2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                TXTS3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                TXTPROJE.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                TXTORTALAMA.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                TXTDURUM.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();

            }
        }

        private void BTNORT_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje;
            double ortalama;
            string durum;

            s1 = Convert.ToInt16(TXTS1.Text);
            s2 = Convert.ToInt16(TXTS2.Text);
            s3 = Convert.ToInt16(TXTS3.Text);
            proje = Convert.ToInt16(TXTPROJE.Text);

            ortalama = (s1 + s2 + s3 + proje) / 4;
            if (ortalama>=50)
            {
                durum = "ture";
            }
            durum = "false";
            TXTDURUM.Text = durum;
        }

        private void BTNLISTELE3_Click(object sender, EventArgs e)
        {
            KulupListesi();
        }

        private void BTNKAYDET3_Click(object sender, EventArgs e)
        {
            EntityClassKulup ent = new EntityClassKulup();
            ent.KULUPAD = TXTKULUPAD.Text;
            LogicClassKulup.EKLE(ent);
        }

        private void BTNGUNCELLE3_Click(object sender, EventArgs e)
        {
            EntityClassKulup ent = new EntityClassKulup();
            ent.KULUPAD = TXTKULUPAD.Text;
            ent.KULUPID = Convert.ToInt16(TXTKULUPID.Text);
            LogicClassKulup.GUNCELLE(ent);
            KulupListesi();
        }
    }
}
