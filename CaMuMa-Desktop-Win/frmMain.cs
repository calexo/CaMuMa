using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Thrift.Protocol;
//using Thrift.Server;
using Thrift.Transport;
using Evernote.EDAM.Type;
using Evernote.EDAM.UserStore;
using Evernote.EDAM.NoteStore;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

using Spotify;
using Microsoft.Win32;
using Gma.QrCodeNet.Encoding;
using System.Drawing.Imaging;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Text;
using PdfSharp.Pdf;


namespace Calexo.CaMuMa
{
    public partial class frmMain : Form
    {
        //private static String envEver = "sandbox";
        private static String envEver = "www";
           

        // Get the Evernote NoteStore URL
        TBinaryProtocol userStoreProt;
        UserStore.Client userStore;
        private Uri notestoreUrl;
        THttpClient noteStoreTrans;
        TBinaryProtocol noteStoreProt;


        private static String evernoteHost = envEver + ".evernote.com";
        private static String edamBaseUrl = "https://" + evernoteHost;
        private Uri userStoreUrl;
        private TTransport userStoreTransport;
        private TProtocol userStoreProtocol;
        private NoteStore.Client noteStore;
        private String authToken;
        //private User user;
        List<Notebook> notebooks;
        Notebook musicNotebook;
        List<Tag> tags;

        private String[] sFolderList;

        // Déplacement de la fenêtre
        private Point LastCursorPosition; 
        private bool IsMouseDown;

        private RegistryKey Registre;

        //private frmSetup sf;
        private Parameters myParams;
        //private frmProgress pg;

        //public event DoWorkEventHandler DoWork;

        private class ProgressStatusClass
        {
            public String Info;
            public int ProgressValue;
            public int ProgressMax;
        }
        /*private ProgressStatusClass ProgressStatus;*/

        public frmMain()
        {
            InitializeComponent();

            setWorkingMode(true);

            lblInfo.Text = "Loading...";

            this.Show();
            this.Cursor = Cursors.WaitCursor;

            Application.DoEvents();

            //Registre = Registry.CurrentUser.CreateSubKey(@"Software\Calexo\CaMuMa");
            Registre = Registry.CurrentUser.OpenSubKey(@"Software\Calexo\CaMuMa", true);
            if (Registre == null) Registre = Registry.CurrentUser.CreateSubKey(@"Software\Calexo\CaMuMa");
            myParams = new Parameters();
            loadParams();

            
            //ProgressStatus = new ProgressStatusClass();

            userStoreUrl = new Uri(edamBaseUrl + "/edam/user");
            userStoreTransport = new THttpClient(userStoreUrl);
            userStoreProtocol = new TBinaryProtocol(userStoreTransport);
            userStore = new UserStore.Client(userStoreProtocol);

            sFolderList = new String[65535];

            Application.DoEvents();

            bool versionOK = userStore.checkVersion("CaMuMa",
                                    Evernote.EDAM.UserStore.Constants.EDAM_VERSION_MAJOR,
                                    Evernote.EDAM.UserStore.Constants.EDAM_VERSION_MINOR);
            //Console.WriteLine("Is my EDAM protocol version up to date? " + versionOK);

            Application.DoEvents();

            if (!versionOK)
            {
                MessageBox.Show("Version KO");
            }
            /*else
            {
                //lblInfo.Text = "Ready...";
            }*/

            userStoreProt = new TBinaryProtocol(new THttpClient(userStoreUrl));
            userStore = new UserStore.Client(userStoreProt, userStoreProt);
            try
            {
                notestoreUrl = new Uri(userStore.getNoteStoreUrl(myParams.DevKey));
                // Set up the NoteStore client 
                noteStoreTrans = new THttpClient(notestoreUrl);
                //noteStoreTrans.setCustomHeader("User-Agent", "Calexo CaMuMa");
                //noteStoreTrans.CustomHeaders.Add(

                noteStoreProt = new TBinaryProtocol(noteStoreTrans);
                noteStore = new NoteStore.Client(noteStoreProt, noteStoreProt);

                authToken = myParams.DevKey;

                notebooks = noteStore.listNotebooks(authToken);
                Console.WriteLine("Found " + notebooks.Count + " notebooks");
                //musicNotebook = notebooks[0];
                cmbNotebook.Items.Clear();
                foreach (Notebook notebook in notebooks)
                {
                    // Console.WriteLine("  * " + notebook.Name);
                    cmbNotebook.Items.Add(notebook.Name);
                    //if (notebook.DefaultNotebook)
                    if (notebook.Name == myParams.Notebook)
                    {
                        musicNotebook = notebook;
                        cmbNotebook.Text = notebook.Name;
                    }
                }

                Application.DoEvents();

                tags = noteStore.listTags(authToken);
                Console.WriteLine("Found " + tags.Count + " tags");
                lblInfo.Text = "Ready !";

                setWorkingMode(false);
            }
            catch (Evernote.EDAM.Error.EDAMUserException e)
            {
                //mes e.ErrorCode;
                lblInfo.Text = "ERREUR : "  + e.ErrorCode;

                setWorkingMode(false);

                btnGo.Enabled = false;
            }

            this.Cursor = DefaultCursor;

            
        }

