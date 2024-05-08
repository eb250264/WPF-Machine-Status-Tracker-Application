using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using log4net;
using log4net.Filter;
using MachineStatusApplication.Models;
using Microsoft.AspNet.SignalR.Client;

namespace MachineStatusApplication.ViewModels
{
    public class MachineStatusesViewModel : INotifyPropertyChanged
    {
        #region Members
        private ObservableCollection<MachineModel> _MachineList;
        private string _errorMessage;
        private bool editPopupIsVisible;
        private bool addPopupIsVisible;
        private MachineModel selectedMchineModel;
        private MachineModel newMchineModel;
        private ICollectionView machineView;
        private string filterStatus;
        private string notificationMessage = string.Empty;
        #endregion Members

        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        

        public string NotificationMessage
        {
            get { return notificationMessage; }
            set
            {
                if (value == notificationMessage) return;
                notificationMessage = value;
                OnPropertyChanged("NotificationMessage");
            }
        }

        public MachineModel SelectedMchineModel
        {
            get { return selectedMchineModel; }
            set
            {
                selectedMchineModel = value;
                OnPropertyChanged("SelectedMchineModel");
            }
        }
        public MachineModel NewMachineModel
        {
            get { return newMchineModel; }
            set
            {
                newMchineModel = value;
                OnPropertyChanged("NewMachineModel");
            }
        }
        public bool EditPopupIsVisible
        {
            get { return editPopupIsVisible; }
            set
            {
                if (value != editPopupIsVisible)
                {
                    editPopupIsVisible = value;
                    OnPropertyChanged("EditPopupIsVisible");
                }
            }
        }

        public bool AddPopupIsVisible
        {
            get { return addPopupIsVisible; }
            set
            {
                if (value != addPopupIsVisible)
                {
                    addPopupIsVisible = value;
                    OnPropertyChanged("AddPopupIsVisible");
                }
            }
        }
        public string FilterStatus
        {
            get
            {
                return filterStatus;
            }
            set
            {
                if (value != filterStatus)
                {
                    filterStatus = value;
                    machineView.Refresh();
                    OnPropertyChanged("Filter");
                }
            }
        }

        public IList<MachineModel> MachineList
        {
            get { return _MachineList; }
        }

        #endregion Properties

        #region Commands
        public ICommand DeleteCommand { get; set; }
        public ICommand OpenEditPopupCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public ICommand AddNewCommand { get; set; }
        public ICommand OpenAddMachinePopupCommand { get; set; }

        
        #endregion Commands

        #region Constructor
        public MachineStatusesViewModel()
        {

            EditPopupIsVisible = false;
            AddPopupIsVisible = false;
            OpenEditPopupCommand = new RelayCommand(o => OpenEditPopup(o));
            DeleteCommand = new RelayCommand(o => DeleteMachine(o));
            UpdateCommand = new RelayCommand(o => Update());
            CancelCommand = new RelayCommand(o => Cancel());
            FilterCommand = new RelayCommand(o => Filter(o));
            AddNewCommand = new RelayCommand(o => AddMachine());
            OpenAddMachinePopupCommand = new RelayCommand(o => OpennAddMachinePopup());
            InitializeMachineList();
            
        }
        #endregion Cunstructor



        #region Methods

        private void InitializeMachineList()
        {
            _MachineList = new ObservableCollection<MachineModel>
        {
            new MachineModel { Name= "Machine Number 1", Description = "The descrition of machine 1", Status = "Offline", Note = "The Notes of Machine 1" },
            new MachineModel { Name= "Machine Number 2", Description = "The descrition of machine 2", Status = "Offline", Note = "The Notes of Machine 2" },
            new MachineModel { Name= "Machine Number 3", Description = "The descrition of machine 3", Status = "Idle", Note = "The Notes of Machine 3" },
            new MachineModel { Name= "Machine Number 4", Description = "The descrition of machine 4", Status = "Running", Note = "The Notes of Machine 4" },
            new MachineModel { Name= "Machine Number 5", Description = "The descrition of machine 5", Status = "Idle", Note = "The Notes of Machine 5" }
            };
            FilterStatus = null;
            machineView = CollectionViewSource.GetDefaultView(_MachineList);
            machineView.Filter = o => String.IsNullOrEmpty(FilterStatus) ? true : ((MachineModel)o).Status == FilterStatus;
            //machineView.Filter = o => String.IsNullOrEmpty(FilterStatus) ? true : ((MachineModel)o).Status.Contains(FilterStatus);
        }

