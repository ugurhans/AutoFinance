using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Abstract;

namespace FormUI
{

    public partial class Form1 : Form
    {

        private IItemService _itemService;

        public Form1(IItemService itemService)
        {
            _itemService = itemService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            dataGridView1.DataSource = _itemService.GetAll();
        }
    }
}
