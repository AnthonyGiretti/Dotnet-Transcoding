// See https://aka.ms/new-console-template for more information


using System.Resources;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official);

var inputPath = "C:\\temp\\Transcoding\\Input\\sample.MOV";
var outputPath = "C:\\temp\\Transcoding\\Output\\sample.mp4";

//var fileInfo = new FileInfo("C:\\temp\\Transcoding\\Input\\sample.MOV");

//var conversion = await FFmpeg.Conversions.FromSnippet.Convert(fileInfo.FullName, "C:\\temp\\Transcoding\\Output\\sample.mp4");

IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(inputPath);

var videoStream = mediaInfo.VideoStreams.First().SetSize(VideoSize.Hd480).SetCodec(VideoCodec.h264);
var audioStream = mediaInfo.AudioStreams.First().SetCodec(AudioCodec.aac);

await FFmpeg.Conversions.New()
            .AddStream(videoStream)
            .AddStream(audioStream)
            .SetOutput(outputPath)
            .Start();

Console.ReadLine();
