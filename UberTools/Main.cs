using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;

using DamirM.AutoUpdate.External;
using DamirM.Modules;
using DamirM.CommonLibrary;

using UberTools.Class;

namespace NTHTools
{
    public partial class Main : Form
    {
        ToolsWindowsMenager toolsWindowsMenager;
        //AppDomain appDomainModule;

        private bool isApplicationDisabled;
        private ModuleManager moduleManager;

        public Main()
        {
            InitializeComponent();
            // Radi pretplatu na event, event vraca ukupan broj zapisa za sve tipove LogType, npr. koliko ERRORA je zabiljezeno
            Log.OnLogTypeNumberChange += new Log.delLogTypeInfo(Log_OnLogTypeNumberChange);
            // Zapisuje osnovne podatke o aplikaciji
            Log.StandardRunInfo();
            Log.Write(Static.conConnectionString, this, "Main", Log.LogType.INFO);

            // make instance of ToolsWindowsMenager
            toolsWindowsMenager = new ToolsWindowsMenager();
            toolsWindowsMenager.AddPanel(pToolsWindowsHolder);

            // stara progerss classa
            JobProgress isStatus = new JobProgress(this);
            isStatus.StatusChange += new JobProgress.delStatusChange(isStatus_StatusChange);

            JobProgress jobProgress = new JobProgress(this);


            // Novi module menager, sadrzi listu svijh UberTools modula
            moduleManager = new ModuleManager();
            moduleManager.OnActivateModule += new ModuleManager.delModuleObject(moduleMenager_OnActivateModule);

            // Ucitaj sve module u ModuleMenager, i pokazi ih na ToolStripMenu listi
            GetPluginsList(Application.StartupPath + "\\plugins");



            //GetAssemblies();
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            //throw new Exception("Kita");
        }

        //void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        //{
        //    Log.Write(e.Exception, this, "Application_ThreadException", Log.LogType.ERROR);
        //}

        //void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    Log.Write(e.ExceptionObject, this, "CurrentDomain_UnhandledException", Log.LogType.ERROR);
        //}

        void Log_OnLogTypeNumberChange(Log.LogType logType, int number)
        {
            // Uzimamo samo broj ERROR-a
            if (logType == Log.LogType.ERROR)
            {
                tssErrors.Text = "Errors: " + number.ToString();
            }
            else if (logType == Log.LogType.WARNING)
            {
                tssWarnings.Text = "Warnings: " + number.ToString();
            }
        }

        void isStatus_StatusChange(object sender, EventArgsStatusChange e)
        {
            tssStatus.Text = e.Message;
        }

        void child_Status(object text)
        {
            // TODO: neki kurac sam ovdje pijan radio
            if (text != null)
            {
                tssStatus.Text = (string)text;
                Application.DoEvents();
                JobProgress.Write((string)text);
            }
            else
            {
                JobProgress.Ready();
            }
        }


        #region MENU_REGION
        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menuTools_Click(object sender, EventArgs e)
        {
            bool isMidiParent = true;
            ChildBase frm = null;
            ToolStripMenuItem con = (ToolStripMenuItem)sender;

            if (con.Name == "menuTools_SeCT_Action")
            {
                frm = new FrmActions();
            }
            else if (con.Name == "menuTools_ClipBoard")
            {
                frm = new NTHClipBoard();
            }
            else if (con.Name == "menuTools_NTHMMSHelp")
            {
                frm = new NTHMMSHelp();
            }
            frm.Status += new ChildBase.delStatus(child_Status);
            if (isMidiParent)
            {
                frm.MdiParent = this;
            }
            frm.Show();
            Log.Write("Starting form " + frm.Name, this.Name, "menuTools_Click", Log.LogType.DEBUG);

        }
        #endregion


        private void FrmParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                tryIcon.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
            else
            {
                Log.End();
            }
        }

