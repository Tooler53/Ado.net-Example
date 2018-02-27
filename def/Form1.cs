using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace def
{
    public partial class Form1 : Form
    {
        public int con1 = -1;
        public int con2 = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = bindingSource1;

            dataGridView1.MultiSelect = false;

            this.клиентыTableAdapter.Fill(this._Как_угодно_Клиенты_DataSet.Клиенты);
            this.проектыTableAdapter.Fill(this._Как_угодно_Клиенты_DataSet.Проекты);
            this.регистрацияTableAdapter.Fill(this._Как_угодно_Клиенты_DataSet.Регистрация);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con1 = comboBox1.SelectedIndex;
            
            if (comboBox1.SelectedIndex == 0) { bindingSource1.DataMember = "Клиенты"; }
            else if (comboBox1.SelectedIndex == 1) { bindingSource1.DataMember = "Проекты"; }
            else if (comboBox1.SelectedIndex == 2) { bindingSource1.DataMember = "Регистрация"; }

            int n = Convert.ToInt32(bindingNavigatorPositionItem.Text) - 1;

            if (dataGridView1.RowCount <= n) n = dataGridView1.RowCount - 1;

            if (comboBox1.SelectedIndex != -1)
            {

                if (comboBox1.SelectedIndex == 0) { label1.Text = "Фамилия"; label2.Text = "Имя"; label3.Text = "Отчество"; textBox1.Text = Convert.ToString(dataGridView1[1, n].Value); textBox2.Text = Convert.ToString(dataGridView1[2, n].Value); textBox3.Text = Convert.ToString(dataGridView1[3, n].Value); }
                else if (comboBox1.SelectedIndex == 1) { label1.Text = "Компания_организатор"; label2.Text = "Название_акции"; label3.Text = "Код_проекта"; textBox1.Text = Convert.ToString(dataGridView1[1, n].Value); textBox2.Text = Convert.ToString(dataGridView1[2, n].Value); textBox3.Text = Convert.ToString(dataGridView1[0, n].Value); }
                else if (comboBox1.SelectedIndex == 2) { label1.Text = "Код_регистрации"; label2.Text = "Код_клиента"; label3.Text = "Код_проекта"; textBox1.Text = Convert.ToString(dataGridView1[0, n].Value); textBox2.Text = Convert.ToString(dataGridView1[1, n].Value); textBox3.Text = Convert.ToString(dataGridView1[2, n].Value); }

            }
            else { textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; }
        }

        public void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {

            int n;

            n = Convert.ToInt32(bindingNavigatorPositionItem.Text) - 1;

            try
            {
                if (comboBox1.SelectedIndex != -1)
                {

                    if (comboBox1.SelectedIndex == 0) { textBox1.Text = Convert.ToString(dataGridView1[1, n].Value); textBox2.Text = Convert.ToString(dataGridView1[2, n].Value); textBox3.Text = Convert.ToString(dataGridView1[3, n].Value); }
                    else if (comboBox1.SelectedIndex == 1) { textBox1.Text = Convert.ToString(dataGridView1[1, n].Value); textBox2.Text = Convert.ToString(dataGridView1[2, n].Value); textBox3.Text = Convert.ToString(dataGridView1[0, n].Value); }
                    else if (comboBox1.SelectedIndex == 2) { textBox1.Text = Convert.ToString(dataGridView1[0, n].Value); textBox2.Text = Convert.ToString(dataGridView1[1, n].Value); textBox3.Text = Convert.ToString(dataGridView1[2, n].Value); }

                }

                else { textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; }
            }
            
            catch(ArgumentOutOfRangeException)
            {

            }
            
            if (dataGridView1.RowCount <= n) n = dataGridView1.RowCount - 1;
        }
        
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(bindingNavigatorPositionItem.Text) - 1;
            if (comboBox1.SelectedIndex == 0)
            {

                dataGridView1[1, n].Value = textBox1.Text.ToString();
                dataGridView1.EndEdit();

            }
            else if (comboBox1.SelectedIndex == 1)
            {

                dataGridView1[1, n].Value = textBox1.Text.ToString();
                dataGridView1.EndEdit();

            }
            else if (comboBox1.SelectedIndex == 2)
            {

                dataGridView1[0, n].Value = textBox1.Text.ToString();
                dataGridView1.EndEdit();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(bindingNavigatorPositionItem.Text) - 1;
            if (comboBox1.SelectedIndex == 0)
            {

                dataGridView1[2, n].Value = textBox2.Text.ToString();
                dataGridView1.EndEdit();

            }
            else if (comboBox1.SelectedIndex == 1)
            {

                dataGridView1[2, n].Value = textBox2.Text.ToString();
                dataGridView1.EndEdit();

            }
            else if (comboBox1.SelectedIndex == 2)
            {

                dataGridView1[1, n].Value = textBox2.Text.ToString();
                dataGridView1.EndEdit();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(bindingNavigatorPositionItem.Text) - 1;
            if (comboBox1.SelectedIndex == 0)
            {

                dataGridView1[3, n].Value = textBox3.Text.ToString();
                dataGridView1.EndEdit();

            }
            else if (comboBox1.SelectedIndex == 1)
            {

                dataGridView1[0, n].Value = textBox3.Text.ToString();
                dataGridView1.EndEdit();

            }
            else if (comboBox1.SelectedIndex == 2)
            {

                dataGridView1[2, n].Value = textBox3.Text.ToString();
                dataGridView1.EndEdit();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          if (dataGridView1.CurrentRow.Index<1)
            {
                bindingNavigatorMoveNextItem.PerformClick();
                bindingNavigatorMovePreviousItem.PerformClick();
            }
        else
            {
                bindingNavigatorMovePreviousItem.PerformClick();
                bindingNavigatorMoveNextItem.PerformClick();
            }
            if (comboBox1.SelectedIndex == 0) клиентыTableAdapter.Update(_Как_угодно_Клиенты_DataSet.Клиенты);
            else if (comboBox1.SelectedIndex == 1) проектыTableAdapter.Update(_Как_угодно_Клиенты_DataSet.Проекты);
            else if (comboBox1.SelectedIndex == 2)регистрацияTableAdapter.Update(_Как_угодно_Клиенты_DataSet.Регистрация);
        }
    }
}