        private void loadParams()
        {
            // Reg -> Params
            if (Registre.GetValue("DefNotebook") != null)
                myParams.Notebook = (string)Registre.GetValue("DefNotebook");
            if (Registre.GetValue("DefPath") != null)
                myParams.Folder = (string)Registre.GetValue("DefPath");
            if (Registre.GetValue("Action") != null)
                myParams.Action = (int)Registre.GetValue("Action");
            if (Registre.GetValue("AddSpotify") != null && (string)Registre.GetValue("AddSpotify")=="True")
                myParams.AddSpotify = true;
            if (Registre.GetValue("ListOnlyMusicFiles") != null && (string)Registre.GetValue("ListOnlyMusicFiles") == "True")
                myParams.ListOnlyMusicFiles = true;
            if (Registre.GetValue("SetNotesReadOnly") != null && (string)Registre.GetValue("SetNotesReadOnly") == "True")
                myParams.SetNotesReadOnly = true;
            if (Registre.GetValue("AddIdTags") != null && (string)Registre.GetValue("AddIdTags") == "True")
                myParams.AddIdTags = true;
            if (Registre.GetValue("DevKey") != null)
                myParams.DevKey = (string)Registre.GetValue("DevKey");


            // Params -> Form
            if (!String.IsNullOrEmpty(myParams.Notebook)) cmbNotebook.Text = myParams.Notebook;
            if (!String.IsNullOrEmpty(myParams.Folder)) txtMusicFolder.Text = myParams.Folder;
            //Console.WriteLine("Reg : sRegDefNotebook = " + sRegDefNotebook);
            //Console.WriteLine("Reg : sRegDefPath = " + sRegDefPath);
            switch (myParams.Action)
            {
                case Parameters.ActionAdd:
                    rbAdd.Checked = true;
                    break;
                case Parameters.ActionAddModify:
                    rbReplace.Checked = true;
                    break;
                case Parameters.ActionAddSpotify:
                    rbActSpotify.Checked = true;
                    break;
                default:
                    rbAdd.Checked = true;
                    break;
            }
            /*if (myParams.AddSpotify) chkSpotify.Checked = true;
            if (myParams.ListOnlyMusicFiles) chkMusicFiles.Checked = true;
            if (myParams.SetNotesReadOnly) chkReadOnly.Checked = true;*/
            chkSpotify.Checked = myParams.AddSpotify;
            chkMusicFiles.Checked = myParams.ListOnlyMusicFiles;
            chkReadOnly.Checked = myParams.SetNotesReadOnly;
            chkAddIdTags.Checked = myParams.AddIdTags;

            txtDevKey.Text = myParams.DevKey;

        }

        private void Vérifier_Click(object sender, EventArgs e)
        {
            setWorkingMode(true);
            Boolean res = isConnexionOK();
            //if (res) Info("Authentication successful for: " + user.Username);
            setWorkingMode(false);
        }

        private void setWorkingMode(bool p)
        {
            p = !p;
            btnGo.Enabled = p;
            btnGo.Visible = p;

            btnStop.Enabled = !p;
            btnStop.Visible = !p;

            this.ControlBox = p;

            cmbNotebook.Enabled = p;
            btnVerif.Enabled = p;
            btnSetup.Enabled = p;
            //btnSetup.Visible = p;
            //btnGo.Enabled = p;
            btnBrowse.Enabled = p;
            btnAddTags.Enabled = p;
            btnClose.Enabled = p;

            rbActSpotify.Enabled = p;
            rbAdd.Enabled = p;
            rbReplace.Enabled = p;
            chkMusicFiles.Enabled = p;
            chkReadOnly.Enabled = p;
            chkSpotify.Enabled = p;
            chkAddIdTags.Enabled = p;
        }

        private bool isConnexionOK()
        {
            return true;
        }

        private void Info(String msg)
        {
            // TODO
            lblInfo.Text = msg;
            lblInfo.Refresh();
            //ProgressStatusClass myParams = new ProgressStatusClass();
            //worker.ReportProgress(j, myProgress);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fbdMusicPath.ShowDialog();

            txtMusicFolder.Text = fbdMusicPath.SelectedPath;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            setWorkingMode(true);

            //SetProgress(0);
            //pg = new frmProgress();

            pbProgress.Value = 0;
            pbProgress.Visible = true;
            lblInfo.Visible = true;
            //pg.ShowDialog(this);
            //pg.TopMost = true;
            //pg.Show(this);

            // On garde les paramètres dans la Registry
            saveParams();
            if (backgroundWorker.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker.RunWorkerAsync(myParams);
                //launch();
            }
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            /*if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }*/
        }

        // This event handler updates the progress.
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            //pbProgress.Value = e.ProgressPercentage;
            if (((ProgressStatusClass)e.UserState).ProgressMax>0)
                pbProgress.Maximum = ((ProgressStatusClass)e.UserState).ProgressMax;
            if (((ProgressStatusClass)e.UserState).ProgressValue <= ((ProgressStatusClass)e.UserState).ProgressMax)
            {
                pbProgress.Value = ((ProgressStatusClass)e.UserState).ProgressValue;
            }
            lblInfo.Text = ((ProgressStatusClass)e.UserState).Info;
        }

