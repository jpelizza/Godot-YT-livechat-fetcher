using System;
using Godot;
using Godot.Collections;

namespace Youtube
{
    namespace Response
    {
        public partial class YouTubeVideoArrayResponse : GodotObject
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public Array<YouTubeVideoItem> items { get; set; }
            public PageInfo pageInfo { get; set; }
        }

        public partial class YouTubeVideoItem : GodotObject
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public string id { get; set; }
            public LiveStreamingDetails liveStreamingDetails { get; set; }
        }



        public partial class LiveStreamingDetails : GodotObject
        {
            public string activeLiveChatId { get; set; }
        }

        public partial class PageInfo : GodotObject
        {
            public int totalResults { get; set; }
            public int resultsPerPage { get; set; }
        }

        public partial class LiveChatMessageArrayResponse : GodotObject
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public string nextPageToken { get; set; }
            public ulong pollingIntervalMillis { get; set; }
            public DateTime offlineAt { get; set; }
            public PageInfo pageInfo { get; set; }
            public Array<LiveChatMessageResource> items { get; set; }
        }

        public partial class LiveChatMessageResource : GodotObject
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public string id { get; set; }
            public Snippet snippet { get; set; }
            public AuthorDetails authorDetails { get; set; }
        }

        public partial class Snippet : GodotObject
        {
            public string type { get; set; }
            public string liveChatId { get; set; }
            public string authorChannelId { get; set; }
            public DateTime publishedAt { get; set; }
            public bool hasDisplayContent { get; set; }
            public string displayMessage { get; set; }
            public FanFundingEventDetails fanFundingEventDetails { get; set; }
            public TextMessageDetails textMessageDetails { get; set; }
            public MessageDeletedDetails messageDeletedDetails { get; set; }
            public UserBannedDetails userBannedDetails { get; set; }
            public MemberMilestoneChatDetails memberMilestoneChatDetails { get; set; }
            public NewSponsorDetails newSponsorDetails { get; set; }
            public SuperChatDetails superChatDetails { get; set; }
            public SuperStickerDetails superStickerDetails { get; set; }
            public MembershipGiftingDetails membershipGiftingDetails { get; set; }
            public GiftMembershipReceivedDetails giftMembershipReceivedDetails { get; set; }
        }

        public partial class FanFundingEventDetails : GodotObject
        {
            public ulong amountMicros { get; set; }
            public string currency { get; set; }
            public string amountDisplayString { get; set; }
            public string userComment { get; set; }
        }

        public partial class TextMessageDetails : GodotObject
        {
            public string messageText { get; set; }
        }

        public partial class MessageDeletedDetails : GodotObject
        {
            public string deletedMessageId { get; set; }
        }

        public partial class UserBannedDetails : GodotObject
        {
            public BannedUserDetails bannedUserDetails { get; set; }
            public string banType { get; set; }
            public ulong banDurationSeconds { get; set; }
        }

        public partial class BannedUserDetails : GodotObject
        {
            public string channelId { get; set; }
            public string channelUrl { get; set; }
            public string displayName { get; set; }
            public string profileImageUrl { get; set; }
        }

        public partial class MemberMilestoneChatDetails : GodotObject
        {
            public string userComment { get; set; }
            public uint memberMonth { get; set; }
            public string memberLevelName { get; set; }
        }

        public partial class NewSponsorDetails : GodotObject
        {
            public string memberLevelName { get; set; }
            public bool isUpgrade { get; set; }
        }

        public partial class SuperChatDetails : GodotObject
        {
            public ulong amountMicros { get; set; }
            public string currency { get; set; }
            public string amountDisplayString { get; set; }
            public string userComment { get; set; }
            public uint tier { get; set; }
        }

        public partial class SuperStickerDetails : GodotObject
        {
            public SuperStickerMetadata superStickerMetadata { get; set; }
            public ulong amountMicros { get; set; }
            public string currency { get; set; }
            public string amountDisplayString { get; set; }
            public uint tier { get; set; }
        }

        public partial class SuperStickerMetadata : GodotObject
        {
            public string stickerId { get; set; }
            public string altText { get; set; }
            public string language { get; set; }
        }

        public partial class MembershipGiftingDetails : GodotObject
        {
            public int giftMembershipsCount { get; set; }
            public string giftMembershipsLevelName { get; set; }
        }

        public partial class GiftMembershipReceivedDetails : GodotObject
        {
            public string memberLevelName { get; set; }
            public string gifterChannelId { get; set; }
            public string associatedMembershipGiftingMessageId { get; set; }
        }

        public partial class AuthorDetails : GodotObject
        {
            public string channelId { get; set; }
            public string channelUrl { get; set; }
            public string displayName { get; set; }
            public string profileImageUrl { get; set; }
            public bool isVerified { get; set; }
            public bool isChatOwner { get; set; }
            public bool isChatSponsor { get; set; }
            public bool isChatModerator { get; set; }
        }
    }
}