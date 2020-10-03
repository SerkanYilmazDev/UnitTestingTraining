using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        List<Video> GetUnprocessedVideos();
    }

    public class VideoRepository : IVideoRepository
    {
        public List<Video> GetUnprocessedVideos()
        {
            var videos = new List<Video>();
            
            using (var context = new VideoContext())
            {
                videos =
                    (from video in context.Videos
                        where !video.IsProcessed
                        select video).ToList();
            }

            return videos;
        }
    }
}