//For deployment jack and Joyce@2011 is the password
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using CsvHelper;
using System.Diagnostics;

using OfficeOpenXml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Excel.Application excelApp;
        StreamWriter writer ;
        CsvWriter csv ;
        List<AddressData> records;
        string sortedFilename;
        string strPath;
        int totalNameCount;
        int foundFrancophone;

        DirectoryInfo[] allFolders;
        int currentFolder;


        public Form1()
        {
            InitializeComponent();


        }
        const string AlreadySearchedFolder = "FilesAlreadySearched";

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GoodConnection())
            {
                MessageBox.Show("Unable to pricess search to Forebears.io with your criteria. Try another riteria");
            }


            richTextBox1.Clear();

            if (FrancophoneSearch.Properties.Settings.Default.DropOffFolder == "")
            {
                MessageBox.Show("Drop off folder is empty. Set your drop off folder first");
                return;
            }

            // Make a reference to a directory.
            DirectoryInfo mainFolder = new DirectoryInfo(FrancophoneSearch.Properties.Settings.Default.DropOffFolder);

            // Get a reference to each directory in that directory.
            //DirectoryInfo[] allFolders = mainFolder.GetDirectories();
            currentFolder = 0;
            allFolders = mainFolder.GetDirectories();

            if (allFolders.Length == 0 || (allFolders.Length == 1 && allFolders[0].Name == AlreadySearchedFolder))
            {
                //loopThroughExcellFiles(mainFolder);
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync(mainFolder);
                }
                else
                { 
                    progressLabel.Text = "Busy processing; please wait!"; 
                }
                
            }
            else
            foreach (System.IO.DirectoryInfo folder in allFolders)
            {
                    //loopThroughExcellFiles(folder);
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync(folder);
                    }
                }

           

          

                richTextBox1.Clear();

           

            string name = "Mitterrand";
            string country = callForbears(name);
            name = "";

        }

        private bool GoodConnection()
        {
            string country = "";

            if (radioFirstname.Checked == true) country = callForbears("Kokouvi");

            if (radioLastname.Checked == true) country = callForbears("Dossou");

            if (radioFirstLast.Checked == true) country = callForbears("Kokouvi", "Dossou");

            return (country != null);
        }

        private string callForbears(string name, string name2 = "")
        {
            List<String> listOfFrenchCountries = new List<String>();
            listOfFrenchCountries = frenchCountries();

            string requestUrl = "";

            const string lastnameSearchUrl = "https://forebears.io/surnames?q={0}";
            const string firstnameSearchUrl = "https://forebears.io/forenames?q={0}";
            //const string firstLastSearchUrl = "https://forebears.io/api/v1/nat?key=b19ba9aaa790b1ff0a4538bf71fb716c&fn={0}&sn={1}";
            const string firstLastSearchUrl = "https://ono.4b.rs/v1/nat?key=b19ba9aaa790b1ff0a4538bf71fb716c&fn={0}&sn={1}";

            const string strTotalMatch = "100% Match";
            const string strPrevalent = "<h6 class=\"detail-title\">Prevalent</h6>";
            const string strBeginQuote = "<";
            const string strEndQuote = ">";

            bool containsSearchResult = false;

           // string name = "Mitterrand";

            //String[] spearator = { "s, ", "For" };
            String[] spearator = { "div class=", "detail-value", " title=", "\"", "\\" };

            int intBeginCountryDiv;
            //int intBeginCountryStr;
            int intEndCountryStr;
            int indexOf100Match = 0;

            string countryString;

            //WebRequest request = WebRequest.Create("https://forebears.io/surnames?q=mitterrand");

                     
            requestUrl = (radioFirstname.Checked == true) ? firstnameSearchUrl: lastnameSearchUrl;

            if (radioFirstname.Checked == true) requestUrl = firstnameSearchUrl;

            if (radioLastname.Checked == true) requestUrl = lastnameSearchUrl;

            if (radioFirstLast.Checked == true) requestUrl = firstLastSearchUrl;

            WebRequest request = null;

            WebResponse response = null;

            try
            {
                request = WebRequest.Create(string.Format(requestUrl, name, name2));

                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.  
                 response = request.GetResponse();
            }
            catch (Exception ex)
            {
              MessageBox.Show("Unable to connect to forebears.io - " +  ex);
                
                return null;
            }          

            //System.Windows.Forms.Application.Exit();

            // Display the status.  
            // Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();

               
                if (radioFirstLast.Checked == true)
                {
                    ResponseObject ResponseObject = JsonConvert.DeserializeObject<ResponseObject>(responseFromServer);
                    countryString = (ResponseObject.countries == null) ? null: ResponseObject.countries[0].jurisdiction;
                }
                else
                {
                    containsSearchResult = responseFromServer.Contains(strTotalMatch);
                                                                    
                    if (!containsSearchResult) return null;

                    indexOf100Match = responseFromServer.IndexOf(strTotalMatch);
                    int test = responseFromServer.IndexOf(strPrevalent, indexOf100Match); // TODO Remove after 
                    //intBeginCountryDiv = responseFromServer.IndexOf(strPrevalent, indexOf100Match) + strPrevalent.Length + 5;
                    intBeginCountryDiv = responseFromServer.IndexOf(strPrevalent, indexOf100Match) + strPrevalent.Length + 1;
                   // intBeginCountryStr = responseFromServer.IndexOf(strBeginQuote, intBeginCountryDiv) + strBeginQuote.Length;
                    intEndCountryStr = responseFromServer.IndexOf(strEndQuote, intBeginCountryDiv) + strBeginQuote.Length;

                    //countryString = responseFromServer.Substring(intBeginCountryStr, intEndCountryStr - intBeginCountryStr - 1);
                    countryString = responseFromServer.Substring(intBeginCountryDiv, intEndCountryStr - intBeginCountryDiv - 1);
                    //String[] separator = new char[] { @"\" }; //= { "\\\"" };
                    String[] strlist = countryString.Split('"');

                    if (strlist == null || strlist.Length == 0) return null;

                    countryString = strlist[3];
                }

                // Display the content.  
               // Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();

            if (listOfFrenchCountries.Contains(countryString))
            {
                return countryString;
            }

            return null;
        }


        public string callTruePeopleSearchByAddress(string address, string city, string state = "")
        {

            string requestUrl = "https://www.fastpeoplesearch.com/address/{0}_{1}-{2}";
                               //https://www.fastpeoplesearch.com/address/5037-luna-ct_middletown-oh

            const string CurrentHomeAddress = "<h3>Current Home Address:</h3><br>"; //35
            const string AKA = "<strong>AKA:</strong>";
            const string prefixPhoneStr = "Search people with phone number ";

            int intBeginStringPhone = 0;
            int intEndStringPhone = 0;
            int intCheck;
            string phoneSection = "";
            string phoneNumber = "";
            state = state.ToLower();
            address = address.ToLower();
            string address_ = address.Replace(' ', '-');
            int retries = 0;


            WebRequest request = null;

            WebResponse response = null;

            try
            {

                retries++;
                request = WebRequest.Create(string.Format(requestUrl, address_, city, state));

                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.  
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                return "";
            }


            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();

                intBeginStringPhone = responseFromServer.IndexOf(CurrentHomeAddress, 1);

                if (intBeginStringPhone < 0) return null;

                intEndStringPhone = responseFromServer.IndexOf(AKA, intBeginStringPhone);
                if (intEndStringPhone < 0) return null;

                phoneSection = responseFromServer.Substring(intBeginStringPhone, intEndStringPhone - intBeginStringPhone);

                //checking to make sure its the same zip code
                intCheck = phoneSection.IndexOf(address_, 1);
                if (intCheck < 0) return null;

                //checking the firstname
              //  intCheck = phoneSection.IndexOf(city, 1);
             //   if (intCheck < 0) return null;

                //checking the lastname
                intCheck = phoneSection.IndexOf(state, 1);
                if (intCheck < 0) return null;

                //checking the phone number exist
                intCheck = phoneSection.IndexOf(prefixPhoneStr, 1);
                if (intCheck < 0) return null;

                //Extracting phone number
                phoneNumber = phoneSection.Substring(intCheck + prefixPhoneStr.Length, 14);




                //second phone number
                intBeginStringPhone = responseFromServer.IndexOf(CurrentHomeAddress, intEndStringPhone);

                if (intBeginStringPhone < 0) return phoneNumber;

                intEndStringPhone = responseFromServer.IndexOf(AKA, intBeginStringPhone);
                if (intEndStringPhone < 0) return phoneNumber;

                phoneSection = responseFromServer.Substring(intBeginStringPhone, intEndStringPhone - intBeginStringPhone);

                //checking to make sure its the same zip code
                intCheck = phoneSection.IndexOf(address_, 1);
                if (intCheck < 0) return phoneNumber;

                //checking the lastname
                intCheck = phoneSection.IndexOf(state, 1);
                if (intCheck < 0) return phoneNumber;

                //checking the phone number exist
                intCheck = phoneSection.IndexOf(prefixPhoneStr, 1);
                if (intCheck < 0) return phoneNumber;

                //Extracting phone number
                phoneNumber = phoneNumber + "\nPhone number 2 is "+phoneSection.Substring(intCheck + prefixPhoneStr.Length, 14);

            }

            // Close the response.  
            response.Close();

            return phoneNumber;

        }

        public string callTruePeopleSearch(string firstname, string lastname, string zipCode = "")
        {
            if (string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname) && string.IsNullOrEmpty(zipCode))
            {
                return string.Empty;
            }

            string requestUrl = "https://www.fastpeoplesearch.com/name/{0}_{1}";

            const string CurrentHomeAddress = "<h3>Current Home Address:</h3><br>"; //35
            const string AKA = "<strong>AKA:</strong>";
            const string prefixPhoneStr = "Search people with phone number ";

            int intBeginStringPhone = 0;
            int intEndStringPhone = 0;
            int intCheck;
            string phoneSection = "";
            string phoneNumber = "";
            firstname = char.ToUpper(firstname[0]) + firstname.Substring(1);
            lastname = char.ToUpper(lastname[0]) + lastname.Substring(1);
            string name = firstname + "-" + lastname.Replace('-','~');
            int retries = 0;

            WebRequest request = null;

            WebResponse response = null;

            try
            {

                retries++;
                request = WebRequest.Create(string.Format(requestUrl, name, zipCode));

                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.  
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Unable to connect to forebears.io - " + ex);

                //  if (retries == 4)
                // {
                //response.Close();
               // Task.Delay(7500).Wait();
                return "";
               // }
              //  else
               // {
                  
                //    response = request.GetResponse();
              //  }

               
            }


            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();

                intBeginStringPhone = responseFromServer.IndexOf(CurrentHomeAddress, 1);

                if (intBeginStringPhone < 0) return null;

                intEndStringPhone = responseFromServer.IndexOf(AKA, intBeginStringPhone);
                if (intEndStringPhone < 0) return null;

                phoneSection = responseFromServer.Substring(intBeginStringPhone, intEndStringPhone- intBeginStringPhone);

                //checking to make sure its the same zip code
                intCheck = phoneSection.IndexOf(zipCode, 1);
                if (intCheck < 0) return null;

                //checking the firstname
                intCheck = phoneSection.IndexOf(firstname, 1);
                if (intCheck < 0) return null;

                //checking the lastname
                intCheck = phoneSection.IndexOf(lastname, 1);
                if (intCheck < 0) return null;

                //checking the phone number exist
                intCheck = phoneSection.IndexOf(prefixPhoneStr, 1);
                if (intCheck < 0) return null;

                //Extracting phone number
                phoneNumber = phoneSection.Substring(intCheck+ prefixPhoneStr.Length, 14);               

            }

            // Close the response.  
            response.Close();

            return phoneNumber;
          
        }

        private List<String> frenchCountries()
        {
            var listOfFrenchCountries = new List<String>() ;

            listOfFrenchCountries.Add("DR Congo");
            listOfFrenchCountries.Add("France");
            listOfFrenchCountries.Add("Canada");
            listOfFrenchCountries.Add("Madagascar");
            listOfFrenchCountries.Add("Cameroon");
            listOfFrenchCountries.Add("Ivory Coast");
            listOfFrenchCountries.Add("Niger");
            listOfFrenchCountries.Add("Burkina Faso");
            listOfFrenchCountries.Add("Mali");
            listOfFrenchCountries.Add("Senegal");
            listOfFrenchCountries.Add("Chad");
            listOfFrenchCountries.Add("Guinea");
            listOfFrenchCountries.Add("Rwanda");
            listOfFrenchCountries.Add("Belgium");
            listOfFrenchCountries.Add("Burundi");
            listOfFrenchCountries.Add("Benin");
            listOfFrenchCountries.Add("Haiti");
            listOfFrenchCountries.Add("Switzerland");
            listOfFrenchCountries.Add("Togo");
            listOfFrenchCountries.Add("Central African Republic");
            listOfFrenchCountries.Add("Congo");
            listOfFrenchCountries.Add("Gabon");
            listOfFrenchCountries.Add("Comoros");
            listOfFrenchCountries.Add("Equatorial Guinea");
            listOfFrenchCountries.Add("Djibouti");
            listOfFrenchCountries.Add("Luxembourg");
            listOfFrenchCountries.Add("Vanuatu");
            listOfFrenchCountries.Add("Seychelles");
            listOfFrenchCountries.Add("Monaco");
            listOfFrenchCountries.Add("French Polynesia");
            listOfFrenchCountries.Add("New Caledonia");
            listOfFrenchCountries.Add("Aosta Valley");
            listOfFrenchCountries.Add("Jersey");
            listOfFrenchCountries.Add("Saint-Martin");
            listOfFrenchCountries.Add("Wallis and Futuna");
            listOfFrenchCountries.Add("Saint-Barthélemy");
            listOfFrenchCountries.Add("Saint-Pierre and Miquelon");
            listOfFrenchCountries.Add("Clipperton");
            listOfFrenchCountries.Add("French Southern and Antarctic Lands");

            return listOfFrenchCountries;
        }

        public void loopThroughExcellFiles(System.IO.DirectoryInfo folderToSearch)
        {
            const string ConstLastName = "Last Name";
            const string ConstPhoneNA = "Not Available";
            //const string AlreadySearchedFolder = "FilesAlreadySearched";

            string alreadySearchedFolderPath;

            string Country ="";
            string LastName = "";
            string FirstName = "";
            string Address = "";
            string HouseNumber = "";
            string PreDirectional = "";
            string Street = "";
            string StreetSuffix = "";
            string PostDirectional = "";
            string ApartmentNumber = "";
            string City = "";
            string State = "";
            string ZIPCode = "";
            string CountyName = "";
            string PhoneNumber = "";
            string PreviousAddress = "";
            string PreviousLastName = "";
            string PreviousFirstName = "";
            string PreviousApartment = "";
            string NextStreet = "";
            string NextAddress = "";
            string NextLastName = "";
            string NextFirstName = "";
            string NextApartment = "";
            string NextHouseNumber = "";
            string NextStreetSuffix = "";
            int z = 2;
            int fCount = 0;

           if (folderToSearch.Name == AlreadySearchedFolder)
            {
                return;
            }

           string strPath = Path.GetFullPath(Directory.GetCurrentDirectory());
           strPath = folderToSearch.FullName;


            //Create a FilesAlreadySearched directory
            alreadySearchedFolderPath = strPath + "\\" + AlreadySearchedFolder;
            System.IO.Directory.CreateDirectory(alreadySearchedFolderPath);

            string[] strFiles = Directory.GetFiles(strPath);
            Excel.Application excel = null;
            string OriginalSortedFilename = "sortedFile.csv";
            string sortedFilename = string.Empty;

            int t = 0;

            excel = new Excel.Application();

            var headerRow = new List<string[]>()
            {
            new string[] 
                {
                    "Country",
                    "Last Name",
                    "First Name",
                    "Address",
                    "House Number",
                    "Pre -directional",
                    "Street",
                    "Street Suffix",
                    "Post -directional",
                    "Apartment Number",
                    "City",
                    "State",
                    "ZIP Code",
                    "County Name",
                    "Phone Number"
                }
            };
             
            sortedFilename = OriginalSortedFilename.Replace(".", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-tt") + ".");

             writer = new StreamWriter(strPath + "\\" + sortedFilename);
             csv = new CsvWriter(writer);
             records = new List<AddressData> ();

            //var writer = new StreamWriter(strPath + "\\" + sortedFilename);
            //var csv = new CsvWriter(writer);
            //var records = new List<AddressData>();

            int i = 1;

            foreach (string strFile in strFiles)
            {
                
                if ((strFile.Contains(OriginalSortedFilename.Replace(".csv",""))) || !((strFile.Contains("csv")) || (strFile.Contains("xls"))))
                {
                    continue;
                }

                if (i == 1)
                {
                    fCount = Directory.GetFiles(FrancophoneSearch.Properties.Settings.Default.DropOffFolder, "*.csv", SearchOption.AllDirectories).Length + Directory.GetFiles(FrancophoneSearch.Properties.Settings.Default.DropOffFolder, "*.xls", SearchOption.AllDirectories).Length;
                }

                totalFiles.Text = i.ToString() + " / " + fCount.ToString() + " Files";
                i = i + 1;

                richTextBox1.Text += Environment.NewLine +"Start searching file " + Path.GetFileName(strFile);
                progressLabel.Text = "Start searching file " + Path.GetFileName(strFile);

               // Excel.Application excelApp = new Excel.Application();
                excelApp = new Excel.Application();
                Excel.Workbook workBook = excelApp.Workbooks.Open(strFile);
                Excel.Worksheet sheet = null;

                sheet = workBook.Worksheets[1];

                progressBar1.Maximum = sheet.UsedRange.Rows.Count;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                //progressBar1.t

                foreach (Excel.Range row in sheet.UsedRange.Rows)
                {
                    t = t + 1;
                    progressBar1.PerformStep();

                    LastName = Convert.ToString(sheet.Cells[row.Row, 1].Value2);
                    if (LastName == ConstLastName) continue;  //First row are headcer values
                    FirstName = Convert.ToString(sheet.Cells[row.Row, 2].Value2);
                    HouseNumber = Convert.ToString(sheet.Cells[row.Row, 3].Value2);
                    PreDirectional = Convert.ToString(sheet.Cells[row.Row, 4].Value2);
                    Street = Convert.ToString(sheet.Cells[row.Row, 5].Value2);
                    StreetSuffix = Convert.ToString(sheet.Cells[row.Row, 6].Value2);
                    PostDirectional = Convert.ToString(sheet.Cells[row.Row, 7].Value2);
                    ApartmentNumber = Convert.ToString(sheet.Cells[row.Row, 8].Value2);
                    City = Convert.ToString(sheet.Cells[row.Row, 9].Value2);
                    State = Convert.ToString(sheet.Cells[row.Row, 10].Value2);
                    ZIPCode = Convert.ToString(sheet.Cells[row.Row, 11].Value2);
                    CountyName = Convert.ToString(sheet.Cells[row.Row, 12].Value2);
                    PhoneNumber = Convert.ToString(sheet.Cells[row.Row, 13].Value2);
                    PhoneNumber = (PhoneNumber == ConstPhoneNA) ? "" : PhoneNumber ;

                    Address = HouseNumber + " " + Street + " " + StreetSuffix;

                    if (DuplicateAddress.Checked == true)
                    {
                        int nextRow = row.Row + 1;
                        NextLastName = Convert.ToString(sheet.Cells[nextRow, 1].Value2);
                        if (NextLastName == LastName)
                        {
                            NextFirstName = Convert.ToString(sheet.Cells[nextRow, 2].Value2);
                            NextHouseNumber = Convert.ToString(sheet.Cells[nextRow, 3].Value2);
                            NextStreet = Convert.ToString(sheet.Cells[nextRow, 5].Value2);
                            NextApartment = Convert.ToString(sheet.Cells[nextRow, 8].Value2);
                            NextStreetSuffix = Convert.ToString(sheet.Cells[nextRow, 6].Value2);
                            NextAddress = NextHouseNumber + " " + NextStreet + " " + NextStreetSuffix;

                            while (NextLastName == LastName && NextAddress == Address && NextApartment == ApartmentNumber)
                            {
                                FirstName = NextFirstName + " - " + FirstName;

                                nextRow = nextRow + 1;
                                NextLastName = Convert.ToString(sheet.Cells[nextRow, 1].Value2);
                                NextFirstName = Convert.ToString(sheet.Cells[nextRow, 2].Value2);
                                NextHouseNumber = Convert.ToString(sheet.Cells[nextRow, 3].Value2);
                                NextStreet = Convert.ToString(sheet.Cells[nextRow, 5].Value2);
                                NextApartment = Convert.ToString(sheet.Cells[nextRow, 8].Value2);
                                NextStreetSuffix = Convert.ToString(sheet.Cells[nextRow, 6].Value2);
                                NextAddress = NextHouseNumber + " " + NextStreet + " " + NextStreetSuffix;
                            }
                        }

                        if (PreviousLastName == LastName && PreviousAddress == Address && PreviousApartment == ApartmentNumber)
                        {
                            //FirstName = PreviousFirstName + " - " + sheet.Cells[row.Row, 1].Value2.ToString();
                            continue;
                        }
                        
                    }

                    
                    if (radioFirstname.Checked == true) Country = callForbears(FirstName);

                    if (radioLastname.Checked == true) Country = callForbears(LastName);

                    if (radioFirstLast.Checked == true) Country = callForbears(FirstName, LastName);

                    //Country =  (radioFirstname.Checked == true) ? callForbears(FirstName) : callForbears(LastName);

                    if (Country == null)
                    {
                        progressLabel.Text = "Searching  " + FirstName + " " + LastName ;
                        continue;
                    }

                    records.Add(new AddressData
                    {
                        LastName = LastName,
                        FirstName = FirstName,
                        HouseNumber = HouseNumber,
                        PreDirectional = PreDirectional,
                        Street = Street + " " + StreetSuffix,
                        PostDirectional = PostDirectional,
                        ApartmentNumber = ApartmentNumber,
                        City = City,
                        State = State,
                        ZIPCode = ZIPCode,
                        CountyName = CountyName,
                        PhoneNumber = PhoneNumber,
                        Country = Country
                    });

                    z = z + 1;

                    richTextBox1.Text += Environment.NewLine + Country + " - Found " + FirstName + " " + LastName + " probably From " + Country + " at " + Address + " " + ApartmentNumber;
                    progressLabel.Text  = Country + " - Found " + FirstName + " " + LastName + " probably From " + Country + " at " + Address + " " + ApartmentNumber;

                    PreviousAddress = Address;
                    PreviousLastName = LastName;
                    PreviousFirstName = Convert.ToString(sheet.Cells[row.Row, 2].Value2); ;
                    PreviousApartment =  ApartmentNumber;

                }

                excelApp.Quit();
                richTextBox1.Text += Environment.NewLine + "End searching file " + Path.GetFileName(strFile) + Environment.NewLine;
                progressLabel.Text = "End searching file " + Path.GetFileName(strFile) + Environment.NewLine;


                if ((System.IO.File.Exists(alreadySearchedFolderPath + "\\" + Path.GetFileName(strFile))))
                    try
                    {  File.Delete(strFile); } catch { continue; }
                
                if (System.IO.Directory.Exists(alreadySearchedFolderPath) &&  (!System.IO.File.Exists(alreadySearchedFolderPath + "\\" + Path.GetFileName(strFile))))
                {
                    try { System.IO.File.Move(strFile, alreadySearchedFolderPath + "\\" + Path.GetFileName(strFile)); }
                    catch (Exception exeption)
                    {
                      string exep =  exeption.ToString();
                        continue;
                    }
                }

                
            }

            csv.WriteRecords(records);
            writer.Flush();

            richTextBox1.Text += Environment.NewLine + "Done searching all files with " + t.ToString() +" names. " + (z-2).ToString() + " probable francophones found." + Environment.NewLine + Environment.NewLine+ "Output file is at "+Path.GetFullPath(strPath )+ "\\" + sortedFilename;
            progressLabel.Text = "Done searching all files with " + t.ToString() + " names. " + (z - 2).ToString() + " probable francophones found." ;

          
        }

        public static Excel.Workbook Open(Excel.Application excelInstance, string fileName, bool readOnly = false, bool editable = true, bool updateLinks = true)
        {
            Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            return book;
        }

        public void IterateRowsWorkBook(Excel.Workbook workbook)
        {
            foreach (Excel.Worksheet sheet in workbook.Worksheets)
            {
              
                foreach (Excel.Range row in sheet.UsedRange.Rows)
                {
                    String[] rowData = new String[row.Columns.Count];
                    for (int i = 0; i < row.Columns.Count; i++)
                        rowData[i] = row.Cells[1, i + 1].Value2.ToString();
                }
            }

          
        }


        public void IterateRowsWorksheet(Excel.Worksheet worksheet)
        {       
                foreach (Excel.Range row in worksheet.UsedRange.Rows)
                {
                    String[] rowData = new String[row.Columns.Count];
                    for (int i = 0; i < row.Columns.Count; i++)
                        rowData[i] = row.Cells[1, i + 1].Value2.ToString();
                }           
        }

        public void createNewFile(string fielename)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                //excel.Workbook.Worksheets.Add("Worksheet2");
                //excel.Workbook.Worksheets.Add("Worksheet3");

                var headerRow = new List<string[]>()
                {
                new string[] { "ID", "First Name", "Last Name", "DOB" }
                };

                // Determine the header range (e.g. A1:D1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["Worksheet1"];

                // Popular header row data
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                FileInfo excelFile = new FileInfo(@"C:\Users\amir\Desktop\test.xlsx");
                excel.SaveAs(excelFile);
            }
        }

        public List<string[]> populateList(string Country,
                                    string LastName,
                                    string FirstName,
                                    string Address,
                                    string HouseNumber,
                                    string PreDirectional,
                                    string Street,
                                    string StreetSuffix,
                                    string PostDirectional,
                                    string ApartmentNumber,
                                    string City,
                                    string State,
                                    string ZIPCode,
                                    string CountyName,
                                    string PhoneNumber,
                                    string PhoneSource)
        {

            var row = new List<string[]>()
                {
                new string[]
                    {
                        Country,
                        LastName,
                        FirstName,
                        Address,
                        HouseNumber,
                        PreDirectional,
                        Street,
                        StreetSuffix,
                        PostDirectional,
                        ApartmentNumber,
                        City,
                        State,
                        ZIPCode,
                        CountyName,
                        PhoneNumber,
                        PhoneSource
                    }
                };
            return row;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioFirstname_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll it automatically
            richTextBox1.ScrollToCaret();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int fCount = 0;
            List<string> countries = frenchCountries();
            foreach (string country in countries)
            {
                frenchCountriesToolStripMenuItem.DropDownItems.Add(country);
            }
            defaultFolderToSearchLabel.Text = defaultFolderToSearchLabel.Text + " " + FrancophoneSearch.Properties.Settings.Default.DropOffFolder;

            if (FrancophoneSearch.Properties.Settings.Default.DropOffFolder != "")
            {
                try
                { 
                    fCount = Directory.GetFiles(FrancophoneSearch.Properties.Settings.Default.DropOffFolder, "*", SearchOption.AllDirectories).Length; 
                }
                catch 
                { 
                    defaultFolderToSearchLabel.Text = "";
                    FrancophoneSearch.Properties.Settings.Default.DropOffFolder = "";
                }
                
                totalFiles.Text = fCount.ToString() + " Files";
            }
        }

        private void dropOffFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            FrancophoneSearch.Properties.Settings.Default.DropOffFolder = folderBrowserDialog1.SelectedPath;
            FrancophoneSearch.Properties.Settings.Default.Save();
        }

        private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\Read Me.pdf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            defaultFolderToSearchLabel.Text = "Folder to Search:";
            folderBrowserDialog1.ShowDialog();
            FrancophoneSearch.Properties.Settings.Default.DropOffFolder = folderBrowserDialog1.SelectedPath;
            FrancophoneSearch.Properties.Settings.Default.Save();
            defaultFolderToSearchLabel.Text = defaultFolderToSearchLabel.Text + " " + FrancophoneSearch.Properties.Settings.Default.DropOffFolder;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                const string ConstLastName = "Last Name";
                const string ConstPhoneNA = "Not Available";
            //const string AlreadySearchedFolder = "FilesAlreadySearched";

            System.IO.DirectoryInfo folderToSearch = (System.IO.DirectoryInfo)e.Argument;

            string alreadySearchedFolderPath;

                string Country = "";
                string LastName = "";
                string FirstName = "";
                string Address = "";
                string HouseNumber = "";
                string PreDirectional = "";
                string Street = "";
                string StreetSuffix = "";
                string PostDirectional = "";
                string ApartmentNumber = "";
                string City = "";
                string State = "";
                string ZIPCode = "";
                string CountyName = "";
                string PhoneNumber = "ReferenceUSA";
            string PhoneSource = "";
            string PreviousAddress = "";
                string PreviousLastName = "";
                string PreviousFirstName = "";
                string PreviousApartment = "";
                string NextStreet = "";
                string NextAddress = "";
                string NextLastName = "";
                string NextFirstName = "";
                string NextApartment = "";
                string NextHouseNumber = "";
                string NextStreetSuffix = "";               
                int fCount = 0;
                string alreadySearchedPath;

                if (folderToSearch.Name == AlreadySearchedFolder)
                {
                    return;
                }

                strPath = Path.GetFullPath(Directory.GetCurrentDirectory());
                strPath = folderToSearch.FullName;


                //Create a FilesAlreadySearched directory
                alreadySearchedFolderPath = strPath + "\\" + AlreadySearchedFolder;
                System.IO.Directory.CreateDirectory(alreadySearchedFolderPath);

                string[] strFiles = Directory.GetFiles(strPath);
                Excel.Application excel = null;
                string OriginalSortedFilename = "sortedFile.csv";
                sortedFilename = string.Empty;

                totalNameCount = 0;
                foundFrancophone = 2;

            excel = new Excel.Application();

                var headerRow = new List<string[]>()
            {
            new string[]
                {
                    "Country",
                    "Last Name",
                    "First Name",
                    "Address",
                    "House Number",
                    "Pre -directional",
                    "Street",
                    "Street Suffix",
                    "Post -directional",
                    "Apartment Number",
                    "City",
                    "State",
                    "ZIP Code",
                    "County Name",
                    "Phone Number"
                }
            };

                sortedFilename = OriginalSortedFilename.Replace(".", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-tt") + ".");

                writer = new StreamWriter(strPath + "\\" + sortedFilename);
                csv = new CsvWriter(writer,false);
                records = new List<AddressData>();

                int i = 1;
                int o = 0;

                foreach (string strFile in strFiles)
                    {

                        if ((strFile.Contains(OriginalSortedFilename.Replace(".csv", ""))) || !((strFile.Contains("csv")) || (strFile.Contains("xls"))))
                        {
                            continue;
                        }

                        if (i == 1)
                        {
                            fCount = Directory.GetFiles(FrancophoneSearch.Properties.Settings.Default.DropOffFolder, "*.csv", SearchOption.AllDirectories).Length + Directory.GetFiles(FrancophoneSearch.Properties.Settings.Default.DropOffFolder, "*.xls", SearchOption.AllDirectories).Length;
                        }

                        i = i + 1;
                    o = 0;

                    //backgroundWorker1.ReportProgress(o, Environment.NewLine + "Start searching file " + Path.GetFileName(strFile));
                backgroundWorker1.ReportProgress(o, Environment.NewLine + "Start searching file " + Path.GetFullPath(strFile));

                // Excel.Application excelApp = new Excel.Application();
                excelApp = new Excel.Application();
                        Excel.Workbook workBook = excelApp.Workbooks.Open(strFile);
                        Excel.Worksheet sheet = null;

                        sheet = workBook.Worksheets[1];

                        if (o == 0)
                        { 
                              backgroundWorker1.ReportProgress(o, sheet.UsedRange.Rows.Count); 
                        }
                    
                        foreach (Excel.Range row in sheet.UsedRange.Rows)
                        {
                        totalNameCount = totalNameCount + 1;
                        o = o + 1;
                        //progressBar1.PerformStep();
                        backgroundWorker1.ReportProgress(o);

                            LastName = Convert.ToString(sheet.Cells[row.Row, 1].Value2);
                            if (LastName == null) continue;
                            if (LastName == ConstLastName) continue;  //First row are headcer values
                            FirstName = Convert.ToString(sheet.Cells[row.Row, 2].Value2);
                            HouseNumber = Convert.ToString(sheet.Cells[row.Row, 3].Value2);
                            PreDirectional = Convert.ToString(sheet.Cells[row.Row, 4].Value2);
                            Street = Convert.ToString(sheet.Cells[row.Row, 5].Value2);
                            StreetSuffix = Convert.ToString(sheet.Cells[row.Row, 6].Value2);
                            PostDirectional = Convert.ToString(sheet.Cells[row.Row, 7].Value2);
                            ApartmentNumber = Convert.ToString(sheet.Cells[row.Row, 8].Value2);
                            City = Convert.ToString(sheet.Cells[row.Row, 9].Value2);
                            State = Convert.ToString(sheet.Cells[row.Row, 10].Value2);
                            ZIPCode = Convert.ToString(sheet.Cells[row.Row, 11].Value2);
                            CountyName = Convert.ToString(sheet.Cells[row.Row, 12].Value2);
                            PhoneNumber = Convert.ToString(sheet.Cells[row.Row, 13].Value2);
                            //PhoneNumber = (PhoneNumber == ConstPhoneNA) ? null : PhoneNumber;
                            if ( PhoneNumber == null || PhoneNumber == ConstPhoneNA)
                            {
                                PhoneNumber = callTruePeopleSearch(FirstName, LastName, ZIPCode);
                                PhoneSource = (PhoneNumber != null) ?  "FastPeopleSearch" : null;
                            }
                            //PhoneNumber = (PhoneNumber == null) ? callTruePeopleSearch(FirstName, LastName, ZIPCode) : PhoneNumber;

                            Address = HouseNumber + " " + Street + " " + StreetSuffix;

                            if (DuplicateAddress.Checked == true)
                            {
                                int nextRow = row.Row + 1;
                                NextLastName = Convert.ToString(sheet.Cells[nextRow, 1].Value2);
                                if (NextLastName == LastName)
                                {
                                    NextFirstName = Convert.ToString(sheet.Cells[nextRow, 2].Value2);
                                    NextHouseNumber = Convert.ToString(sheet.Cells[nextRow, 3].Value2);
                                    NextStreet = Convert.ToString(sheet.Cells[nextRow, 5].Value2);
                                    NextApartment = Convert.ToString(sheet.Cells[nextRow, 8].Value2);
                                    NextStreetSuffix = Convert.ToString(sheet.Cells[nextRow, 6].Value2);
                                    NextAddress = NextHouseNumber + " " + NextStreet + " " + NextStreetSuffix;

                                    while (NextLastName == LastName && NextAddress == Address && NextApartment == ApartmentNumber)
                                    {
                                        FirstName = NextFirstName + " - " + FirstName;

                                        nextRow = nextRow + 1;
                                        NextLastName = Convert.ToString(sheet.Cells[nextRow, 1].Value2);
                                        NextFirstName = Convert.ToString(sheet.Cells[nextRow, 2].Value2);
                                        NextHouseNumber = Convert.ToString(sheet.Cells[nextRow, 3].Value2);
                                        NextStreet = Convert.ToString(sheet.Cells[nextRow, 5].Value2);
                                        NextApartment = Convert.ToString(sheet.Cells[nextRow, 8].Value2);
                                        NextStreetSuffix = Convert.ToString(sheet.Cells[nextRow, 6].Value2);
                                        NextAddress = NextHouseNumber + " " + NextStreet + " " + NextStreetSuffix;
                                    }
                                }

                                if (PreviousLastName == LastName && PreviousAddress == Address && PreviousApartment == ApartmentNumber)
                                {
                                    //FirstName = PreviousFirstName + " - " + sheet.Cells[row.Row, 1].Value2.ToString();
                                    continue;
                                }

                            }


                            if (radioFirstname.Checked == true) Country = callForbears(FirstName);

                            if (radioLastname.Checked == true) Country = callForbears(LastName);

                            if (radioFirstLast.Checked == true) Country = callForbears(FirstName, LastName);

                            //Country =  (radioFirstname.Checked == true) ? callForbears(FirstName) : callForbears(LastName);

                            if (Country == null)
                            {
                            //progressLabel.Text = "Searching  " + FirstName + " " + LastName;
                            backgroundWorker1.ReportProgress(o, "@Processing " + FirstName + " " + LastName);
                            continue;
                            }

                            records.Add(new AddressData
                            {
                                LastName = LastName,
                                FirstName = FirstName,
                                HouseNumber = HouseNumber,
                                PreDirectional = PreDirectional,
                                Street = Street + " " + StreetSuffix,
                                PostDirectional = PostDirectional,
                                ApartmentNumber = ApartmentNumber,
                                City = City,
                                State = State,
                                ZIPCode = ZIPCode,
                                CountyName = CountyName,
                                PhoneNumber = PhoneNumber,
                                PhoneSource = PhoneSource,
                                Country = Country
                            });

                            foundFrancophone = foundFrancophone + 1;

                        backgroundWorker1.ReportProgress(o, Environment.NewLine + Country + " - Found " + FirstName + " " + LastName + " at " + Address + " " + ApartmentNumber + " probably From " + Country );
                
                        PreviousAddress = Address;
                            PreviousLastName = LastName;
                            PreviousFirstName = Convert.ToString(sheet.Cells[row.Row, 2].Value2); ;
                            PreviousApartment = ApartmentNumber;

                        }

                        excelApp.Quit();
  
                        if ((System.IO.File.Exists(alreadySearchedFolderPath + "\\" + Path.GetFileName(strFile))))
                            try
                              { File.Delete(strFile); }
                            catch 
                              {
                                   // continue; 
                              }

                        if (System.IO.Directory.Exists(alreadySearchedFolderPath) && (!System.IO.File.Exists(alreadySearchedFolderPath + "\\" + Path.GetFileName(strFile))))
                        {
                                alreadySearchedPath = alreadySearchedFolderPath + "\\" + Path.GetFileName(strFile);
                                    //try { System.IO.File.Move(@strFile, alreadySearchedPath); }
                                try 
                                {
                                    System.GC.Collect();
                                    System.GC.WaitForPendingFinalizers();
                                    System.IO.File.Move(@strFile, @alreadySearchedPath);
                                    //System.IO.File.Copy(@strFile, @alreadySearchedPath,true);
                                    //  System.IO.File.Delete(@strFile);
                                }
                                catch (Exception exeption)
                                {
                                    //string exep = exeption.ToString();
                                    backgroundWorker1.ReportProgress(o, Environment.NewLine + "Unable to move file " + Path.GetFileName(strFile) + " to folder " + AlreadySearchedFolder );
                                    //throw new Exception(exeption.ToString());
                                }
                        }

                //  csv.Dispose();

               // backgroundWorker1.ReportProgress(o, Environment.NewLine + "End searching file " + Path.GetFileName(strFile) + Environment.NewLine);
                backgroundWorker1.ReportProgress(o, Environment.NewLine + "End searching file " + Path.GetFullPath(strFile) + Environment.NewLine);

                e.Result = records;

                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        backgroundWorker1.ReportProgress(0);
                        break;
                        //return;
                    }

                }

             

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int number = 0;
            string progressText = string.Empty;

            if (e.ProgressPercentage == 0 && e.UserState != null && Int32.TryParse(e.UserState.ToString(), out number))
            {
                if (number > 0) progressBar1.Maximum = number;
            }
           
            if (e.UserState!= null)
            {
                if (number > 0)
                    progressText = "";
                else
                    progressText = e.UserState.ToString();

                if (progressText != "" && progressText[0] == '@')
                {
                    progressLabel.Text = progressText.Substring(1);
                }
                else 
                {
                    richTextBox1.Text += progressText;
                }
                
            }
            if (e.ProgressPercentage > progressBar1.Maximum )
            {
                progressBar1.Value = 0;
            }
            else
            {
                progressBar1.Value = e.ProgressPercentage;
            }
           

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progressLabel.Text = "Processing cancel";
            }
            else if (e.Error != null)
            {
             //  csv.WriteRecords(records); 
                csv.WriteRecords(e.Result as List<AddressData>);
                writer.Flush(); 
                progressLabel.Text = e.Error.Message;
            }
            else
            {
                try
                {

                    using ( writer )
                    using ( csv )
                    {
                        csv.WriteRecords(records);
                        richTextBox1.Text += Environment.NewLine + "Done searching all files with " + (totalNameCount - 1).ToString() + " names. " + (foundFrancophone - 2).ToString() + " probable francophones found." + Environment.NewLine + Environment.NewLine + "Output file is at " + Path.GetFullPath(strPath) + "\\" + sortedFilename + Environment.NewLine;
                        progressLabel.Text = (foundFrancophone - 2).ToString() + " probable francophones found.";

                        //writer.Flush();
                    }

                    //Loop trhoug  all files and call the background worker
                    currentFolder = currentFolder + 1;
                    if (allFolders.Length > 0 && allFolders.Length > currentFolder && allFolders[currentFolder].Name != AlreadySearchedFolder)
                    {
                        backgroundWorker1.RunWorkerAsync(allFolders[currentFolder]);
                    }

                     //   String path = @"C:\\AddressSearch\\Test\\Test2";
                   // DirectoryInfo fl = new DirectoryInfo(path);
                  //  backgroundWorker1.RunWorkerAsync(fl);

                    //csv.WriteRecords(records);
                    // writer.Flush();
                }
                catch 
                { 
                }           

                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                progressBar1.Value = 0;
            }
            else { progressLabel.Text = "No operation in progresss to cancel"; }
        }

        private void phoneSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void yNameZipCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrancophoneSearch.PhonesSearch phones = new FrancophoneSearch.PhonesSearch();
            //PhonesSearch f2 = new PhonesSearch(); 
            phones.ShowDialog();
        }

        private void byAddressStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrancophoneSearch.PhoneSearchByAddress phones = new FrancophoneSearch.PhoneSearchByAddress();
            //PhonesSearch f2 = new PhonesSearch(); 
            phones.ShowDialog();
        }
    }

    public class Country
    {
        public string jurisdiction { get; set; }
        public string percent { get; set; }
    }

    public class Sphere
    {
        public string sphere { get; set; }
        public string percent { get; set; }
    }

    public class ResponseObject
    {
        public List<Country> countries { get; set; }
        public List<Sphere> spheres { get; set; }
        public string forename { get; set; }
        public string surname { get; set; }
        public int remainingCredits { get; set; }
    }

    public class AddressData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string HouseNumber { get; set; }
        public string PreDirectional { get; set; }
        public string Street { get; set; }
        public string PostDirectional { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIPCode { get; set; }
        public string CountyName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneSource { get; set; }
        public string Country { get; set; }
    }
}