        // This event handler deals with the results of the background operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //lblInfo.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                lblInfo.Text = "Error: " + e.Error.Message;
            }
            else
            {
                lblInfo.Text = "Done!";
            }
            
            setWorkingMode(false);

            //pbProgress.Value = 100;
            //pbProgress.Visible = false;
            //lblInfo.Visible = false;

            //pg.Dispose();
        }

        // This event handler is where the time-consuming work is done.
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            launch(worker, e);
            
            try
            {
                launch(worker, e);
            }
            catch (System.Exception dbz)
            {
                System.Console.WriteLine("Error!");
                System.Console.WriteLine(dbz.Message);
                //myProgress.Info = i + " directories...";
                ProgressStatusClass myProgress = new ProgressStatusClass();
                myProgress.ProgressMax = 0;
                myProgress.ProgressValue = 0;
                myProgress.Info = dbz.Message;
                worker.ReportProgress(0, myProgress);
                e.Cancel = true;
                //e.Argument = dbz.Message;
                //return 0;
            }


        }

        private void saveParams()
        {
            // Set myParams
            // Param principaux
            myParams.Notebook = cmbNotebook.Text;
            myParams.Folder = txtMusicFolder.Text;
            myParams.DevKey = txtDevKey.Text;
            // Action
            if (rbReplace.Checked) myParams.Action = Parameters.ActionAddModify;
            if (rbAdd.Checked) myParams.Action = Parameters.ActionAdd;
            if (rbActSpotify.Checked) myParams.Action = Parameters.ActionAddSpotify;
            // Options
            myParams.AddSpotify = chkSpotify.Checked;
            myParams.ListOnlyMusicFiles = chkMusicFiles.Checked;
            myParams.SetNotesReadOnly = chkReadOnly.Checked;
            myParams.AddIdTags = chkAddIdTags.Checked;

            // Set registry
            Registre.SetValue("DevKey", txtDevKey.Text);
            Registre.SetValue("DefNotebook", cmbNotebook.Text);
            Registre.SetValue("DefPath", txtMusicFolder.Text);
            Registre.SetValue("Action", myParams.Action);
            Registre.SetValue("AddSpotify", myParams.AddSpotify);
            Registre.SetValue("ListOnlyMusicFiles", myParams.ListOnlyMusicFiles);
            Registre.SetValue("SetNotesReadOnly", myParams.SetNotesReadOnly);
            Registre.SetValue("AddIdTags", myParams.AddIdTags);
        }

        delegate void SetProgressCallback(int value);

        private void SetProgress(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.pbProgress.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(SetProgress);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.pbProgress.Value = value;
            }
        }

        private void launch(BackgroundWorker worker, DoWorkEventArgs e)
        {
            //this.pbProgress.Value = 0;
            //SetProgress(0);
            //frmMain frmMainE = (frmMain)e.Argument;
            myParams = (Parameters)e.Argument;
            ProgressStatusClass myProgress = new ProgressStatusClass();

            // List of listed extensions when Only Music Files is Checked
            List<string> sExtOK = new List<string>();
            sExtOK.Add(".flac");
            sExtOK.Add(".mp3");
            sExtOK.Add(".ogg");
            sExtOK.Add(".wma");
            sExtOK.Add(".alac");


            foreach (Notebook notebook in notebooks)
            {
                if (notebook.Name == myParams.Notebook)
                {
                    musicNotebook = notebook;
                }
            }

            // Liste des M-0Top
            if (chkRegenLists.Checked)
            {
                //TextWriter tw_lst = new StreamWriter(myParams.Folder + "\\camuma-top.lst", false, Encoding.Default);
                TextWriter tw_lst = new StreamWriter(myParams.Folder + "\\camuma-top.lst", false, Encoding.GetEncoding(850));
                

                NoteFilter filter = new NoteFilter();
                filter.NotebookGuid = musicNotebook.Guid;
                //filter.Words = "intitle:\"" + dir.Name + "\"";
                //any: "Camuma ID: 153266"  intitle:"Muse - 1999 - Showbiz"
                //filter.Words = "\"CaMuMa ID: " + sId + "\"";
                // Recherche par CaMuMa ID ou Titre
                //filter.Words = "any: \"CaMuMa ID: " + sId + "\" intitle:\"" + dir.Name + "\"";
                filter.Words = "tag:M-0Top";
                NotesMetadataResultSpec spec = new NotesMetadataResultSpec();
                spec.IncludeTitle = true;
                int pageSize = 10;
                int offset = 0;
                NotesMetadataList notes = noteStore.findNotesMetadata(authToken, filter, 0, pageSize, spec);
                do {
                    notes = noteStore.findNotesMetadata(authToken, filter, offset, pageSize, spec);
                    foreach (NoteMetadata note in notes.Notes) {
                        Console.WriteLine("M-0Top : " + note.Title);
                        tw_lst.WriteLine(note.Title);
                    }
                    offset = offset + notes.Notes.Count;
                } while (notes.TotalNotes > offset);
                tw_lst.Close();
            } //Liste des M-0Top

            /*if (chkPdf.Checked)
            {
                PdfDocument pdf = new PdfDocument();
                pdf.PageLayout = PdfPageLayout.TwoColumnLeft;
                //pdf.PageMode = PdfPageMode.
                pdf.Info.Title = "CaMuMa List";
                //pdf.Info.Producer = "Calexo CaMuMa";
                pdf.Info.Creator = "Calexo CaMuMa";
            }*/

            // Listing all directories
            DirectoryInfo dir = new DirectoryInfo(myParams.Folder);
            DirectoryInfo dir2;
            //String sMsg="";
            Int32 i = 0;
            foreach (DirectoryInfo f in dir.GetDirectories())
            {
                this.sFolderList[i] = f.FullName;
                dir2 = new DirectoryInfo(this.sFolderList[i]);
                foreach (DirectoryInfo f2 in dir2.GetDirectories())
                {
                    i++;
                    this.sFolderList[i] = f2.FullName;
                }

                i++;
                myProgress.Info = i + " directories...";
                worker.ReportProgress(0, myProgress);
            }

            //TextWriter tw = new StreamWriter(myParams.Folder + "\\camuma.lst", false, System.Text.Encoding.Unicode);
            //TextWriter tw = new StreamWriter(myParams.Folder + "\\camuma.lst", false, Encoding.GetEncoding(65001));
            //TextWriter tw = new StreamWriter(myParams.Folder + "\\camuma.lst", false, Encoding.BigEndianUnicode);
            TextWriter tw = new StreamWriter(myParams.Folder + "\\camuma.lst", false, Encoding.Default);
            
            
            // Checking each directory
            // Checking if MP3 or Flac is here
            // Adding note
            bool isFlac, isMP3, isAlac, isWma;
            bool isFolderJPG;
            bool isSpotify;
            String sFileList;
            String sContent = "";
            String sFolderJPG = "";
            Int32 j = 0;
            String sId = "";
            List<string> lTagNames;
            String sArtist, sAlbum, sYear; //, sGenre;
            Boolean isParsed;
            Regex oRegex; MatchCollection oMatchCollection;

            String regArtist = @"^(?<ARTIST>([\w\'\(\)\&\, -])*([\w\'\(\)\&\,]))";
            String regAlbum = @"(?<ALBUM>([\w\'\(\)\-\&\,\. ])+)$";
            String regYear = @"(?<YEAR>([0-9]{4}))";
            String regDash = "[ ]+-[ ]+";

            foreach (String sDirName in sFolderList)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                

                if (sDirName != null)
                {
                    dir = new DirectoryInfo(sDirName);
                    isFlac = false;
                    isMP3 = false;
                    isWma = false;
                    isAlac = false;
                    isSpotify = false;
                    isFolderJPG = false;
                    sFolderJPG = "";
                    sFileList = "<div ><ul>";// "<div><b>" + WebUtility.HtmlEncode("Liste des fichiers :") + "</b></div>";
                    sContent = "";
                    sArtist = ""; sAlbum = ""; sYear = ""; //sGenre = "";
                    isParsed = false;

                    if (chkAddIdTags.Checked)
                    {
                        if (File.Exists(dir.FullName + "\\camuma.id"))
                        {
                            TextReader tr = new StreamReader(dir.FullName + "\\camuma.id");
                            sId = tr.ReadLine().Trim();
                        }
                        else
                        {
                            Random rRnd = new Random();
                            int iRnd = rRnd.Next(1001, 999999);
                            sId = iRnd.ToString().PadLeft(6,'0');
                            System.IO.File.WriteAllText(@dir.FullName + "\\camuma.id", sId);
                        }

                        // Ajout au camuma.lst
                        tw.WriteLine(sId + ":" + dir.FullName.Replace(myParams.Folder+"\\",""));
                        //tw.Flush();

                        if (!File.Exists(dir.FullName + "\\camuma.png"))
                        {
                            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
                            QrCode qrCode = new QrCode();
                            //QrCode qrCode = qrEncoder.Encode(sId, out qrCode);
                            qrEncoder.TryEncode("camuma://" + sId, out qrCode);
                            //GraphicsRenderer renderer = new GraphicsRenderer(5, Brushes.Black, Brushes.White);
                            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                            //int pixelSize = renderer.Measure( qrCode.Matrix.Width).Width;
                            //WriteableBitmap wBitmap = new WriteableBitmap(pixelSize, pixelSize, 96, 96, PixelFormats.Gray8, null);
                            //renderer.CreateImageFile(qrCode.Matrix, @dir.FullName + "\\camuma.png", ImageFormat.Png);
                            
                            using (FileStream stream = new FileStream(@dir.FullName + "\\camuma.png", FileMode.Create))
                            {
                                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
                            }

                            SizeF size;
                            Font f = new Font(FontFamily.GenericSansSerif,20);
                            // creates 1Kx1K image buffer and uses it to find out how bit the image needs to be to fit the text
                            using (Image imageg = (Image)new Bitmap(1000, 1000))
                                size = Graphics.FromImage(imageg).MeasureString(sId, f);

                            using (Bitmap image = new Bitmap((int)size.Width, (int)size.Height)) //,, PixelFormat.Format32bppArgb))
                            {
                                Graphics g = Graphics.FromImage((Image)image);
                                //g.TranslateTransform(image.Width, image.Height);
                                //g.RotateTransform(180.0F); //note that we need the rotation as the default is down
                                //Color colBG = new Color();
                                //colBG.
                                g.Clear(ColorTranslator.FromHtml("#ABDA4C"));
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                // draw text
                                g.DrawString(sId, f, Brushes.Black, 0f, 0f);

                                //note that this image has to be a PNG, as GDI+'s gif handling renders any transparency as black.
                                //context.Response.AddHeader("ContentType", "image/png");
                                using (MemoryStream memStream = new MemoryStream())
                                {
                                    //note that context.Response.OutputStream doesn't support the Save, but does support WriteTo
                                    image.Save(memStream, ImageFormat.Png);
                                    //memStream.WriteTo(context.Response.OutputStream);
                                    System.IO.File.WriteAllBytes(@dir.FullName + "\\camumaid.png", memStream.ToArray());
                                }
                            }

                            
                            
                        }
                    }


                    foreach (FileInfo f in dir.GetFiles())
                    {
                        //if (f.Extension.Equals("flac", StringComparison.CurrentCultureIgnoreCase)
                        if (f.Extension.Equals(".flac", StringComparison.CurrentCultureIgnoreCase)) isFlac = true;
                        else if (f.Extension.Equals(".mp3", StringComparison.CurrentCultureIgnoreCase)) isMP3 = true;
                        else if (f.Extension.Equals(".wma", StringComparison.CurrentCultureIgnoreCase)) isWma = true;
                        else if (f.Extension.Equals(".alac", StringComparison.CurrentCultureIgnoreCase)) isAlac = true;
                        else if (f.Name.Equals("folder.jpg", StringComparison.CurrentCultureIgnoreCase))
                        {
                            isFolderJPG = true;
                            sFolderJPG = f.FullName;
                        }
                        if (!chkMusicFiles.Checked || sExtOK.Contains(f.Extension.ToLower()))
                        {
                            sFileList += "<li>" + WebUtility.HtmlEncode(f.Name) + "</li>";
                        }
                    }
                    sContent = "<h1>" + WebUtility.HtmlEncode(dir.Name) + "</h1>";
                    sContent += sFileList + "</ul></div>";

                    if (isMP3 || isFlac || isWma || isAlac)
                    {
                        j++;
                        myProgress.ProgressValue = j;
                        myProgress.Info = j + "/" + i +" \nAlbum...";
                        worker.ReportProgress(j, myProgress);
                        //Info("Creating Note... " + j + "/" + i);

                        lTagNames = new List<string>();
                        lTagNames.Add("M-Support:Cowon");
                        lTagNames.Add("M-Support:NAS2");
                        lTagNames.Add("M-Support:WD");
                        lTagNames.Add("M-Album");
                        if (isMP3) lTagNames.Add("M-MP3");
                        if (isFlac) lTagNames.Add("M-FLAC");
                        if (isAlac) lTagNames.Add("M-ALAC");
                        if (isWma) lTagNames.Add("M-WMA");
                        if (isFolderJPG) lTagNames.Add("M-Cover");
                        else lTagNames.Add("M-NoCover");

                        Console.WriteLine(dir.Name + "...");
                        
                        // ARTIST - YEAR - ALBUM
                        oRegex = new Regex(regArtist + regDash + regYear + regDash + regAlbum);
                        oMatchCollection = oRegex.Matches(dir.Name);
                        foreach (Match oMatch in oMatchCollection)
                        {
                            Console.WriteLine(" * " + oMatch.Groups["ARTIST"] + ":" + oMatch.Groups["ALBUM"] + "(" + oMatch.Groups["YEAR"] + ")");
                            sArtist = oMatch.Groups["ARTIST"].ToString();
                            sYear = oMatch.Groups["YEAR"].ToString();
                            sAlbum = oMatch.Groups["ALBUM"].ToString();
                            isParsed = true;
                        }

                        // ARTIST - ALBUM - YEAR
                        if (!isParsed)
                        {
                            oRegex = new Regex(regArtist + regDash + regAlbum + regDash + regYear);
                            oMatchCollection = oRegex.Matches(dir.Name);
                            foreach (Match oMatch in oMatchCollection)
                            {
                                Console.WriteLine(" * " + oMatch.Groups["ARTIST"] + ":" + oMatch.Groups["ALBUM"] + "(" + oMatch.Groups["YEAR"] + ")");
                                sArtist = oMatch.Groups["ARTIST"].ToString();
                                sYear = oMatch.Groups["YEAR"].ToString();
                                sAlbum = oMatch.Groups["ALBUM"].ToString();
                                isParsed = true;
                            }
                        }


                        // ARTIST - ALBUM
                        if (!isParsed)
                        {
                            oRegex = new Regex(regArtist + regDash + regAlbum);
                            oMatchCollection = oRegex.Matches(dir.Name);
                            foreach (Match oMatch in oMatchCollection)
                            {
                                //lTagNames.Add (oMatch.Groups["ARTIST"].ToString());
                                Console.WriteLine(" * " + oMatch.Groups["ARTIST"] + ":" + oMatch.Groups["ALBUM"]);
                                sArtist = oMatch.Groups["ARTIST"].ToString();
                                sAlbum = oMatch.Groups["ALBUM"].ToString();
                                isParsed = true;
                            }
                        }

                        if (isParsed)
                        {
                            sArtist = sArtist.Trim();
                            sYear = sYear.Trim();
                            sAlbum = sAlbum.Trim();
                            if (!String.IsNullOrWhiteSpace(sArtist)) lTagNames.Add("M-Artist:" + sArtist);
                            if (!String.IsNullOrWhiteSpace(sYear)) lTagNames.Add("M-Year:" + sYear);
                            else lTagNames.Add("M-Year:None");
                            //if (!String.IsNullOrWhiteSpace(sAlbum)) lTagNames.Add("M-Album:" + sAlbum);

                            myProgress.Info = j + "/" + i + "\n"  + "Album : " + sArtist + ":" + sAlbum + "... ";
                            worker.ReportProgress(j, myProgress);
                        }
                        else lTagNames.Add("M-NotParsed");

                        // Spotify
                        if (chkSpotify.Checked)
                        {
                            try
                            {
                                SearchResults<Album> spoRes = Search.SearchAlbums(dir.Name);
                                if (spoRes.SearchResultsPage.Length > 0)
                                {
                                    Album album = spoRes.SearchResultsPage.First();
                                    Console.WriteLine(" * Spotify : " + album.Artist + " - " + album.Name + " (" + album.Url + ")");
                                    sContent += "<div><br/></div>";
                                    sContent += "<h2>Liens</h2>";
                                    sContent += "<div><strong>Spotify</strong> : ";
                                    sContent += "<a href=\"" + album.Url + "\">";
                                    sContent += WebUtility.HtmlEncode(album.Artist + " - " + album.Name + " : " + album.Url);
                                    sContent += "</a>";
                                    sContent += "</div>";

                                    lTagNames.Add("M-Spotify");
                                    isSpotify = true;
                                }
                            }
                            catch (WebException we)
                            {
                                Console.WriteLine(" * Spotify : " + we.Message);
                            }
                            catch (System.FormatException we)
                            {
                                Console.WriteLine(" * Spotify : " + we.Message);
                            }
                        } // chkSpotify true

                        /*foreach (Album album in spoRes.SearchResultsPage)
                        {
                            Console.WriteLine(" * Spotify : " + album.Artist + " - " + album.Name + " (" + album.Url + ")");
                        }*/

                        // Add CaMuMa Id
                        sContent += "<div><p><i>CaMuMa ID:</i> <a href=\"camuma://" + sId + "\">" + sId + "</a></p>";
                        byte[] image = ReadFully(File.OpenRead(@dir.FullName + "\\camuma.png"));
                        byte[] hashQR = new MD5CryptoServiceProvider().ComputeHash(image);
                        String hashHexQR = BitConverter.ToString(hashQR).Replace("-", "").ToLower();
                        //sContent += "<a href=\"camuma://" + sId + "\">";
                        sContent += "<en-media type=\"image/png\" hash=\"" + hashHexQR + "\"/>";
                        sContent += "</div>";
                        Data data = new Data();
                        data.Size = image.Length;
                        data.BodyHash = hashQR;
                        data.Body = image;
                        Resource imgQR = new Resource();
                        imgQR.Mime = "image/png";
                        imgQR.Data = data;
                        Console.WriteLine(@dir.FullName + "\\camuma.png -> " + hashHexQR);

                        // On ajoute si on n'est pas dans le Action AddSpotify
                        // ou si il y a effectivement du Spotify
                        if (chkEvernote.Checked)
                        {
                            if (!rbActSpotify.Checked || isSpotify)
                            {
                                // On recherche la note avec le même titre
                                NoteFilter filter = new NoteFilter();
                                filter.NotebookGuid = musicNotebook.Guid;
                                //filter.Words = "intitle:\"" + dir.Name + "\"";
                                //any: "Camuma ID: 153266"  intitle:"Muse - 1999 - Showbiz"
                                //filter.Words = "\"CaMuMa ID: " + sId + "\"";
                                // Recherche par CaMuMa ID ou Titre
                                //filter.Words = "any: \"CaMuMa ID: " + sId + "\" intitle:\"" + dir.Name + "\"";
                                filter.Words = "\"CaMuMa ID: " + sId;
                                NotesMetadataResultSpec spec = new NotesMetadataResultSpec();
                                spec.IncludeTitle = true;
                                int pageSize = 10;
                                NotesMetadataList notes = noteStore.findNotesMetadata(authToken, filter, 0, pageSize, spec);

                                // Non existing Note
                                if (notes.TotalNotes == 0)
                                {
                                    // If Adding ou Replacing
                                    if (rbAdd.Checked || rbReplace.Checked)
                                    {
                                        // Creating new note
                                        createNote(sFolderJPG, sContent, dir.Name, lTagNames, imgQR);
                                        Console.WriteLine(" * Creation");
                                    }
                                }
                                else if (notes.TotalNotes == 1)
                                {
                                    NoteMetadata noteToMod = notes.Notes.First();
                                    Console.WriteLine(" * Existing...");
                                    if (rbReplace.Checked)
                                    {
                                        Note note = noteStore.getNote(authToken, noteToMod.Guid, true, true, false, false);
                                        String hashHex = "";

                                        // Suppr tags négatifs (NotParsed, ...)
                                        note.TagGuids.Remove(getTagGuid("M-NotParsed"));
                                        note.TagGuids.Remove(getTagGuid("M-NoCover"));
                                        // Adding new tags
                                        note.TagNames = lTagNames;
                                        byte[] hash = null;
                                        if (sFolderJPG != "")
                                        {
                                            Console.WriteLine(" * folder.jpg exists");
                                            image = ReadFully(File.OpenRead(sFolderJPG));
                                            hash = new MD5CryptoServiceProvider().ComputeHash(image);
                                            hashHex = BitConverter.ToString(hash).Replace("-", "").ToLower();
                                        }

                                        if (note.Content != nodeContentEnrich(sContent, hashHex))
                                        {
                                            Console.WriteLine(" * Different contents");
                                            note.Content = nodeContentEnrich(sContent, hashHex);
                                            note.Resources = new List<Resource>();

                                            if (hash != null)
                                            {
                                                Console.WriteLine(" * Adding folder image");
                                                Data dataF = new Data();
                                                dataF.Size = image.Length;
                                                dataF.BodyHash = hash;
                                                dataF.Body = image;
                                                Resource resource = new Resource();
                                                resource.Mime = "image/jpg";
                                                resource.Data = dataF;
                                                note.Resources.Add(resource);
                                            }

                                            note.Resources.Add(imgQR);

                                            Console.WriteLine("Res : " + note.Resources.Count);

                                            note.UpdateSequenceNum = 0;
                                            note.Updated = 0;

                                            Note newNote = noteStore.updateNote(authToken, note);

                                            if (newNote != null)
                                            {
                                                Console.WriteLine(" * Modified");
                                                Console.WriteLine("Res : " + newNote.Resources.Count);
                                                //Console.WriteLine(newNote.Title);
                                                //Console.WriteLine(newNote.Updated);
                                                //Console.WriteLine(note.UpdateSequenceNum + " -> " + newNote.UpdateSequenceNum);
                                            }
                                            else
                                            {
                                                Console.WriteLine(" * Modification failed");
                                            }
                                        }



                                    }
                                } // TotalNotes=1
                                else // More than 1 matches
                                {
                                    createNote(sFolderJPG, sContent, dir.Name, lTagNames, imgQR);
                                    Console.WriteLine(" * ERROR - Multiple found");
                                }
                            } // ActSpotify
                        } // chkEvernote
                    }
                    else
                    {
                        i--;
                    }
                }

                //this.pbProgress.Maximum = i;
                //pbProgress.Value = j;

                myProgress.ProgressMax = i;
                myProgress.ProgressValue = j;
                worker.ReportProgress(j, myProgress);
            }
            //Info("OK");
            tw.Close();
        }

        private Note createNote(String sImageFile, String sContent, String sTitle, List<string> sTags, Resource resQR)
        {
            if (isConnexionOK())
            {

                Note note = new Note();
                note.NotebookGuid = musicNotebook.Guid;

                note.Title = sTitle;
                /*note.Content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<!DOCTYPE en-note SYSTEM \"http://xml.evernote.com/pub/enml2.dtd\">" +
                    "<en-note>";*/

                string hashHex="";
                note.Resources = new List<Resource>();

                if (sImageFile != "")
                {
                    byte[] image = ReadFully(File.OpenRead(sImageFile));
                    byte[] hash = new MD5CryptoServiceProvider().ComputeHash(image);
                    hashHex = BitConverter.ToString(hash).Replace("-", "").ToLower();

                    Data data = new Data();
                    data.Size = image.Length;
                    data.BodyHash = hash;
                    data.Body = image;
                    Resource resource = new Resource();
                    resource.Mime = "image/jpg";
                    resource.Data = data;

                    
                    // folder.jpg
                    note.Resources.Add(resource);


                    //note.Content += "<en-media type=\"image/jpg\" hash=\"" + hashHex + "\"/>";
                }

                // camuma.png
                note.Resources.Add(resQR);

                //note.Content += sContent + "<br/>";
                //note.Content += "</en-note>";

                note.Content = nodeContentEnrich(sContent, hashHex);

                Console.WriteLine(note.Content);

                note.TagNames = sTags;

                // Gestion du Read-Only
                /*if (this.chkReadOnly.Checked)
                {*/
                    note.Attributes = new NoteAttributes();
                    note.Attributes.ContentClass = "calexo.camuma";
                //}

                return noteStore.createNote(authToken, note);

            }
            else return null;
        }

        private string nodeContentEnrich(string sContent, string hashHex)
        {
            String cnt;

            cnt = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<!DOCTYPE en-note SYSTEM \"http://xml.evernote.com/pub/enml2.dtd\">" +
                "<en-note bgcolor=\"#abda4c\">";
            if (hashHex!="")
                cnt += "<span style=\"float:right;\"><en-media width=\"200\" height=\"200\" type=\"image/jpg\" hash=\"" + hashHex + "\"/></span>";
            cnt += sContent + "<br/>";
            cnt += "<div>&copy; Calexo 2013 - Calexo Music Management - <a href=\"http://www.calexo.com\">http://www.calexo.com</a></div>";
            cnt += "</en-note>";

            return cnt;

        }

        private String createTag(String sTitle)
        {
            if (isConnexionOK())
            {
                String rTagGuid = getTagGuid(sTitle);
                if (String.IsNullOrEmpty (rTagGuid))
                {
                    Tag tag = new Tag();
                    tag.Name = sTitle;
                    Tag createdTag = noteStore.createTag(authToken, tag);
                    return createdTag.Guid;
                }
                else
                {
                    return rTagGuid;
                }

            } else return null;
        }

        public static byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                    {
                        return ms.ToArray();
                    }
                    ms.Write(buffer, 0, read);
                }
            }
        }

        private void btnToListen_Click(object sender, EventArgs e)
        {
            setWorkingMode(true);

            createTag("M-AEcouter");

            setWorkingMode(false);

        }

        private String getTagGuid(String pTag)
        {
            Tag rTag = null;
            foreach (Tag tag in tags)
            {
                //Console.WriteLine("  * " + tag.Name);
                if (tag.Name == pTag)
                {
                    rTag = tag;
                }
            }
            //Console.WriteLine("Tag " + pTag + " -> " + rTag);
            if (rTag!=null)
                return rTag.Guid;
            else
            {
                return null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = true;
            this.LastCursorPosition = new Point(e.X, e.Y);
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown == true)
            {
                //Move the form
                this.Location = new Point(this.Left - (this.LastCursorPosition.X - e.X), this.Top - (this.LastCursorPosition.Y - e.Y));

                //Redraw the form//
                this.Invalidate();
            }

        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = false;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            frmMain.ActiveForm.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            //buttonToolTip.ToolTipTitle = "Button Tooltip";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;


            buttonToolTip.ShowAlways = true;


            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 500;


            buttonToolTip.SetToolTip(chkSpotify, "Adds Spotify URI when adding. If replace is checked, only replace notes without existing Spotify URI.");
        }

        private void lblOptions_Click(object sender, EventArgs e)
        {

        }

        private void rbActSpotify_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActSpotify.Checked) chkSpotify.Checked=true;

        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            //frmSetup.ActiveForm.Show();
            
            //this.sf.ShowDialog(this);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            btnStop.Enabled = false;
        }

        // Buttons Management
        // Big : 100x35
        /*
        private void btn_100_35_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x35_on));
        }
        private void btn_100_35_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x35));
        }
        private void btn_100_35_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x35_down));
        }
        private void btn_100_35_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x35));
        }

        // Medium : 100x25
        private void btn_100_25_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x25_on));
        }
        private void btn_100_25_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x25));
        }
        private void btn_100_25_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x25_down));
        }
        private void btn_100_25_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_100x25));
        }

        // Small : 35x25
        private void btn_35_25_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_35x25_on));
        }
        private void btn_35_25_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_35x25));
        }
        private void btn_35_25_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_35x25_down));
        }
        private void btn_35_25_MouseUp(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_35x25));
        }

        // Bigger : 150x25
        private void btn_150_25_MouseEnter(object sender, EventArgs e)
        {
            //lblInfo.Text = sender.GetType().ToString();

            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.CheckBox":
                    ((CheckBox)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25_on));
                    break;
                case "System.Windows.Forms.RadioButton":
                    ((RadioButton)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25_on));
                    break;
            }
        }
        private void btn_150_25_MouseLeave(object sender, EventArgs e)
        {
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.CheckBox":
                    ((CheckBox)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25));
                    break;
                case "System.Windows.Forms.RadioButton":
                    ((RadioButton)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25));
                    break;
            }
        }
        private void btn_150_25_MouseDown(object sender, MouseEventArgs e)
        {
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.CheckBox":
                    ((CheckBox)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25_down));
                    break;
                case "System.Windows.Forms.RadioButton":
                    ((RadioButton)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25_down));
                    break;
            }
        }
        private void btn_150_25_MouseUp(object sender, MouseEventArgs e)
        {
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.CheckBox":
                    ((CheckBox)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25));
                    break;
                case "System.Windows.Forms.RadioButton":
                    ((RadioButton)sender).BackgroundImage = ((System.Drawing.Image)(Properties.Resources.button_empty_150x25));
                    break;
            }
        }*/

        private void lnkCalexo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.calexo.com");
        }

        private void cmbNotebook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDevKey_TextChanged(object sender, EventArgs e)
        {
            saveParams();
        }

    
    }

}
