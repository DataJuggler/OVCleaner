# OVCleaner
NVidia Omniverse Kit apps when they install newer versions, leave behind the old versions. This is a Windows Form .NET 6 app designed to discover and delete the old versions.

Specifically, this app reads the folders in the directory:
C:\Users\User\AppData\Local\ov\pkg

Replace User with your Windows user account name.

I had to include a few code changes that felt like hacks, because some of the directory 

Below is a screen shot of my machine before running OV Cleaner.

<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/InstalledOVApps.png>

And here is a screen shot of after:

<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/CleanedOVFolder.png>

The deps folder is skipped when OV Cleaner when the Discover button is clicked.
The deps folder on my machine is 55 gig, and I do not have any way of knowing what if any of these folders are out of date.
Many of the folders in deps directory has a kit.exe, and each copy says the last accessed date is today in Windows Properties, so I leaving this folder alone.

I estimate I cleaned about 9 - 15 gig from my machine. I had to run this a few times as I debugged the app and I can only test once.

To Install / Run:

Installed Version:

Install the release version of OV Cleaner. There should be a desktop icon installed on your desktop. Double click OV Cleaner Icon to run (The Wolf *).

Visual Studio 2022
You must have Windows Desktop Apps installed to run, or you will have to modify Visual Studio configuration.

1. Clone Project
2. Hit F5 or Debug Menu -> Start Debugging.

When you run the app, your OV Folder should be populated for you, unless you installed to another location.

3. Click the Discover button.

<img src=https://github.com/DataJuggler/SharedRepo/blob/master/Shared/Images/OVCleaner.png height=540 width=872>

A screen shot of OVCleaner after the Discover button was clicked. If you have duplicate versions in your ov folder, the Old Versions should be above 0, and the checkbox should be checked.

Note: One important limitation I left ouf of version 1, is the check boxes do not actually do anything, other than show you what is being cleaned. I should either make this read only or skip removal if unchecked. I wrote this app in a few hours yesterday and I have a dozen other projects I should have been working on, so I kind of rushed it.

I just thought I would share it here if anyone finds it useful. This app has been tested on a total of one computer, so please understand if something doesn't get deleted. If this happens, create an issue here and paste of a screen shot of your folder and I can probably fix it.

* The Wolf image / icon used comes from the Cleaner in Pulp Fiction. I have another project called The Wolf that cleans your users temp folder and reused the same image.

I have run the installed version, but I can only delete from my computer once, so I haven't thoroughly tested the install version.

I want to say Thank You to Advanced Installed for giving me a free license to help me give away free software.



