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
    public partial class Plays : Form
    {
        public Plays()
        {
            InitializeComponent();
        }

        private void PlayBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.theater_actorsDataSet);

        }

        private void Plays_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'theater_actorsDataSet.play' table. You can move, or remove it, as needed.
            this.playTableAdapter.Fill(this.theater_actorsDataSet.play);

        }
    }
}
