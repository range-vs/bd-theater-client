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
    public partial class Actors : Form
    {
        public Actors()
        {
            InitializeComponent();
        }

        private void ActorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.actorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.theater_actorsDataSet);

        }

        private void Actors_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'theater_actorsDataSet.actor' table. You can move, or remove it, as needed.
            this.actorTableAdapter.Fill(this.theater_actorsDataSet.actor);

        }
    }
}
