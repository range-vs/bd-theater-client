using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursMaryTwoSemestry.DatabaseTable
{
    public partial class Statuses : Form
    {
        public Statuses()
        {
            InitializeComponent();
        }

        private void StatusBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.statusBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.theater_actorsDataSet);

        }

        private void Statuses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'theater_actorsDataSet.status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.theater_actorsDataSet.status);

        }
    }
}
