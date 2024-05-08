
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace MachineStatusApplication.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MachineStatusesView : Window
    {
        public MachineStatusesView()
        {
            InitializeComponent();
        }
        //    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //    public static MainWindow Instance { get; private set; }
        //    private readonly NotificationManager _note = new NotificationManager();

        //    private readonly ListView _readersTotalList = new ListView();


        //    public MainWindow()
        //    {
        //        Log.Debug("Init dashboard page start");

        //        InitializeComponent();

        //        if (DashboardViewModel.connection == null)
        //        {
        //            DashboardViewModel.connection = new ConnectionProxy();
        //        }

        //        this.searchCamera.OnSearchButtonClicked += SearchCamera_OnSearchButtonClicked;
        //        this.searchCamera.OnSearchEnterKeyClicked += SearchCamera_OnSearchEnterKeyClicked;
        //        this.add_new.Click += addNew;
        //        this.add_new_popup.Visibility = Visibility.Collapsed;

        //        Instance = this;

        //        InitReadersList();


        //        //temporary camer_listview
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Reader c = new Reader();
        //            c.Name = "Dual stereoscopic camera Infrared" + i;
        //            c.IPAddress = "D123456789123123";
        //            c.Building = "" + i;
        //            c.Campus = i % 2 == 0 ? "Tel Aviv" : "Rison";
        //            c.FirmewareAddress = "D123456789123123";
        //            c.MACAddress = "D123456789123123";
        //            c.OperationMode = "D123456789123123";
        //            //c.Status = i % 3 == 0 ? "ERROR" : i % 3 == 1 ? "OK" : "Disconnected";
        //            c.StatusDescription = i % 3 == 0 ? "OK" : i % 3 == 1 ? "Disconnected" : "ERROR";
        //            camer_listview.Items.Add(c);
        //        }


        //    }

        //    private void SetCamerasListViewHeight()
        //    {
        //        if (camer_listview.Items.Count <= 10) return;

        //        var screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
        //        camer_listview.Height = screenHeight * 0.55;
        //    }


        //    #region Init Readers
        //    private void InitReadersList()
        //    {
        //        Log.Debug("Call Server hub function GetReadersList");
        //        DashboardViewModel.connection.HubTask<int>("GetReadersList");
        //    }
        //    public static void GetReadersListCompletedStatic(List<Reader> readers)
        //    {
        //        Instance.InitReaders(readers);
        //    }
        //    private void InitReaders(List<Reader> readers)
        //    {
        //        Log.Debug("Init readers on client page: fill camera lists");

        //        this.Dispatcher.Invoke(() =>
        //        {
        //            foreach (Reader reader in readers)
        //            {
        //                reader.StatusDescription = reader.StatusId == 0 ? "OK" : reader.StatusId == 1 ? "Disconnected" : "ERROR";
        //                reader.IsGoToConfigurationEnabled = reader.StatusId == 0 ? true : false;
        //                reader.SyncIconVisibility = reader.StatusId == 0  
        //                && (reader.OperationMode == "FACE_IDENTIFY" || reader.OperationMode == "FACE_VERIFY_WIEGAND" || reader.OperationMode == "FACE_IDENTIFY_WEB_SERVER") 
        //                ? Visibility.Visible : Visibility.Collapsed;
        //                reader.TotalCapacityOnUnit = reader.TotalUsersOnUnit.ToString() + "/" + reader.TotalLicensesOnUnit.ToString();

        //                camer_listview.Items.Add(reader);
        //            }

        //            foreach (Reader item in camer_listview.Items)
        //            {
        //                _readersTotalList.Items.Add(item);
        //            }

        //            UpdateCamerasCounter();
        //            SetCamerasListViewHeight();
        //        });
        //    }
        //    private void UpdateCamerasCounter()
        //    {
        //        Log.Debug("Update camera counters buttons");

        //        this.Dispatcher.Invoke(() =>
        //        {
        //            int connectedCamerasCounter = 0;
        //            int disconnectedCamerasCounter = 0;
        //            int errorCamerasCounter = 0;

        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                switch (camera.StatusDescription)
        //                {
        //                    case "OK":
        //                        connectedCamerasCounter++;
        //                        break;
        //                    case "Disconnected":
        //                        disconnectedCamerasCounter++;
        //                        break;
        //                    case "ERROR":
        //                        errorCamerasCounter++;
        //                        break;
        //                }
        //            }

        //            camerasCountConnected.Amount = connectedCamerasCounter.ToString();
        //            camerasCountDisonnected.Amount = disconnectedCamerasCounter.ToString();
        //            camerasCountError.Amount = errorCamerasCounter.ToString();
        //            camerasCountTotal.Amount = (connectedCamerasCounter + disconnectedCamerasCounter + errorCamerasCounter).ToString();
        //        });

        //    }
        //    #endregion Init Readers



        //    public static void UpdateReaderStatusDisplayStatic(Reader reader)
        //    {
        //        Instance.UpdateReaderStatusDisplay(reader);
        //    }
        //    private void UpdateReaderStatusDisplay(Reader readerChanged)
        //    {
        //        Log.Debug("Update reader statuses display");

        //        this.Dispatcher.Invoke(() =>
        //        {
        //            foreach (Reader camera in camer_listview.Items)
        //            {
        //                if (camera.ID != readerChanged.ID) continue;

        //                camera.StatusDescription = readerChanged.StatusId == 0 ? "OK" : readerChanged.StatusId == 1 ? "Disconnected" : "ERROR";
        //                camera.IsGoToConfigurationEnabled = readerChanged.StatusId == 0 ? true : false;
        //                camera.SyncIconVisibility = readerChanged.StatusId == 0 
        //                && (readerChanged.OperationMode == "FACE_IDENTIFY" || readerChanged.OperationMode == "FACE_VERIFY_WIEGAND" || readerChanged.OperationMode == "FACE_IDENTIFY_WEB_SERVER") 
        //                ? Visibility.Visible : Visibility.Collapsed;
        //                camera.TotalCapacityOnUnit = readerChanged.TotalUsersOnUnit.ToString() + "/" + readerChanged.TotalLicensesOnUnit.ToString();
        //                camera.StatusId = readerChanged.StatusId;
        //                camera.OperationMode = readerChanged.OperationMode;
        //                camera.FirmewareAddress = readerChanged.FirmewareAddress;
        //                camera.MACAddress = readerChanged.MACAddress;
        //                camera.Building = readerChanged.Building;
        //                camera.Campus = readerChanged.Campus;
        //            }
        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                if (camera.ID != readerChanged.ID) continue;

        //                camera.StatusDescription = readerChanged.StatusId == 0 ? "OK" : readerChanged.StatusId == 1 ? "Disconnected" : "ERROR";
        //                camera.IsGoToConfigurationEnabled = readerChanged.StatusId == 0 ? true : false;
        //                camera.SyncIconVisibility = readerChanged.StatusId == 0 
        //                && (readerChanged.OperationMode == "FACE_IDENTIFY" || readerChanged.OperationMode == "FACE_VERIFY_WIEGAND" || readerChanged.OperationMode == "FACE_IDENTIFY_WEB_SERVER") 
        //                ? Visibility.Visible : Visibility.Collapsed;
        //                camera.TotalCapacityOnUnit = readerChanged.TotalUsersOnUnit.ToString() + "/" + readerChanged.TotalLicensesOnUnit.ToString();
        //                camera.StatusId = readerChanged.StatusId;
        //                camera.OperationMode = readerChanged.OperationMode;
        //                camera.FirmewareAddress = readerChanged.FirmewareAddress;
        //                camera.MACAddress = readerChanged.MACAddress;
        //                camera.Building = readerChanged.Building;
        //                camera.Campus = readerChanged.Campus;
        //            }
        //        });
        //        UpdateCamerasCounter();
        //    }


        //    private void CamerasFilter_Click(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("Cameras filter clicked (statuses button)");

        //        var statusNameFiltering ="";
        //        switch (((Suricata.Controls.DashboardButtonImg)sender).Name)
        //        {
        //            case "camerasCountConnected":
        //                statusNameFiltering = "OK";
        //                break;
        //            case "camerasCountDisonnected":
        //                statusNameFiltering = "Disconnected";
        //                break;
        //            case "camerasCountError":
        //                statusNameFiltering = "ERROR";
        //                break;
        //            case "camerasCountTotal":
        //                statusNameFiltering = "ALL";
        //                break;
        //            default:
        //                break;
        //        }

        //        Log.Debug("Update readers list by selected status filter : " + statusNameFiltering);

        //        camer_listview.Items.Clear();
        //        if (statusNameFiltering == "ALL")
        //        {
        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                camer_listview.Items.Add(camera);
        //            }
        //        }
        //        else
        //        {
        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                if (camera.StatusDescription == statusNameFiltering)
        //                {
        //                    camer_listview.Items.Add(camera);
        //                }
        //            }
        //        }
        //    }


        //    #region Search Reader
        //    private void SearchCamera_OnSearchButtonClicked(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("Search Camera Clicked (search icon)");
        //        Controls.SearchTextBox searchTexBox = sender as Controls.SearchTextBox;
        //        if (searchTexBox == null) return;

        //        string searchText = searchTexBox.Text;
        //        Log.Debug("Search text input: " + searchText);

        //        if (string.IsNullOrWhiteSpace(searchText)) return;

        //        Log.Debug("Call Server hub function SearchReader");
        //        DashboardViewModel.connection.HubTask<int>("SearchReader", searchText.ToLower());
        //    }
        //    private void SearchCamera_OnSearchEnterKeyClicked(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("Search Camera Clicked (enter key)");
        //        Controls.SearchTextBox searchTexBox = sender as Controls.SearchTextBox;

        //        if (searchTexBox == null) return;

        //        var searchText = searchTexBox.Text;
        //        Log.Debug("Search text input: " + searchText);

        //        if (string.IsNullOrWhiteSpace(searchText)) return;

        //        Log.Debug("Call Server hub function SearchReader");
        //        DashboardViewModel.connection.HubTask<int>("SearchReader", searchText.ToLower());
        //    }
        //    public static void DisplaySearchResultsStatic(List<Reader> readers)
        //    {
        //        Instance.DisplaySearchResults(readers);
        //    }
        //    private void DisplaySearchResults(List<Reader> readers)
        //    {
        //        Log.Debug("Display search results on client page: refill camera lists");

        //        this.Dispatcher.Invoke(() =>
        //        {
        //            camer_listview.Items.Clear();

        //            foreach (Reader reader in readers)
        //            {
        //                var existingReaderItem = _readersTotalList.Items.Cast<Reader>().FirstOrDefault(x => x.Name == reader.Name);
        //                if (existingReaderItem != null)
        //                {
        //                    reader.StatusDescription = existingReaderItem.StatusDescription;
        //                    reader.MACAddress = existingReaderItem.MACAddress;
        //                    reader.FirmewareAddress = existingReaderItem.FirmewareAddress;
        //                    reader.OperationMode = existingReaderItem.OperationMode;
        //                    reader.IsGoToConfigurationEnabled = existingReaderItem.StatusId == 0 ? true : false;
        //                    reader.SyncIconVisibility = existingReaderItem.StatusId == 0 
        //                    && (existingReaderItem.OperationMode == "FACE_IDENTIFY" || existingReaderItem.OperationMode == "FACE_VERIFY_WIEGAND" || existingReaderItem.OperationMode == "FACE_IDENTIFY_WEB_SERVER") 
        //                    ? Visibility.Visible : Visibility.Collapsed;
        //                    reader.TotalCapacityOnUnit = existingReaderItem.TotalUsersOnUnit.ToString() + "/" + existingReaderItem.TotalLicensesOnUnit.ToString();
        //                }

        //                camer_listview.Items.Add(reader);
        //            }

        //            camerasCountTotal.IsChecked = false;
        //            camerasCountConnected.IsChecked = false;
        //            camerasCountError.IsChecked = false;
        //            camerasCountDisonnected.IsChecked = false;

        //            searchCamera.Text = "";
        //        });
        //    }
        //    #endregion Search Reader



        //    #region Delete Reader
        //    private void ReaderDelete_Click(object sender, MouseButtonEventArgs e)
        //    {
        //        try
        //        {
        //            Log.Debug("Reader delete button clicked");

        //            if (sender is Image b)
        //            {
        //                Reader selectedReader = b.DataContext as Reader;

        //                StackPanel popupContent = (StackPanel)DeleteCameraPopup.Content;

        //                TextBlock popupContentDeviceIdField = (TextBlock)popupContent.Children[1];
        //                if (selectedReader != null)
        //                {
        //                    popupContentDeviceIdField.Text = selectedReader.ID.ToString();

        //                    TextBlock popupContentDeviceNameField = (TextBlock)popupContent.Children[0];
        //                    popupContentDeviceNameField.Text =
        //                        "Are you sure you want to delete the " + selectedReader.Name + " device?";
        //                }
        //            }

        //            this.DeleteCameraPopup.Visibility = Visibility.Visible;
        //            Log.Debug("Display confirmation popup on delete request");
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Error("ReaderDelete_Click failed", ex);
        //        }
        //    }
        //    private void DeleteReader(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("DeleteReader action confirmed from popup");

        //        StackPanel popupContent = (StackPanel)DeleteCameraPopup.Content;
        //        TextBlock popupContentDeviceIdField = (TextBlock)popupContent.Children[1];
        //        long readerId = Convert.ToInt64(popupContentDeviceIdField.Text);

        //        Log.Debug("Call Server hub function DeleteReader with readerId: " + readerId);
        //        DashboardViewModel.connection.HubTask<int>("DeleteReader", readerId);
        //    }
        //    private void CancelDelete(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("DeleteReader action canceled from popup");
        //        this.DeleteCameraPopup.Visibility = Visibility.Collapsed;
        //    }
        //    public static void ReaderDeletedStatic(Reader readerDeleted)
        //    {
        //        Instance.ReaderDeleted(readerDeleted);
        //    }
        //    private void ReaderDeleted(Reader readerDeleted)
        //    {
        //        Log.Debug("Update readers list view on client page after reader deleted");

        //        this.Dispatcher.Invoke(() =>
        //        {
        //            foreach (Reader camera in camer_listview.Items)
        //            {
        //                if (camera.ID == readerDeleted.ID)
        //                {
        //                    camer_listview.Items.Remove(camera);
        //                    break;
        //                }
        //            }
        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                if (camera.ID == readerDeleted.ID)
        //                {
        //                    _readersTotalList.Items.Remove(camera);
        //                    break;
        //                }
        //            }
        //            ShowMessage(NotificationType.Success, "Reader deleted successfully");
        //            this.DeleteCameraPopup.Visibility = Visibility.Collapsed;
        //        });
        //        UpdateCamerasCounter();

        //    }
        //    #endregion Delete Reader



        //    #region Edit/Save Reader
        //    private void addNew(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("Add Reader button clicked");

        //        StackPanel popupContent = (StackPanel)add_new_popup.Content;

        //        string popupTitle = "Add New Device";

        //        Button b = sender as Button;
        //        if (b == null)
        //        {
        //            Log.Debug("Edit Device mode");

        //            Image imageCtrl = sender as Image;
        //            if (imageCtrl != null)
        //            {
        //                Reader selectedReader = imageCtrl.DataContext as Reader;
        //                popupTitle = "Edit Device";

        //                StackPanel popupContentDeviceIdChild = (StackPanel)popupContent.Children[1];
        //                TextBox popupContentDeviceIdField = (TextBox)popupContentDeviceIdChild.Children[1];
        //                popupContentDeviceIdField.Text = selectedReader.ID == 0 ? "" : selectedReader.ID.ToString();

        //                StackPanel popupContentIpAddressChild = (StackPanel)popupContent.Children[2];
        //                TextBox popupContentIpAddressField = (TextBox)popupContentIpAddressChild.Children[1];
        //                popupContentIpAddressField.Text = selectedReader.IPAddress == null ? "" : selectedReader.IPAddress;

        //                StackPanel popupContentDeviceNameChild = (StackPanel)popupContent.Children[3];
        //                TextBox popupContentDeviceNameField = (TextBox)popupContentDeviceNameChild.Children[1];
        //                popupContentDeviceNameField.Text = selectedReader.Name == null ? "" : selectedReader.Name;

        //                StackPanel popupContentDescriptionChild = (StackPanel)popupContent.Children[4];
        //                RichTextBox popupContentDescriptionField = (RichTextBox)popupContentDescriptionChild.Children[1];
        //                TextRange popupContentDescriptionFieldTextRange = new TextRange(popupContentDescriptionField.Document.ContentStart, popupContentDescriptionField.Document.ContentEnd);
        //                popupContentDescriptionFieldTextRange.Text = selectedReader.Remarks == null ? "" : selectedReader.Remarks;
        //            }
        //        }
        //        TextBlock popupContentTitleField = (TextBlock)popupContent.Children[0];
        //        popupContentTitleField.Text = popupTitle;


        //        this.add_new_popup.Visibility = Visibility.Visible;
        //        Log.Debug("Display reader details popup");
        //    }
        //    private void cancelAddNew(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("Add/Edit Reader action canceled from popup");

        //        StackPanel popupContent = (StackPanel)add_new_popup.Content;

        //        StackPanel popupContentDeviceIdChild = (StackPanel)popupContent.Children[1];
        //        TextBox popupContentDeviceIdField = (TextBox)popupContentDeviceIdChild.Children[1];
        //        popupContentDeviceIdField.Text = "";

        //        StackPanel popupContentIpAddressChild = (StackPanel)popupContent.Children[2];
        //        TextBox popupContentIpAddressField = (TextBox)popupContentIpAddressChild.Children[1];
        //        popupContentIpAddressField.Text = "";

        //        TextBlock popupContentIpAddressValidationMessage = (TextBlock)popupContentIpAddressChild.Children[2];
        //        popupContentIpAddressValidationMessage.Visibility = Visibility.Collapsed;

        //        StackPanel popupContentDeviceNameChild = (StackPanel)popupContent.Children[3];
        //        TextBox popupContentDeviceNameField = (TextBox)popupContentDeviceNameChild.Children[1];
        //        popupContentDeviceNameField.Text = "";

        //        StackPanel popupContentDescriptionChild = (StackPanel)popupContent.Children[4];
        //        RichTextBox popupContentDescriptionField = (RichTextBox)popupContentDescriptionChild.Children[1];
        //        TextRange popupContentDescriptionFieldTextRange = new TextRange(popupContentDescriptionField.Document.ContentStart, popupContentDescriptionField.Document.ContentEnd);
        //        popupContentDescriptionFieldTextRange.Text = "";

        //        this.add_new_popup.Visibility = Visibility.Collapsed;
        //    }
        //    private void SaveNewReader(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("Save Reader action confirmed from popup");

        //        StackPanel popupContent = (StackPanel)add_new_popup.Content;

        //        StackPanel popupContentDeviceIdChild = (StackPanel)popupContent.Children[1];
        //        TextBox popupContentDeviceIdField = (TextBox)popupContentDeviceIdChild.Children[1];
        //        string deviceId = popupContentDeviceIdField.Text;
        //        long id = deviceId == "" ? 0 : Convert.ToInt32(deviceId);

        //        StackPanel popupContentIpAddressChild = (StackPanel)popupContent.Children[2];
        //        TextBox popupContentIpAddressField = (TextBox)popupContentIpAddressChild.Children[1];
        //        string ipAddress = popupContentIpAddressField.Text;
        //        TextBlock popupContentIpAddressValidationMessage = (TextBlock)popupContentIpAddressChild.Children[2];

        //        StackPanel popupContentDeviceNameChild = (StackPanel)popupContent.Children[3];
        //        TextBox popupContentDeviceNameField = (TextBox)popupContentDeviceNameChild.Children[1];
        //        string deviceName = popupContentDeviceNameField.Text;

        //        StackPanel popupContentDescriptionChild = (StackPanel)popupContent.Children[4];
        //        RichTextBox popupContentDescriptionField = (RichTextBox)popupContentDescriptionChild.Children[1];
        //        TextRange popupContentDescriptionFieldTextRange = new TextRange(popupContentDescriptionField.Document.ContentStart, popupContentDescriptionField.Document.ContentEnd);
        //        string description = popupContentDescriptionFieldTextRange.Text.Trim();

        //        if (ValidateReaderData(ipAddress, id))
        //        {

        //            Reader device = new Reader
        //            {
        //                ID = id,
        //                IPAddress = ipAddress,
        //                Name = deviceName,
        //                Remarks = description
        //            };

        //            Log.Debug("Call Server hub function SaveReader with readerId: " + device.ID);
        //            DashboardViewModel.connection.HubTask<int>("SaveReader", device);
        //            this.add_new_popup.Visibility = Visibility.Collapsed;

        //            popupContentIpAddressField.Text = "";
        //            popupContentDeviceIdField.Text = "";
        //            popupContentDeviceNameField.Text = "";
        //            popupContentDescriptionFieldTextRange.Text = "";

        //            popupContentIpAddressValidationMessage.Text = "";
        //        }
        //        else
        //        {
        //            Log.Debug("Ip Address is not valid: " + ipAddress + ". Abort save reader");
        //        }
        //    }
        //    private bool ValidateReaderData(string ipAddress, long id)
        //    {
        //        bool isValid = true;

        //        StackPanel popupContent = (StackPanel)add_new_popup.Content;
        //        StackPanel popupContentIpAddressChild = (StackPanel)popupContent.Children[2];
        //        TextBlock popupContentIpAddressValidationMessage = (TextBlock)popupContentIpAddressChild.Children[2];

        //        if (!Validators.ValidateIPv4(ipAddress))
        //        {
        //            popupContentIpAddressValidationMessage.Text = "Invalid IP Address";
        //            popupContentIpAddressValidationMessage.Visibility = Visibility.Visible;

        //            isValid = false;
        //        }
        //        else
        //        {
        //            foreach (Reader camera in camer_listview.Items)
        //            {
        //                if (camera.IPAddress == ipAddress && camera.ID != id)
        //                {
        //                    popupContentIpAddressValidationMessage.Text = "Device with IP Address already exists";
        //                    popupContentIpAddressValidationMessage.Visibility = Visibility.Visible;

        //                    isValid = false;
        //                    break;
        //                }
        //            }
        //        }

        //        return isValid;
        //    }
        //    private void ReaderEdit_Click(object sender, MouseButtonEventArgs e)
        //    {
        //        Log.Debug("Edit Reader button clicked. Forward to Add Reader method");
        //        addNew(sender, e);
        //    }
        //    public static void ReaderSavedStatic(Reader readerSaved, string status)
        //    {
        //        Instance.ReaderSaved(readerSaved, status);
        //    }
        //    private void ReaderSaved(Reader readerSaved, string status)
        //    {
        //        Log.Debug("Update readers list view on client page after reader saved");

        //        this.Dispatcher.Invoke(() =>
        //        {
        //            if (status == "Added")
        //            {
        //                readerSaved.StatusDescription = readerSaved.StatusId == 0 ? "OK" : readerSaved.StatusId == 1 ? "Disconnected" : "ERROR";
        //                camer_listview.Items.Add(readerSaved);
        //                _readersTotalList.Items.Add(readerSaved);

        //                ShowMessage(NotificationType.Success, "Reader Saved successfully");
        //            }
        //            else
        //            {
        //                int index = 0;


        //                foreach (Reader camera in camer_listview.Items)
        //                {
        //                    if (camera.ID == readerSaved.ID)
        //                    {
        //                        camer_listview.Items.RemoveAt(index);
        //                        //readerSaved.StatusId = camera.StatusId;
        //                        readerSaved.StatusDescription = readerSaved.StatusId == 0 ? "OK" : readerSaved.StatusId == 1 ? "Disconnected" : "ERROR";
        //                        //readerSaved.MACAddress = camera.MACAddress;
        //                        //readerSaved.FirmewareAddress = camera.FirmewareAddress;
        //                        //readerSaved.OperationMode = camera.OperationMode;
        //                        camer_listview.Items.Insert(index, readerSaved);
        //                        break;
        //                    }
        //                    index++;
        //                }

        //                index = 0;
        //                foreach (Reader camera in _readersTotalList.Items)
        //                {
        //                    if (camera.ID == readerSaved.ID)
        //                    {
        //                        _readersTotalList.Items.RemoveAt(index);
        //                        //readerSaved.StatusId = camera.StatusId;
        //                        readerSaved.StatusDescription = readerSaved.StatusId == 0 ? "OK" : readerSaved.StatusId == 1 ? "Disconnected" : "ERROR";
        //                        //readerSaved.MACAddress = camera.MACAddress;
        //                        //readerSaved.FirmewareAddress = camera.FirmewareAddress;
        //                        //readerSaved.OperationMode = camera.OperationMode;
        //                        _readersTotalList.Items.Insert(index, readerSaved);
        //                        break;
        //                    }
        //                    index++;
        //                }
        //                ShowMessage(NotificationType.Success, "Reader Updated successfully");
        //            }
        //        });
        //        UpdateCamerasCounter();

        //    }
        //    #endregion Edit/Save Reader



        //    public void ReaderSync_Click(object sender, MouseButtonEventArgs e)
        //    {
        //        Log.Debug("Sync Reader button clicked");

        //        GridView gridView = camer_listview.View as GridView;
        //        DataTemplate dataTemplate = gridView.Columns[6].CellTemplate;

        //        (dataTemplate.LoadContent() as SuricataClient.Controls.SyncButtonControl).IsLoading = true;

        //        //SuricataClient.Controls.SyncButtonControl o = dataTemplate.LoadContent() as SuricataClient.Controls.SyncButtonControl;
        //        //o.IsLoading = true;
        //        //o.Diameter = 100;



        //        if (!(sender is SuricataClient.Controls.SyncButtonControl syncBtnCtrl)) return;

        //        SyncButtonControl syncButtonControl = sender as SyncButtonControl;
        //        syncButtonControl.IsLoading = true;

        //        Reader selectedReader = syncBtnCtrl.DataContext as Reader;

        //        Log.Debug("Call Server hub function SyncPersonsDBWithSingleDevice with readerId: " + selectedReader.ID);
        //        DashboardViewModel.connection.HubTask<int>("SyncPersonsDBWithSingleDevice", selectedReader.ID);
        //    }

        //    public static void PersonsDBSyncedWithSingleDeviceStatic(int readerId, int usersOnUnitDBCount)
        //    {
        //        Instance.PersonsDBSyncedWithSingleDevice(readerId, usersOnUnitDBCount);
        //    }
        //    private void PersonsDBSyncedWithSingleDevice(int readerId, int usersOnUnitDBCount)
        //    {
        //        this.Dispatcher.Invoke(() =>
        //        {
        //            foreach (Reader camera in camer_listview.Items)
        //            {
        //                if (camera.ID != readerId) continue;

        //                string totalLicensesOnUnit = camera.TotalCapacityOnUnit.Split('/')[1];
        //                camera.TotalCapacityOnUnit = usersOnUnitDBCount.ToString() + "/" + totalLicensesOnUnit;

        //            }
        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                if (camera.ID != readerId) continue;

        //                string totalLicensesOnUnit = camera.TotalCapacityOnUnit.Split('/')[1];
        //                camera.TotalCapacityOnUnit = usersOnUnitDBCount.ToString() + "/" + totalLicensesOnUnit;
        //            }
        //        });
        //    }

        //    public static void SetSystemModeCompletedStatic(int readerId, string operationMode)
        //    {
        //        Instance.SetSystemModeCompleted(readerId, operationMode);
        //    }
        //    private void SetSystemModeCompleted(int readerId, string operationMode)
        //    {
        //        this.Dispatcher.Invoke(() =>
        //        {
        //            foreach (Reader camera in camer_listview.Items)
        //            {
        //                if (camera.ID != readerId) continue;

        //                camera.OperationMode = operationMode;

        //            }
        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                if (camera.ID != readerId) continue;

        //                camera.OperationMode = operationMode;
        //            }
        //        });
        //    }

        //    public static void UpdateFirmwareCompletedStatic(int readerId, string versionOS)
        //    {
        //        Instance.UpdateFirmwareCompleted(readerId, versionOS);
        //    }

        //    public void UpdateFirmwareCompleted(int readerId, string versionOS)
        //    {
        //        this.Dispatcher.Invoke(() =>
        //        {
        //            foreach (Reader camera in camer_listview.Items)
        //            {
        //                if (camera.ID != readerId) continue;

        //                camera.FirmewareAddress = versionOS;

        //            }
        //            foreach (Reader camera in _readersTotalList.Items)
        //            {
        //                if (camera.ID != readerId) continue;

        //                camera.FirmewareAddress = versionOS;
        //            }
        //        });
        //    }

        //    private void ReaderConfiguration_Click(object sender, RoutedEventArgs e)
        //    {
        //        Log.Debug("GoToConfiguration button clicked");

        //        if (!(sender is Image imageCtrl)) return;

        //        Reader selectedReader = imageCtrl.DataContext as Reader;

        //        Log.Debug("Forward to configuration page");
        //        MenuWindow.GoToConfigurationStatic(selectedReader);
        //    }
        //    private void OnDevice_Click(object sender, RoutedEventArgs e)
        //    {
        //        if (!(sender is TextBlock textBlockCtrl)) return;

        //        Reader selectedReader = textBlockCtrl.DataContext as Reader;

        //        MenuWindow.GoToConfigurationStatic(selectedReader);
        //    }

        //    #region Sort Column Data
        //    GridViewColumnHeader _lastHeaderClicked = null;
        //    ListSortDirection _lastDirection = ListSortDirection.Ascending;
        //    void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        //    {
        //        var headerClicked = e.OriginalSource as GridViewColumnHeader;
        //        if (headerClicked == null) return;

        //        var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
        //        var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

        //        if (sortBy == null) return;

        //        if (headerClicked.Role == GridViewColumnHeaderRole.Padding) return;

        //        ListSortDirection direction;
        //        if (headerClicked != _lastHeaderClicked)
        //        {
        //            direction = ListSortDirection.Ascending;
        //        }
        //        else
        //        {
        //            direction = _lastDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
        //        }

        //        Sort(sortBy, direction);

        //        if (direction == ListSortDirection.Ascending)
        //        {
        //            headerClicked.Column.HeaderTemplate = this.FindResource("HeaderTemplateArrowUp") as DataTemplate;
        //        }
        //        else
        //        {
        //            headerClicked.Column.HeaderTemplate = this.FindResource("HeaderTemplateArrowDown") as DataTemplate;
        //        }
        //        if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
        //        {
        //            _lastHeaderClicked.Column.HeaderTemplate = null;
        //        }
        //        _lastHeaderClicked = headerClicked;
        //        _lastDirection = direction;
        //    }
        //    private void Sort(string sortBy, ListSortDirection direction)
        //    {
        //        sortBy = SortHeaderAdapter(sortBy);
        //        ICollectionView dataView =
        //          CollectionViewSource.GetDefaultView(camer_listview.Items);
        //        dataView.SortDescriptions.Clear();
        //        SortDescription sd = new SortDescription(sortBy, direction);
        //        dataView.SortDescriptions.Add(sd);
        //        dataView.Refresh();
        //    }
        //    private string SortHeaderAdapter(string sortBy)
        //    {
        //        switch (sortBy)
        //        {
        //            case "Device Name":
        //                return "Name";
        //            case "IP Address":
        //                return "IPAddress";
        //            default:
        //                return sortBy;
        //        }
        //    }
        //    #endregion Sort Column Data


        //    #region Status Message
        //    public static void DisplayMessageStatic(string message, string messageType)
        //    {
        //        Instance.DisplayMessage(message, messageType);
        //    }
        //    private void DisplayMessage(string message, string messageType)
        //    {
        //        try
        //        {
        //            Enum.TryParse(messageType, out NotificationType msgType);

        //            this.Dispatcher.Invoke(() =>
        //            {
        //                ShowMessage(msgType, message);
        //            });
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Error("DisplayMessage failed", ex);
        //        }
        //    }
        //    private void ShowMessage(NotificationType type, string text)
        //    {
        //        string titleTxt = "";
        //        switch (type)
        //        {
        //            case NotificationType.Success:
        //                titleTxt = "Success";
        //                break;
        //            case NotificationType.Warning:
        //                titleTxt = "Warning";
        //                break;
        //            case NotificationType.Error:
        //                titleTxt = "Error";
        //                break;
        //            case NotificationType.Information:
        //                titleTxt = "Attention";
        //                break;
        //        }
        //        try
        //        {
        //            _note.Show(new NotificationContent { Title = titleTxt, Message = text, Type = type }, areaName: "WindowArea");
        //        }
        //        catch (Exception ex)
        //        {
        //            var r = ex;
        //        }
        //    }
        //    #endregion Status Message
        //}


    }
}
