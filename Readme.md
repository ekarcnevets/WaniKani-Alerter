## WaniKani Alerter
(Name temporary).  A simple background application that polls the WaniKani API,
notifying you when you have above a certain number of reviews.

### Installation
WaniKani Alerter requires the .NET 4.5 runtime.  You can download it
[here][dotnet45].  After this, merely move the executable file and its dll
files to a folder of your choice and run the program.

If you wish to set it as a startup item, for now I recommend setting it as a
task in Task Scheduler, triggered when you log on.

A proper installer providing start menu and desktop shortcuts, a startup item,
uninstaller, etc, will come shortly.

### Uninstallation
To remove the program, just delete it from the location you put it in.  If you
want to also remove the user settings store, it can be found at
`%LOCALAPPDATA%/WaniKaniAlerter`.

### Suggestions, feedback, and bug reporting
Please make any issues or feature suggestions [as an issue on GitHub][ghissue].
For any other feedback, please [email me][email].

[ghissue]: https://github.com/adituv/WaniKani-Alerter/issues/new
[email]: mailto:aditu.venyhandottir@gmail.com
[dotnet45]: http://www.microsoft.com/en-us/download/details.aspx?id=30653