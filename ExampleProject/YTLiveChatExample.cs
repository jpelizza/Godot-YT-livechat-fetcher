using Godot;
using System;
using Youtube;
using Youtube.Response;

public partial class YTLiveChatExample : Node2D
{
	LiveChat lc;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lc = GetNode<LiveChat>("./LiveChat");
		lc.SetApiKey("ABC123");
		lc.SetVideoID("XYZ789");
		lc.SetFetchTimer(5);

		lc.Start();
		// lc.Start("ABC123","ZXY789",5);
	}

	public void PrintYTLiveChatMsg(LiveChatMessageArrayResponse LCMArray)
	{
		GD.Print("New messages!");
		foreach (LiveChatMessageResource msg in LCMArray.items)
		{
			GD.Print(msg.authorDetails.displayName, msg.snippet.displayMessage);
		}
	}
}
