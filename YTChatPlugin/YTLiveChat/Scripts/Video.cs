using Godot;
using System;
using System.Text;
using Youtube.Response;
using Newtonsoft.Json;

namespace Youtube
{
    public partial class Video : HttpRequest
    {
        [Signal]
        public delegate void RequestCompleteEventHandler(YouTubeVideoItem videoItem);

        public void FetchVideoInformation(String videoID, String apiKey)
        {
            string url = $"https://youtube.googleapis.com/youtube/v3/videos?part=liveStreamingDetails&id={videoID}&key={apiKey}";
            string[] headers = new String[1];
            headers[0] = "Accept: application/json";
            Request(url, headers);
        }


        private void OnRequestComplete(int resultCode, int responseCode, String[] headers, byte[] body)
        {
            string responseBody = Encoding.UTF8.GetString(body);
            if (responseCode == 200)
            {
                YouTubeVideoArrayResponse response = JsonConvert.DeserializeObject<YouTubeVideoArrayResponse>(responseBody);
                if (response.items[0] != null)
                {
                    EmitSignal(SignalName.RequestComplete, response.items[0]);
                }
                else
                {
                    GD.PrintErr("Response 200 but empty");

                }
            }
            else
            {
                GD.PrintErr("Video information request response not 200");
                GD.PrintErr(responseBody);
            }
        }
    }
}