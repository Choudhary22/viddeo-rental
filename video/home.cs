using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace video
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void GetCustomer(object sender, EventArgs e)
        {
            Customer Shopper = new Customer();
            Shopper.Show();
        }

        private void GetMovie(object sender, EventArgs e)
        {
            Movies Picture = new Movies();
            Picture.Show();
        }

        private void GetRental(object sender, EventArgs e)
        {
            Rental Rented = new Rental();
            Rented.Show();
        }
    }
}
