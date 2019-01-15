# MyOxygen.Libraries-XamarinLibrary
A collection of libraries to prevent writing duplicate code for multiple projects.

## Purpose

Xamarin.Forms has numerous plugins to facilitate cross platform development. These plugins are normally used to access platform specific code in such a way to reduce code and ease portability. Unfortunately, there are cases where documentation is scarse and/or the resulting code can further be minimised with another layer. 

The purpose of this library is to provide that additional layer to facilitate access to these plugins without having to constantly include a specific file containing the same methods for every project.

This library is **not** designed for project-specific libraries (example: access application folder in-app). These should be kept with their respective projects, and should not be brought into this library.

## Testing

For every change and/or new control added to this library, it can be tested by adding it to the [NugetTester](https://github.com/MyOxygen/NugetTester-XamarinLibraryTester). If it doesn't work in **NugetTester**, it won't work in any other project.

## Libraries

To date, the following libraries are part of this collection:

### Network

The **Network** library adds an additional layer on top of the [Connectivity Plugin](https://github.com/jamesmontemagno/ConnectivityPlugin). The library simply allows the developer to quickly check for WiFi or Mobile Data connection, set an event for connection (type) changes, and encrypt URL parameters to be URL-safe.

The following methods are available:

- `IsConnectionWifiOrCellular`
  - Checks whether the connection is Wifi or Mobile Data. Returns `boolean` true for connected to either, otherwise false.
- `IsConnectionWifi`
  - Checks whether the connection is Wifi only. Returns `boolean` true for connected to Wifi, otherwise false.
- `IsConnectionCellular`
  - Checks whether the connection is Mobile Data only. Returns `boolean` true for connected to Mobile Data, otherwise false.
- `EncodeForUrl(string parameter)`
  - Encodes the `parameter` to be URL-safe. Returns the parameter as a URL-encoded `string`.
- `SetOnConnectionChangedEvent`
  - Sets the connection changed event handler.
- `SetOnConnectionTypeChangedEvent`
  - Sets the connection type changed event handler.

### SimpleDialogs

The **SimpleDialogs** library adds an addition layer on top of [ACR.UserDialogs](https://github.com/aritchie/userdialogs). The library allows the developer to create dialogs easily and with minimal code. Custom dialogs are not implemented.

The following methods are available:

- `InfoDialog`
  - Creates a standard dialog with a title, text and a "close dialog" button. There is no limit to the number of overlapping dialogs that can be shown.
- `LoadingDialogShow`
  - Creates a loading dialog with the specified text. This method can be called again to change the text. Only one loading dialog can be shown at any time.
- `LoadingDialogDismiss`
  - Closes the loading dialog, if it is on display.
- `EntryDialog`
  - Creates a dialog with one entry control to allow the user to type something in.
- `ConfirmationDialog`
  - Creates a dialog with positive or negative buttons. This is commonly used with _Are you sure?_ questions. Returns `boolean` true for positive answer, otherwise false.
- `YesNoDialog`
  - Creates a `ConfirmationDialog` with yes/no buttons. Returns `boolean` true for _Yes_, otherwise false.

Other methods are available to set generic dialogs (for example, warning dialogs, information, success, error etc). These incorporate hard-coded strings, which can be accessed by calling `SimpleDialogs.Strings`.
