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
    public partial class Employments : Form
    {
        public Employments()
        {
            InitializeComponent();
        }

        private void EmploymentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.theater_actorsDataSet);

        }

        private void Employment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'theater_actorsDataSet.employment' table. You can move, or remove it, as needed.
            this.employmentTableAdapter.Fill(this.theater_actorsDataSet.employment);

        }
    }
}
