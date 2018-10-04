/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-09-07
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using EVOFramework;
using WorkFlowDiagram;
using EVOFramework.Windows.Forms;
using SystemMaintenance.UIDataModel;
using CommonLib;
using SystemMaintenance.Controller;
using SystemMaintenance.DTO;
using System.Drawing.Drawing2D;
using Message = EVOFramework.Message;
using SystemMaintenance.Validators;
using System.Data;
using System.Drawing.Imaging;

/* Fixed Record
 * =========
 * 2009-09-23 Fixed by: ASSI.Teerayut
 *     Fixed drag and drop of MenuTree and Favorite to support. Spare rectangle-area for click over item. 
 *     When occur mousedown and then occur trigger mousemove, it will calculate absolute xy-axis to support work area.
 * 2009-09-22 Added by: ASSI.Teerayut
 *     Add screen type "ScreenPane" to support opening form over on Menu form as pane panel.
 */
namespace SystemMaintenance.Forms
{
    [Screen("Menu", "Menu", eShowAction.Normal, eScreenType.Dialog, "Menu")]
    public sealed partial class MenuFrame : CustomizeBaseForm
    {
        /// <summary>
        /// Constant distance absolute on X-axis for ignore when user click drag button.
        /// </summary>
        private const int C_ABS_LIMITED_X_AXIS = 5;
        /// <summary>
        /// Constant distance absolute on Y-axis for ignore when user click drag button.
        /// </summary>
        private const int C_ABS_LIMITED_Y_AXIS = 5;

        #region Variables
        /// <summary>
        /// Default button size.
        /// </summary>
        public Size m_defaultButtonSize = new Size(100, 70);

        /// <summary>
        /// Flag to indicate that user has logout system.
        /// </summary>
        private bool m_bLogout = false;

        /// <summary>
        /// Program screen cache.
        /// </summary>
        private readonly ProgramScreenCache m_programScreenCache = null;
        /// <summary>
        /// Database screen cache.
        /// </summary>
        private readonly DatabaseScreenCache m_databaseScreenCache = null;
        /// <summary>
        /// Store image cache.
        /// </summary>
        private readonly ImageCache m_imageCache = null;
        /// <summary>
        /// Menu Controller
        /// </summary>
        private readonly MenuController m_menuController = null;
        /// <summary>
        /// List of buffer workflow document.
        /// </summary>
        private readonly List<WorkflowDocument> m_workflowDocumentList = new List<WorkflowDocument>();

        private int checknummenu = 1;

        private bool bShowMenuBar = true;
        private int iMenuWidth = 0;
        #endregion

        #region Constructor
        public MenuFrame()
        {
            InternalVariable.MenuFrame_Instance = this;

            InitializeComponent();

            if (!this.DesignMode)
            {
                m_databaseScreenCache = DatabaseScreenCache.GetInstance();
                m_programScreenCache = ProgramScreenCache.GetInstance();
                m_imageCache = ImageCache.GetInstance();

                m_menuController = new MenuController();
            }
        }
        #endregion

        #region Disposed
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            InternalVariable.MenuFrame_Instance = null;
        }
        #endregion

        #region Form events
        private void MenuFrame_Shown(object sender, EventArgs e)
        {
            // Load Image.
            picHeaderLogo.Image = Properties.Resources.MENU_HEADER;
            pnlHeaderLine.BackgroundImage = Properties.Resources.MENU_HEADER_HLINE;
            pnlLeftSideMenu.BackgroundImage = Properties.Resources.MENU_BAR_VLINE;
            pnlContentWorkflow.BackgroundImage = Properties.Resources.MENU_BACKGROUND;
            // Add by Pongthorn S. @ 2012-05-08
            pcbLogoff.Image = Properties.Resources.LOG_OFF;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(pcbLogoff, "Log off");
            // End Add.
        }

