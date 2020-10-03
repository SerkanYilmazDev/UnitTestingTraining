using System.Collections.Generic;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCall_ReturnEmptyUnprocessedVideos()
        {
            var videoRepository = new Mock<IVideoRepository>();
            var fileReader = new Mock<IFileReader>();

            videoRepository.Setup(v => v.GetUnprocessedVideos()).Returns(new List<Video>());

            var videoService = new VideoService(videoRepository.Object, fileReader.Object);

            var result = videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCall_ReturnListUnprocessedVideos()
        {
            var videoRepository = new Mock<IVideoRepository>();
            var fileReader = new Mock<IFileReader>();

            videoRepository.Setup(v => v.GetUnprocessedVideos()).Returns(new List<Video>()
                {
                    new Video()
                    {
                        Id = 1
                    },
                    new Video()
                    {
                        Id = 2
                    },
                    new Video()
                    {
                        Id = 3
                    }
                }
            );

            var videoService = new VideoService(videoRepository.Object, fileReader.Object);

            var result = videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }

        [Test]
        public void ReadVideoTitle_WhenSetPathIsNull_ReturnErrorParsing()
        {
            var videoRepository = new Mock<IVideoRepository>();
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns("");

            var videoService = new VideoService(videoRepository.Object, fileReader.Object);

            var result = videoService.ReadVideoTitle(It.IsAny<string>());

            Assert.That(result, Is.EqualTo("Error parsing the video."));
        }

        [Test]
        public void ReadVideoTitle_WhenCall_ReturnVideoTitle()
        {
            var videoRepository = new Mock<IVideoRepository>();
            var fileReader = new Mock<IFileReader>();

            var videoJsonString = JsonConvert.SerializeObject(new Video()
            {
                Title = "title"
            });
            
            fileReader.Setup(f => f.ReadAllText(It.IsAny<string>())).Returns(videoJsonString);
            
            var videoService = new VideoService(videoRepository.Object, fileReader.Object);
            var result = videoService.ReadVideoTitle(It.IsAny<string>());

            Assert.That(result, Is.EqualTo("title"));
        }
    }
}