        public async Task ShowMessageAndHide(string message)
        {
            NotificationMessage = message;
            await Task.Delay(5000);
            NotificationMessage = string.Empty;
        }

        private void DeleteMachine(object sender)
        {
            MachineModel machine = sender as MachineModel;
            if(machine != null )
            {
                _MachineList.Remove(machine);
            }
        }

        private void AddMachine()
        {
            ErrorMessage = string.Empty;
            if (NewMachineModel != null)
            {
                if (string.IsNullOrEmpty(NewMachineModel.Name))
                    ErrorMessage = "The machine name cannot be Empty. ";
                else if(_MachineList.FirstOrDefault(x=>x.Name == newMchineModel.Name) != null)
                    ErrorMessage = "This machine name already exist. ";
                if (!(NewMachineModel.Status == "Idle" || NewMachineModel.Status == "Running" || NewMachineModel.Status == "Offline"))
                    ErrorMessage += "The status is not valid. the options for status are: Running, Offlide and Idle";
                if(ErrorMessage == string.Empty)
                {
                    _MachineList.Add(NewMachineModel);
                    AddPopupIsVisible = false;
                    ShowMessageAndHide("The Machine: " + NewMachineModel.Name + " successfully added.");
                }
            }
            
        }

        private void OpennAddMachinePopup()
        {
            NewMachineModel = new MachineModel();
            AddPopupIsVisible = true;
        }

        private void Filter(object sender)
        {
            switch (sender.ToString())
            {
                case "Offline":
                    FilterStatus = "Offline";
                    break;
                case "Idle":
                    FilterStatus = "Idle";
                    break;
                case "All":
                    FilterStatus = null;
                    break;
                case "Running":
                    FilterStatus = "Running";
                    break;
                default:
                    break;
            }
        }
        
       
        private void OpenEditPopup(object sender)
        {
            
            MachineModel machine = sender as MachineModel;
            if (machine != null)
            {
                SelectedMchineModel = new MachineModel(); 
                SelectedMchineModel.Name = machine.Name;
                SelectedMchineModel.Description = machine.Description;
                SelectedMchineModel.Status = machine.Status;
                SelectedMchineModel.Note = machine.Note;
                EditPopupIsVisible = true;
            }
        }

        private void Update()
        {
            ErrorMessage = string.Empty;
            if (selectedMchineModel != null)
            {
                if (!(selectedMchineModel.Status == "Idle" || selectedMchineModel.Status == "Running" || selectedMchineModel.Status == "Offline"))
                    ErrorMessage = "The status is not valid. the options for status are: Running, Offlide and Idle ";
                else
                {
                    MachineModel machineToUpdate = _MachineList.FirstOrDefault(x => x.Name == selectedMchineModel.Name);
                    machineToUpdate.Description = selectedMchineModel.Description;
                    machineToUpdate.Status = selectedMchineModel.Status;
                    machineToUpdate.Note = selectedMchineModel.Note;
                    machineView.Refresh();
                    OnPropertyChanged("Filter");
                    //SelectedMchineModel = machine;
                    //PopupIsVisible = true;
                    EditPopupIsVisible = false;
                    ShowMessageAndHide("The Machine: " + selectedMchineModel.Name + " successfully updated.");
                }
            }
            
        }

        private void Cancel()
        {
            newMchineModel = null;
            selectedMchineModel = null;
            EditPopupIsVisible = false;
            AddPopupIsVisible = false;
        }

        
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion Methods
    }


}
