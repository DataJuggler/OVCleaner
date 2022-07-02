

namespace OVCleaner
{

    #region class MainForm
    /// <summary>
    /// This is the MainForm for this app.
    /// </summary>
    public partial class MainForm : Form
    {
        
        #region Private Variables
        private List<OVApp> apps;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

            #region CleanButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'CleanButton' is clicked.
            /// </summary>
            private void CleanButton_Click(object sender, EventArgs e)
            { 
                // reset
                Graph.Visible = true;
                Graph.Maximum = Apps.Count;
                Graph.Value = 0;

                // If the Apps collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(Apps))
                {
                    // Iterate the collection of OVApp objects
                    foreach (OVApp app in Apps)
                    {
                        // Increment the value for Graph
                        Graph.Value++;

                        // if there are old versions                        
                        if (app.OldVersions.Count > 0)
                        {
                            // iterate the old versions                            
                            foreach (OVApp oldVersion in app.OldVersions)
                            {
                                // Delete the old version
                                Directory.Delete(oldVersion.FullPath, true);
                            }
                        }
                    }
                
                    // hide
                    Graph.Visible = false;
                                        
                    // finished
                    MessageBox.Show("Done");
                }
            }
            #endregion
            
            #region DiscoverButton_Click(object sender, EventArgs e)
            /// <summary>
            /// event is fired when the 'DiscoverButton' is clicked.
            /// </summary>
            private void DiscoverButton_Click(object sender, EventArgs e)
            {
                // Discover the apps
                DiscoverApps();

                // Sort the apps with the same name into groups
                DiscoverOldVersions();

                // Display the Apps
                DisplayApps();

                // Display the text for the Reclaimable space (estimate)
                long total = Apps.Sum(x => x.ReclaimableSize) / 1024 / 1024 / 8;
                ReclaimStatus.Text = total.ToString("#,##0") + " meg";

                // hide
                Graph.Visible = false;

                Refresh();
                Application.DoEvents();
            }
            #endregion
            
        #endregion

        #region Methods

            #region DiscoverApps()
            /// <summary>
            /// returns a list of Apps
            /// </summary>
            public void DiscoverApps()
            {
                // get the directories
                List<string> directories = Directory.GetDirectories(OVFolderControl.Text).ToList();

                // Create a new collection of 'OVApp' objects.
                Apps = new List<OVApp>();

                // If the directories collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(directories))
                {
                    // Setup the Graph
                    Graph.Maximum = directories.Count;
                    Graph.Value = 0;
                    Graph.Visible = true;

                    // refresh the UI
                    Refresh();
                    Application.DoEvents();

                    // Iterate the collection of string objects
                    foreach (string directory in directories)
                    {
                        // omit the deps folder. Might have to make this a list
                        if (!directory.EndsWith("deps"))
                        {
                            // increment the Graph
                            Graph.Value++;

                            // refresh the UI
                            Refresh();
                            Application.DoEvents();

                            // Create a new instance of a 'DirectoryInfo' object.
                            DirectoryInfo info = new DirectoryInfo(directory);

                            // create an app
                            OVApp app = new OVApp(info.Name, info.FullName);

                            // Add this app
                            Apps.Add(app);
                        }
                    }
                }
            }
            #endregion
            
            #region DiscoverOldVersions()
            /// <summary>
            /// Discover Old Versions
            /// </summary>
            public void DiscoverOldVersions()
            {
                // create a list of List<OVApp> objects
                List<List<OVApp>> groups = GroupApps();

                // Fix Blender being named 3.1.0 appears in its own group
                groups = FixBlender(groups);

                // get the latestApps
                List<OVApp> latestApps = new List<OVApp>();

                // If the groups collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(groups))
                {   
                    // iterate the groups                    
                    foreach (List<OVApp> group in groups)
                    {
                        // Get the last app
                        OVApp latestApp = group.Last();

                        // iterate up to just before the last item
                        for (int x = 0; x < group.Count - 1; x++)
                        {
                            // Add the old version
                            latestApp.OldVersions.Add(group[x]);
                        }

                        // Get the
                        latestApps.Add(latestApp);
                    }
                }

                // Reset the Apps now that we are done
                Apps = latestApps;
            }
            #endregion
            
