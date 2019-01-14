using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace MyOxygen.Libraries
{
    public static class SimpleDialogs
    {
        private static IProgressDialog loadingDialog;
        private static IDisposable standardDialog;
        private static IDisposable entryDialog;


        /// <summary>
        /// Displays a standard message box.
        /// </summary>
        /// <param name="title">Title of the dialog.</param>
        /// <param name="text">Content of the dialog box.</param>
        /// <param name="okText">Text to close the dialog (default: "OK").</param>
        public static void InfoDialog(string title, string text, string okText = "OK")
        {
            Device.BeginInvokeOnMainThread(() =>
                standardDialog = UserDialogs.Instance.Alert(title: title, message: text, okText: okText));
        }


        /// <summary>
        /// Displays a generic loading dialog.
        /// </summary>
        /// <param name="text">Text to display to the user.</param>
        public static void LoadingDialogShow(string text)
        {
            if (loadingDialog == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                    loadingDialog = UserDialogs.Instance.Loading(
                       title: text,
                       show: true));
            }
            else if (!loadingDialog.IsShowing)
            {
                loadingDialog.Title = text;
                loadingDialog.Show();
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => loadingDialog.Title = text);
            }
        }


        /// <summary>
        /// Closes the loading dialog if it is open.
        /// </summary>
        public static void LoadingDialogDismiss()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if ((loadingDialog != null) && (loadingDialog.IsShowing))
                {
                    loadingDialog.Hide();
                }
            });
        }


        /// <summary>
        /// Displays a generic entry dialog, where the user can type data in.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="message">Dialog display message.</param>
        /// <param name="entryContent">Entry content.</param>
        /// <param name="onEntryCompletionHandler">On entry completion handler.</param>
        public static void EntryDialog(string title, string message, string entryContent, Action<string> onEntryCompletionHandler)
        {
            EntryDialog(title, message, entryContent, onEntryCompletionHandler, Strings.OkString, Strings.CancelString);
        }


        /// <summary>
        /// Displays an entry dialog, where the user can type data in.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="message">Dialog display message.</param>
        /// <param name="entryContent">Entry content.</param>
        /// <param name="onEntryCompletionHandler">On entry completion handler.</param>
        /// <param name="completeButtonText">Complete button text.</param>
        /// <param name="cancelButtonText">Cancel button text.</param>
        public static void EntryDialog(string title, string message, string entryContent, Action<string> onEntryCompletionHandler, string completeButtonText, string cancelButtonText)
        {
            PromptConfig promptConfig = new PromptConfig()
            {
                Title = title,
                Text = entryContent,
                Message = message,
                CancelText = cancelButtonText,
                IsCancellable = true,
                OkText = completeButtonText,
                OnAction = (result) =>
                {
                    if (result.Ok)
                    {
                        onEntryCompletionHandler(result.Text);
                    }
                }
            };
            Device.BeginInvokeOnMainThread(() =>
                entryDialog = UserDialogs.Instance.Prompt(promptConfig));
        }


        /// <summary>
        /// Displays a confirmation dialog, prompting the user for a yes/no response.
        /// </summary>
        /// <returns>The yes/no response, where <see langword="true"/> is a "Yes" response.</returns>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        public static Task<bool> YesNoDialogAsync(string title, string message)
        {
            return ConfirmationDialogAsync(title, message, Strings.YesString, Strings.NoString);
        }


        /// <summary>
        /// Displays a generic confirmation dialog.
        /// </summary>
        /// <returns>The user response, where <see langword="true"/> is a positive" response.</returns>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="confirmButtonText">Confirmation button text.</param>
        /// <param name="denyButtonText">Deny button text.</param>
        public static Task<bool> ConfirmationDialogAsync(string title, string message, string confirmButtonText, string denyButtonText)
        {
            ConfirmConfig confirmConfig = new ConfirmConfig()
            {
                Title = title,
                Message = message,
                OkText = confirmButtonText,
                CancelText = denyButtonText
            };

            return UserDialogs.Instance.ConfirmAsync(confirmConfig);
        }


        public static void GenericSystemErrorDialog(string message)
        {
            InfoDialog(Strings.SystemErrorString, message);
        }

        public static void GenericUserErrorDialog(string message)
        {
            InfoDialog(Strings.UserErrorString, message);
        }

        public static void GenericSuccessDialog(string message)
        {
            InfoDialog(Strings.SuccessString, message);
        }

        public static void GenericWarningDialog(string message)
        {
            InfoDialog(Strings.WarningString, message);
        }

        public static void GenericInformationDialog(string message)
        {
            InfoDialog(Strings.InformationString, message);
        }

        public static void GenericHelpDialog(string message)
        {
            InfoDialog(Strings.HelpString, message);
        }


        public static class Strings
        {
            public static string OkString = "OK";
            public static string CancelString = "Cancel";
            public static string YesString = "Yes";
            public static string NoString = "No";
            public static string SystemErrorString = "Error";
            public static string UserErrorString = "Oops!";
            public static string SuccessString = "Success";
            public static string WarningString = "Warning";
            public static string InformationString = "Information";
            public static string HelpString = "Help";
        }
    }
}
