# YT livechat fetcher

This is a small scene that given an API KEY and a VIDEO ID, it'll fetch chat messages and store them arranged just like youtube's api.

## Table of Contents

- [About](#about)
- [Installation](#installation)
- [Usage](#usage)

## About

To use this project it's as simple as dropping YTLiveChat folder into your project and instanciating it's scene onto whatever scene you want to have access to messages coming in.

## Installation

1.) Drop YTLiveChat into your project's root folder.

2.) Install Bewtibsift.Json using `` dotnet add package Newtonsoft.Json ``.

3.) Have a slot function to be signaled to when a new batch of messages arrive.

## Receiving function Example

```C#
public void PrintYTLiveChatMsg(LiveChatMessageArrayResponse LCMArray)
	{
		GD.Print("New messages!");
		foreach (LiveChatMessageResource msg in LCMArray.items)
		{
			GD.Print(msg.authorDetails.displayName, msg.snippet.displayMessage);
		}
	}
```

## Complete example project

Can be found under `` ExampleProject ``