        private void tryIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tryIcon.Visible = false;
            this.Show();
        }

        private void menuHelp_Log_Click(object sender, EventArgs e)
        {
            Log form = new Log();
            try
            {
                form.Show(this);
            }
            catch
            {
                Log.Write("Log instance error", this.Name, "menuHelp_Log_Click", Log.LogType.ERROR);
            }
        }

        private void GetPluginsList(string moduleFolder)
        {
            //1- AppDomain appDomainInfo;
            Assembly assembly = null;
            Type pluginType = null;
            IModule plugin = null;
            ToolStripMenuItem tsmItem = null;

            // Exit if folder do not exists ?
            if (!Directory.Exists(moduleFolder))
            {
                Common.MakeAllSubFolders(moduleFolder);
                Log.Write("No plugin to load", this, "GetPluginsList", Log.LogType.WARNING);
                return;
            }
            // Get all dll files from directory
            string[] modulePathList = Directory.GetFiles(moduleFolder, "*.dll");
            // create temp domain for module info assemblys
            //1- appDomainInfo = AppDomain.CreateDomain("InfoDomain");
            // For each dll file check it is typeof UberToolsPluginAttribute
            foreach (string modulePath in modulePathList)
            {
                pluginType = null;
                assembly = null;
                // Try load assembly file 
                try
                {
                    assembly = null;
                    assembly = Assembly.LoadFile(modulePath);

                    //AssemblyName assemblyName = new AssemblyName();
                    //assemblyName.CodeBase = dllFile;
                    //appDomainModule.Load(assemblyName);
                    //ModuleLoader lp = (ModuleLoader)appDomainModule.CreateInstanceAndUnwrap("UberToolsPlugins"Assembly.GetExecutingAssembly().FullName, "DamirM.Module.ModuleLoader");
                    //ModuleLoader lp = (ModuleLoader)appDomainInfo.CreateInstanceAndUnwrap("UberToolsPlugins", "DamirM.Modules.ModuleLoader");
                    //ModuleLoader lp = (ModuleLoader)appDomainInfo.CreateInstanceAndUnwrap("UberTools", "UberTools.Class.ModuleLoader");

                    //assembly = lp.ReflectionOnlyLoadAssambly(modulePath);                    

                    ////    - - - - fix neki -    -- -- - -temp
                    //FileStream fs = new FileStream(modulePath, FileMode.Open);
                    //byte[] buffer = new byte[(int)fs.Length];
                    //fs.Read(buffer, 0, buffer.Length);
                    //fs.Close();


                    //assembly = Assembly.Load(buffer);

                    if (assembly != null)
                    {
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (type.IsAbstract) continue;
                            if (type.IsDefined(typeof(ModuleAttribute), true))
                            {
                                pluginType = type;
                                break;
                            }
                        }
                        if (pluginType != null)
                        {
                            Log.Write("Loading module info: " + pluginType.ToString(), this, "GetPluginsList", Log.LogType.DEBUG);

                            // Activite plugin, interface
                            plugin = (IModule)Activator.CreateInstance(pluginType);
                            // Create ModuleObject class in ModuleMenager and add it to list of moduls in sleep
                            ModuleObject moduleObject = moduleManager.Add(modulePath, plugin.Name);
                            // Show ToolStripMenu menu in main form
                            tsmItem = new ToolStripMenuItem(plugin.Name);

                            //plugin.GetModuleLog.OnLog += new ModuleLog.delLog(Log.Write);
                            if (plugin.Icon != null)
                            {
                                tsmItem.Image = plugin.Icon.ToBitmap();
                            }
                            // Bound menu click event with moduleObject Activete methot, when user clikc on menu it will load plugin and show it 
                            tsmItem.Click += new EventHandler(moduleObject.Activeite);
                            tsmPlugins.DropDownItems.Add(tsmItem);
                        }
                        else
                        {
                            Log.Write(new string[] { "Error loading module: " + modulePath, "Invalid module type" }, this, "GetPluginsList", Log.LogType.ERROR);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Write("Error loading plugin " + modulePath, this, "GetPluginsList", Log.LogType.DEBUG);
                    Log.Write(ex, this, "GetPluginsList", Log.LogType.ERROR);
                }
                finally
                {
                    // list assembly for this domain 
                    assembly = null;
                    plugin = null;
                    pluginType = null;
                    //1- GetAssemblies(appDomainInfo);
                    //1- AppDomain.Unload(appDomainInfo);
                }
            }



        }

        private void moduleMenager_OnActivateModule(ModuleObject moduleObject)
        {
            Assembly assembly = null;
            Type pluginType = null;
            IModule moduleInstance = null;

            try
            {
                if (moduleManager.IsActive(moduleObject.Instance) == true)
                {
                    MessageBox.Show("Aktivane vec");
                    return;
                }

                //AppDomainSetup info = new AppDomainSetup();
                
                //moduleObject.AppDomain = AppDomain.CreateDomain("ModuleActive" + new Random().Next(100), null, info);
                assembly = null;
                assembly = Assembly.LoadFile(moduleObject.Path);
                ///
                ////ModuleLoader lp = (ModuleLoader)moduleObject.AppDomain.CreateInstanceAndUnwrap("UberToolsPlugins", "DamirM.Module.ModuleLoader");
                //ModuleLoader lp = (ModuleLoader)moduleObject.AppDomain.CreateInstanceAndUnwrap("UberTools", "UberTools.Class.ModuleLoader");
                ////assembly = lp.LoadAssambly(moduleObject.Path);

                ////    - - - - fix neki -    -- -- - -temp
                //FileStream fs = new FileStream(moduleObject.Path, FileMode.Open);
                //byte[] buffer = new byte[(int)fs.Length];
                //fs.Read(buffer, 0, buffer.Length);
                //fs.Close();

                //assembly = Assembly.Load(buffer);

                if (assembly != null)
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.IsAbstract) continue;
                        // if this type have Module attribute then this is ubertools module
                        if (type.IsDefined(typeof(ModuleAttribute), true))
                        {
                            pluginType = type;
                            break;
                        }
                    }


                    if (pluginType != null)
                    {
                        Log.Write("Loading module: " + moduleObject.Name, this, "moduleMenager_OnActivateModule", Log.LogType.DEBUG);
                        // crete new domain, TEST
                        //AppDomain domain = AppDomain.CreateDomain("NewAppDomain");
                        //domain.CreateInstance(assembly.GetName,

                        //domain.CreateInstance(assembly.GetName().ToString(), pluginType.FullName);

                        // Create module instace 
                        moduleInstance = (IModule)Activator.CreateInstance(pluginType);
                        // subscribe to module unload event
                        moduleInstance.Unload += new ModuleManager.delModule(plugin_Unload);

                        // save instance of this module
                        moduleObject.Instance = moduleInstance;
                        
                        // set moduleobject to module instance
                        //moduleInstance.ModuleObject = moduleObject;

                        ModuleParams uberToolsPluginParams = new ModuleParams();
                        uberToolsPluginParams.DataPath = Common.BuildPath(Application.StartupPath, "data");
                        moduleInstance.ModuleParams = uberToolsPluginParams;

                        moduleInstance.GetModuleLog.OnLog += new ModuleLog.delLog(Log.Write);

                        ModuleMainFormBase moduleMainForm = moduleInstance.ShowDialog(this, true);
                        // subscribe to events
                        moduleMainForm.Enter += new EventHandler(toolsWindowsMenager.Activate);
                        moduleMainForm.Deactivate += new EventHandler(toolsWindowsMenager.LostFocus);

                        moduleMainForm.WindowState = FormWindowState.Maximized;
                        if (moduleMainForm.ToolsWindows() != null)
                        {
                            toolsWindowsMenager.AddControls(moduleMainForm.ToolsWindows());
                        }
                    }
                    else
                    {
                        Log.Write(new string[] { "Error loading module: " + moduleObject.Path, "Invalid module type" }, this, "moduleMenager_OnActivateModule", Log.LogType.ERROR);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write("Error loading plugin " + moduleObject.Path, this, "moduleMenager_OnActivateModule", Log.LogType.DEBUG);
                Log.Write(ex, this, "moduleMenager_OnActivateModule", Log.LogType.ERROR, true);
            }
        }

        void plugin_Unload(IModule module)
        {
            moduleManager.Remove(module);
            toolsWindowsMenager.Clear();
            //GetAssemblies(module.ModuleObject.AppDomain);
            //AppDomain.Unload(module.ModuleObject.AppDomain);
        }

        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            bool autoStart;
            DialogResult rez = MessageBox.Show("Check for updates", "AutoUpdate", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (rez == DialogResult.OK)
            {
                if (CheckForNewUpdate(out autoStart))
                {
                    rez = MessageBox.Show("New update avaible, start update now", "AutoUpdate", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (rez == DialogResult.OK)
                    {
                        StartAutoUpdate();
                    }
                }
                else
                {
                    MessageBox.Show("Application is up to date ", "AutoUpdate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void tUpdateChecker_Tick(object sender, EventArgs e)
        {
            tUpdateChecker.Enabled = false;
            try
            {
                //Log.delGenericLogMessage glm = new Log.delGenericLogMessage(Log.Write);
                //External update = new External(Static.conUpdateURL, Static.conProductID, glm);


                //External update = new External(Static.conUpdateURL, Static.conProductID, Static.conUsername, Static.conPassword, glm);

                //if (update.Product.updateReady)
                //{
                //    tssNewUpdate.Visible = true;
                //    Log.Write("New update ready", this, "tUpdateChecker_Tick", Log.LogType.DEBUG);
                //}
                //else
                //{
                //    Log.Write("Application on the last available version", this, "tUpdateChecker_Tick", Log.LogType.DEBUG);
                //}
                //if (!update.Product.allowStart)
                //{
                //    this.isApplicationDisabled = true;
                //}
                bool autoStart;
                CheckForNewUpdate(out autoStart);
                if (autoStart)
                {
                    Log.Write("Starting autoupdate...", this, "tUpdateChecker_Tick", Log.LogType.DEBUG);
                    StartAutoUpdate();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, this, "tUpdateChecker_Tick", Log.LogType.ERROR);
            }
        }
        private bool CheckForNewUpdate(out bool autoStart)
        {
            bool result = false;
            try
            {
                //Log.delGenericLogMessage glm = new Log.delGenericLogMessage(Log.Write);
                External update = new External(Static.conUpdateURL, Static.conProductName, Static.conUsername, Static.conPassword);

                if (update.Product.updateReady)
                {
                    tssNewUpdate.Visible = true;
                    Log.Write("New update ready", this, "CheckForNewUpdate", Log.LogType.DEBUG);
                    result = true;
                    autoStart = update.Product.autoStartUpdate;
                }
                else
                {
                    Log.Write("Application on the last available version", this, "CheckForNewUpdate", Log.LogType.DEBUG);
                    autoStart = false;
                }
                if (!update.Product.allowStart)
                {
                    // Ukloni kasnije
                    //this.isApplicationDisabled = true;
                }

            }
            catch (Exception ex)
            {
                autoStart = false;
                Log.Write(ex, this, "CheckForNewUpdate", Log.LogType.ERROR);
            }
            return result;
        }
        private static void StartAutoUpdate()
        {
            string putanja = Common.SetSlashOnEndOfDirectory(Application.StartupPath) + "AutoUpdate.exe";
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(putanja, string.Format("server={0} productname={1}", Static.conUpdateURL, Static.conProductName));
            if (process != null)
            {
                Application.Exit();
            }
        }

        private void GetAssemblies()
        {
            GetAssemblies(AppDomain.CurrentDomain);
        }
        private void GetAssemblies(AppDomain appDomain)
        {
            //Provide the current application domain evidence for the assembly.
            System.Security.Policy.Evidence asEvidence = appDomain.Evidence;
            //Load the assembly from the application directory using a simple name.

            //Create an assembly called CustomLibrary to run this sample.
            //currentDomain.Load("CustomLibrary", asEvidence);

            //Make an array for the list of assemblies.
            Assembly[] assems = appDomain.GetAssemblies();

            //List the assemblies in the current application domain.
            Log.Write(assems, this, "GetAssemblies", Log.LogType.DEBUG);
        }
    }
    
}
