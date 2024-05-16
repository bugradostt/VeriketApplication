using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmListLog : Form
    {
        public FrmListLog()
        {
            InitializeComponent();
        }

        private void FrmListLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogList_Click(object sender, EventArgs e)
        {
            GetLogList();
        }

        private void GetLogList()
        {
            // Mevcut veriyi temizle
            dgvLog.Rows.Clear();

            // Mevcut sütunları temizle
            dgvLog.Columns.Clear();

            try
            {


                // test 
                //string filePath = "C:\\ProgramData\\VeriketApp\\VeriketAppTest.txt";

                // ProgramData klasörünün yolunu
                string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

                // VeriketApp klasörünün yolu
                string veriketAppFolderPath = Path.Combine(programDataPath, "VeriketApp");

                // Log dosyasının yolu
                string filePath = Path.Combine(veriketAppFolderPath, "VeriketAppTest.txt");

                // Verileri saklamak için bir dize listesi oluştur
                var dataList = new List<string[]>();

                // Metin dosyasını satır satır oku
                using (var reader = new StreamReader(filePath))
                {
                    string column;
                    while ((column = reader.ReadLine()) != null)
                    {
                        // Satırı virgülle ayırarak verileri al
                        string[] parts = column.Split(',');
                        dataList.Add(parts);
                    }
                }

                // DataGridView'e sütunları ekle
                dgvLog.Columns.Add("Column1", "Tarih");
                dgvLog.Columns.Add("Column2", "Bilgisayar Adı");
                dgvLog.Columns.Add("Column3", "Oturum Açan Kullanıcı Adı");

                // DataGridView'e verileri yükle
                foreach (var data in dataList)
                {
                    dgvLog.Rows.Add(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    
    
    }
}
