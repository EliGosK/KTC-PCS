using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
//using BusinessCore;

namespace EVOFramework.Windows.Forms
{
    public class MessageDialog
    {
        private MessageDialog() { }

        #region MessageDialog SingleItem -- Native.
        /// <summary>
        /// Show MessageDialog with full option.
        /// </summary>
        /// <returns></returns>
        public static MessageDialogResult ShowSingleItem(IWin32Window owner, string Title, string Text, MessageDialogIcon icon, MessageDialogButtons buttons, string[] TextButton, MessageDialogDefaultButtons defaultButton, IntPtr controlHandle)
        {
            MessageDialogSingle msgDlg = new MessageDialogSingle();
            StringBuilder sb = new StringBuilder(255);
            if (Title == null && owner != null && owner.Handle != IntPtr.Zero)
            {
                Win32.GetWindowText(owner.Handle, sb, sb.Capacity);
                msgDlg.Text = sb.ToString();
            }
            else
                msgDlg.Text = Title;

            msgDlg.TextDescription = Text;
            msgDlg.MessageDialogIcon = icon;
            msgDlg.MessageDialogButtons = buttons;
            msgDlg.MessageDialogDefaultButton = defaultButton;
            msgDlg.TextButtons = TextButton;
            msgDlg.SetCaptureControl(controlHandle);
            return msgDlg.ShowDialog(owner);
        }

        public static MessageDialogResult ShowSingleItem(IWin32Window owner, string Title, string Text, MessageDialogIcon icon, IntPtr controlHandle)
        {
            return ShowSingleItem(owner, Title, Text, icon, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, controlHandle);
        }

        public static MessageDialogResult ShowSingleItem(IWin32Window owner, string Title, string Text, MessageDialogIcon icon)
        {
            return ShowSingleItem(owner, Title, Text, icon, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, IntPtr.Zero);
        }

        public static MessageDialogResult ShowSingleItem(IWin32Window owner, string Title, string Text, IntPtr controlHandle)
        {
            return ShowSingleItem(owner, Title, Text, MessageDialogIcon.None, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, controlHandle);
        }

        public static MessageDialogResult ShowSingleItem(IWin32Window owner, string Title, string Text)
        {
            return ShowSingleItem(owner, Title, Text, MessageDialogIcon.None, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, IntPtr.Zero);
        }
        #endregion

        #region MessageDialog MultiItem -- Native
        public static MessageDialogResult ShowMultiItem(IWin32Window owner, string title, string text, MessageDialogIcon icon, MessageDialogButtons buttons, string[] textButton, MessageDialogDefaultButtons defaultButton, WarningLineItem[] warningList)
        {
            MessageDialogMulti dialog = new MessageDialogMulti();
            StringBuilder sb = new StringBuilder(255);
            if (title == null && owner != null && owner.Handle != IntPtr.Zero)
            {
                Win32.GetWindowText(owner.Handle, sb, sb.Capacity);
                dialog.Text = sb.ToString();
            }
            else
                dialog.Text = title;

            if (text != null)
                dialog.TextDescription = text;

            dialog.MessageDialogIcon = icon;
            dialog.MessageDialogButtons = buttons;
            dialog.MessageDialogDefaultButton = defaultButton;
            dialog.TextButtons = textButton;

            if (warningList != null)
            {
                for (int i = 0; i < warningList.Length; i++)
                {
                    dialog.Items.Add(warningList[i]);
                }
            }

            MessageDialogResult result = dialog.ShowDialog(owner);
            return result;
        }

        public static MessageDialogResult ShowMultiItem(IWin32Window owner, string title, string text, MessageDialogIcon icon, WarningLineItem[] warningList)
        {
            return ShowMultiItem(owner, title, text, icon, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, warningList);
        }

        public static MessageDialogResult ShowMultiItem(IWin32Window owner, string text, MessageDialogIcon icon, MessageDialogButtons buttons, string[] textButton, MessageDialogDefaultButtons defaultButton, WarningLineItem[] warningList)
        {
            return ShowMultiItem(owner, null, text, icon, buttons, textButton, defaultButton, warningList);
        }

        public static MessageDialogResult ShowMultiItem(IWin32Window owner, string text, MessageDialogIcon icon, WarningLineItem[] warningList)
        {
            return ShowMultiItem(owner, null, text, icon, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, warningList);
        }
        #endregion

        #region ShowMessage Business. [OK], Icon Warning
        public static MessageDialogResult ShowBusiness(IWin32Window owner, string Title, string MsgCD, string MsgDesc, IntPtr controlHandle)
        {
            return ShowSingleItem(owner, Title, String.Format("{0}\r\n{1}", MsgCD, MsgDesc), MessageDialogIcon.Warning, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, controlHandle);
        }

        public static MessageDialogResult ShowBusiness(IWin32Window owner, string text, IntPtr controlHandle)
        {
            return ShowSingleItem(owner, null, text, MessageDialogIcon.Warning, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, controlHandle);
        }
        public static MessageDialogResult ShowBusiness(IWin32Window owner, string text)
        {
            return ShowBusiness(owner, text, IntPtr.Zero);
        }

