using SlackNet;
using SlackNet.Blocks;
using SlackNet.WebApi;

namespace Noobow.Commons.Utils
{
    public static class SlackUtil
    {
        private static ISlackApiClient? _slackClient;

        private static ISlackApiClient GetClient()
        {
            if (_slackClient == null)
            {
                string? token = Environment.GetEnvironmentVariable("SLACK_BOT_TOKEN");
                _slackClient = new SlackServiceBuilder()
                    .UseApiToken(token)
                    .GetApiClient();
            }
            return _slackClient;
        }

        public static async Task PostAsync(string channel, string text)
        {
            await GetClient().Chat.PostMessage(new SlackNet.WebApi.Message { Text = text, Channel = channel });
        }

        public static async Task PostAsync(string channel, string text, IList<Block> blocks)
        {
            await GetClient().Chat.PostMessage(new SlackNet.WebApi.Message { Text = text, Channel = channel, Blocks = blocks });
        }

        public static async Task<ConversationMessagesResponse> GetHistoryAsync(string channel, string? cursor = null, int limit = 100)
        {
            return await GetClient().Conversations.History(channelId: channel, cursor: cursor, limit: limit);
        }

        public static async Task DeleteAsync(string channel, string ts)
        {
            await GetClient().Chat.Delete(ts, channel);
        }

        //Botが参加しているチャンネルのみ（未参加チャンネルは履歴取得・削除ができないため）
        public static async Task<IList<Conversation>> GetMemberChannelsAsync()
        {
            var result = new List<Conversation>();
            string? cursor = null;
            do
            {
                var resp = await GetClient().Conversations.List(
                    excludeArchived: true,
                    limit: 200,
                    types: new[] { ConversationType.PublicChannel, ConversationType.PrivateChannel },
                    cursor: cursor);
                result.AddRange((resp.Channels ?? new List<Conversation>()).Where(c => c.IsMember));
                cursor = string.IsNullOrEmpty(resp.ResponseMetadata?.NextCursor) ? null : resp.ResponseMetadata.NextCursor;
            } while (cursor != null);
            return result;
        }
    }
}
