using System.Windows.Forms;

namespace task6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is Label || c is PictureBox) c.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            errorProvider1.Clear();

            if (textBox1.Text.Trim() == "")
            {
                errorProvider1.SetError(textBox1, "Məbləğ daxil edin");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int mebleg))
            {
                errorProvider1.SetError(textBox1, "Düzgün məbləğ daxil edin");
                return;
            }

            if (mebleg <= 0)
            {
                MessageBox.Show("Mənfi və ya sıfır məbləğ xırdalanmaz", "Diqqət",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] nominal = { 500, 200, 100, 50, 20, 10, 5, 1 };
            Label[] labels = { label9, label8, label7, label6, label5, label4, label3, label1 };

            for (int i = 0; i < nominal.Length; i++)
            {
                int say = mebleg / nominal[i];
                mebleg = mebleg % nominal[i];

                labels[i].Text = say.ToString();
                labels[i].Visible = say > 0;

                PictureBox pb = EskinasTap(labels[i]);
                if (pb != null) pb.Visible = say > 0;

            }
        }

        private PictureBox EskinasTap(Label lbl)
        {
            PictureBox en = null;
            int minMesafe = int.MaxValue;
            foreach (Control c in panel2.Controls)
            {
                if (c is PictureBox pb && pb.Right <= lbl.Left + 10)
                {
                    int mesafe = Math.Abs((pb.Top + pb.Height / 2) - (lbl.Top + lbl.Height / 2))
                               + (lbl.Left - pb.Right);
                    if (mesafe < minMesafe) { minMesafe = mesafe; en = pb; }
                }
            }
            return en;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}

