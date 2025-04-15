# PC Scan App
I created a basic diagnostic tool for windows, that provides information about computer software and hardware components:
- windows full information
- BIOS data
- processor
- motherboard
- memory
- storage
- graphics card

# Requirements
1) Operating systems:
- Windows 2000 (with limitations)
- Windows XP / Vista
- Windows 7 / 8 / 8.1
- Windows 10 / 11
- Windows Server 2003 -> 2022
- Windows Embedded (not always, based on edition)
2) Run requirements:
- .NET runtime: https://dotnet.microsoft.com/en-us/download
(most of the systems already has it, if not, when first launching the app, the pop up message will be shown for runtime installer)

# Install
All the files you'll find in releases...
You can either install software by setup.msi or download .rar or .zip package, unpack it and run .exe application.

# Usage
Run PC Scan App.exe

# How the application work?
Software is written in design pattern MVVM using WPF C# GUI .NET framework, it fetches data from WMI System Management package and prints it on the UI.

# Future updates
2025:
- GUI better look
- More components

# Licence
Product is licenced under GPLv3.

# What is this branch?
Default repo branch
