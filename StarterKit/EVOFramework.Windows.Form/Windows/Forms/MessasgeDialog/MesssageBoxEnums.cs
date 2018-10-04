using System;
using System.Collections.Generic;
using System.Text;

namespace EVOFramework.Windows.Forms
{
    public enum MessageDialogButtons
    {
        OK,
        OKCancel,
        YesNo,
        YesNoCancel,
        Custom1,
        Custom2,
        Custom3,
        Custom4,
        Custom5,
        Custom6,
    }
    public enum MessageDialogDefaultButtons
    {
        Button1,
        Button2,
        Button3,
        Button4,
        Button5,
        Button6,
    }

    public enum MessageDialogResult
    {
        OK,
        Cancel,
        Yes,
        No,
        Custom1,
        Custom2,
        Custom3,
        Custom4,
        Custom5,
        Custom6,
    }

    // Summary:
    //     Specifies constants defining which information to display.
    public enum MessageDialogIcon
    {
        // Summary:
        //     The message box contain no symbols.
        None = 0,
        //
        // Summary:
        //     The message box contains a symbol consisting of white X in a circle with
        //     a red background.
        Error = 16,
        //
        // Summary:
        //     The message box contains a symbol consisting of a white X in a circle with
        //     a red background.
        Hand = 16,
        //
        // Summary:
        //     The message box contains a symbol consisting of white X in a circle with
        //     a red background.
        Stop = 16,
        //
        // Summary:
        //     The message box contains a symbol consisting of a question mark in a circle.
        Question = 32,
        //
        // Summary:
        //     The message box contains a symbol consisting of an exclamation point in a
        //     triangle with a yellow background.
        Exclamation = 48,
        //
        // Summary:
        //     The message box contains a symbol consisting of an exclamation point in a
        //     triangle with a yellow background.
        Warning = 48,
        //
        // Summary:
        //     The message box contains a symbol consisting of a lowercase letter i in a
        //     circle.
        Information = 64,
        //
        // Summary:
        //     The message box contains a symbol consisting of a lowercase letter i in a
        //     circle.
        Asterisk = 64,
    }

}