        private void MenuFrame_Load(object sender, EventArgs e)
        {
            //ScreenPermission.CanView = true;

            // Raise update text to current language.
            RaiseChangedLanguage();

            lblVersion.Text = Common.Version.NVL(string.Empty);
            lblUpdateDate.Text = Common.UpdateDate.NVL(string.Empty);
            lblUser.Text = Common.CurrentUserInfomation.Username.StrongValue + @"@" + Common.CurrentDatabase.Credential.DatabaseName;

            this.Text += "     Server : [" + Common.CurrentDatabase.Credential.ServerName + "]" +
                     "     DB Name : [" + Common.CurrentDatabase.Credential.DatabaseName + "]" +
                     "     User : [" + Common.CurrentUserInfomation.UserCD + "]";


            this.label1.Text = "";
        }


        private void MenuFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageDialogResult dr = MessageDialog.ShowConfirmation(null, new EVOFramework.Message(Messages.eConfirm.CFM9011.ToString()).MessageDescription, MessageDialogButtons.YesNo);

            //if (dr != MessageDialogResult.Yes)
            //{
            //    e.Cancel = true;
            //}
        }
        #endregion

        /// <summary>
        /// Flag to indicate that user has logout system.
        /// </summary>
        public bool IsLogout
        {
            get { return m_bLogout; }
        }
        public void Logout()
        {
            //MessageDialog.ShowConfirmation(this, "Do you want to logout from system.", MessageDialogButtons.YesNo);
            DialogResult dr = MessageBox.Show("Do you want to logout from system.", "Log off", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);  

            if (dr != DialogResult.Yes)
            {
                return;
            }

            UserController userController = new UserController();
            if (userController.Logout())
            {
                m_bLogout = true;
                this.Close();
                return;
            }

            MessageDialog.ShowBusiness(this, "Can't logout.", "Warning");
        }

        #region Change language

        public void RaiseChangedLanguage()
        {
            this.SuspendLayout();

            //MenuSubList menuList = m_menuManager.GetMenu();
            List<MenuSub> menuList = m_menuController.LoadMenuHierachy();

            // Load buffer workflow document list.
            m_workflowDocumentList.Clear();
            for (int i = 0; i < menuList.Count; i++)
            {
                WorkflowDocument doc = WorkflowDocument.LoadDatabase(Common.CurrentDatabase, menuList[i].WORKFLOW_ID.NVL(String.Empty), Common.CurrentUserInfomation.UserCD);
                m_workflowDocumentList.Add(doc);
            }

            // Load Menu control.
            menuTree1.BeginUpdateMenuBar();
            menuTree1.ClearMenuBars();
            for (int i = 0; i < menuList.Count; i++)
            {
                MenuSub menuSub = menuList[i];

                MenuBar menuBar = new MenuBar();
                menuBar.Host = menuTree1;
                menuBar.Text = menuSub.MENU_SUB_DESC.NVL(string.Empty);
                menuBar.Tag = menuSub;


                for (int iScreen = 0; iScreen < menuSub.MenuSubItemList.Count; iScreen++)
                {
                    MenuSubItemDTO menuSubItem = menuSub.MenuSubItemList[iScreen];

                    MenuItem menuItem = new MenuItem(menuBar);

                    DatabaseScreen dbScreen = m_databaseScreenCache[menuSubItem.SCREEN_CD.StrongValue];

                    if (dbScreen == null)
                    {
#if DEBUG
                        MessageDialog.ShowBusiness(this, "Not found screen code: " + menuSubItem.SCREEN_CD.StrongValue);
#endif
                        continue;
                    }
                    menuItem.Tag = menuSubItem;
                    menuItem.Text = dbScreen.ScreenDescription.StrongValue;

                    ImageItem imgItem = m_imageCache.Get(dbScreen.ImageCD.NVL(String.Empty));
                    Image img = null;
                    if (imgItem != null)
                    {
                        img = imgItem.ImageBin;
                    }
                    if (img != null)
                    {
                        try
                        {
                            menuItem.Image = ImageHelper.GetThumbnailImage(img, 16, 16);
                        }
                        catch (Exception err)
                        {
                            MessageDialog.ShowBusiness(this, err.Message);
                        }
                    }
                    menuBar.MenuItems.Add(menuItem);

                }


                menuTree1.AddMenuBar(menuBar);
            }

            if (menuTree1.MenuBars.Count > 0)
                menuTree1.MenuBarSelected = menuTree1.MenuBars[0];

            menuTree1.EndUpdateMenuBar();

            // Load Favorite button
            flowFavorite.Controls.Clear();
            LoadFavorite();

            this.ResumeLayout(false);
        }
        #endregion

        #region Utility

        /// <summary>
        /// Use this method to open screen by ScreenCode.
        /// </summary>
        /// <param name="ScreenCD"></param>
        private void OpenScreen(string ScreenCD)
        {
            ProgramScreen screen = m_programScreenCache[ScreenCD];
            if (screen == null)
            {
                MessageDialog.ShowBusiness(this, "Not found screen on class library.");
                return;
            }

            // check for view permission
            AuthorizedMaintenanceController authorizedMntCtrl = new AuthorizedMaintenanceController();
            DataTable dtUser = authorizedMntCtrl.LoadUserPermissionJoinScreen(ScreenCD);
            bool hasViewPermission = false;
            string Userpermission = string.Empty;
            string Grouppermission = string.Empty;

            if (dtUser != null)
            {
                // Check User Permission First
                DataRow[] dr = dtUser.Select(String.Format("USER_CD = '{0}'", Common.CurrentUserInfomation.UserCD.StrongValue));
                Userpermission = dr[0][PermissionValue.eUserPermission.FLG_VIEW.ToString()].ToString();
                if (dr.Length != 0)
                {
                    if (Userpermission == "1")
                        hasViewPermission = true;
                }
            }
            if (Userpermission == "2")
            {
                // Check Group Permission
                DataTable dtGroup = authorizedMntCtrl.LoadGroupPermissionJoinScreen(ScreenCD);

                if (dtGroup != null)
                {
                    DataRow[] dr = dtGroup.Select(String.Format("GROUP_CD = '{0}'", Common.CurrentUserInfomation.GroupCode.StrongValue));
                    Grouppermission = dr[0][PermissionValue.eGroupPermission.FLG_VIEW.ToString()].ToString();
                    if ((Grouppermission == "1"))
                        hasViewPermission = true;
                }
            }
            if (hasViewPermission)
            {
                screen.CreateScreen(null);
            }
            else
            {
                EVOFramework.Windows.Forms.MessageDialog.ShowInformation(this, "Permissionn Control"
                    , EVOFramework.Message.LoadMessage(Messages.eInformation.INF9004.ToString()).MessageDescription);
            }

        }

        #endregion

        #region "  Workflow Events  "
        private void workflowViewer1_ButtonLoad(object sender, WorkflowButtonArgs e)
        {
            ProgramScreen screen = ProgramScreenCache.GetInstance()[e.Data.TAG1];

            if (screen != null)
            {
                e.Text = screen.DatabaseScreenData.ScreenDescription.NVL(string.Empty);
                ImageItem imageItem = m_imageCache[screen.DatabaseScreenData.ImageCD.StrongValue];

                if (imageItem != null)
                {
                    if (e.Data != null && e.Data.FLG_VIEW == 1)
                    {
                        e.Image = imageItem.ImageBin;
                    }
                    else
                    {
                        Bitmap bmpPic = new Bitmap(imageItem.ImageBin);
                        Bitmap greyPic = MakeGrayscale(bmpPic);


                        e.Image = imageItem.ImageBin;
                    }

                }
            }
        }


        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }


        private void workflowViewer1_ButtonClick(object sender, WorkflowButton button)
        {
            OpenScreen(button.Data.TAG1);
        }
        #endregion

        #region " Menu Tree events "
        private void menuTree1_MenuItemClick(object sender, MenuItem item)
        {
            MenuSubItemDTO menuItem = item.Tag as MenuSubItemDTO;
            if (menuItem != null)
            {
                OpenScreen(menuItem.SCREEN_CD.NVL(string.Empty));
            }

        }

        private void menuTree1_MenuBarClick(object sender, MenuBar bar)
        {

        }

        private void menuTree1_MenuBarSelectedChange(object sender, MenuBar bar)
        {
            if (bar == null)
            {
                workflowViewer1.CloseDocument();
                return;
            }

            for (int i = 0; i < m_workflowDocumentList.Count; i++)
            {
                MenuSub menuSub = bar.Tag as MenuSub;
                if (menuSub != null)
                {
                    if (menuSub.WORKFLOW_ID.NVL(String.Empty) == m_workflowDocumentList[i].WorkflowID)
                    {
                        workflowViewer1.LoadDocument(m_workflowDocumentList[i]);
                        return;
                    }
                }
            }
        }

        private void menuTree1_MenuItemMouseOver(object sender, MenuItem item)
        {
            //#if DEBUG
            //            if (item == null)
            //            {
            //                StatusBarDesription = "";
            //            }
            //            else
            //            {
            //                Manager.MenuSubItem menuItem = item.Tag as Manager.MenuSubItem;
            //                if (menuItem != null)
            //                    StatusBarDesription = menuItem.MenuItem.ScreenCD;
            //            }

            //            this.UpdateStatusBarDescription();
            //#endif
        }
        #endregion

        #region Favorite Drag and Drop

        private ScreenFavoriteData m_holdFavorite = null;
        private bool m_bStartDrag = false;

        /// <summary>
        /// Load Favorite button
        /// </summary>
        private void LoadFavorite()
        {
            flowFavorite.Controls.Clear();

            List<string> screens = m_menuController.LoadScreenFavorite(Common.CurrentUserInfomation.UserCD);
            for (int i = 0; i < screens.Count; i++)
            {
                ScreenFavoriteData data = new ScreenFavoriteData();
                data.SCREEN_CD = screens[i];
                data.USER_ACCOUNT = Common.CurrentUserInfomation.UserCD.StrongValue;
                AddButtonFavorite(data);
            }
        }
        /// <summary>
        /// Add button into favorite.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool AddButtonFavorite(ScreenFavoriteData data)
        {
            // Check duplicate control on container.
            for (int i = 0; i < flowFavorite.Controls.Count; i++)
            {
                ScreenFavoriteData tagData = (ScreenFavoriteData)flowFavorite.Controls[i].Tag;
                if (tagData.SCREEN_CD == data.SCREEN_CD)
                {
                    MessageDialog.ShowBusiness(this, Message.LoadMessage(Messages.eValidate.VLM9017.ToString()));
                    return false;
                }
            }

            // Save favorite into Container.
            try
            {
                FavoriteButton button = new FavoriteButton();
                button.Tag = data;
                button.Size = m_defaultButtonSize;
                button.BackColor = flowFavorite.BackColor;
                button.BorderColor = ColorHelper.ShiftBrighness(button.BackColor, -100);

                DatabaseScreen dbScreen = m_databaseScreenCache.Get(data.SCREEN_CD);
                if (dbScreen != null)
                {
                    button.Text = dbScreen.ScreenDescription.NVL(string.Empty);

                    ImageItem imageItem = m_imageCache[dbScreen.ImageCD.StrongValue];
                    if (imageItem == null)
                        button.Image = Properties.Resources.img_not_found;
                    else
                        button.Image = imageItem.ImageBin;
                }

                button.MouseDown += new MouseEventHandler(btnFavorite_MouseDown);
                button.MouseMove += new MouseEventHandler(btnFavorite_MouseMove);
                button.MouseUp += new MouseEventHandler(btnFavorite_MouseUp);
                button.Click += new EventHandler(btnFavorite_Click);
                flowFavorite.Controls.Add(button);
                return true;
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, "Can't add favorite. " + err.Message);
                return false;
            }
        }



        /// <summary>
        /// Remove button from favorite flow and database.
        /// </summary>
        /// <param name="data"></param>
        private void RemoveButtonFavorite(ScreenFavoriteData data)
        {
            // Save favorite;
            try
            {
                // Remove button from favorite.
                m_menuController.RemoveScreenFavorite(Common.CurrentUserInfomation.UserCD, new NZString(null, data.SCREEN_CD));

                for (int i = 0; i < flowFavorite.Controls.Count; i++)
                {
                    ScreenFavoriteData tagData = (ScreenFavoriteData)flowFavorite.Controls[i].Tag;
                    if (tagData.SCREEN_CD == data.SCREEN_CD)
                    {
                        flowFavorite.Controls.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception err)
            {
                MessageDialog.ShowBusiness(this, "Can't add favorite. " + err.Message);
            }
        }

        #region Source drag-n-drop on MenuControl

        private void menuTree1_MenuItemDown(object sender, MenuItem item, System.Windows.Forms.MouseEventArgs e)
        {
            // Start hold object to prepare data before drag and drop.
            ScreenFavoriteData data = new ScreenFavoriteData();
            data.USER_ACCOUNT = Common.CurrentUserInfomation.UserCD.StrongValue;
            data.SCREEN_CD = ((MenuSubItemDTO)item.Tag).SCREEN_CD.StrongValue;
            data.DIRECTION = ScreenFavoriteData.eDirection.FromMenu;

            m_holdFavorite = data;
            m_bStartDrag = false;
            m_lastPoint = e.Location;
        }

        private void menuTree1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_holdFavorite != null && !m_bStartDrag && m_lastPoint != e.Location)
            {
                bool bAllowDrag = false;
                if (Math.Abs(e.Location.X - m_lastPoint.X) >= C_ABS_LIMITED_X_AXIS)
                {
                    bAllowDrag = true;
                }

                if (!bAllowDrag && Math.Abs(e.Location.Y - m_lastPoint.Y) >= C_ABS_LIMITED_Y_AXIS)
                {
                    bAllowDrag = true;
                }

                if (!bAllowDrag)
                    return;

                //Start drag-n-drop.
                m_bStartDrag = true;


                // Synchronize call method.
                DragDropEffects effect = DoDragDrop(m_holdFavorite, DragDropEffects.Copy);
                if (effect != DragDropEffects.Copy)
                {
                    m_holdFavorite = null;
                    m_bStartDrag = false;
                }
            }
        }

        private void menuTree1_MouseUp(object sender, MouseEventArgs e)
        {
            // Release drag-n-drop.
            m_holdFavorite = null;
            m_bStartDrag = false;
        }
        #endregion

        #region Source drag-n-drop on Button favorite
        Point m_lastPoint = Point.Empty;

        private void btnFavorite_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            ScreenFavoriteData data = new ScreenFavoriteData();
            data.USER_ACCOUNT = Common.CurrentUserInfomation.UserCD.StrongValue;
            data.SCREEN_CD = ((ScreenFavoriteData)btn.Tag).SCREEN_CD;
            data.DIRECTION = ScreenFavoriteData.eDirection.FromFavorite;

            m_holdFavorite = data;
            m_bStartDrag = false;
            m_lastPoint = e.Location;

        }

        private void btnFavorite_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_holdFavorite != null && !m_bStartDrag && m_lastPoint != e.Location)
            {
                bool bAllowDrag = false;
                if (Math.Abs(e.Location.X - m_lastPoint.X) >= C_ABS_LIMITED_X_AXIS)
                {
                    bAllowDrag = true;
                }

                if (!bAllowDrag && Math.Abs(e.Location.Y - m_lastPoint.Y) >= C_ABS_LIMITED_Y_AXIS)
                {
                    bAllowDrag = true;
                }

                if (!bAllowDrag)
                    return;

                m_bStartDrag = true;
                if (DoDragDrop(m_holdFavorite, DragDropEffects.Move) != DragDropEffects.Move)
                {
                    m_holdFavorite = null;
                    m_bStartDrag = false;
                }
            }
        }

        private void btnFavorite_MouseUp(object sender, MouseEventArgs e)
        {
            m_holdFavorite = null;
            m_bStartDrag = false;
        }
        #endregion

        #region " Drop on flow favorite "
        private void flowFavorite_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ScreenFavoriteData)))
            {
                ScreenFavoriteData data = (ScreenFavoriteData)e.Data.GetData(typeof(ScreenFavoriteData));
                e.Effect = (data.DIRECTION == ScreenFavoriteData.eDirection.FromMenu) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void flowFavorite_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ScreenFavoriteData)))
            {
                ScreenFavoriteData data = (ScreenFavoriteData)e.Data.GetData(typeof(ScreenFavoriteData));

                if (data.DIRECTION == ScreenFavoriteData.eDirection.FromMenu)  // if drag from MenuControl, it will copy to favorite.
                {
                    if (AddButtonFavorite(data))
                    {
                        // Check before add
                        MenuFrameValidator validator = new MenuFrameValidator();
                        ErrorItem errorItem = validator.CheckExistFavorite(Common.CurrentUserInfomation.UserCD, data.SCREEN_CD.ToNZString());

                        if (errorItem != null)
                        {
                            MessageDialog.ShowBusiness(this, errorItem.Message);
                            return;
                        }

                        m_menuController.AddScreenFavorite(new NZString(null, data.USER_ACCOUNT), new NZString(null, data.SCREEN_CD));
                    }
                }
            }
        }
        #endregion

        #region " Drop on MenuControl "
        private void menuTree1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ScreenFavoriteData)))
            {
                ScreenFavoriteData data = (ScreenFavoriteData)e.Data.GetData(typeof(ScreenFavoriteData));
                if (data.DIRECTION == ScreenFavoriteData.eDirection.FromFavorite)
                    e.Effect = e.AllowedEffect;
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void menuTree1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ScreenFavoriteData)))
            {
                ScreenFavoriteData data = (ScreenFavoriteData)e.Data.GetData(typeof(ScreenFavoriteData));

                if (data.DIRECTION == ScreenFavoriteData.eDirection.FromFavorite)
                {
                    RemoveButtonFavorite(data);
                }
            }
        }
        #endregion

        void btnFavorite_Click(object sender, EventArgs e)
        {
            ScreenFavoriteData data = (ScreenFavoriteData)((Button)sender).Tag;

            OpenScreen(data.SCREEN_CD);
        }
        #endregion

        #region Menu Item events
        private void mnuLogout_Click(object sender, EventArgs e)
        {
            this.Logout();
        }
        #endregion

        #region Panel ScreenPane
        /// <summary>
        /// Assign form to display on ScreenPane.
        /// </summary>
        /// <param name="form"></param>
        public void AssignFormToScreenPane(EVOForm form)
        {
            pnlScreenPane.Close();

            pnlScreenPane.AssignForm(form);
            ShowScreenPane();
        }

        /// <summary>
        /// Show ScreenPane on Top.
        /// </summary>
        public void ShowScreenPane()
        {
            pnlScreenPane.BringToFront();
        }

        /// <summary>
        /// Hide ScreenPane.
        /// </summary>
        public void HideScreenPane()
        {
            pnlScreenPane.SendToBack();
        }
        #endregion

        private void pnlLeftSideMenu_DoubleClick(object sender, EventArgs e)
        {
            if (bShowMenuBar)
            {
                splitBody.SplitterDistance = 0;
                bShowMenuBar = false;
            }
            else
            {
                splitBody.SplitterDistance = 253;
                bShowMenuBar = true;
            }
        }

        private void pcbLogoff_Click(object sender, EventArgs e)
        {
            this.Logout();
        }
    }
}