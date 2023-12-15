# 🎵 Youtube MP3 and MP4 Downloader 🎵
![image](https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Logo_of_YouTube_%282013-2015%29.svg/668px-Logo_of_YouTube_%282013-2015%29.svg.png)

## Overview
This C# application allows users to download audio (MP3) and video (MP4, FLAC, WAV) files from YouTube. The application provides a simple graphical user interface to enter the YouTube video URL, choose the output folder, and select the desired file format.

## Features 📝
Download MP3, MP4, FLAC, and WAV files from YouTube videos.
Choose the output folder for downloaded files.
User-friendly interface with easy-to-use controls.
Option to convert downloaded MP4 files to other audio formats (MP3, FLAC, WAV).
Visual progress bar and status updates during download and conversion processes.
Responsive design with mouse hover effects on buttons for better user experience.

## Requirements 📙
.NET Framework
FFmpeg executable (FFmpeg.exe) in the same directory as the application executable.

## Usage ⚙️
Run the application (Youtube_MP3_and_MP4_Downloader.exe).
Enter the YouTube video URL.
Click the "Browse" button to choose the output folder.
Select the desired file format (MP3, MP4, FLAC, WAV).
Click the "Download" button to initiate the download or conversion process.
Monitor the progress bar and status updates.
Once the process is complete, the application will display the status and open the output folder.

## Note 📙
Make sure to have the FFmpeg executable (FFmpeg.exe) in the same directory as the application executable. FFmpeg is required for the conversion process.
This application utilizes the VideoLibrary library for interacting with YouTube videos.

## Acknowledgments
VideoLibrary: https://github.com/youtube/api-samples/tree/master/dotnet/Google.Apis.YouTube.Samples

## Author
[Mariusz]

Feel free to contribute, report issues, or suggest improvements!