        public static MessageDialogResult ShowBusiness(IWin32Window owner, string Title, string MsgCD, string MsgDesc)
        {
            return ShowBusiness(owner, Title, MsgCD, MsgDesc, IntPtr.Zero);
        }
        public static MessageDialogResult ShowBusiness(IWin32Window owner, string MsgCD, string MsgDesc, IntPtr controlHandle)
        {
            return ShowBusiness(owner, null, MsgCD, MsgDesc, controlHandle);
        }
        public static MessageDialogResult ShowBusiness(IWin32Window owner, string MsgCD, string MsgDesc)
        {
            return ShowBusiness(owner, MsgCD, MsgDesc, IntPtr.Zero);
        }
        public static MessageDialogResult ShowBusiness(string MsgCD, string MsgDesc, IntPtr controlHandle)
        {
            return ShowSingleItem(null, MsgCD, MsgDesc, controlHandle);
        }
        public static MessageDialogResult ShowBusiness(string MsgCD, string MsgDesc)
        {
            return ShowBusiness(null, MsgCD, MsgDesc, IntPtr.Zero);
        }
        public static MessageDialogResult ShowBusiness(IWin32Window owner, Message message)
        {
            return ShowBusiness(owner, message.MessageCode, message.MessageDescription);
        }

        /// <summary>
        /// Show Business with formatting description
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static MessageDialogResult ShowBusiness(IWin32Window owner, Message message, object[] objs)
        {
            return ShowBusiness(owner, message.MessageCode, String.Format(message.MessageDescription, objs));
        }

        public static MessageDialogResult ShowBusiness(IWin32Window owner, Message message, IntPtr controlHandle)
        {
            return ShowBusiness(owner, message.MessageCode, message.MessageDescription, controlHandle);
        }
        public static MessageDialogResult ShowBusiness(IWin32Window owner, Message message, Control control)
        {
            return ShowBusiness(owner, message.MessageCode, message.MessageDescription, control.Handle);
        }


        public static MessageDialogResult ShowBusinessMultiItem(IWin32Window owner, string title, string text, WarningLineItem[] warningList)
        {
            return ShowMultiItem(owner, title, text, MessageDialogIcon.Warning, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, warningList);
        }

        public static MessageDialogResult ShowBusinessMultiItem(IWin32Window owner, string text, WarningLineItem[] warningList)
        {
            return ShowMultiItem(owner, null, text, MessageDialogIcon.Warning, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, warningList);
        }


        #endregion

        #region ShowMessage Confirmation [YesNoCancel], Icon Confirmation
        public static MessageDialogResult ShowConfirmation(IWin32Window owner, string Text, MessageDialogButtons buttons)
        {
            return ShowSingleItem(owner, null, Text, MessageDialogIcon.Question, buttons, null, MessageDialogDefaultButtons.Button1, IntPtr.Zero);
        }
        /// <summary>
        /// <para>MessageDialog show confirmation</para>
        /// <para>[YesNoCancel]</para>
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static MessageDialogResult ShowConfirmation(IWin32Window owner, string Text)
        {
            return ShowSingleItem(owner, null, Text, MessageDialogIcon.Question, MessageDialogButtons.YesNoCancel, null, MessageDialogDefaultButtons.Button1, IntPtr.Zero);
        }

        /// <summary>
        /// <para>MessageDialog show confirmation</para>
        /// <para>[YesNoCancel]</para>
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="Title"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static MessageDialogResult ShowConfirmation(IWin32Window owner, string Title, string Text)
        {
            return ShowSingleItem(owner, Title, Text, MessageDialogIcon.Question, MessageDialogButtons.YesNoCancel, null, MessageDialogDefaultButtons.Button1, IntPtr.Zero);
        }

        public static MessageDialogResult ShowConfirmation(IWin32Window owner, Message message, MessageDialogButtons buttons)
        {
            string msgDesc = message.MessageDescription;
            return ShowConfirmation(owner, msgDesc, buttons);
        }

        /// <summary>
        /// <para>MessageDialog show confirmation</para>
        /// <para>[YesNoCancel]</para>
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static MessageDialogResult ShowConfirmation(IWin32Window owner, Message message)
        {
            string msgDesc = message.MessageDescription;
            return ShowConfirmation(owner, msgDesc, MessageDialogButtons.YesNoCancel);
        }

        ///// <summary>
        ///// <para>MessageDialog show confirmation</para>
        ///// <para>[Yes] [No]</para>
        ///// </summary>
        ///// <param name="owner"></param>
        ///// <param name="Text"></param>
        ///// <returns></returns>
        //public static MessageDialogResult ShowConfirmationYesNo(IWin32Window owner, string Text)
        //{
        //    return ShowSingleItem(owner, null, Text, MessageDialogIcon.Question, MessageDialogButtons.YesNo, null, MessageDialogDefaultButtons.Button1, IntPtr.Zero);
        //}

        /// <summary>
        /// <para>MessageDialog show confirmation for Multi-Line</para>
        /// <para>[Yes,YesAll,No,NoAll,Cancel]</para>
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="Title"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static MessageDialogResult ShowConfirmationMultiline(IWin32Window owner, string Title, string Text)
        {
            return ShowSingleItem(owner, Title, Text, MessageDialogIcon.Question, MessageDialogButtons.Custom5, new string[] { "Yes", "Yes All", "No", "No All", "Cancel" }, MessageDialogDefaultButtons.Button1, IntPtr.Zero);
        }
        #endregion

        #region ShowMessage Information [OK], Icon Information
        public static MessageDialogResult ShowInformation(IWin32Window owner, string Title, string Text)
        {
            return ShowSingleItem(owner, Title, Text, MessageDialogIcon.Information, MessageDialogButtons.OK, null, MessageDialogDefaultButtons.Button1, IntPtr.Zero);

        }
        #endregion

        #region MessageDialog-MutiItem


        #endregion
    }
}
