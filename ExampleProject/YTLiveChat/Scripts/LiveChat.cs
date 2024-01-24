using Godot;
using System;
using System.Text;
using Newtonsoft.Json;
using Youtube.Response;

namespace Youtube
{
    public partial class LiveChat : HttpRequest
    {

        [Export] String videoID;
        [Export] String apiKey;
        [Export] Double fetchTimer = 5; // in seconds

        [Signal]
        public delegate void newMessageListEventHandler(Response.LiveChatMessageArrayResponse msgList);
        private String liveChatID, pageToken;
        public Video videoInformation;
        private Timer FetchChatTimer;
        public override void _Ready()
        {
            videoInformation = GetNode<Video>("./Video");
            FetchChatTimer = GetNode<Timer>("./FetchTimer");
        }

        public void Start()
        {
            videoInformation.FetchVideoInformation(videoID, apiKey);
            FetchChatTimer.OneShot = true;
            FetchChatTimer.Stop();
        }
        public void Start(String videoID, String apiKey, Double fetchTimer = 5)
        {
            SetVideoID(videoID);
            SetApiKey(apiKey);
            SetFetchTimer(fetchTimer);
            videoInformation.FetchVideoInformation(videoID, apiKey);
            FetchChatTimer.OneShot = true;
            FetchChatTimer.Stop();
        }


        public void FetchChatMessages()
        {
            String url = pageToken == "" ?
            ($"https://youtube.googleapis.com/youtube/v3/liveChat/messages?liveChatId={liveChatID}&part=snippet%2CauthorDetails&key={apiKey}") :
            ($"https://youtube.googleapis.com/youtube/v3/liveChat/messages?liveChatId={liveChatID}&pageToken={pageToken}&part=snippet%2CauthorDetails&key={apiKey}");

            Request(url);
        }

        private void OnRequestComplete(int resultCode, int responseCode, String[] headers, byte[] body)
        {
            string responseBody = Encoding.UTF8.GetString(body);
            if (responseCode == 200)
            {
                Response.LiveChatMessageArrayResponse lcMsgList = JsonConvert.DeserializeObject<Response.LiveChatMessageArrayResponse>(responseBody);
                if (lcMsgList.items.Count > 0)
                    EmitSignal(SignalName.newMessageList, lcMsgList);
                pageToken = lcMsgList.nextPageToken;
            }
            else
            {
                GD.PrintErr("Error requestion video information");
                GD.PrintErr(responseBody);
            }
            FetchChatTimer.Start();
        }

        private void OnVideoInformationRetrieved(YouTubeVideoItem response)
        {
            String activeLiveChatId = response.liveStreamingDetails.activeLiveChatId;
            if (activeLiveChatId != "")
            {
                liveChatID = activeLiveChatId;
                FetchChatMessages();
            }
            else
            {
                GD.PrintErr("OnVideoInformationRetrieved: YouTubeVideoItem has no activeLiveChatId");
            }
        }
        public void SetApiKey(String apiKey)
        {
            this.apiKey = apiKey;
        }
        public void SetVideoID(String videoID)
        {
            this.videoID = videoID;
        }
        public void SetFetchTimer(Double seconds)
        {
            this.fetchTimer = seconds;
        }
    }
}
