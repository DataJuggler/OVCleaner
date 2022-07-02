
namespace OVCleaner
{

    #region class OVApp
    /// <summary>
    /// 
    /// </summary>
    public class OVApp
    {
        
        #region Private Variables
        private string name;
        private string fullPath;
        private List<OVApp> oldVersions;
        private long size;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new instance of a Name object
        /// </summary>
        /// <param name="name"></param>
        public OVApp(string name, string fullPath)
        {
            // store the args
            Name = name;
            FullPath = fullPath;

            // Attempt to get the size of the files in the directory
            Size = GetSize();

            // Create a new collection of 'OVApp' objects.
            OldVersions = new List<OVApp>();
        }
        #endregion

        #region Methods

            #region GetSize()
            /// <summary>
            /// returns the Size
            /// </summary>
            public long GetSize()
            {
                // initial value
                long size = 0;

                // local
                List<string> files = new List<string>();

                try
                {   
                    // attempt to get all files
                    files = FileHelper.GetFilesRecursively(FullPath, ref files);

                    // If the files collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(files))
                    {
                        // Iterate the collection of string objects
                        foreach (string file in files)
                        {
                            // Create a fileInfo
                            FileInfo fileInfo = new FileInfo(file);

                            // Append this files length
                            size += fileInfo.Length;
                        }
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("GetSize", "MainForm", error);
                }
                
                // return value
                return size;
            }
            #endregion
            
            #region ToString()
            /// <summary>
            /// method returns the Name when ToString is called.
            /// </summary>
            public override string ToString()
            {
                // return the Name
                return Name;
            }
            #endregion
            
        #endregion

        #region Properties

            #region DisplayName
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string DisplayName
            {
                get 
                {
                    // remove the weird name for Machinima
                    return ShortName + " " + Version.ToString() + "  Old Versions: " + OldVersions.Count;
                }
            }
            #endregion

            #region FullPath
            /// <summary>
            /// This property gets or sets the value for 'FullPath'.
            /// </summary>
            public string FullPath
            {
                get { return fullPath; }
                set { fullPath = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get 
                { 
                    // remove the weird name for Machinima
                    return name.Replace("-rel.1", "").Replace("-usd.", "-");
                }
                set { name = value; }
            }
            #endregion
            
            #region OldVersions
            /// <summary>
            /// This property gets or sets the value for 'OldVersions'.
            /// </summary>
            public List<OVApp> OldVersions
            {
                get { return oldVersions; }
                set { oldVersions = value; }
            }
            #endregion
            
            #region ReclaimableSize
            /// <summary>
            /// This read only property returns the value of ReclaimableSize from the object OldVersions.
            /// </summary>
            public long ReclaimableSize
            {
                
                get
                {
                    // initial value
                    long reclaimableSize = 0;
                    
                    // if OldVersions exists
                    if (OldVersions != null)
                    {
                        // set the return value
                        reclaimableSize = OldVersions.Sum(x => x.Size);
                    }
                    
                    // return value
                    return reclaimableSize;
                }
            }
            #endregion
            
            #region ShortName
            /// <summary>
            /// This read only property returns the value of ShortName from the object Name.
            /// </summary>
            public string ShortName
            {
                
                get
                {
                    // initial value
                    string shortName = "";
                    
                    // if Name exists
                    if (Name != null)
                    {
                        // set the return value
                        shortName = TextHelper.CapitalizeFirstChar(Name.Replace("-" + Version.ToString(), "").Replace("-rel.1", ""));
                    }
                    
                    // return value
                    return shortName;
                }
            }
            #endregion
            
            #region Size
            /// <summary>
            /// This property gets or sets the value for 'Size'.
            /// </summary>
            public long Size
            {
                get { return size; }
                set { size = value; }
            }
            #endregion
            
            #region Version
            /// <summary>
            /// This read only property returns the value of Version from the object Name.
            /// </summary>
            public Version Version
            {
                
                get
                {
                    // initial value
                    Version version = new Version();

                    // local
                    char[] delimiters = new char[] { '-' };
                    
                    // if Name exists
                    if (Name != null)
                    {
                        // get the words
                        List<Word> words = TextHelper.GetWords(Name, delimiters);

                        // If the words collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(words))
                        {
                            // get the las
                            Word lastWord = words.Last();

                            // get a temp string
                            string temp = lastWord.Text.Replace("usd.", "");

                            // get the firstChar
                            string firstChar = temp[0].ToString();

                            // if the first char is a number
                            if (NumericHelper.ParseInteger(firstChar, -1, -2) >= 0)
                            {
                                // parse the version
                                version = Version.Parse(temp);    
                            }
                        }
                    }
                    
                    // return value
                    return version;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
