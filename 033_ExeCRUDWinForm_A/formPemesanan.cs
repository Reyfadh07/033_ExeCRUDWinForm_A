using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _033_ExeCRUDWinForm_A
{
    public partial class formPemesanan : Form
    {
        DataTable dt;
        DataRow dr;
        String code;
        public formPemesanan()
        {
            InitializeComponent();

            this.tiveltabelTableAdapter.Fill(this.tivelDataSet1.Tiveltabel);
            this.tiveltabelTableAdapter.Fill(this.tivelDataSet1.Tiveltabel);
            txtid.Enabled = false;
            txtnama.Enabled = false;
            txtemail.Enabled = false;
            txtnotelp.Enabled = false;
            txtjeniskelamin.Enabled = false;
            cbkelas.Enabled = false;
            cbkelas.Items.Add("Super Class");
            cbkelas.Items.Add("Super Bisnis");
            btnsave.Enabled = false;
        }

        private void formPemesanan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tivelDataSet1.Tiveltabel' table. You can move, or remove it, as needed.
            this.tiveltabelTableAdapter.Fill(this.tivelDataSet1.Tiveltabel);
            // TODO: This line of code loads data into the 'tivelDataSet.Tivel1' table. You can move, or remove it, as needed.

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            btnsave.Enabled = true;
            txtnama.Enabled = true;
            txtemail.Enabled = true;
            txtnotelp.Enabled = true;
            txtjeniskelamin.Enabled = true;
            cbkelas.Enabled = true;
            txtnama.Text = "";
            txtemail.Text = "";
            txtnotelp.Text = "";
            txtjeniskelamin.Text = "";
            cbkelas.Text = "";
            int ctr, len;
            string codeval;
            dt = tivelDataSet1.Tables["Tiveltabel"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["id"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtid.Text = "T00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtid.Text = "T" + ctr;
            }

            btnadd.Enabled = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            dt = tivelDataSet1.Tables["Tiveltabel"];
            dr = dt.NewRow();
            dr[0] = txtid.Text;
            dr[1] = txtnama.Text;
            dr[2] = txtemail.Text;
            dr[3] = txtnotelp.Text;
            dr[4] = txtjeniskelamin.Text;
            dr[5] = cbkelas.SelectedItem;
            dt.Rows.Add(dr);
            tiveltabelTableAdapter.Update(tivelDataSet1);
            txtid.Text = System.Convert.ToString(dr[0]);
            txtid.Enabled = false;
            txtnama.Enabled = false;
            txtemail.Enabled = false;
            txtnotelp.Enabled = false;
            txtjeniskelamin.Enabled = false;
            cbkelas.Enabled = false;
            this.tiveltabelTableAdapter.Fill(this.tivelDataSet1.Tiveltabel);
            btnadd.Enabled = true;
            btnsave.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtid.Text;
            dr = tivelDataSet1.Tables["Tiveltabel"].Rows.Find(code);
            dr.Delete();
            tiveltabelTableAdapter.Update(tivelDataSet1);
        }

        private void btnkembali_Click(object sender, EventArgs e)
        {
            new formMenu().Show();
            this.Hide();
        }
    }
}
