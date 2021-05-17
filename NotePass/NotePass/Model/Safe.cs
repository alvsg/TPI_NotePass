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
        private List<Entry> _lstEntry, _lstFavorites;
        private Entry _newEntry;
        private XmlFile xmlFile;
        private View.FrmMain frmMain;
        private FlowLayoutPanel flpButton;
        private Button btnEntry;
        private List<int> _addedInXmlFile, _modifiedInXmlFile, _deletedInXmlFile;
        private int _noData;
        private bool _cancel;

        public List<int> AddedInXmlFile { get => _addedInXmlFile; set => _addedInXmlFile = value; }
        public List<int> ModifiedInXmlFile { get => _modifiedInXmlFile; set => _modifiedInXmlFile = value; }
        public List<int> DeletedInXmlFile { get => _deletedInXmlFile; set => _deletedInXmlFile = value; }
        public List<Entry> LstEntry { get => _lstEntry; set => _lstEntry = value; }
        public int NoData { get => _noData; set => _noData = value; }
        public Entry NewEntry { get => _newEntry; }
        public bool Cancel { get => _cancel; }
        public List<Entry> LstFavorites { get => _lstFavorites; }

        public Safe(View.FrmMain formMain)
        {
            frmMain = formMain;
            xmlFile = new XmlFile();
            _lstEntry = xmlFile.GetDataInArray();
            _noData = _lstEntry.Count;
            _addedInXmlFile = new List<int>();
            _deletedInXmlFile = new List<int>();
            _modifiedInXmlFile = new List<int>();
            _lstFavorites = xmlFile.GetAllFavoritesData();
        }

        public void OnLoad(List<Entry> lstData, FlowLayoutPanel flpEntry)
        {
            if(flpEntry.Controls.Count > 0)
            {
                flpEntry.Controls.Clear();
            }

            foreach (Entry entry in lstData)
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
            btnEntry.Width = 188;
            btnEntry.Height = 111;
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
            if (frmEntry.DialogResult == DialogResult.OK)
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
                        _lstFavorites.Remove(frmEntry.Enregistrement);
                    }
                }
            }
            else if(frmEntry.DialogResult == DialogResult.Cancel)
            {
                if (Convert.ToBoolean(frmEntry.Enregistrement.Favorites))
                {
                    _lstFavorites.Add(frmEntry.Enregistrement);
                }
                else
                {
                    if (_lstFavorites.IndexOf(frmEntry.Enregistrement) < 0)
                    {
                        _lstFavorites.Remove(frmEntry.Enregistrement);
                    }
                }

                _lstEntry[index].Favorites = frmEntry.Enregistrement.Favorites;
                _modifiedInXmlFile.Add(index);
            }
                secure.ActionOnFileContent(frmMain.Key, this);
        }

        public void AddValuesInData()
        {
            View.FrmEntry frmEntry = new View.FrmEntry(false);
            frmEntry.ShowDialog();
            if (frmEntry.DialogResult == DialogResult.Yes)
            {
                _cancel = false;

                _newEntry = new Entry(frmEntry.Enregistrement.Name, frmEntry.Enregistrement.Url, frmEntry.Enregistrement.Password, frmEntry.Enregistrement.Username, DateTime.Now, frmEntry.Enregistrement.Favorites);
                _lstEntry.Add(_newEntry);
                int index = _lstEntry.IndexOf(_newEntry);
                _addedInXmlFile.Add(index);
            }
            else
            {
                _cancel = true;
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