            #region DisplayApps()
            /// <summary>
            /// Display Apps
            /// </summary>
            public void DisplayApps()
            {
                // Clear the items
                AppsCheckBox.Items.Clear();

                // add each name
                foreach (OVApp app in Apps)
                {  
                    // Add the short name
                    AppsCheckBox.Items.Add(app.DisplayName, (app.OldVersions.Count > 0));
                }
            }
            #endregion
            
            #region FixBlender()
            /// <summary>
            /// returns a list of Blender
            /// </summary>
            public List<List<OVApp>> FixBlender(List<List<OVApp>> groups)
            {  
                // locals
                bool addToNextGroup = false;
                OVApp nextApp = null;
                int index = -1;
                int removeIndex = -1;
                bool blenderFixed = false;
                
                // if the groups exist
                if (ListHelper.HasOneOrMoreItems(groups))
                {
                    // fix Blender issue where Blender 3.1.0 shows up as its own group
                    foreach(List<OVApp> group in groups)
                    {
                        // Increment the value for index
                        index++;

                        // needed to move
                        if ((addToNextGroup) && (NullHelper.Exists(nextApp)))
                        {
                            // Add this item to the beginning
                            group.Insert(0, nextApp);

                            // no longer needed
                            addToNextGroup = false;
                            
                            // Blender has been fixed
                            blenderFixed = true;
                        }

                        // if the group exists
                        if (ListHelper.HasOneOrMoreItems(group))
                        {
                            // if Blender
                            if ((group[0].ShortName.StartsWith("Blender-3.1.0")) && (!blenderFixed))
                            {
                                // set to true so the next group gets this item
                                addToNextGroup = true;

                                // set the nextApp
                                nextApp = group[0];

                                // set the index to remove
                                removeIndex = index;
                            }
                        }                        
                    }

                    // if the removeIndex is set
                    if (removeIndex >= 0)
                    {
                        // remove this item
                        groups.RemoveAt(removeIndex);
                    }
                }

                // return value
                return groups;
            }
            #endregion
            
            #region GroupApps()
            /// <summary>
            /// returns a list of Apps
            /// </summary>
            public List<List<OVApp>> GroupApps()
            {
                // initial value
                List<List<OVApp>> groups = new List<List<OVApp>>();

                // local
                string last = "";

                // Create a new collection of 'OVApp' objects.
                List<OVApp> group = new List<OVApp>();

                // If the Apps collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(Apps))
                {
                    // Iterate the collection of OVApp objects
                    foreach (OVApp app in Apps)
                    {
                        // if we already have an item
                        if (TextHelper.Exists(last))
                        {
                            // if same as the Last
                            if (TextHelper.IsEqual(last, app.ShortName))
                            {
                                // Add this item
                                group.Add(app);
                            }
                            else
                            {
                                // new group

                                // Add this group
                                groups.Add(group);

                                // Create a new collection of 'OVApp' objects.
                                group = new List<OVApp>();

                                // Add this item
                                group.Add(app);
                            }
                        }
                        else
                        {
                            // create a new group
                            group = new List<OVApp>();

                            // Add this item
                            group.Add(app);
                        }

                        // set the last value
                        last = app.ShortName;
                    }

                    // add the last one
                    groups.Add(group);
                }
                
                // return value
                return groups;
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // path to the package folder
                string temp = @"ov\pkg";

                // Populate the path
                OVFolderControl.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), temp);
            }
            #endregion

        #endregion

        #region Properties

            #region Apps
            /// <summary>
            /// This property gets or sets the value for 'Apps'.
            /// </summary>
            public List<OVApp> Apps
            {
                get { return apps; }
                set { apps = value; }
            }
            #endregion

            #region CreateParams
            /// <summary>
            /// This property here is what did the trick to reduce the flickering.
            /// I also needed to make all of the controls Double Buffered, but
            /// this was the final touch. It is a little slow when you switch tabs
            /// but that is because the repainting is finishing before control is
            /// returned.
            /// </summary>
            protected override CreateParams CreateParams
            {
                get
                {
                    // initial value
                    CreateParams cp = base.CreateParams;

                    // Apparently this interrupts Paint to finish before showing
                    cp.ExStyle |= 0x02000000;

                    // return value
                    return cp;
                }
            }
        #endregion

        #endregion
    }
    #endregion

}
