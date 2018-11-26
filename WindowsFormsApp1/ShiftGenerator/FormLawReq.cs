using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftGenerator
{
    public partial class FormLawReq : Form
    {
        DataClasses1DataContext data;
        FormMenu formHandler;
        private LawRequirement lawRequirement;


        public FormLawReq(FormMenu form)
        {
            InitializeComponent();
            this.formHandler = form;
            data = new DataClasses1DataContext();

            //ADDING VALUES TO COMBOBOXES
            //JOB CONTRACTS
            Dictionary<string, string> jobContracts = new Dictionary<string, string>();
            jobContracts.Add("11 godzin", "11 godzin dziennego odpoczynku");
            jobContracts.Add("35 godzin", "35 godzin tygodniowego odpoczynku");
            jobContracts.Add("niedziele", "Co czwarta niedziela wolna");
            comboBoxLaws.DataSource = new BindingSource(jobContracts, null);
            comboBoxLaws.DisplayMember = "Value";
            comboBoxLaws.ValueMember = "Key";

            lawRequirement = data.LawRequirements.SingleOrDefault(x => x.idRequirements == 1);
            labelLaw.Text = lawRequirement.reqDesc;
        }

        private void comboBoxLaws_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLaws.SelectedValue.ToString() == "11 godzin")
            {
                lawRequirement = data.LawRequirements.SingleOrDefault(x => x.idRequirements == 1);
                labelLaw.Text = lawRequirement.reqDesc;
            }
            else if (comboBoxLaws.SelectedValue.ToString() == "35 godzin")
            {
                lawRequirement = data.LawRequirements.SingleOrDefault(x => x.idRequirements == 2);
                labelLaw.Text = lawRequirement.reqDesc;
            }
            else if (comboBoxLaws.SelectedValue.ToString() == "niedziele")
            {
                lawRequirement = data.LawRequirements.SingleOrDefault(x => x.idRequirements == 3);
                labelLaw.Text = lawRequirement.reqDesc;
            }
        }


    }
}
