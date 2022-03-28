# group-15-swe-project

This is the AR Escape Room project coded by Durham University's Group 15 for the client IBM 

## How to access the files

In order to access the game files, you must have Unity 2020.3.21f1 installed. Also, for the ease of access, Unity Hub is heavily recommended. Clone this reporitory into an easily accessible location, and then open this project with Unity (easiest way is through Unity Hub). That way, you get access to all of the game's assets, scripts, prefabs and values set in the editor.

REMARK: In order to push this solution onto Github.com, two folders had to be zipped up. At group-15-swe-project\AR Escape Room\Library\Il2cppBuildCache\Android\arm64-v8a\Native\arm64-v8a you will find a zipped folder libilFiles.zip; unzip those files and, importantly, **place those files back in arm64-v8a folder** (libilFiles was just a temporary folder created to store these big files)
Similarly, at directory group-15-swe-project\AR Escape Room\Library\il2cpp_android_arm64-v8a\il2cpp_cache you'll find a zipped folder linkresult_EE1FA726403E5491B06083940CCD0578.zip. Unzip it and **keep the files inside the folder**

## How to get the app on your device

A pre-requisite for downloading the app onto your device is the operating system of the device being Android 9 or higher. The easiest download method is to compile the app straight from the Unity editor. By connecting your Android device to your PC/Laptop through a USB-C cable and going into 'File' -> 'Build and Run', exporting the app as an APK file and downloading it onto your device will commence.

NOTE: it is necessary to give your PC/Laptop permission to access the mobile devices' content for the download to commence. If you receive an error that the build cannot continue due to lack of access, you might need to enable USB debugging in Developer Options. Here is a [guide on how to open Developer Options] (https://www.samsung.com/uk/support/mobile-devices/how-do-i-turn-on-the-developer-options-menu-on-my-samsung-galaxy-device/) and here is how [you enable USB debugging] (https://developer.android.com/studio/debug/dev-options#enable). You know you've done it correctly if after pressing "Build and Run", a notification will appear on your phone to "Allow USB Debugging?" with the computer's RSA key fingerprint. 

It's also possible to simply transfer the AREscapeRoom.apk file onto your mobile device and unpack it from there.