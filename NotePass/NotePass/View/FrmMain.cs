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
        private UserInput userInput;
        private bool isOnlyFavorites;
        private List<Button> lstToDelete;

        public string Key { get => _key; }

        public FrmMain(string password)
        {
            InitializeComponent();
            _key = password;
            xmlFile = new Model.XmlFile(password, true);
            secure = new Model.Security(xmlFile);
            safe = new Model.Safe(this);
            userInput = new UserInput();
            isOnlyFavorites = false;
            lstToDelete = new List<Button>();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            secure.ActionOnFile(true, _key, "writing", xmlFile.DataFilePath);
            safe.OnLoad(safe.LstEntry, flpEntry);
        }

        private void flpEntry_ControlAdded(object sender, ControlEventArgs e)
        {
            if (safe.LstEntry.Count > safe.NoData)
            {
                secure.ActionOnFileContent(_key, safe);
                safe.NoData = safe.LstEntry.Count;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isOnlyFavorites = false;
            safe.AddValuesInData();
            if (!safe.Cancel)
            {
                safe.CreateButtons(safe.NewEntry, flpEntry);
            }
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void btnFavorites_Click(object sender, EventArgs e)
        {
            isOnlyFavorites = true;
            foreach (Button button in flpEntry.Controls)
            {
                Model.Entry entry = (Model.Entry)button.Tag;
                if (!safe.LstFavorites.Contains(entry))
                {
                    lstToDelete.Add(button);
                }
            }

            foreach (Button button in lstToDelete)
            {
                flpEntry.Controls.Remove(button);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            isOnlyFavorites = false;
            safe.OnLoad(safe.LstEntry, flpEntry);
        }

        private void tsmiAlphabeticalOrder_Click(object sender, EventArgs e)
        {
            MakeMyLIstMakeMyListSort(tsmiAlphabeticalOrder);
        }

        private void tsmiDateAsc_Click(object sender, EventArgs e)
        {
            MakeMyLIstMakeMyListSort(tsmiDateAsc);
        }

        private void tsmiDateDesc_Click(object sender, EventArgs e)
        {
            MakeMyLIstMakeMyListSort(tsmiDateDesc);
        }

        private void MakeMyLIstMakeMyListSort(ToolStripMenuItem toolStripMenuItem)
        {
            List<Model.Entry> lstEntry;
            if (isOnlyFavorites)
            {
                lstEntry = userInput.SortTheList(safe.LstFavorites, toolStripMenuItem.Name);
            }
            else
            {
                lstEntry = userInput.SortTheList(safe.LstEntry, toolStripMenuItem.Name);
            }

            safe.OnLoad(lstEntry, flpEntry);
        }
    }
}
