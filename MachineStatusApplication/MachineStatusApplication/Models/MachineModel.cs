using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MachineStatusApplication.Models
{
    public class MachineModel: INotifyPropertyChanged
    {
        private string name;
        private string description;
        private string status;
        private string note;

        public MachineModel()
        {
            this.name = "";
            this.description = "";
            this.note = "";
            this.status = "";
        }

        public long Id { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }
      
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
