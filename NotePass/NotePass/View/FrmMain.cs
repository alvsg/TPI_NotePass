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
        private string _key;
        private Model.Security secure;
        private Model.XmlFile xmlFile;
        private Model.Safe safe;

        public string Key { get => _key; }

        public FrmMain(string password)
        {
            InitializeComponent();
            _key = password;
            xmlFile = new Model.XmlFile();
            secure = new Model.Security(xmlFile);
            safe = new Model.Safe(this);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            secure.ActionOnFile(true, _key, "", xmlFile.DataFilePath);
            safe.OnLoad(flpEntry);
        }

        private void flpEntry_ControlAdded(object sender, ControlEventArgs e)
        {
            if(flpEntry.Controls.Count > safe.NoData)
            {
                secure.ActionOnFileContent(_key, safe);
                safe.NoData++;
            }
        }
    }
}
