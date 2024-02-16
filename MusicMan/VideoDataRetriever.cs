using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;


namespace MusicMan
{
    public class VideoDataRetriever
    {
        private string              m_VideoId;
        private YoutubeClient       m_Client;
        private StreamManifest      m_StreamManifest;
        private Stream              m_StreamClient;

        public VideoDataRetriever(string VideoId) 
        {
            m_Client = new YoutubeClient();
            m_VideoId = VideoId;
        }

        public void GetStream()
        {
            var task = Task.Run(async() => m_StreamManifest = await m_Client.Videos.Streams.GetManifestAsync(m_VideoId));
            task.Wait();
            //RetrieveStream.Start();
            //RetrieveStream.Wait();
            Debug.Write("Done");
        }

        private async void RetrieveStreamManifest()
        {
            try
            {
                m_StreamManifest = await m_Client.Videos.Streams.GetManifestAsync(m_VideoId);
            }
            catch (Exception ex)
            {
                Debug.Write($"Failed to retrieve the stream manifest: {ex}");
            }
        }

        private async void Worker_RetrieveAudioOnlyStream(object sender, DoWorkEventArgs e) 
        {
            m_StreamClient = await RetrieveAudioOnlyStream(m_StreamClient);

            if (m_StreamManifest == null)
            {
                throw new Exception("Ahhhhhhhhhh!!!!!!!!");
            }
        }

        private async Task<Stream> RetrieveAudioOnlyStream(Stream client)
        {

            try
            {
                var audioOnlyStream = m_StreamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                client = await m_Client.Videos.Streams.GetAsync(audioOnlyStream);
                return client;
            }
            catch (Exception ex)
            {
                Debug.Write($"Failed to retrieve the stream: {ex}");
                return null;
            }
        }
    }
}
