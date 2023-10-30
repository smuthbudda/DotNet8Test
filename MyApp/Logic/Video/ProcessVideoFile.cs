
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;

namespace MyApp.Logic.Video
{
    public class ProcessVideoFile
    {

        private MyDbContext _context;

        public ProcessVideoFile(MyDbContext context)
        {
            _context = context;
        }
        public ProcessVideoFile()
        {

        }

        public async Task ConvertVideoToFrames()
        {
            string filePath = "C:\\Users\\jkdsa\\Source\\Repos\\smuthbudda\\DotNet8Test\\MyApp\\Logic\\Video\\Block start.mp4";
            string outputPath = Constants.VideoFramePath;

            try
            {

                using var engine = new Engine();
                var mp4 = new MediaFile { Filename = filePath };

                engine.GetMetadata(mp4);

                var i = 0;
                while (i < mp4.Metadata.Duration.TotalSeconds)
                {
                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(i) };
                    var outputFile = new MediaFile { Filename = string.Format("{0}\\image-{1}.jpeg", outputPath, i) };
                    engine.GetThumbnail(mp4, outputFile, options);
                    i++;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
