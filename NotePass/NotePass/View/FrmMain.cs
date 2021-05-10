using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePass.View
{
    public partial class FrmMain : Form
    {
        private string key;
        private Model.Security secure;
        private Model.XmlFile xmlFile;

        public FrmMain(string password)
        {
            InitializeComponent();
            key = password;
            xmlFile = new Model.XmlFile();
            secure = new Model.Security(xmlFile);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            secure.ActionOnFile(true, key, "");
        }
    }
}
