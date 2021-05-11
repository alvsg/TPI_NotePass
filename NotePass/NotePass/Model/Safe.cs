using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //Directive ajouté manuellement

namespace NotePass.Model
{
    class Safe
    {
        private List<Entry> _lstEntry;
        private XmlFile xmlFile;
        private View.FrmMain frmMain;
        private FlowLayoutPanel flpButton;
        private Button btnEntry;
        private List<int> _addedInXmlFile, _modifiedInXmlFile, _deletedInXmlFile;
        private int _noData;

        public List<int> AddedInXmlFile { get => _addedInXmlFile; set => _addedInXmlFile = value; }
        public List<int> ModifiedInXmlFile { get => _modifiedInXmlFile; set => _modifiedInXmlFile = value; }
        public List<int> DeletedInXmlFile { get => _deletedInXmlFile; set => _deletedInXmlFile = value; }
        public List<Entry> LstEntry { get => _lstEntry; set => _lstEntry = value; }
        public int NoData { get => _noData; set => _noData = value; }

        public Safe(View.FrmMain formMain)
        {
            frmMain = formMain;
            xmlFile = new XmlFile();
            _lstEntry = xmlFile.GetDataInArray();
            _noData = _lstEntry.Count;
        }

        public void OnLoad(FlowLayoutPanel flpEntry)
        {
            foreach (Entry entry in _lstEntry)
            {
                CreateButtons(entry, flpEntry);
            }
        }

        public void CreateButtons(Entry entry, FlowLayoutPanel flpEntry)
        {
            flpButton = flpEntry;

            btnEntry = new Button();
            btnEntry.Name = entry.Name;
            btnEntry.Text = entry.Name;
            btnEntry.FlatStyle = FlatStyle.Flat;
            btnEntry.Width = 167;
            btnEntry.Height = 79;
            btnEntry.Click += btnFlp_Click;
            btnEntry.Tag = entry;
            flpEntry.Controls.Add(btnEntry);
        }

        private void btnFlp_Click(object sender, EventArgs e)
        {
            // Boucle qui vérifie que le sender est bien un bouton
            if (sender is Button btnEntry)
            {
                ShowAndLetModifyValuesInData((Entry)btnEntry.Tag);
            }
        }

        private void ShowAndLetModifyValuesInData(Entry entry)
        {
            int index = _lstEntry.IndexOf(entry);
            Security secure = new Security();
            View.FrmEntry frmEntry = new View.FrmEntry(entry, true, _lstEntry);
            frmEntry.ShowDialog();
            if (frmEntry.DialogResult == DialogResult.Yes)
            {
                UpdateOnButton(index, frmEntry.Enregistrement.Name);
                _lstEntry[index] = new Entry(frmEntry.Enregistrement.Name, frmEntry.Enregistrement.Url, frmEntry.Enregistrement.Password, frmEntry.Enregistrement.Username, frmEntry.Enregistrement.Date, frmEntry.Enregistrement.Favorites);
                _modifiedInXmlFile.Add(index);
            }
            else if (frmEntry.DialogResult == DialogResult.Abort)
            {
                foreach (Button btnEntry in flpButton.Controls)
                {
                    if (index == flpButton.Controls.IndexOf(btnEntry))
                    {
                        flpButton.Controls.RemoveAt(index);
                        _deletedInXmlFile.Add(index);
                    }
                }
            }
            secure.ActionOnFileContent(frmMain.Key, this);
        }

        public void AddValuesInData()
        {
            View.FrmEntry frmEntry = new View.FrmEntry(false);
            frmEntry.ShowDialog();
            if (frmEntry.DialogResult == DialogResult.OK)
            {

            }
        }

        private void UpdateOnButton(int index, string newName)
        {
            Button button = (Button)flpButton.Controls[index];
            if (button.Text != newName)
            {
                button.Text = newName;
            }
        }
    }
}
