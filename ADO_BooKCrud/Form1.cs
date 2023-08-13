using ADO_BooKCrud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_BooKCrud
{
    public partial class Form1 : Form
    {

        BookCurd curd;

        public Form1()
        {
            InitializeComponent();
            curd = new BookCurd();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Book b = new Book();
                b.Name = BName.Text;
                b.Author = BAuthor.Text;
                b.Price=Convert.ToInt32(BPrice.Text);

                int res = curd.AddBook(b);
                if(res>0)
                {
                    MessageBox.Show("Book Inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Book b = new Book();
                b.Id = Convert.ToInt32(BId.Text);
                b.Name = BName.Text;
                b.Author = BAuthor.Text;
                b.Price = Convert.ToInt32(BPrice.Text);
                int res = curd.UpdateBook(b);
                if (res > 0)
                {
                    MessageBox.Show("Book Upadted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int res = curd.DeleteBook(Convert.ToInt32(BId.Text));
                if (res > 0)
                {
                    MessageBox.Show("Record deleted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSerach_Click(object sender, EventArgs e)
        {
            try
            {
                Book prod = curd.GetBookById(Convert.ToInt32(BId.Text));
                if(prod != null) { 


                    BName.Text = prod.Name;
                    BAuthor.Text = prod.Author;
                    BPrice.Text = prod.Price.ToString();
                }
                else
                {
                    MessageBox.Show("Book Not found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                
            }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataTable table = curd.GetAllBooks();
            dataGridView1.DataSource = table;
        }
    }
}
